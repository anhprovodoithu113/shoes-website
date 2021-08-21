namespace Shoes_Website.Domain.AutorizationServices
{
    public interface IAuthorizationService
    {
        bool IsAdmin();

        bool IsAdmin(AuthorizationServiceDto loginUser);

        bool CheckPermissionForUser(string emailUser);
    }
}
