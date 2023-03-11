using System;
using System.Collections.Generic;

namespace FashionShop_BE.Entity;

public partial class User
{
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public string? FullName { get; set; }

    public bool? Gender { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Address { get; set; }

    public int? RolesId { get; set; }

    public bool? Status { get; set; }

    public virtual ICollection<Comment> Comments { get; } = new List<Comment>();

    public virtual ICollection<Favorite> Favorites { get; } = new List<Favorite>();

    public virtual ICollection<FeedBack> FeedBacks { get; } = new List<FeedBack>();

    public virtual Role? Roles { get; set; }
}
