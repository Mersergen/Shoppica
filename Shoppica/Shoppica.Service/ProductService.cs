using Microsoft.EntityFrameworkCore;
using Shoppica.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Shoppica.Service
{
    public class ProductService
    {
        ShoppicaContext DB = new ShoppicaContext();

        public IEnumerable<Product> SearchProducts(string text)
        {
            #region MyRegion-1
            //return (from p in DB.Products.Where(x => x.ProductName.Contains(text))
            //        select new Product
            //        {
            //            Carts = p.Carts,
            //            BrandId = p.BrandId,
            //            Brand = p.Brand,
            //            Category = p.Category,
            //            CategoryId = p.CategoryId,
            //            CreatedDate = p.CreatedDate,
            //            Description = p.Description,
            //            Discount = p.Discount,
            //            Id = p.Id,
            //            Image = p.Image,
            //            ImageCount = p.ImageCount,
            //            IsSpecial = p.IsSpecial,
            //            ProductImages = p.ProductImages,
            //            ProductName = p.ProductName,
            //            UnitInStock = p.UnitInStock,
            //            UnitPrice = p.UnitPrice
            //        }).ToList(); 
            #endregion

            #region MyRegion-2

            //string sql = $"select * from Product where ProductName like '%{text}%'";

            //var liste = (from p in DB.Products.FromSqlRaw(sql)
            //             select new Product
            //             {
            //                 Carts = p.Carts,
            //                 BrandId = p.BrandId,
            //                 Brand = p.Brand,
            //                 Category = p.Category,
            //                 CategoryId = p.CategoryId,
            //                 CreatedDate = p.CreatedDate,
            //                 Description = p.Description,
            //                 Discount = p.Discount,
            //                 Id = p.Id,
            //                 Image = p.Image,
            //                 ImageCount = p.ImageCount,
            //                 IsSpecial = p.IsSpecial,
            //                 ProductImages = p.ProductImages,
            //                 ProductName = p.ProductName,
            //                 UnitInStock = p.UnitInStock,
            //                 UnitPrice = p.UnitPrice
            //             }).ToList();
            #endregion

            #region MyRegion-3

            //string sql = $"EXEC sp_SearchProducts '{text}'";

            ////var liste = DB.Products.FromSqlRaw(sql).ToList();

            //var liste = (from p in DB.Products.FromSqlRaw(sql).AsEnumerable()
            //             select p).ToList();
            #endregion

            #region MyRegion-4

            string sql = $"select * from dbo.fn_SearchProducts('{text}')";

            //var liste = DB.Products.FromSqlRaw(sql).ToList();

            var liste = (from p in DB.Products.FromSqlRaw(sql)
                         select new Product
                         {
                             Carts = p.Carts,
                             BrandId = p.BrandId,
                             Brand = p.Brand,
                             Category = p.Category,
                             CategoryId = p.CategoryId,
                             CreatedDate = p.CreatedDate,
                             Description = p.Description,
                             Discount = p.Discount,
                             Id = p.Id,
                             Image = p.Image,
                             ImageCount = p.ImageCount,
                             IsSpecial = p.IsSpecial,
                             ProductImages = p.ProductImages,
                             ProductName = p.ProductName,
                             UnitInStock = p.UnitInStock,
                             UnitPrice = p.UnitPrice
                         }).ToList();
            #endregion
            return liste;
        }
        public Product GetDetails(int id)
        {
            return (from p in DB.Products
                    where p.Id == id
                    select new Product
                    {
                        Brand = p.Brand,
                        BrandId = p.BrandId,
                        Carts = p.Carts,
                        Category = p.Category,
                        CategoryId = p.CategoryId,
                        CreatedDate = p.CreatedDate,
                        Description = p.Description,
                        Discount = p.Discount,
                        Id = p.Id,
                        Image = p.Image,
                        ImageCount = p.ImageCount,
                        IsSpecial = p.IsSpecial,
                        ProductImages = p.ProductImages,
                        ProductName = p.ProductName,
                        UnitInStock = p.UnitInStock,
                        UnitPrice = p.UnitPrice
                    }).FirstOrDefault() ?? new Product();
        }
        public IEnumerable<Product> GetRelatedProducts(int id)
        {

            Product product = DB.Products.Find(id) ?? new Product();
            return (from p in DB.Products.Where(x => x.CategoryId == product.CategoryId && x.Id != id)
                    select new Product
                    {
                        Carts = p.Carts,
                        BrandId = p.BrandId,
                        Brand = p.Brand,
                        Category = p.Category,
                        CategoryId = p.CategoryId,
                        CreatedDate = p.CreatedDate,
                        Description = p.Description,
                        Discount = p.Discount,
                        Id = p.Id,
                        Image = p.Image,
                        ImageCount = p.ImageCount,
                        IsSpecial = p.IsSpecial,
                        ProductImages = p.ProductImages,
                        ProductName = p.ProductName,
                        UnitInStock = p.UnitInStock,
                        UnitPrice = p.UnitPrice
                    }).OrderByDescending(p => Guid.NewGuid()).Take(4).ToList();
        }
        public IEnumerable<Product> GetCategoryProducts(int id)
        {
            Category category = DB.Categories.Find(id) ?? new Category();
            IEnumerable<Product> products;

            if (category.TopId == null) //ana kategori
            {
                products = (from p in DB.Products
                            join c in DB.Categories on p.CategoryId equals c.Id
                            where c.TopId == id
                            select new Product
                            {
                                Brand = p.Brand,
                                BrandId = p.BrandId,
                                Carts = p.Carts,
                                Category = p.Category,
                                CategoryId = p.CategoryId,
                                CreatedDate = p.CreatedDate,
                                Description = p.Description,
                                Discount = p.Discount,
                                Id = p.Id,
                                Image = p.Image,
                                ImageCount = p.ImageCount,
                                IsSpecial = p.IsSpecial,
                                ProductImages = p.ProductImages,
                                ProductName = p.ProductName,
                                UnitInStock = p.UnitInStock,
                                UnitPrice = p.UnitPrice
                            });
            }
            else                        //alt kategori
            {
                products = (from p in DB.Products
                            join c in DB.Categories on p.CategoryId equals c.Id
                            where p.CategoryId == id
                            select new Product
                            {
                                Brand = p.Brand,
                                BrandId = p.BrandId,
                                Carts = p.Carts,
                                Category = p.Category,
                                CategoryId = p.CategoryId,
                                CreatedDate = p.CreatedDate,
                                Description = p.Description,
                                Discount = p.Discount,
                                Id = p.Id,
                                Image = p.Image,
                                ImageCount = p.ImageCount,
                                IsSpecial = p.IsSpecial,
                                ProductImages = p.ProductImages,
                                ProductName = p.ProductName,
                                UnitInStock = p.UnitInStock,
                                UnitPrice = p.UnitPrice
                            });
            }
            return products;
        }
        public IEnumerable<Product> GetProducts(int id)
        {
            IEnumerable<Product> products = new List<Product>();

            switch ((ContentType)id)
            {

                case ContentType.Slider: products = GetSliderProducts(); break; //slider
                case ContentType.Special: products = GetSpecialProducts(); break;//special
                case ContentType.LastAdd: products = GetLastAddProducts(); break;//lastAdd
                case ContentType.CriticStock: products = GetCriticStockProducts(); break;//criticStock
                case ContentType.Featured: products = GetFeaturedProducts(); break;//featured
            }

            return products;
        }
        private IEnumerable<Product> GetFeaturedProducts()//featured
        {
            return (from p in DB.Products
                    select new Product
                    {
                        Carts = p.Carts,
                        BrandId = p.BrandId,
                        Brand = p.Brand,
                        Category = p.Category,
                        CategoryId = p.CategoryId,
                        CreatedDate = p.CreatedDate,
                        Description = p.Description,
                        Discount = p.Discount,
                        Id = p.Id,
                        Image = p.Image,
                        ImageCount = p.ImageCount,
                        IsSpecial = p.IsSpecial,
                        ProductImages = p.ProductImages,
                        ProductName = p.ProductName,
                        UnitInStock = p.UnitInStock,
                        UnitPrice = p.UnitPrice
                    }).OrderBy(p => p.CreatedDate).Take(15).ToList();
        }
        private IEnumerable<Product> GetCriticStockProducts()
        {
            return (from p in DB.Products.Where(p => p.UnitInStock < 20)
                    select new Product
                    {
                        Carts = p.Carts,
                        BrandId = p.BrandId,
                        Brand = p.Brand,
                        Category = p.Category,
                        CategoryId = p.CategoryId,
                        CreatedDate = p.CreatedDate,
                        Description = p.Description,
                        Discount = p.Discount,
                        Id = p.Id,
                        Image = p.Image,
                        ImageCount = p.ImageCount,
                        IsSpecial = p.IsSpecial,
                        ProductImages = p.ProductImages,
                        ProductName = p.ProductName,
                        UnitInStock = p.UnitInStock,
                        UnitPrice = p.UnitPrice
                    }).OrderByDescending(p => Guid.NewGuid()).Take(6).ToList();
        }//criticStock
        private IEnumerable<Product> GetLastAddProducts()//lastAdd
        {
            return (from p in DB.Products
                    select new Product
                    {
                        Carts = p.Carts,
                        BrandId = p.BrandId,
                        Brand = p.Brand,
                        Category = p.Category,
                        CategoryId = p.CategoryId,
                        CreatedDate = p.CreatedDate,
                        Description = p.Description,
                        Discount = p.Discount,
                        Id = p.Id,
                        Image = p.Image,
                        ImageCount = p.ImageCount,
                        IsSpecial = p.IsSpecial,
                        ProductImages = p.ProductImages,
                        ProductName = p.ProductName,
                        UnitInStock = p.UnitInStock,
                        UnitPrice = p.UnitPrice
                    }).OrderByDescending(p => p.CreatedDate).Take(6).ToList();
        }
        private IEnumerable<Product> GetSpecialProducts()//special
        {
            return (from p in DB.Products.Where(p => p.IsSpecial == true)
                    select new Product
                    {
                        Carts = p.Carts,
                        BrandId = p.BrandId,
                        Brand = p.Brand,
                        Category = p.Category,
                        CategoryId = p.CategoryId,
                        CreatedDate = p.CreatedDate,
                        Description = p.Description,
                        Discount = p.Discount,
                        Id = p.Id,
                        Image = p.Image,
                        ImageCount = p.ImageCount,
                        IsSpecial = p.IsSpecial,
                        ProductImages = p.ProductImages,
                        ProductName = p.ProductName,
                        UnitInStock = p.UnitInStock,
                        UnitPrice = p.UnitPrice
                    }).OrderBy(p => Guid.NewGuid()).Take(6).ToList();
        }
        private IEnumerable<Product> GetSliderProducts()//slider
        {
            return (from p in DB.Products
                    select new Product
                    {
                        Carts = p.Carts,
                        BrandId = p.BrandId,
                        Brand = p.Brand,
                        Category = p.Category,
                        CategoryId = p.CategoryId,
                        CreatedDate = p.CreatedDate,
                        Description = p.Description,
                        Discount = p.Discount,
                        Id = p.Id,
                        Image = p.Image,
                        ImageCount = p.ImageCount,
                        IsSpecial = p.IsSpecial,
                        ProductImages = p.ProductImages,
                        ProductName = p.ProductName,
                        UnitInStock = p.UnitInStock,
                        UnitPrice = p.UnitPrice
                    }).OrderBy(p => Guid.NewGuid()).Take(5).ToList();
        }
    }
}
