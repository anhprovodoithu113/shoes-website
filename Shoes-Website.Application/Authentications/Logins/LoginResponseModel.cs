using System;

namespace Shoes_Website.Application.Authentications.Logins
{
    public class LoginResponseModel
    {
        public string Username { get; set; }
        public string AccessToken { get; set; }
        public DateTime ExpiredTime { get; set; }
    }
}
