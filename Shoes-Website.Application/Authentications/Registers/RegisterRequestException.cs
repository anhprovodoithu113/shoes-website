using Shoes_Website.Domain;

namespace Shoes_Website.Application.Authentications.Registers
{
    public class RegisterRequestException : BusinessValidationException
    {
        public RegisterRequestException(string message) : base(message)
        {

        }
    }
}
