using MediatR;

namespace Shoes_Website.Application.Authentications.Logins
{
    public class LoginRequest : IRequest<LoginResponseModel>
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
