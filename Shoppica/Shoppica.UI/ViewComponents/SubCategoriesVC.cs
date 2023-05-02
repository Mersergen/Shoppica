using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shoppica.UI.Models;

namespace Shoppica.UI.ViewComponents
{
    public class SubCategoriesVC : ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            var response = GlobalConfig.Client.GetAsync("Category/" + id).Result;
            var json = response.Content.ReadAsStringAsync().Result;
            var categoryList = JsonConvert.DeserializeObject<List<CategoryVM>>(json).Take(6);
            return View(categoryList);
        }
    }
}
