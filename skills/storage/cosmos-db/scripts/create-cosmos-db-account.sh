#!/bin/bash

let "id=$RANDOM*$RANDOM"
accountName="lfarci-cosmos-db-account-$id"
resourceGroupName=lfarci-cosmos-db-rg-$id

location="germanywestcentral"

az group create --location $location --name $resourceGroupName >> /dev/null

if [ $? -ne 0 ]; then
    echo "Failed to create resource group $resourceGroupName"
    exit 1
else
    echo "Resource group $resourceGroupName created successfully"
fi

documentEndpoint=$(az cosmosdb create --name $accountName --resource-group $resourceGroupName --query "documentEndpoint" --output tsv)
primaryMasterKey=$(az cosmosdb keys list --name $accountName --resource-group $resourceGroupName --query "primaryMasterKey" --output tsv)

echo "Cosmos DB account created: $accountName. Document Endpoint: $documentEndpoint. Primary Master Key: $primaryMasterKey"

export documentEndpoint
export primaryMasterKey

# az cosmosdb sql database list --resource-group $resourceGroupName --account-name $accountName
# az cosmosdb sql container list --resource-group $resourceGroupName --account-name $accountName --database-name ToDoList