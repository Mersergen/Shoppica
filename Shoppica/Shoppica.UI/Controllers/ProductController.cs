using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shoppica.UI.Models;

namespace Shoppica.UI.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult GetProducts(int id)//list view
        {
            var response = GlobalConfig.Client.GetAsync("CategoryProducts/" + id).Result;
            var json = response.Content.ReadAsStringAsync().Result;
            var products = JsonConvert.DeserializeObject<List<ProductVM>>(json);
            return View(products);
        }
        public IActionResult GetProducts2(int id)//grid view
        {
            var response = GlobalConfig.Client.GetAsync("CategoryProducts/" + id).Result;
            var json = response.Content.ReadAsStringAsync().Result;
            var products = JsonConvert.DeserializeObject<List<ProductVM>>(json);
            return View(products);
        }
        public IActionResult GetProductDetails(int id)
        {
            var response = GlobalConfig.Client.GetAsync("ProductDetails/" + id).Result;
            var json = response.Content.ReadAsStringAsync().Result;
            var product = JsonConvert.DeserializeObject<ProductVM>(json);
            return View(product);
        }
        public IActionResult GetSearch(string text)
        {
            var response = GlobalConfig.Client.GetAsync("ProductSearch/" + text).Result;
            var json = response.Content.ReadAsStringAsync().Result;
            var products = JsonConvert.DeserializeObject<List<ProductVM>>(json);
            return View(products);
        }
    }
}
