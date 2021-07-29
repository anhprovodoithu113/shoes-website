using System.Threading;
using System.Threading.Tasks;

namespace Shoes_Website.Domain.Intefaces
{
    public interface IUnitOfWorkUser
    {
        Task<int> CommitAsync(CancellationToken cancellationToken = default);
    }
}
