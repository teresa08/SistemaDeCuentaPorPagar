using Dominio.DTO.Payment;
using Dominio.Interface.CaseUse.Payment;
using Dominio.Request.Payment;
using Dominio.Request;
using Microsoft.AspNetCore.Mvc;

namespace SistemasDeCuentaPorPagar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Payment : ControllerBase
    {
        private readonly IPaymentUseCase _PaymentUseCase;
       public Payment(IPaymentUseCase paymentUseCase)
        {
            _PaymentUseCase = paymentUseCase;
        }
        [HttpPost("new_payment")]
        public async Task<IActionResult> AddPayment([FromBody] PaymentReq payment)
        {
            var res = await _PaymentUseCase.AddPayment(payment);
            if (!res.IsSuccess)
            {
                return Problem(statusCode: res.StatuCode, detail: res.Message);
            }
            return Ok(res);
        }
        [HttpGet("payments")]
        public async Task<IActionResult> GetPayments()
        {
            var res = await _PaymentUseCase.GetPayments();
            if (!res.IsSuccess)
            {
                return Problem(statusCode: res.StatuCode, detail: res.Message);
            }
            return Ok(res);
        }

    }
}
