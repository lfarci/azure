#!/bin/bash

$resource_group_name = "lfarci-container-webapi-rg"
$location = "germanywestcentral"

az group create --name $resource_group_name --location $location

