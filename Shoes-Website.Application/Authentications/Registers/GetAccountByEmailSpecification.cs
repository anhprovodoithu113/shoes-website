using System.Linq;
using Ardalis.Specification;
using Shoes_Website.Domain.Models.ShoesWebsiteUser;

namespace Shoes_Website.Application.Authentications.Registers
{
    public class GetAccountByEmailSpecification : Specification<Account>
    {
        public GetAccountByEmailSpecification(string email)
        {
            Query.Where(a => a.Email.Equals(email));
        }
    }
}
