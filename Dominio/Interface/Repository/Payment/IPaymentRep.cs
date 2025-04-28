using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.DTO.Payment;
using Dominio.Request.Payment;
using Dominio.Request;

namespace Dominio.Interface.Repository.Payment
{
    public interface IPaymentRep
    {
        Task<MessageResponse<string>> AddPayment(PaymentReq payment);
        Task<MessageResponse<string>> DeletePayment(int id);
        Task<MessageResponse<List<PaymentRes>>> GetPayments();
    }
}
