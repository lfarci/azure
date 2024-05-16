Deploy a ASP.NET REST API to an Azure Web App instance using the ZipDeploy feature.

Follow those steps to get started (use Bash and the Azure CLI).
```bash
az login --tenant "$TENANT_ID"
$project_root="C:\Users\<user>\azure\samples\webapp\webapp-basic-linux"
cd $project_root
. run.sh

# Wait for the script to complete and try the application out
```