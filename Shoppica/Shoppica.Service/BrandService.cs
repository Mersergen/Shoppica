using Shoppica.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoppica.Service
{
    public class BrandService
    {
        ShoppicaContext DB = new ShoppicaContext();

        public IEnumerable<Brand> GetBrands()
        {
            return DB.Brands;
        }
    }
}
