using Shoppica.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoppica.Service
{
    public class CategoryService
    {
        ShoppicaContext DB = new ShoppicaContext();

        public IEnumerable<Category> GetMainCategories()
        {
            return (from c in DB.Categories.Where(x => x.TopId == null)
                    select new Category
                    {
                        CategoryName = c.CategoryName,
                        TopId = c.TopId,
                        Id = c.Id,
                        Top = c.Top,
                        InverseTop = c.InverseTop.ToList(),
                        Products = c.Products.ToList()
                    });
        }
        public IEnumerable<Category> GetAltCategories(int id)
        {
            Category category = DB.Categories.Find(id) ?? new Category();

            IEnumerable<Category> list;

            if (category.TopId == null)     //ana kategori
            {
                list = (from c in DB.Categories.Where(x => x.TopId == id) select c).ToList();
            }
            else                            //alt kategori
            {
                list = (from c in DB.Categories.Where(x => x.TopId == category.TopId) select c).ToList();
            }
            return list;
        }
    }
}
