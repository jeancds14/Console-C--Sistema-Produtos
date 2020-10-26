using Produtos.Context;
using Produtos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Produtos.Service
{
    public class ProductService
    {
        public void CreateProduct(Product product)
        {
            using(var db = new ProductContext())
            {
                db.Products.Add(product);
                db.SaveChanges();
            }
        }

        public Product GetProduct(int id)
        {
            using (var db = new ProductContext())
            {
                var result = db.Products.Where(x => x.Id == id).FirstOrDefault();
                return result;
            }
        }

        public List<Product> GetAllProduct()
        {
            using (var db = new ProductContext())
            {
                var result = db.Products.ToList();
                return result;
            }
        }

        public void DeleteProduct(int id)
        {
            using (var db = new ProductContext())
            {
                var result = db.Products.Find(id);
                db.Products.Remove(result);
                db.SaveChanges();
            }
        }

        public Product UpdateProduct(int id, int quant)
        {
            using (var db = new ProductContext())
            {
                var result = db.Products.Find(id);
                result.Quantity = result.Quantity + quant;
                db.Products.Update(result);
                db.SaveChanges();
                return result;
            }
        }
    }
}
