using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shoppica.UI.Models;

namespace Shoppica.UI.ViewComponents
{
    public class CriticStockVC : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var response = GlobalConfig.Client.GetAsync("Product/4").Result;
            var json = response.Content.ReadAsStringAsync().Result;
            var productList = JsonConvert.DeserializeObject<List<ProductVM>>(json).Take(6);
            return View(productList);
        }
    }
}
