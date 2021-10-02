using Ardalis.Specification;
using Shoes_Website.Domain.Models.ShoesWebsiteUser;

namespace Shoes_Website.Application.Authentications.Logins
{
    public class GetRoleByIdSpecification : Specification<Role>
    {
        public GetRoleByIdSpecification(int roleId)
        {
            Query.Where(r => r.Id.Equals(roleId));
        }
    }
}
