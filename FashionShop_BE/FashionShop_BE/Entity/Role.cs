using System;
using System.Collections.Generic;

namespace FashionShop_BE.Entity;

public partial class Role
{
    public int RolesId { get; set; }

    public string? RolesName { get; set; }

    public virtual ICollection<User> Users { get; } = new List<User>();
}
