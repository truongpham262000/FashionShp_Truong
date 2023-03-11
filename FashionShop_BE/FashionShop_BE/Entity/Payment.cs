using System;
using System.Collections.Generic;

namespace FashionShop_BE.Entity;

public partial class Payment
{
    public int PaymentId { get; set; }

    public string? PaymentName { get; set; }

    public virtual ICollection<Cart> Carts { get; } = new List<Cart>();
}
