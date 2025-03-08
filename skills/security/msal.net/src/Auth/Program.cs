using System.Threading.Tasks;
using Microsoft.Identity.Client;
using Auth;

var config = AuthConfig.ReadConfiguration();
var scopes = new[] { "User.Read" };

var app = PublicClientApplicationBuilder
    .Create(config.ClientId)
    .WithAuthority(AzureCloudInstance.AzurePublic, config.TenantId)
    .WithRedirectUri(config.RedirectUri)
    .Build();

AuthenticationResult result = await app.AcquireTokenInteractive(scopes).ExecuteAsync();

Console.WriteLine($"Token:\t{result.AccessToken}");

