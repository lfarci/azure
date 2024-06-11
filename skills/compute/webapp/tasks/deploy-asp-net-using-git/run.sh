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
    --template-file "$project_root/templates/template.json" \
    --parameters webAppName=$applicationName sku=$pricingTier linuxFxVersion=$stack location=$location

echo "Successfully created web app named $applicationName."

# This configures the web app to use local git deployment
az webapp deployment source config-local-git \
    --name $applicationName \
    --resource-group $resourceGroupName

mkdir -p repo
cp $project_root/app/* repo
cd repo
git init
git add .
git commit -m "Initial commit"

# Get the Git URL and the credentials
az webapp deployment list-publishing-credentials \
    --name $applicationName \
    --resource-group $resourceGroupName \
    --query scmUri

# git remote add azure <scmUri>
# git push -u azure master 

# Possible to change the branch to deploy to
# az webapp config appsettings set --name <app-name> --resource-group <group-name> --settings DEPLOYMENT_BRANCH='main'
# git push azure main

# # This is required because the app name does not match the DLL name
# az webapp config set \
#     --resource-group $resourceGroupName \
#     --name $applicationName \
#     --startup-file "dotnet app.dll" # Files are deployed in /home/site/wwwroot

# echo "Successfully set startup file to app.dll for $applicationName."

# echo "Service should be available at "http://$applicationName.azurewebsites.net/weatherforecast"."