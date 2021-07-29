using System;
using System.Threading;
using System.Threading.Tasks;
using Shoes_Website.Domain.Intefaces;
using Shoes_Website.Infrastructure.AuthorizationServices;

namespace Shoes_Website.Infrastructure.Domain
{
    public class UnitOfWorkUser : IUnitOfWorkUser
    {
        private readonly UserDbContext _userDbContext;

        public UnitOfWorkUser(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            return await _userDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
