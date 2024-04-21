# About
---

# What should I learn?
---

This is based on both the study guide for the basic outline. Details come from the associated Exam Readiness Zone video.

- Create an Azure App Service Web App
	- Azure service plan and Azure service web app relationship
	- Azure service plan pricing tiers and know key differences between them
	- App service on Linux
- Enable diagnostics logging
	- Familiarity with all the different types of logs and what information is in each of them
		- Application logging on Windows
		- Application logging on Linux
		- Application logging on containers
		- Web server logging
	- Add log messages in code
	- Stream logs
	- Access log files
- Deploy code to a web app
	- Automated deployment (Azure DevOps, GitHub, Bitbucket)
	- Manual deployment (Git, CLI, Zipdeploy, FTP/S)
	- Use deployment slots (and their settings)
- Configure web app settings
	- Adding and editing settings
	- Adding and editing settings in bulk (JSON)
	- Configure configuration strings
	- Deployment slots settings
	- Read secrets from an Azure Key Vault
	- Stack settings (runtime, language version, SDK version)
	- Platform settings (when and why they should be enabled)
	- Debugging (enable remote debugging)
	- SSL/TLS settings
		- Buy and import App Service certificate
		- Import a certificate from Key Vault
		- Upload a private/ public certificate
		- Renew a expiring/uploaded/App service certificate
		- Renew a certificate imported from Key Vault
		- Manage App Service certificates
		- Automate with scripts
		- When to use a Key Vault instead of uploading them to Azure Service
		- Knowing the basics around certificates
- Implement autoscaling
	- What is autoscaling?
	- When should it be used?
	- Enable autoscaling
	- Add scale conditions
	- Create scale rules
	- Monitor autoscaling activity
	- Azure service plan pricing tiers scaling limits
	- Know best practices
		- Ensure the maximum and minimum values are different and have an adequate margin between them (this is to avoid flapping, we should be able to identify when this is happening and fix this)
		- Choose the appropriate statistic for your diagnostics metric
		- Choose the thresholds carefully for all metric types
		- Remember considerations for scaling when multiple rules are configured in a profile
		- Always select a save default instance count
		- Configure autoscale notifications
