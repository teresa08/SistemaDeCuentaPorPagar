using System;
using System.Collections.Generic;

namespace SistemasDeCuentaPorPagar.DB_Data_Context;

public partial class Invoice
{
    public int Id { get; set; }

    public int SupplierId { get; set; }

    public string InvoiceNumber { get; set; } = null!;

    public DateOnly IssueDate { get; set; }

    public DateOnly ExpirationDate { get; set; }

    public decimal TotalAmount { get; set; }

    public string? State { get; set; }
}
