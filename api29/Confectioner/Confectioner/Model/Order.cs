using System;
using System.Collections.Generic;

namespace Confectioner.Model;

public partial class Order
{
    public int IdOrders { get; set; }

    public int? Quantity { get; set; }

    public int? Price { get; set; }

    public DateOnly? DateOfIssue { get; set; }

    public DateOnly? DataOrder { get; set; }

    public int? ClientId { get; set; }

    public int? AssortmentId { get; set; }

    public virtual Assortment? Assortment { get; set; }

    public virtual Client? Client { get; set; }
}
