namespace App
{
    internal class ConfigurationReader
    {
        public readonly string TenantIdVariableName = "AZURE_TENANT_ID";
        public readonly string StorageAccountVariableName = "AZURE_STORAGE_ACCOUNT_URI";

        private string TenantId = string.Empty;
        private string StorageAccountName = string.Empty;

        private static bool EnvironmentVariablesIsSet(string variableName) => !string.IsNullOrEmpty(Environment.GetEnvironmentVariable(variableName));

        private static string ReadEnvironmentVariable(string variableName) => Environment.GetEnvironmentVariable(variableName)!;

        private ConfigurationReader SetTenantId()
        {
            if (EnvironmentVariablesIsSet(TenantIdVariableName))
            {
                TenantId = ReadEnvironmentVariable(TenantIdVariableName);
            }

            return this;
        }

        private ConfigurationReader SetStorageAccount()
        {
            if (EnvironmentVariablesIsSet(StorageAccountVariableName))
            {
                StorageAccountName = ReadEnvironmentVariable(StorageAccountVariableName);
            }

            return this;
        }

        private Configuration Build() => new(TenantId, StorageAccountName);

        public static Configuration Read() => new ConfigurationReader()
            .SetStorageAccount()
            .SetTenantId()
            .Build();
    }
}
