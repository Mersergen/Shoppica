using System;
using System.Collections.Generic;

namespace Shoppica.Core.Models
{
    public partial class Category
    {
        public Category()
        {
            InverseTop = new HashSet<Category>();
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string? CategoryName { get; set; }
        public int? TopId { get; set; }

        public virtual Category? Top { get; set; }
        public virtual ICollection<Category> InverseTop { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
