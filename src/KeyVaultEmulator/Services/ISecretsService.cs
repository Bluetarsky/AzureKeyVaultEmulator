using System.Threading.Tasks;
using Microsoft.Azure.KeyVault.Models;

namespace KeyVaultEmulator.Services
{
    public interface ISecretsService
    {
        Task<BackupSecretResult> BackupSecretAsync(string secretName);

        Task<SecretBundle> GetSecretAsync(string secretName, string secretVersion);

        Task<SecretBundle> SetSecretAsync(string secretName, SecretSetParameters secretSetParameters);
    }
}