using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.DTO.Invoice;
using Dominio.Request.Invoices;
using Dominio.Request;

namespace Dominio.Interface.Repository.Invoice
{
    public interface IInvoiceRep
    {
        Task<MessageResponse<string>> AddInvoice(InvoiceReq invoice);
        Task<MessageResponse<string>> UpdateInvoice(InvoiceReq invoice);
        Task<MessageResponse<InvoiceRes>> GetInvoice(string invoiceNumber);
        Task<MessageResponse<List<InvoiceRes>>> GetInvoices();
        Task<MessageResponse<List<string>>> GetInvoiceNumbers();
    }
}
