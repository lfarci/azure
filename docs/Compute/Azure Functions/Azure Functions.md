[Create serverless applications learning path - Training | Microsoft Learn](https://learn.microsoft.com/en-gb/training/paths/create-serverless-applications/)


# Additional resources
- [Azure Functions documentation](https://learn.microsoft.com/en-us/azure/azure-functions/)
- [Azure Serverless Computing Cookbook](https://azure.microsoft.com/resources/azure-serverless-computing-cookbook/)
- [How to use Queue storage from Node.js](https://learn.microsoft.com/en-us/azure/storage/queues/storage-nodejs-how-to-use-queues)
- [Introduction to Azure Cosmos DB: SQL API](https://learn.microsoft.com/en-us/azure/cosmos-db/sql-api-introduction)
- [A technical overview of Azure Cosmos DB](https://azure.microsoft.com/blog/a-technical-overview-of-azure-cosmos-db/)
- [Azure Cosmos DB documentation](https://learn.microsoft.com/en-us/azure/cosmos-db/)


# Extra practice

You can apply the approaches you've learned here to add and test bindings in your functions. Here are a few interesting ideas to get more practice with bindings and to build on what you have learned here.

- Create another function to read from Blob storage and other input bindings that we haven't used in this module.
    
- Create another function to write to more destinations by using other supported output binding types.
    
- In the preceding unit, we introduced a queue and posted messages to it with an output binding. As a next step, consider adding another function that reads the messages in the queue and prints the **MESSAGE TEXT** to the console with `console.log()`.