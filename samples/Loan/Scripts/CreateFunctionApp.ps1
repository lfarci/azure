$resourceGroupName = "lfarci-loan-wizard-rg";
$resourceGroupLocation = "westeurope";
$storageAccountName = "loanwizard";
$functionsAppName = "lfarci-loan-wizard-fa";

az group create --name $resourceGroupName --location $resourceGroupLocation
az storage account create --name $storageAccountName --location $resourceGroupLocation --resource-group $resourceGroupName --kind StorageV2
az functionapp create --resource-group $resourceGroupName --name $functionsAppName --storage-account $storageAccountName --runtime dotnet --consumption-plan-location $resourceGroupLocation --functions-version 4
