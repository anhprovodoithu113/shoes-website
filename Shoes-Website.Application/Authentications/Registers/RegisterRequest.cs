using MediatR;

namespace Shoes_Website.Application.Authentications.Registers
{
    public class RegisterRequest : IRequest
    {
        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
