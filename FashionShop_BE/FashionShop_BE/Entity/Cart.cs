using System;
using System.Collections.Generic;

namespace FashionShop_BE.Entity;

public partial class Cart
{
    public int CartId { get; set; }

    public int? UserId { get; set; }

    public int? PaymentId { get; set; }

    public int? CouponId { get; set; }

    public string? FullName { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string? Country { get; set; }

    public string? Province { get; set; }

    public string? City { get; set; }

    public double? ItemDiscount { get; set; }

    public double? Vat { get; set; }

    public double? Shipping { get; set; }

    public double? Total { get; set; }

    public double? Discount { get; set; }

    public bool? Status { get; set; }

    public DateTime? CreateAt { get; set; }

    public string? Content { get; set; }

    public virtual ICollection<CartItem> CartItems { get; } = new List<CartItem>();

    public virtual Coupon? Coupon { get; set; }

    public virtual Payment? Payment { get; set; }
}
