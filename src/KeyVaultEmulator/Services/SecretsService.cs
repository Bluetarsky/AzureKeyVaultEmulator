using System;
using System.Linq;
using System.Threading.Tasks;
using AzureKeyVaultEmulator;
using KeyVaultEmulator.Repositories;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Rest.Azure;

namespace KeyVaultEmulator.Services
{
    public class SecretsService : ISecretsService
    {
        private readonly ISecretsRepository _secretsRepository;
        
        public SecretsService(ISecretsRepository secretsRepository)
        {
            if (secretsRepository is null)
            {
                throw new ArgumentNullException(nameof(secretsRepository));
            }

            _secretsRepository = secretsRepository;
        }

        public async Task<BackupSecretResult> BackupSecretAsync(string secretName)
        {
            var secrets = await _secretsRepository.GetSecretsAsync(secretName, int.MaxValue);
            
            return new BackupSecretResult
            {

            };
        }

        public async Task<IPage<SecretItem>> GetSecretVersionsAsync(string secretName, int maxResults)
        {
            var secrets = await _secretsRepository.GetSecretsAsync(secretName, maxResults);

            var page = new Page<SecretItem>()
            {
                
            };

            return page;
        }

        public async Task<SecretBundle> GetSecretAsync(string secretName, string secretVersion)
        {
            return new SecretBundle
            {

            };
        }



        public async Task<SecretBundle> SetSecretAsync(string secretName, SecretSetParameters secretSetParameters)
        {
            var id = Utilities.GenerateId();
            var secret = await _secretsRepository.SetSecretAsync(secretName, secretSetParameters);
            if (secret is null)
            {

            }

            return new SecretBundle()
            {
                Attributes = new SecretAttributes(secret.Enabled, secret.NotBefore, secret.Expires, secret.Created, secret.Updated, secret.RecoveryLevel),
                ContentType = secret.ContentType,
                Id = $"http://localhost:9314/secrets/{secretName}/{secret.Id.ToString()}",
                Tags = secret.Tags?.ToDictionary(t => t.Key, t => t.Value),
                Value = secret.Value
            };
        }

        public async Task<DeletedSecretBundle> DeleteSecretAsync(string secretName)
        {
            return new DeletedSecretBundle
            {

            };
        }

        public async Task<IPage<SecretItem>> GetSecretsAsync(int maxResults)
        {
            return new Page<SecretItem>();
        }

        public async Task<SecretBundle> RestoreSecretAsync(string value)
        {
            return new SecretBundle();
        }

        public async Task<SecretBundle> UpdateSecretAsync(string secretName, string secretVersion, SecretUpdateParameters secretUpdateParameters)
        {
            return new SecretBundle();
        }
    }
}