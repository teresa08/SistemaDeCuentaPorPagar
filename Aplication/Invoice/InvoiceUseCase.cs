using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.DTO.Invoice;
using Dominio.Interface.CaseUse.Invoices;
using Dominio.Interface.Repository.Invoice;
using Dominio.Request;
using Dominio.Request.Invoices;

namespace Aplication.Invoice
{
    public class InvoiceUseCase : IInvoiceUseCase
    {
        private IInvoiceRep _InvoiceRep;
        public InvoiceUseCase(IInvoiceRep invoiceRep)
        {
            _InvoiceRep = invoiceRep;
        }
        public async Task<MessageResponse<string>> AddInvoice(InvoiceReq invoice)
        {
           return await _InvoiceRep.AddInvoice(invoice);
        }

        public async Task<MessageResponse<InvoiceRes>> GetInvoice(string invoiceNumber)
        {
            return await _InvoiceRep.GetInvoice(invoiceNumber);
        }

        public async Task<MessageResponse<List<string>>> GetInvoiceNumbers()
        {
            return await _InvoiceRep.GetInvoiceNumbers();
        }

        public async Task<MessageResponse<List<InvoiceRes>>> GetInvoices()
        {
            return await _InvoiceRep.GetInvoices();
        }

        public async Task<MessageResponse<string>> UpdateInvoice(InvoiceReq suppliers)
        {
            return await _InvoiceRep.UpdateInvoice(suppliers);
        }
    }
}
