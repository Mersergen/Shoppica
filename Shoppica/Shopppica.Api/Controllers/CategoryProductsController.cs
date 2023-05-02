using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoppica.Core.Models;
using Shoppica.Service;

namespace Shopppica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryProductsController : ControllerBase
    {
        ProductService ps = new ProductService();

        [HttpGet("{id}")]
        public IEnumerable<Product> GetCategoryProducts(int id)
        {
            return ps.GetCategoryProducts(id);
        }
    }
}
