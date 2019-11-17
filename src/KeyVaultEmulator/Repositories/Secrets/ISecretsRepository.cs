using AzureKeyVaultEmulator.Data;
using Microsoft.Azure.KeyVault.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureKeyVaultEmulator.Repositories.Secrets
{
    public interface ISecretsRepository
    {
        Task<List<Secret>> GetSecretsAsync(string secretName, int? maxResults);

        Task<Secret> SetSecretAsync(string secretName, SecretSetParameters secretSetParameters);

        Task<Secret> GetSecretByVersionAsync(string secretName, string secretVersion);

        Task<Secret> UpdateSecretAsync(string secretName, string secretVersion, SecretUpdateParameters secretUpdateParameters);
    }
}