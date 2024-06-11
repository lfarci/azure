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

# Deploy the built application using ZipDeploy feature
az webapp deployment source config-zip \
    --resource-group $resourceGroupName \
    --name $applicationName \
    --src $project_root/deploy-asp-net-using-zip/app.zip

echo "Successfully deployed code from $project_root/app.zip to $applicationName."

# This is required because the app name does not match the DLL name
az webapp config set \
    --resource-group $resourceGroupName \
    --name $applicationName \
    --startup-file "dotnet app.dll" # Files are deployed in /home/site/wwwroot

echo "Successfully set startup file to app.dll for $applicationName."

echo "Service should be available at "http://$applicationName.azurewebsites.net/weatherforecast"."