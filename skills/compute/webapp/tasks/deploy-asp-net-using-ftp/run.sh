#!/bin/bash

let "id=$RANDOM*$RANDOM"
applicationName="basic-linux-$id-webapp"
resourceGroupName=basic-linux-$id-webapp-rg
applicationPlanName=$applicationName-plan

location="westeurope"
stack="dotnetcore|8.0"
pricingTier="F1"

echo "Generating random resource names..."
echo "Application Name: $applicationName"
echo "Resource Group Name: $resourceGroupName"
echo "Application Plan Name: $applicationPlanName"

echo "Creating resource group..."
az group create --name $resourceGroupName --location $location
echo "Successfully created resource group named $resourceGroupName."

az deployment group create \
    --resource-group $resourceGroupName \
    --template-file "$project_root/templates/basic-linux.json" \
    --parameters webAppName=$applicationName sku=$pricingTier linuxFxVersion=$stack location=$location

echo "Successfully created web app named $applicationName."

# Show the FTPS endpoint and credentials to use in the FTP client to upload files
az webapp deployment list-publishing-profiles \
    --name $applicationName \
    --resource-group $resourceGroupName \
    --query "[?ends_with(profileName, 'FTP')].{profileName: profileName, publishUrl: publishUrl, userName: userName, password: userPWD }"

# This is required because the app name does not match the DLL name
az webapp config set \
    --resource-group $resourceGroupName \
    --name $applicationName \
    --startup-file "dotnet app.dll" # Files are deployed in /home/site/wwwroot

echo "Successfully set startup file to app.dll for $applicationName."

echo "Service should be available at "http://$applicationName.azurewebsites.net/weatherforecast"."