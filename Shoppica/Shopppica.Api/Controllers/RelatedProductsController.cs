using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoppica.Core.Models;
using Shoppica.Service;

namespace Shopppica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatedProductsController : ControllerBase
    {
        ProductService ps = new ProductService();
        [HttpGet("{id}")]
        public IEnumerable<Product> GetProducts(int id)
        {
            return ps.GetRelatedProducts(id);
        }
    }
}
