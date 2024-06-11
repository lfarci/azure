#!/bin/bash

applicationName="$applicationName-webapp"

az webapp config connection-string list \
    --resource-group $resourceGroupName \
    --name $applicationName

az webapp config connection-string set \
    --resource-group $resourceGroupName \
    --name $applicationName \
    --settings SqlServer=ThisIsATest \
    --connection-string-type Custom

az webapp config connection-string set \
    --resource-group $resourceGroupName \
    --name $applicationName \
    --settings "@connection-strings.json"