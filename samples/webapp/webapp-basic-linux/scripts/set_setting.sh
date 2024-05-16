#!/bin/bash

az webapp config appsettings list \
    --name $applicationName \
    --resource-group $resourceGroupName

az webapp config appsettings set \
    --name $applicationName \
    --resource-group $resourceGroupName \
    --settings ValueA=Coucou ValueB=Bonjour ValueC=Salut

az webapp config appsettings set \
    --resource-group $resourceGroupName \
    --name $applicationName \
    --settings "@settings.json"


