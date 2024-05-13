#!/bin/bash

applicationName="$applicationName-webapp"

az webapp config appsettings list \
    --name $applicationName \
    --resource-group $resourceGroupName

az webapp config appsettings set \
    --name $applicationName \
    --resource-group $resourceGroupName \
    --settings ValueA=Coucou ValueB=Bonjour ValueC=Salut

az webapp config connection-string set \
    --resource-group basic-linux-webapp-rg \
    --name myapp-20240513233105-webapp \
    --settings SqlServer=ThisIsATest \
    --connection-string-type Custom

az webapp config appsettings list \
    --name $applicationName \
    --resource-group $resourceGroupName