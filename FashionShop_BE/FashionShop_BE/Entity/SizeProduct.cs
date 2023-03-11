using System;
using System.Collections.Generic;

namespace FashionShop_BE.Entity;

public partial class SizeProduct
{
    public int SizeId { get; set; }

    public string? SizeName { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
