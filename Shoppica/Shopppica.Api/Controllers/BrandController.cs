using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoppica.Core.Models;
using Shoppica.Service;

namespace Shopppica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        BrandService service = new BrandService();
        [HttpGet]
        public IEnumerable<Brand> GetAll()
        {
            return service.GetBrands();
        }
    }
}
