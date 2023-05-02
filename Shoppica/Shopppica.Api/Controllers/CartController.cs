using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoppica.Core.Models;
using Shoppica.Service;

namespace Shopppica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        CartService cs = new CartService();

        [HttpGet]
        public IEnumerable<CartProduct> Get()
        {
            return cs.GetAll();
        }
        [HttpPost]
        public void Post(Cart cart)
        {
            cs.AddToCart(cart);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            cs.DeleteFromCart(id);
        }
    }
}
