# Deploy
Deploy a ASP.NET REST API to an Azure Web App instance using the ZipDeploy feature.

# Get started
Follow those steps to get started (use Bash and the Azure CLI).
```bash
az login --tenant "$TENANT_ID"
$project_root="C:\Users\<user>\azure\samples\webapp\webapp-basic-linux"
cd $project_root
. run.sh

# Wait for the script to complete and try the application out

# Don't forget to clean once you're done:
. clean.sh
```

# Notes
Files present in the ZIP are all copied in the `home/site/wwwroot` directory in the Azure App Service container. The startup command needs to be provided to let the service know how to start the web service.

For example if the release contains the file name `MyGreatApplication.dll`, the startup command should be set to `dotnet MyGreatApplication.dll`.