using Microsoft.EntityFrameworkCore;

namespace ecomApi.Controllers.Models
{
    public class EcomDbContext: DbContext  // DbContext is Inherited from Microsoft.EntityFrameworkCore namespace
    {
        public EcomDbContext(DbContextOptions<EcomDbContext> options) : base(options)
        {

        }
        public DbSet<CategoryModel> CategoryModels { get; set; }
        public DbSet<productModel> productModels { get; set; }
    }
}
