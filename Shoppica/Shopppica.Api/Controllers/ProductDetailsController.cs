using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoppica.Core.Models;
using Shoppica.Service;

namespace Shopppica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        ProductService ps = new ProductService();
        [HttpGet("{id}")]
        public Product GetProductDetails(int id)
        {
            return ps.GetDetails(id);
        }
    }
}
