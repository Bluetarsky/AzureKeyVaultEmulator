using KeyVaultEmulator.Data;
using Microsoft.Azure.KeyVault.Models;
using System.Threading.Tasks;

namespace KeyVaultEmulator.Repositories
{
    public interface ISecretsRepository
    {
        Task<Secret> SetSecretAsync(string secretName, SecretSetParameters secretSetParameters);
    }
}