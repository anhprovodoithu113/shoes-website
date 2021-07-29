using Shoes_Website.Domain.Models.ShoesWebsiteUser;
using Shoes_Website.Application.Auth.Common;
using Shoes_Website.Domain.DatabaseEnum;
using Shoes_Website.Domain.Intefaces;
using System.Collections.Generic;
using System.Security.Claims;
using System.Linq;

namespace Shoes_Website.Application.Helpers
{
    public class CurrentUser
    {
        private readonly ICacheService _cacheService;

        public CurrentUser(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        public List<Claim> GetClaims(Account user)
        {
            var key = user.Email + user.Username;
            var claims = _cacheService.GetFromCache<List<Claim>>(key);

            if (claims is null || !claims.Any())
            {
                claims = new List<Claim>();

                claims.Add(new Claim(ClaimTypes.Role, ((BaseRole)user.RoleId).GetEnumDescription()));
                claims.Add(new Claim("userEmail", user.Email));

                _cacheService.SetCache(key, claims, LoginConstant.EXPIRATED_HOUR);
            }

            return claims;
        }
    }
}
