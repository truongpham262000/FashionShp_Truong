using System;
using System.Collections.Generic;

namespace FashionShop_BE.Entity;

public partial class Product
{
    public int ProductId { get; set; }

    public string? ProductCode { get; set; }

    public string? ProductName { get; set; }

    public string? MetaTitle { get; set; }

    public string? Description { get; set; }

    public string? ProductImage { get; set; }

    public int? SizeId { get; set; }

    public string? MoreImages { get; set; }

    public decimal? Price { get; set; }

    public bool? IncludeVat { get; set; }

    public int? Quantity { get; set; }

    public string? Detail { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public int CategoryId { get; set; }

    public string? MetaKeywords { get; set; }

    public string? MetaDescriptions { get; set; }

    public bool? Status { get; set; }

    public int? ViewCounts { get; set; }

    public virtual ICollection<CartItem> CartItems { get; } = new List<CartItem>();

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Comment> Comments { get; } = new List<Comment>();

    public virtual ICollection<Favorite> Favorites { get; } = new List<Favorite>();

    public virtual ICollection<Sale> Sales { get; } = new List<Sale>();

    public virtual SizeProduct? Size { get; set; }
}
