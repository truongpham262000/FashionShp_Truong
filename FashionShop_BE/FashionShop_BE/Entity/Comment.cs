using System;
using System.Collections.Generic;

namespace FashionShop_BE.Entity;

public partial class Comment
{
    public int CommentId { get; set; }

    public int? UserId { get; set; }

    public int? ProductId { get; set; }

    public string? CommentText { get; set; }

    public DateTime? CreateAt { get; set; }

    public virtual Product? Product { get; set; }

    public virtual User? User { get; set; }
}
