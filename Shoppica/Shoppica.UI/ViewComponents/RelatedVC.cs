using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shoppica.UI.Models;

namespace Shoppica.UI.ViewComponents
{
    public class RelatedVC : ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            var response = GlobalConfig.Client.GetAsync("RelatedProducts/" + id).Result;
            var json = response.Content.ReadAsStringAsync().Result;
            var productList = JsonConvert.DeserializeObject<List<ProductVM>>(json);
            return View(productList);
        }
    }
}
