using System;
using System.Collections.Generic;

namespace SistemasDeCuentaPorPagar.DB_Data_Context;

public partial class Payment
{
    public int Id { get; set; }

    public int InvoiceId { get; set; }

    public DateOnly PaymentDate { get; set; }

    public decimal PaidAmount { get; set; }

    public string PaymentMethod { get; set; } = null!;
}
