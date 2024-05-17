# Deploy
Deploy a ASP.NET REST API to an Azure Web App instance using FTPS and WinSCP.

# Get started
Follow those steps to get started (use Bash and the Azure CLI).
```bash
az login --tenant "$TENANT_ID"
. run.sh

# Wait for the script to complete and upload files using the FTPS client.

# Don't forget to clean once you're done:
. clean.sh
```

# Notes
Files are all copied in the `home/site/wwwroot` directory in the Azure App Service container. The startup command needs to be provided to let the service know how to start the web service.

For example if the release contains the file name `MyGreatApplication.dll`, the startup command should be set to `dotnet MyGreatApplication.dll`.