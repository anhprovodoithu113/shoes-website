using System.Linq;
using Ardalis.Specification;
using Shoes_Website.Domain.Models.ShoesWebsiteUser;

namespace Shoes_Website.Application.Authentications.Logins
{
    public class GetAccountByUsernameOrEmailSpecification : Specification<Account>
    {
        public GetAccountByUsernameOrEmailSpecification(string username)
        {
            Query.Where(a => a.Username.Equals(username)
                          || a.Email.Equals(username));
        }
    }
}
