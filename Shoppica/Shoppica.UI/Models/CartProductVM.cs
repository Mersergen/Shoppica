using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoppica.UI.Models
{
    public class CartProductVM
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int Quantity { get; set; }
        public string? ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public string CategoryName { get; set; }
        public string? Image { get; set; }

        public decimal Total { get { return (this.Quantity * this.UnitPrice); } }

    }
}
