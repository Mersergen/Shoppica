using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoppica.Core.Models;
using Shoppica.Service;

namespace Shopppica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSearchController : ControllerBase
    {
        ProductService ps = new ProductService();
        [HttpGet("{text}")]
        public IEnumerable<Product> GetSearchProducts(string text)
        {
            return ps.SearchProducts(text);
        }
    }
}
