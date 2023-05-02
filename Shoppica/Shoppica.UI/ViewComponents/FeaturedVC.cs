using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shoppica.UI.Models;

namespace Shoppica.UI.ViewComponents
{
    public class FeaturedVC : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var response = GlobalConfig.Client.GetAsync("Product/5").Result;
            var json = response.Content.ReadAsStringAsync().Result;
            var productList = JsonConvert.DeserializeObject<List<ProductVM>>(json);
            return View(productList);
        }
    }
}
