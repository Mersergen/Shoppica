using Microsoft.AspNetCore.Mvc;

namespace Shoppica.UI.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
