namespace App
{
    internal class Configuration
    {
        private readonly string _tenantId;
        private readonly string _storageAccountUri;

        public Configuration(string tenantId, string storageAccountName)
        { 
            _tenantId = tenantId;
            _storageAccountUri = storageAccountName;
        }

        public string TenantId => _tenantId;

        public Uri StorageAccountUri
        {
            get
            {
                return new Uri(_storageAccountUri);
            }
        }
    }
}
