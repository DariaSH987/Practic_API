using System;
using System.Collections.Generic;

namespace Confectioner.Model;

public partial class Client
{
    public int IdClient { get; set; }

    public string FirstName { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string? Address { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
