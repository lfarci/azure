using System;
using Microsoft.Azure.Cosmos;

string documentEndpoint = Environment.GetEnvironmentVariable("DocumentEndpoint");
string primaryMasterKey = Environment.GetEnvironmentVariable("PrimaryMasterKey");

if (string.IsNullOrEmpty(documentEndpoint))
{
    Console.WriteLine("Could not resolve the document endpoint.");
}
else
{
    Console.WriteLine($"Document endpoint: {documentEndpoint}");
}

if (string.IsNullOrEmpty(primaryMasterKey))
{
    Console.WriteLine("Could not resolve the primary master key.");
}
else
{
    Console.WriteLine($"Primary master key: {primaryMasterKey}");
}

var cosmosClient = new CosmosClient(documentEndpoint, primaryMasterKey);

var database = await cosmosClient.CreateDatabaseIfNotExistsAsync("ToDoList");

Console.WriteLine("Database created successfully: ToDoList.");

var container = await database.Database.CreateContainerIfNotExistsAsync("Items", "/category");

Console.WriteLine("Container created successfully: Items.");
