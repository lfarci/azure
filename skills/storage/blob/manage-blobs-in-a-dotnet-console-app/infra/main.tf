resource "azurerm_resource_group" "resource_group" {
  name     = "${var.prefix}-${var.workload_name}-rg"
  location = var.location
}

resource "azurerm_storage_account" "storage_account" {
  name                     = var.storage_account_name
  resource_group_name      = azurerm_resource_group.resource_group.name
  location                 = azurerm_resource_group.resource_group.location
  account_tier             = var.account_tier
  account_replication_type = var.account_replication_type
}

resource "azurerm_storage_container" "containers" {
  count                 = length(var.container_names)
  name                  = element(var.container_names, count.index)
  storage_account_id    = azurerm_storage_account.storage_account.id
  container_access_type = "blob"
}