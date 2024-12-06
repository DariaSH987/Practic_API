using System;
using System.Collections.Generic;

namespace Confectioner.Model;

public partial class Supplier
{
    public int IdSuppliers { get; set; }

    public string? SuppliersName { get; set; }

    public string? Goods { get; set; }

    public virtual ICollection<Assortment> Assortments { get; set; } = new List<Assortment>();
}
