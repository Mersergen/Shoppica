using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shoppica.UI.Models;

namespace Shoppica.UI.ViewComponents
{
    public class RightCategoriesVC : ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            var response = GlobalConfig.Client.GetAsync("Category").Result;
            var json = response.Content.ReadAsStringAsync().Result;
            var categoryList = JsonConvert.DeserializeObject<List<CategoryVM>>(json);
            ViewBag.Top = id;
            return View(categoryList);
        }
    }
}
