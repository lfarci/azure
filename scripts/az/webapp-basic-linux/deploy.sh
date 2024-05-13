#!/bin/bash

az group create --name $resourceGroupName --location westeurope
az deployment group create \
    --resource-group $resourceGroupName \
    --template-uri https://raw.githubusercontent.com/Azure/azure-quickstart-templates/master/quickstarts/microsoft.web/webapp-basic-linux/azuredeploy.json \
    --parameters webAppName=$applicationName sku='F1'

