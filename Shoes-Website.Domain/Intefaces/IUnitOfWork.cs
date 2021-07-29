using System.Threading;
using System.Threading.Tasks;

namespace Shoes_Website.Domain.Intefaces
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync(CancellationToken cancellationToken = default);
    }
}
