# Azure Cosmos DB

- Explore the resource hierarchy
- Explore consistency level a choose a level for a given scenario
	- Strong
	- Bounded Staleness
	- Session
	- Consistent Prefix
	- Eventual
- Implement change feed notifications
	- Work with change feed using Azure Functions or change feed processor
	- Use your provisioned throughput to read from the change feed
	- Capture deletes by setting a "soft-delete" flag without your items in place of deletes
	- Synchronize changes from any point in time
	- Process changes from large containers in parallel by multiple consumers

# Azure Blob storage

- Set and retrieve properties and metadata for blob resources by using REST
	- How to format the URIs for different requests (reading or writing data)
	- Format of URIs to  target containers or in the individual blob
	- Familiarity with common properties and how they are used
- Azure blob storage client library
	- Perform operations like reading and writing blobs using the library
	- Know common methods used on this different objects
	- Exam does not test language syntax
- Azure blob storage lifecycle
	- Different between hot, cool and archive
	- How to work with each of them from the application code
- Automate with the blob lifecycle management policies
	- Each rule definition includes a filter set and an action set
	- Familiarity with different ways to set rules and actions
- Static site hosting
	- Enable static website hosting
	- Upload files
	- Enable metrics on static website
	- $web container
