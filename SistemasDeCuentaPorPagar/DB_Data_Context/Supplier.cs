using System;
using System.Collections.Generic;

namespace SistemasDeCuentaPorPagar.DB_Data_Context;

public partial class Supplier
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string RncCedula { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }
}
