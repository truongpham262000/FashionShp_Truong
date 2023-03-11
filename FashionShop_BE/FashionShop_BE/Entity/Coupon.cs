using System;
using System.Collections.Generic;

namespace FashionShop_BE.Entity;

public partial class Coupon
{
    public int CouponId { get; set; }

    public string? Code { get; set; }

    public int? Count { get; set; }

    public int? Promotion { get; set; }

    public string? Describe { get; set; }

    public virtual ICollection<Cart> Carts { get; } = new List<Cart>();
}
