using Shoppica.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoppica.Service
{
    public class CartService
    {
        ShoppicaContext DB = new ShoppicaContext();

        public IEnumerable<CartProduct> GetAll()
        {
            return (from c in DB.Carts
                    join p in DB.Products on c.ProductId equals p.Id
                    select new CartProduct
                    {
                        Id = c.Id,
                        ProductId = c.ProductId,
                        Image = p.Image,
                        ProductName = p.ProductName,
                        CategoryName = p.Category.CategoryName,
                        UnitPrice = p.IsSpecial == true ? p.Discount : p.UnitPrice,
                        Quantity = c.Quantity
                    }).ToList();
        }

        public void AddToCart(Cart cart)
        {
            Cart? cart1 = DB.Carts.Where(x => x.ProductId == cart.ProductId).FirstOrDefault();

            if (cart1 == null)//ADD
            {
                DB.Carts.Add(cart);
            }
            else//UPDATE
            {
                cart1.Quantity += cart.Quantity;
                DB.Update(cart1);
            }
            DB.SaveChanges();
        }
        public void DeleteFromCart(int id)
        {
            Cart? cart = DB.Carts.Where(x => x.Id == id).FirstOrDefault();
            if (cart != null)
            {
                DB.Remove(cart);
                DB.SaveChanges();
            }
        }
    }
}
