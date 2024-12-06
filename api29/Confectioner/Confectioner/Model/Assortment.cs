using System;
using System.Collections.Generic;

namespace Confectioner.Model;

public partial class Assortment
{
    public int IdAssortment { get; set; }

    public string ProductName { get; set; } = null!;

    public string Stuffing { get; set; } = null!;

    public string? Decor { get; set; }

    public int SupplierId { get; set; }

    public int Price { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Supplier Supplier { get; set; } = null!;
}
