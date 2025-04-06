using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Request.Payment
{
    public class PaymentReq
    {
        public string InvoiceNumber { get; set; }
        public decimal PaidAmount { get; set; }
        public string PaymentMethod { get; set; }
        public DateOnly PaymentDate { get; set; }
    }
}
