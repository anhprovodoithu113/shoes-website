using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Shoes_Website.Domain.Models.ShoesWebsite;

namespace Shoes_Website.Infrastructure.Domain
{
    public class ShoesWebsiteDbContext : DbContext
    {
        public ShoesWebsiteDbContext(DbContextOptions<ShoesWebsiteDbContext> options) : base(options)
        {
            try
            {
                Database.SetCommandTimeout(360);
            }
            catch { }
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductOptions> ProductOptions { get; set; }
        public virtual DbSet<CustomerReviews> CustomerReviews { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
