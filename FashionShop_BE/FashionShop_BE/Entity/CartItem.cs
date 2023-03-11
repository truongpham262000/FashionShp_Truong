using System;
using System.Collections.Generic;

namespace FashionShop_BE.Entity;

public partial class CartItem
{
    public int CartItemId { get; set; }

    public int? ProductId { get; set; }

    public int? CartId { get; set; }

    public double? Price { get; set; }

    public double? Discount { get; set; }

    public int? Quantity { get; set; }

    public DateTime? CreateAt { get; set; }

    public string? Content { get; set; }

    public virtual Cart? Cart { get; set; }

    public virtual Product? Product { get; set; }
}
