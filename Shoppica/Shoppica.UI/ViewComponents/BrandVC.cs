using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shoppica.UI.Models;

namespace Shoppica.UI.ViewComponents
{
    public class BrandVC : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var response = GlobalConfig.Client.GetAsync("Brand").Result;
            var json = response.Content.ReadAsStringAsync().Result;
            var brands = JsonConvert.DeserializeObject<IEnumerable<BrandVM>>(json);
            return View(brands);
        }
    }
}
