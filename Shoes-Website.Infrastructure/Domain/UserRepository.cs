using Shoes_Website.Domain.Intefaces;
using Shoes_Website.Infrastructure.AuthorizationServices;

namespace Shoes_Website.Infrastructure.Domain
{
    public class UserRepository : EFRepositoryBase, IUserRepository
    {
        public UserRepository(UserDbContext dbContext) : base(dbContext)
        {

        }
    }
}
