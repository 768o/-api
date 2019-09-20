using CustomerData.Core.Products;
using Microsoft.EntityFrameworkCore;

namespace CustomerData.EFCore
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}
