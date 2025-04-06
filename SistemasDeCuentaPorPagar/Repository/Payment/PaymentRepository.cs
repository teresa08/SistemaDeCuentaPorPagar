using Dominio.DTO.Payment;
using Dominio.DTO.SupplierManagement;
using Dominio.Interface.Repository.Payment;
using Dominio.Request;
using Dominio.Request.Payment;
using Microsoft.EntityFrameworkCore;
using SistemasDeCuentaPorPagar.Controllers;
using SistemasDeCuentaPorPagar.DB_Data_Context;

namespace SistemasDeCuentaPorPagar.Repository.Payment
{
    public class PaymentRepository : IPaymentRep
    {
        private readonly CuentasPorPagarContext _CuentasPorPagarContext;
        public PaymentRepository(CuentasPorPagarContext cuentasPorPagarContext)
        {
            _CuentasPorPagarContext = cuentasPorPagarContext;
        }

        public async Task<MessageResponse<string>> AddPayment(PaymentReq payment)
        {
            try
            {
                var invoice = await _CuentasPorPagarContext.Invoices.Where(i => i.InvoiceNumber == payment.InvoiceNumber).Select(i => i.Id).FirstOrDefaultAsync();

                if (invoice <= 0)
                    return new MessageResponse<string>
                    {
                        IsSuccess = false,
                        Message = "La factura no esta registrada",
                        StatuCode = 404
                    };

                await _CuentasPorPagarContext.Payments.AddAsync(new DB_Data_Context.Payment
                {
                    InvoiceId = invoice,
                    PaymentDate = payment.PaymentDate,
                    PaidAmount = payment.PaidAmount,
                    PaymentMethod = payment.PaymentMethod
                });
                _CuentasPorPagarContext.SaveChanges();

                return new MessageResponse<string>
                {
                    IsSuccess = true,
                    Payload = "Successful",
                    StatuCode = 201
                };

            }
            catch (Exception ex)
            {
                return new MessageResponse<string>
                {
                    IsSuccess = false,
                    Message = "Ha ocurrido un problema en el servidor",
                    StatuCode = 500
                };

            }
        }

        public async Task<MessageResponse<List<PaymentRes>>> GetPayments()
        {
            try
            {
                var res = await (from payment in _CuentasPorPagarContext.Payments
                                 join invoice in _CuentasPorPagarContext.Invoices
                                 on payment.InvoiceId equals invoice.Id
                                 join supplier in _CuentasPorPagarContext.Suppliers
                                 on invoice.SupplierId equals supplier.Id
                                 select new PaymentRes
                                 {
                                     InvoiceNumber = invoice.InvoiceNumber,
                                     PaidAmount = payment.PaidAmount,
                                     PaymentDate = payment.PaymentDate,
                                     PaymentMethod = payment.PaymentMethod,
                                     RncCedula = supplier.RncCedula,
                                 }).ToListAsync();

                return new MessageResponse<List<PaymentRes>>
                {
                    IsSuccess = true,
                    Payload = res,
                    StatuCode = 200
                };
            }
            catch (Exception)
            {
                return new MessageResponse<List<PaymentRes>>
                {
                    IsSuccess = false,
                    Message = "Ha ocurrido un problema en el servidor",
                    StatuCode = 500
                };
            }
        }
    }
}
