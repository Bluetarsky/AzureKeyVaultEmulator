using System.Linq;
using System.Threading.Tasks;
using KeyVaultEmulator.Repositories;
using Microsoft.Azure.KeyVault.Models;

namespace KeyVaultEmulator.Services
{
    public class SecretsService : ISecretsService
    {
        private readonly ISecretsRepository _secretsRepository;
        
        public SecretsService(ISecretsRepository secretsRepository)
        {
            _secretsRepository = secretsRepository;
        }

        public async Task<BackupSecretResult> BackupSecretAsync(string secretName)
        {
            
            return new BackupSecretResult
            {

            };
        }

        public async Task<SecretBundle> GetSecretAsync(string secretName, string secretVersion)
        {
            return new SecretBundle
            {

            };
        }

        public async Task<SecretBundle> SetSecretAsync(string secretName, SecretSetParameters secretSetParameters)
        {
            var secret = await _secretsRepository.SetSecretAsync(secretName, secretSetParameters);
            if (secret is null)
            {

            }

            return new SecretBundle()
            {
                Attributes = new SecretAttributes(secret.Enabled, secret.NotBefore, secret.Expires, secret.Created, secret.Updated, secret.RecoveryLevel),
                ContentType = secret.ContentType,
                Id = $"http://localhost:9314/secrets/{secretName}/secret.Id.ToString()",
                Tags = secret.Tags?.ToDictionary(t => t.Key, t => t.Value),
                Value = secret.Value
            };
        }
    }
}