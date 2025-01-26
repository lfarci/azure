using App;
using Azure.Core;
using Azure.Identity;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

internal class BlobStorage
{
    private readonly Configuration _configuration;
    private BlobServiceClient? _blobServiceClient;

    public BlobStorage(Configuration configuration)
    {
        _configuration = configuration;
    }

    private DefaultAzureCredentialOptions CreateOptions() => new()
    {
        VisualStudioTenantId = _configuration.TenantId,
        SharedTokenCacheTenantId = _configuration.TenantId
    };

    private Uri StorageAccountUri => _configuration.StorageAccountUri;

    private TokenCredential Credential => new DefaultAzureCredential(CreateOptions());

    private BlobServiceClient Client => _blobServiceClient ??= new BlobServiceClient(StorageAccountUri, Credential);

    public bool Contains(string containerName)
    {
        var containerClient = Client.GetBlobContainerClient(containerName);

        return containerClient.Exists();
    }

    public BlobContainerClient GetContainer(string containerName)
    {
        return Client.GetBlobContainerClient(containerName);
    }

    public IList<string> ListContainers()
    {
        return Client.GetBlobContainers().Select(container => container.Name).ToList();
    }

    public void CreateContainer(string containerName)
    {
        var containerClient = Client.GetBlobContainerClient(containerName);
        containerClient.CreateIfNotExists(PublicAccessType.Blob);
    }

    public void DeleteContainer(string containerName)
    {
        var containerClient = Client.GetBlobContainerClient(containerName);
        containerClient.DeleteIfExists();
    }
}