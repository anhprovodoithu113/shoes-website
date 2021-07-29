using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Shoes_Website.Domain.Intefaces;

namespace Shoes_Website_Project.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly HttpContext _httpContext;

        public string Email { get; }

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            Email = GetEmail(httpContextAccessor.HttpContext?.User);
            _httpContext = httpContextAccessor.HttpContext;
        }

        private string GetEmail(ClaimsPrincipal principal)
        {
            return GetClaim(principal, "userEmail");
        }

        private string GetClaim(ClaimsPrincipal principal, string claimType)
        {
            return principal?.Claims?.FirstOrDefault(p => p.Type.Equals(claimType))?.Value;
        }
    }
}
