#/bin/bash

az acr build --image sample/hello-world:v1 --registry lfarci01 --file Dockerfile .
