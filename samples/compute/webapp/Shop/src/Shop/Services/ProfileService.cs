using Shop.Models;
using System.Security.Claims;

namespace Shop.Services
{
    public class ProfileService
    {
        private static readonly string _objectIdentifier = "http://schemas.microsoft.com/identity/claims/objectidentifier";
        private static readonly string _name = "name";
        private static readonly string _emailAddress = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress";

        private readonly ILogger<ProfileService> _logger;

        public ProfileService(ILogger<ProfileService> logger)
        {
            _logger = logger;
        }

        private static string FindClaimValue(ClaimsPrincipal principal, string claimType)
        {
            return principal.FindFirst(claimType)?.Value ?? string.Empty;
        }

        private bool HasClaimes(ClaimsPrincipal principal)
        {
            return principal.HasClaim(c => c.Type == _objectIdentifier) &&
                principal.HasClaim(c => c.Type == _name) &&
                principal.HasClaim(c => c.Type == _emailAddress);
        }

        public Profile? ReadProfile(HttpRequest request)
        {
            var principal = ClaimsPrincipalParser.Parse(request);

            if (principal is not null && HasClaimes(principal))
            {
                var profile = new Profile();

                if (principal.HasClaim(c => c.Type == _objectIdentifier))
                {
                    profile.Id = FindClaimValue(principal, _objectIdentifier);
                }

                if (principal.HasClaim(c => c.Type == _name))
                {
                    profile.Name = FindClaimValue(principal, _name);
                }

                if (principal.HasClaim(c => c.Type == _emailAddress))
                {
                    profile.EmailAddress = FindClaimValue(principal, _emailAddress);
                }

                return profile;
            }

            return null;
        }
    }
}
