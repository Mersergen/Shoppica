using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shoppica.UI.Models;

namespace Shoppica.UI.ViewComponents
{
    public class CartListVC : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var response = GlobalConfig.Client.GetAsync("Cart").Result;
            var json = response.Content.ReadAsStringAsync().Result;
            var cartList = JsonConvert.DeserializeObject<IEnumerable<CartProductVM>>(json);
            return View(cartList);
        }
    }
}
