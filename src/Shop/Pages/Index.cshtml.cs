using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Models;
using Shop.Services;
using System.Security.Claims;

namespace Shop.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public Profile Profile { get; set; }
        public ClaimsPrincipal? Principal { get; private set; }

        public void OnGet()
        {
            Profile = new Profile
            {
                IdToken = Request.Headers["X-MS-TOKEN-AAD-ID-TOKEN"],
                AccessToken = Request.Headers["X-MS-TOKEN-AAD-ACCESS-TOKEN"],
                ExpiresOn = Request.Headers["X-MS-TOKEN-AAD-EXPIRES-ON"],
                RefreshToken = Request.Headers["X-MS-TOKEN-AAD-REFRESH-TOKEN"],
                Name = ClaimsPrincipal.Current?.FindFirst(ClaimTypes.Name)?.Value,
            };

            Principal = ClaimsPrincipalParser.Parse(Request);
        }
    }
}
