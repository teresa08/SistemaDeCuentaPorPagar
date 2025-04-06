using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.DTO.Payment
{
    public class PaymentRes
    {
        public string RncCedula { get; set; }
        public DateOnly PaymentDate { get; set; }
        public decimal PaidAmount { get; set; }
        public string PaymentMethod { get; set; }
        public string InvoiceNumber { get; set; }
    }
}
