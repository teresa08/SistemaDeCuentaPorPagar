using Dominio.DTO.Invoice;
using Dominio.Interface.CaseUse.Invoices;
using Dominio.Request;
using Dominio.Request.Invoices;
using Microsoft.AspNetCore.Mvc;

namespace SistemasDeCuentaPorPagar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Invoice : ControllerBase
    {
        private readonly IInvoiceUseCase _InvoiceUseCase;
        public Invoice(IInvoiceUseCase invoiceUseCase)
        {
            _InvoiceUseCase = invoiceUseCase;
        }
        [HttpPost("invoice_new")]
        public async Task<IActionResult> AddInvoice([FromBody] InvoiceReq invoice)
        {
            var res = await _InvoiceUseCase.AddInvoice(invoice);

            if (!res.IsSuccess)
            {
                return Problem(statusCode: res.StatuCode, detail: res.Message);
            }
             return Ok(res);
        }

        [HttpPost("{invoiceNumber}/update")]
        public async Task<IActionResult> UpdateInvoice([FromBody] InvoiceReq invoice, [FromRoute] string invoiceNumber )
        {
            var res = await _InvoiceUseCase.UpdateInvoice(invoice, invoiceNumber);

            if (!res.IsSuccess)
            {
                return Problem(statusCode: res.StatuCode, detail: res.Message);
            }
            return Ok(res);
        }
        [HttpGet("{invoiceNumber}")]
        public async Task<IActionResult> GetInvoice([FromRoute] string invoiceNumber)
        {
            var res = await _InvoiceUseCase.GetInvoice(invoiceNumber);

            if (!res.IsSuccess)
            {
                return Problem(statusCode: res.StatuCode, detail: res.Message);
            }
            return Ok(res);
        }
        [HttpGet("invoices")]
        public async Task<IActionResult> GetInvoices()
        {
            var res = await _InvoiceUseCase.GetInvoices();

            if (!res.IsSuccess)
            {
                return Problem(statusCode: res.StatuCode, detail: res.Message);
            }
            return Ok(res);
        }
        [HttpGet("invoice_numbers")]
        public async Task<IActionResult> GetInvoiceNumbers()
        {
            var res = await _InvoiceUseCase.GetInvoiceNumbers();

            if (!res.IsSuccess)
            {
                return Problem(statusCode: res.StatuCode, detail: res.Message);
            }
            return Ok(res);
        }

    }
}
