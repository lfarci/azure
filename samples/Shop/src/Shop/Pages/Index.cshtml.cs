using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Models;
using Shop.Services;
using System.Security.Claims;

namespace Shop.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ProfileService _profileService;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ProfileService profileService, ILogger<IndexModel> logger)
        {
            _profileService = profileService;
            _logger = logger;
        }
        
        public bool HasProfile => Profile is not null;

        public Profile? Profile { get; private set; }

        public string? EnvironmentName => Environment.GetEnvironmentVariable("ENVIRONMENT_NAME");
        public string? Version => Environment.GetEnvironmentVariable("APP_VERSION");

        public void OnGet()
        {
            Profile = _profileService.ReadProfile(Request);
            _logger.LogInformation("Id: {Id}", Profile?.Id);
            _logger.LogInformation("Name: {Name}", Profile?.Name);
            _logger.LogInformation("Email: {Email}", Profile?.EmailAddress);
        }
    }
}
