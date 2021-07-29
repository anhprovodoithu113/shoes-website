using Microsoft.EntityFrameworkCore;
using Shoes_Website.Domain.Models.ShoesWebsiteUser;

namespace Shoes_Website.Infrastructure.AuthorizationServices
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> opts) : base(opts)
        {

        }

        public virtual DbSet<Account> Accounts { get; set; }

        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<AccountDetail> AccountDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
