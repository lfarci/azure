# Deploy
Deploy a ASP.NET REST API to an Azure Web App instance using a local Git repository.

# Get started
Follow those steps to get started (use Bash and the Azure CLI).
```bash
az login --tenant "$TENANT_ID"
$project_root="C:\Users\<user>\azure\samples\webapp\webapp-basic-linux\deploy-asp-net-using-git"
cd $project_root
. run.sh # Follow the commands step by step

# Wait for the script to complete and try the application out

# Don't forget to clean once you're done:
. clean.sh
```