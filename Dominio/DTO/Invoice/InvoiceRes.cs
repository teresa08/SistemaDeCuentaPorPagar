using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.DTO.Invoice
{
    public class InvoiceRes
    {
        public string RncOrCedula { get; set; }
        public string InvoiceNumber { get; set; }
        public DateOnly IssueDate { get; set; }
        public DateOnly ExpirationDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string State { get; set; }
    }
}
