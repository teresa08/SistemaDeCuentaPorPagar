using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.DTO.SupplierManagement;
using Dominio.Request.SupplierManagement;
using Dominio.Request;
using Dominio.Request.Invoices;
using Dominio.DTO.Invoice;

namespace Dominio.Interface.CaseUse.Invoices
{
    public interface IInvoiceUseCase
    {
        Task<MessageResponse<string>> AddInvoice(InvoiceReq invoice);
        Task<MessageResponse<string>> UpdateInvoice(InvoiceReq invoice);
        Task<MessageResponse<InvoiceRes>> GetInvoice(string invoiceNumber);
        Task<MessageResponse<List<InvoiceRes>>> GetInvoices();
        Task<MessageResponse<List<string>>> GetInvoiceNumbers();
    }
}
