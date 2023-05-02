using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shoppica.UI.Models;
using System.Text;

namespace Shoppica.UI.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            var response = GlobalConfig.Client.GetAsync("Cart").Result;
            var json = response.Content.ReadAsStringAsync().Result;
            var cartList = JsonConvert.DeserializeObject<List<CartProductVM>>(json);
            return View(cartList);
        }
        public async Task<IActionResult> CartAdd(int id, int quan = 1)
        {
            CartVM cart = new CartVM() { ProductId = id, Quantity = quan };
            try
            {
                var json = JsonConvert.SerializeObject(cart);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await GlobalConfig.Client.PostAsync("Cart", content);
                return RedirectToAction("Index", "Cart");
            }
            catch
            {
                return View(cart);
            }
        }
        public async Task<IActionResult> CartDelete(int id)
        {
            var response = await GlobalConfig.Client.DeleteAsync("Cart/" + id);
            return RedirectToAction("Index", "Cart");
        }
    }
}
