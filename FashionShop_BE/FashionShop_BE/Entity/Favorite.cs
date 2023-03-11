﻿using System;
using System.Collections.Generic;

namespace FashionShop_BE.Entity;

public partial class Favorite
{
    public int FavoriteId { get; set; }

    public int? UserId { get; set; }

    public int? ProductId { get; set; }

    public virtual Product? Product { get; set; }

    public virtual User? User { get; set; }
}
