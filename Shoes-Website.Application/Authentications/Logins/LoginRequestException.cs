using Shoes_Website.Domain;

namespace Shoes_Website.Application.Authentications.Logins
{
    public class LoginRequestException : BusinessValidationException
    {
        public LoginRequestException(string message) : base(message)
        {

        }
    }
}
