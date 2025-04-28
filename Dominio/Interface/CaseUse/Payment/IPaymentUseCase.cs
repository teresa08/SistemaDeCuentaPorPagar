using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.DTO.Payment;
using Dominio.Request;
using Dominio.Request.Payment;

namespace Dominio.Interface.CaseUse.Payment
{
    public interface IPaymentUseCase
    {
        Task<MessageResponse<string>> AddPayment(PaymentReq payment);
        Task<MessageResponse<string>> DeletePayment(int id);
        Task<MessageResponse<List<PaymentRes>>> GetPayments();
    }
}
