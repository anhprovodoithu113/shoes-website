using Shoes_Website.Domain.Intefaces;

namespace Shoes_Website.Infrastructure.Domain
{
    public class EFRepository : EFRepositoryBase, IRepository
    {
        public EFRepository(ShoesWebsiteDbContext dbContext):base(dbContext)
        {

        }
    }
}
