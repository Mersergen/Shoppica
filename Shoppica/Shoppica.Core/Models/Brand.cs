﻿using System;
using System.Collections.Generic;

namespace Shoppica.Core.Models
{
    public partial class Brand
    {
        public Brand()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string? BrandName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
