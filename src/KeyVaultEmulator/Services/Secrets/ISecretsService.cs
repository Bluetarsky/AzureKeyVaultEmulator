using AzureKeyVaultEmulator.V7.Models;
using System.Threading.Tasks;

namespace AzureKeyVaultEmulator.Services.Secrets
{
    public interface ISecretsService
    {
        Task<BackupSecretResult> BackupSecretAsync(string secretName);

        Task<SecretListResult> GetSecretVersionsAsync(string secretName, int maxResults);

        Task<SecretBundle> GetSecretAsync(string secretName, string secretVersion);

        Task<SecretBundle> SetSecretAsync(string secretName, SecretSetParameters secretSetParameters);

        Task<DeletedSecretBundle> DeleteSecretAsync(string secretName);

        Task<SecretListResult> GetSecretsAsync(int maxResults);

        Task<SecretBundle> RestoreSecretAsync(SecretRestoreParameters secretRestoreParameters);

        Task<SecretBundle> UpdateSecretAsync(string secretName, string secretVersion, SecretUpdateParameters secretUpdateParameters);
    }
}