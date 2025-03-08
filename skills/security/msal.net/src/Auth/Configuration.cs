namespace Auth;

internal record AuthConfig(string ClientId, string TenantId, string RedirectUri)
{
    public static AuthConfig ReadConfiguration()
    {
        var clientId = Environment.GetEnvironmentVariable("APPLICATION_CLIENT_ID");
        var tenantId = Environment.GetEnvironmentVariable("DIRECTORY_TENANT_ID");
        var redirectUri = Environment.GetEnvironmentVariable("REDIRECT_URI");

        if (string.IsNullOrEmpty(clientId))
        {
            throw new InvalidOperationException("Environment variable 'APPLICATION_CLIENT_ID' is missing or empty.");
        }

        if (string.IsNullOrEmpty(tenantId))
        {
            throw new InvalidOperationException("Environment variable 'DIRECTORY_TENANT_ID' is missing or empty.");
        }

        if (string.IsNullOrEmpty(redirectUri))
        {
            throw new InvalidOperationException("Environment variable 'REDIRECT_URI' is missing or empty.");
        }

        return new AuthConfig(clientId, tenantId, redirectUri);
    }
}

