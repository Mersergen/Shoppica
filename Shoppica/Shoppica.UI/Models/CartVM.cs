using System;
using System.Collections.Generic;

namespace Shoppica.UI.Models
{
    public partial class CartVM
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }

        public virtual ProductVM? Product { get; set; }
    }
}
