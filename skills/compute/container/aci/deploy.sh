#/bin/bash

function checkpoint() {
    read -p "Continue? (Y/N): " confirm

    while [[ ! $confirm =~ ^[YyNn]$ ]]; do
        echo "Invalid input. Please enter Y or N."
        read -p "Continue? (Y/N): " confirm
    done

    if [[ $confirm == [Nn] ]]; then
        echo "Ok we're done."
        exit 0
    fi
}

resource_group_name="lfarci-aci-exercise-rg"
location="germanywestcentral"
container_name="mycontainer"

echo "Creating resource group..."
az group create --name $resource_group_name --location $location
echo "Resource group created."

checkpoint

DNS_NAME_LABEL=aci-example-$RANDOM

echo "Creating container group..."

az container create --resource-group $resource_group_name \
    --name $container_name \
    --image mcr.microsoft.com/azuredocs/aci-helloworld \
    --ports 80 --os-type Linux --cpu 1 --memory 1 \
    --dns-name-label $DNS_NAME_LABEL --location $location

checkpoint

az container show --resource-group $resource_group_name \
    --name $container_name \
    --query "{FQDN:ipAddress.fqdn,ProvisioningState:provisioningState}" \
    --out table 

checkpoint

echo "Deleting resource group..."
az group delete --name $resource_group_name --yes --no-wait
echo "Resource group deletion initiated."