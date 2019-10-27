using AzureKeyVaultEmulator.Configuration;
using AzureKeyVaultEmulator.Repositories.Secrets;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Extensions.Options;
using Microsoft.Rest.Azure;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AzureKeyVaultEmulator.Services.Secrets
{
    public class SecretsService : ISecretsService
    {
        private readonly ContainerSettings _containerSettings;
        private readonly ISecretsRepository _secretsRepository;

        public SecretsService(
            IOptions<ContainerSettings> options,
            ISecretsRepository secretsRepository)
        {
            if (options is null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            if (secretsRepository is null)
            {
                throw new ArgumentNullException(nameof(secretsRepository));
            }

            _containerSettings = options.Value;
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
            var secret = await _secretsRepository.SetSecretAsync(secretName, secretSetParameters);

            return new SecretBundle()
            {
                Attributes = new SecretAttributes(secret.Enabled, secret.NotBefore, secret.Expires, secret.Created, secret.Updated, secret.RecoveryLevel),
                ContentType = secret.ContentType,
                Id = $"http://localhost:{_containerSettings.Port}/secrets/{secretName}/{secret.Id.ToString()}",
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