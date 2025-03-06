#!/bin/bash

resource_group_name="lfarci-container-webapi-rg"
location="germanywestcentral"
acr_name="lfarciacr$(( RANDOM % 1000 ))"

az group create --name $resource_group_name --location $location
az acr create --resource-group $resource_group_name --name $acr_name --sku Basic