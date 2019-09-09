using System.Threading.Tasks;
using Microsoft.Azure.KeyVault.Models;

namespace KeyVaultEmulator.Services
{
    public interface ISecretsService
    {
         Task<BackupSecretResult> BackupSecretAsync(string secretName);
    }
}