using System.Threading.Tasks;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Rest.Azure;

namespace AzureKeyVaultEmulator.Services.Secrets
{
    public interface ISecretsService
    {
        Task<BackupSecretResult> BackupSecretAsync(string secretName);

        Task<IPage<SecretItem>> GetSecretVersionsAsync(string secretName, int maxResults);

        Task<SecretBundle> GetSecretAsync(string secretName, string secretVersion);

        Task<SecretBundle> SetSecretAsync(string secretName, SecretSetParameters secretSetParameters);

        Task<DeletedSecretBundle> DeleteSecretAsync(string secretName);

        Task<IPage<SecretItem>> GetSecretsAsync(int maxResults);

        Task<SecretBundle> RestoreSecretAsync(string value);

        Task<SecretBundle> UpdateSecretAsync(string secretName, string secretVersion, SecretUpdateParameters secretUpdateParameters);
    }
}