using System.Linq;
using Ardalis.Specification;
using Shoes_Website.Domain.Models.ShoesWebsiteUser;

namespace Shoes_Website.Application.Authentications.Registers
{
    public class GetAccountByUsernameSpecification : Specification<Account>
    {
        public GetAccountByUsernameSpecification(string username)
        {
            Query.Where(a => a.Username.Equals(username));
        }
    }
}
