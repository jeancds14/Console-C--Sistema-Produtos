using Microsoft.EntityFrameworkCore;
using Produtos.Model;

namespace Produtos.Context
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlServer("Server=DESKTOP-65I5PJ5\\SQLEXPRESS;Database=Product;Trusted_Connection=True;");
    }
}