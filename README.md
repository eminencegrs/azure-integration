# Azure Integration

### Statuses
[![.NET](https://github.com/eminencegrs/azure-integration/actions/workflows/dotnet.yml/badge.svg)](https://github.com/eminencegrs/azure-integration/actions/workflows/dotnet.yml)
[![codecov](https://codecov.io/gh/eminencegrs/azure-integration/graph/badge.svg?token=8RKPKNMKFQ)](https://codecov.io/gh/eminencegrs/azure-integration)

## Overview

This solution provides an API using ASP.NET.
It integrates with Azure Data Lake and Azure Key Vault 
to ensure secure and scalable data storage and management.

## Getting Started

### Prerequisites

- .NET 8 SDK installed
- Azure CLI installed
- Azure subscription with Data Lake and Key Vault services set up

### Installation

1. Clone the repository: `git clone https://github.com/eminencegrs/azure-integration.git`
2. Navigate to the project directory: `cd azure-integration`
3. Restore dependencies: `dotnet restore`

### Configuration

1. Update the `appsettings.json` file with Azure Data Lake and Key Vault configurations.
2. Ensure the necessary environment variables are set for authentication and authorization.
3. Ensure Managed Identity is enabled on both Data Lake and Key Vault.

### Running the Application

Use the following command to run the application:

```bash
dotnet run
```