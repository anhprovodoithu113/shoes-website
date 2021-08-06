using System.Threading;
using System.Threading.Tasks;
using Shoes_Website.Domain.Intefaces;

namespace Shoes_Website.Infrastructure.Domain
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShoesWebsiteDbContext _shoesDbContext;

        public UnitOfWork(ShoesWebsiteDbContext shoesDbContext)
        {
            _shoesDbContext = shoesDbContext;
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            return await _shoesDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
