using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FashionShop_BE.Entity;

public partial class About
{
    public int AboutId { get; set; }

    public string? Title { get; set; }

    public string? MetaTitle { get; set; }

    public string? Description { get; set; }

    public string? Image { get; set; }

    public string? Detail { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public string? MetaKeywords { get; set; }

    public string? MetaDescriptions { get; set; }

    public bool? Status { get; set; }
}
