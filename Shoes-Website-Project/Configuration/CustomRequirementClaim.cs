using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Shoes_Website_Project.Configuration
{
    public class CustomRequirementClaim : IAuthorizationRequirement
    {
        public CustomRequirementClaim(string claimType)
        {
            ClaimType = claimType;
        }

        public string ClaimType { get; }
    }

    public class CustomRequireClaimHandler : AuthorizationHandler<CustomRequirementClaim>
    {
        public CustomRequireClaimHandler()
        {

        }

        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            CustomRequirementClaim requirement)
        {
            var hasClaim = context.User.Claims.Any(x => x.Type == requirement.ClaimType);
            if (hasClaim)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }

    public static class AuthorizationPolicyBuilderExtensions
    {
        public static AuthorizationPolicyBuilder RequireCustomClaim(
            this AuthorizationPolicyBuilder builder,
            string claimType)
        {
            builder.AddRequirements(new CustomRequirementClaim(claimType));
            return builder;
        }
    }
}
