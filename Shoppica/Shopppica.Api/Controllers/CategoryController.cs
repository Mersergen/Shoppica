using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoppica.Core.Models;
using Shoppica.Service;

namespace Shopppica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        CategoryService cs = new CategoryService();
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return cs.GetMainCategories();
        }
        [HttpGet("{id}")]
        public IEnumerable<Category> GetAlt(int id)
        {
            return cs.GetAltCategories(id);
        }
    }
}
