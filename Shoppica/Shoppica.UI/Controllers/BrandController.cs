using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shoppica.UI.Models;
using System.Collections;
using System.Text.Json.Serialization;

namespace Shoppica.UI.Controllers
{
    public class BrandController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var response = await GlobalConfig.Client.GetAsync("Brand");
            var json = await response.Content.ReadAsStringAsync();
            var brands = JsonConvert.DeserializeObject<IEnumerable<BrandVM>>(json);
            return View(brands);
        }
    }
}
