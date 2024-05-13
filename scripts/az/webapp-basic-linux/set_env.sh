#!/bin/bash

applicationName=$(echo "myapp-$(date +%Y%m%d%H%M%S)" | tr '[:upper:]' '[:lower:]')
resourceGroupName=basic-linux-webapp-rg
applicationPlanName=myapp-plan