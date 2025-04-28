using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.DTO.Payment;
using Dominio.Interface.CaseUse.Payment;
using Dominio.Interface.Repository.Payment;
using Dominio.Interface.Repository.SupplierManagement;
using Dominio.Request;
using Dominio.Request.Payment;

namespace Aplication.Payment
{
    public class PaymentUseCase: IPaymentUseCase
    {
        private IPaymentRep _PaymentRep;
        public PaymentUseCase(IPaymentRep paymentRep)
        {
            _PaymentRep = paymentRep;
        }

        public async Task<MessageResponse<string>> AddPayment(PaymentReq invoice)
        {
            return await _PaymentRep.AddPayment(invoice); 
        }

        public async Task<MessageResponse<string>> DeletePayment(int id)
        {
            return await _PaymentRep.DeletePayment(id);
        }

        public async Task<MessageResponse<List<PaymentRes>>> GetPayments()
        {
            return await _PaymentRep.GetPayments();
        }
    }
}
