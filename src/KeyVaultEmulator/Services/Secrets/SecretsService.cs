using AzureKeyVaultEmulator.Configuration;
using AzureKeyVaultEmulator.Data;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace AzureKeyVaultEmulator.Services.Secrets
{
    public class SecretsService : ISecretsService
    {
        private readonly ILogger<SecretsService> _logger;
        private readonly PortOptions _portOptions;
        private readonly KeyVaultEmulatorContext _keyVaultEmulatorContext;

        public SecretsService(
            ILogger<SecretsService> logger,
            IOptions<PortOptions> options,
            KeyVaultEmulatorContext keyVaultEmulatorContext)
        {
            if (logger is null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            if (options is null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            if (keyVaultEmulatorContext is null)
            {
                throw new ArgumentNullException(nameof(keyVaultEmulatorContext));
            }

            _logger = logger;
            _portOptions = options.Value;
            _keyVaultEmulatorContext = keyVaultEmulatorContext;
        }

        public async Task<BackupSecretResult> BackupSecretAsync(string secretName)
        {
            var secrets = await GetSecretsAsync(secretName, int.MaxValue);

            // Convert to SecretBundle
            var secretBundles = secrets.Select(s => s.ToSecretBundle(_portOptions.Port));

            // Convert to byte array
            var backedUpSecret = JsonSerializer.SerializeToUtf8Bytes(secretBundles);

            return new BackupSecretResult(backedUpSecret);
        }

        public async Task<IPage<SecretItem>> GetSecretVersionsAsync(string secretName, int maxResults)
        {
            var secrets = await GetSecretsAsync(secretName, maxResults);

            var page = (Page<SecretItem>)secrets.AsEnumerable();

            return page;
        }

        public async Task<SecretBundle> GetSecretAsync(string secretName, string secretVersion)
        {
            var secret = await _keyVaultEmulatorContext.Secrets
                .SingleOrDefaultAsync(s => s.Name == secretName && s.VersionId == secretVersion);

            return secret.ToSecretBundle(_portOptions.Port);
        }

        public async Task<SecretBundle> SetSecretAsync(string secretName, SecretSetParameters secretSetParameters)
        {
            if (secretSetParameters is null)
            {
                throw new ArgumentNullException(nameof(secretSetParameters));
            }

            var id = Utilities.GenerateId();

            var secret = new Secret
            {
                Name = secretName,
                ContentType = secretSetParameters.ContentType,
                Created = secretSetParameters.SecretAttributes?.Created,
                Enabled = secretSetParameters.SecretAttributes?.Enabled,
                Expires = secretSetParameters.SecretAttributes?.Expires,
                NotBefore = secretSetParameters?.SecretAttributes?.NotBefore,
                RecoveryLevel = DeletionRecoveryLevel.Purgeable,
                Tags = secretSetParameters.Tags?.Select(t => new Tag
                {
                    Key = t.Key,
                    Value = t.Value
                }).ToList(),
                Updated = secretSetParameters.SecretAttributes?.Updated,
                Value = secretSetParameters.Value,
                VersionId = id
            };

            var entity = _keyVaultEmulatorContext.Add(secret);
            _ = await _keyVaultEmulatorContext.SaveChangesAsync().ConfigureAwait(false);

            return secret.ToSecretBundle(_portOptions.Port);
        }

        public async Task<DeletedSecretBundle> DeleteSecretAsync(string secretName)
        {


            return new DeletedSecretBundle
            {

            };
        }

        public async Task<IPage<SecretItem>> GetSecretsAsync(int maxResults)
        {
            var secrets = await _keyVaultEmulatorContext.Secrets
                .Take(maxResults)
                .ToListAsync();

            foreach (var secret in secrets)
            {
                
            }

            return new Page<SecretItem>();
        }

        public async Task<SecretBundle> RestoreSecretAsync(string value)
        {
            return new SecretBundle();
        }

        public async Task<SecretBundle> UpdateSecretAsync(string secretName, string secretVersion, SecretUpdateParameters secretUpdateParameters)
        {
            var secret = await GetSecretByVersionAsync(secretName, secretVersion);
            secret.ContentType = secretUpdateParameters.ContentType;
            secret.Tags = secretUpdateParameters.Tags
                .Select(t => new Tag
                {
                    Key = t.Key,
                    Value = t.Value
                })
                .ToList();
            secret.Created = secretUpdateParameters.SecretAttributes.Created;
            secret.Enabled = secretUpdateParameters.SecretAttributes.Enabled;
            secret.Expires = secretUpdateParameters.SecretAttributes.Expires;
            secret.NotBefore = secretUpdateParameters.SecretAttributes.NotBefore;
            secret.RecoveryLevel = secretUpdateParameters.SecretAttributes.RecoveryLevel;
            secret.Updated = secretUpdateParameters.SecretAttributes.Updated;
            _ = await _keyVaultEmulatorContext.SaveChangesAsync();
            return secret.ToSecretBundle(_portOptions.Port);
        }

        private async Task<List<Secret>> GetSecretsAsync(string secretName, int? maxResults = null)
        {
            var secretsQueryable = _keyVaultEmulatorContext.Secrets
                .Where(s => string.Equals(s.Name, secretName, StringComparison.InvariantCulture)
                    && !s.Removed);

            if (maxResults.HasValue)
            {
                secretsQueryable.Take(maxResults.Value);
            }

            var secrets = await secretsQueryable.ToListAsync();

            return secrets;
        }

        private async Task<Secret> GetSecretByVersionAsync(string secretName, string secretVersion)
        {
            return await _keyVaultEmulatorContext.Secrets
                .SingleOrDefaultAsync(s => s.Name == secretName && s.VersionId == secretVersion);
        }
    }
}