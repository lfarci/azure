using Shop.Models;
using Shop.Pages;
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

        public Profile? ReadProfile(HttpRequest request)
        {
            var principal = ClaimsPrincipalParser.Parse(request);
            Profile? profile = null;

            if (principal is not null)
            {
                foreach (var claim in principal.Claims)
                {
                    _logger.LogInformation("Claim: {Type} {Value}", claim.Type, claim.Value);
                }

                profile = new Profile
                {
                    Id = FindClaimValue(principal, _objectIdentifier),
                    Name = FindClaimValue(principal, _name),
                    EmailAddress = FindClaimValue(principal, _emailAddress)
                };
            }

            return profile;
        }
    }
}
