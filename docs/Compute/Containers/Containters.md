

# What should I learn?
---
- Create and manage container images for solutions
	- Quick tasks: build and push images to a repository completely in Azure (without a Docker engine installed)
	- Automatically triggered tasks
		- Trigger on source code update in a repository
		- Trigger on base image update (Use ACR task to track dependency on a base image)
		- Image build
		- Multi-step task (define tasks using YAML)
		- `az acr` command
- Publish an image to Azure Container Registry
	- Understanding of the use cases
		- Scalable orchestration systems (Kubernetes)
		- AKS, Azure app service, Azure Batch service fabric
	- Choose the ACR service tier and know key differences between them (Basic, standard, and premium)
	- Know supported images and artifacts
		- Repository, container, image
		- Windows and Linux images
		- Helm charts (OCI format)
	- Azure Container Registry tasks
		- Build
		- Test
		- Push
		- Deploy
- Run containers by using Azure Container Instance
	- Use cases and features
		- Fast startup times
		- Public IP connectivity and DNS name
		- Hypervisor-level security
		- Custom sizes
		- Persistent storage
		- Linux and Windows containers
		- Co-scheduled groups
		- Virtual network deployment
	- Know when to use AKS instead of ACI
	- Work with ACI
		- Deployment (when to use ARM template or YAML file)
		- Container groups
		- Resource allocation
		- Networking
		- Storage
		- Common scenarios
			- App and monitoring container
			- Web app container and a container polling latest content from source control
- Create solutions by using Azure Container Apps
	- Use it to
		- Deploy API endpoints
		- Host background processing applications
		- Handle event-driven processing
		- Run microservices
	- Build application to dynamically scale based on
		- HTTP traffic
		- Event-driven processing
		- CPU or memory load
		- Any KEDA-supported scaler



[Deploy cloud-native apps using Azure Container Apps - Training | Microsoft Learn](https://learn.microsoft.com/en-us/training/paths/deploy-cloud-native-applications-to-azure-container-apps/)
[Deploy containers by using Azure Kubernetes Service (AKS) - Training | Microsoft Learn](https://learn.microsoft.com/en-us/training/paths/deploy-manage-containers-azure-kubernetes-service/)





# Services
---
- Azure container registry (ACR)
- Azure container instances (ACI)
- Azure container apps

