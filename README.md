# Azure Key Vault Emulator

This is a project that attempts to emulate [Azure Key Vault](https://azure.microsoft.com/en-us/services/key-vault/) functionality to enable developers to work with a local Key Vault rather than having to create a resource in Azure.

[![Build Status](https://dev.azure.com/tmblue87/OpenSource/_apis/build/status/Bluetarsky.AzureKeyVaultEmulator?branchName=master)](https://dev.azure.com/tmblue87/OpenSource/_build/latest?definitionId=9&branchName=master)

## Currently supported operations

### Secrets
| Action | Supported |
|--|--|
| [Backup secret](https://docs.microsoft.com/en-us/rest/api/keyvault/BackupSecret) | :heavy_check_mark: |
| [Delete secret](https://docs.microsoft.com/en-us/rest/api/keyvault/DeleteSecret) | |
| [Get deleted secret](https://docs.microsoft.com/en-us/rest/api/keyvault/GetDeletedSecret)| |
| [Get deleted secrets](https://docs.microsoft.com/en-us/rest/api/keyvault/GetDeletedSecret)| |
| [Get secret](https://docs.microsoft.com/en-us/rest/api/keyvault/GetSecret) | :heavy_check_mark: |
| [Get secret versions](https://docs.microsoft.com/en-us/rest/api/keyvault/GetSecretVersions) |  |
| [Get secrets](https://docs.microsoft.com/en-us/rest/api/keyvault/GetSecrets) | |
| [Purge deleted secrets](https://docs.microsoft.com/en-us/rest/api/keyvault/PurgeDeletedSecret) | |
| [Recover deleted secret](https://docs.microsoft.com/en-us/rest/api/keyvault/RecoverDeletedSecret) | |
| [Set secret](https://docs.microsoft.com/en-us/rest/api/keyvault/SetSecret) | :heavy_check_mark: |
| [Update secret](https://docs.microsoft.com/en-us/rest/api/keyvault/UpdateSecret) | :heavy_check_mark: |

### Key
| Action | Supported |
|--|--|
| [Backup key]() | |
| [Create key]() | |
| [Decrypt]() | |
| [Encrypt]() | |
| [Get deleted key]() | |
| [Get deleted keys]() | |
| [Get key]() | |
| [Get key versions]() | |
| [Get keys]() | |
| [Import keys]() | |
| [Purge deleted key]() | |
| [Recover deleted key]() | |
| [Restore key]() | |
| [Sign]() | |
| [Unwrap key]() | |
| [Update key]() | |
| [Verify]() | |
| [Wrap key]() | |

### Certificate
| Action | Supported |
|--|--|
| [Backup certificate]() | |
| [Create certificate]() | |
| [Delete certificate]() | |
| [Delete certificate contacts]() | |
| [Delete certificate issuer]() | |
| [Delete certificate operation]() | |
| [Get certificate]() | |
| [Get certificate contacts]() | |
| [Get certificate issuer]() | |
| [Get certificate issuers]() | |
| [Get certificate operation]() | |
| [Get certifgicate policy]() | |
| [Get certificate versions]() | |
| [Get certificates]() | |
| [Get deleted certificate]() | |
| [Get deleted certificates]() | |
| [Import certificate]() | |
| [Merge certificate]() | |
| [Purge deleted certificate]() | |
| [Recover deleted certificate]() | |
| [Restore certificate]() | |
| [Set certificate contacts]() | |
| [Set certificate issuer]() | |
| [Update certificate]() | |
| [Update certificate issuer]() | |
| [Update certificate operation]() | |
| [Update certificate policy]() | |

## Why?
This is mainly a project to enable me to learn new things about the .NET Core and the Key Vault service itself and better ways it could be used at my current place of work.