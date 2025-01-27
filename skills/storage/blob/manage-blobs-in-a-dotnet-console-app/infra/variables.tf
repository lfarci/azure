variable "subscription_id" {
  type        = string
  description = "The Azure Subscription ID"
}

variable "prefix" {
  type        = string
  description = "Prefix for the resources"
  default     = "lfarci"
}

variable "workload_name" {
  type        = string
  description = "Custom workload name, use a descriptive name"
  default     = "manage-blobs-demo"
}

variable "storage_account_name" {
  type        = string
  description = "The name of the Storage Account"
  default     = "demo"
}

variable "container_names" {
  type        = list(string)
  description = "Names of the container to create"
  default     = [ "items" ]
}

variable "location" {
  type        = string
  description = "value for the location"
  default     = "germanywestcentral"
}

variable "account_tier" {
  type        = string
  description = "The tier of the Storage Account"
  default     = "Standard"
  validation {
    condition     = contains(["Standard", "Premium"], var.account_tier)
    error_message = "The account_tier must be either 'Standard' or 'Premium'."
  }
}

variable "account_replication_type" {
  type        = string
  description = "The replication type of the Storage Account"
  default     = "LRS"
  validation {
    condition     = contains(["LRS", "ZRS", "GRS", "RAGRS"], var.account_replication_type)
    error_message = "The account_replication_type must be one of 'LRS', 'ZRS', 'GRS', or 'RAGRS'."
  }
}
