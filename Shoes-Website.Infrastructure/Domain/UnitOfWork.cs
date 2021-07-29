using System;
using System.Threading;
using System.Threading.Tasks;
using Shoes_Website.Domain.Intefaces;

namespace Shoes_Website.Infrastructure.Domain
{
    public class UnitOfWork : IUnitOfWork
    {
        public Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
