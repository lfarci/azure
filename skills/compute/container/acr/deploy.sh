#/bin/bash

az group create --name acr-rg --location germanywestcentral

az acr create --resource-group acr-rg --name lfarci01 --sku Basic
