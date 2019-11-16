using AzureKeyVaultEmulator.Data;
using AzureKeyVaultEmulator.Repositories.Secrets;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureKeyVaultEmulator.Repositories
{
    public class SecretsRepository : ISecretsRepository
    {
        private readonly KeyVaultEmulatorContext _dbContext;

        public SecretsRepository(KeyVaultEmulatorContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Secret>> GetSecretsAsync(string secretName, int? maxResults)
        {
            var secretsQueryable = _dbContext.Secrets
                .Where(s => string.Equals(s.Name, secretName, StringComparison.InvariantCulture)
                    && !s.Removed);

            if (maxResults.HasValue)
            {
                secretsQueryable.Take(maxResults.Value);
            }

            var secrets = await secretsQueryable.ToListAsync();

            return secrets;
        }

        public async Task<Secret> SetSecretAsync(string secretName, SecretSetParameters secretSetParameters)
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

            var entity = _dbContext.Add(secret);
            _ = await _dbContext.SaveChangesAsync().ConfigureAwait(false);

            return entity.Entity;
        }

        public async Task<Secret> GetSecretByVersionAsync(string secretName, string secretVersion)
        {
            return await _dbContext.Secrets
                .SingleOrDefaultAsync(s => s.Name == secretName && s.VersionId == secretVersion);
        }

        public async Task SoftDeleteSecretAsync(string secretName)
        {
            var secrets = await _dbContext.Secrets
                .Where(s => s.Name == secretName)
                .ToListAsync();

            foreach (var secret in secrets)
            {
                secret.Removed = true;
            }

            _ = await _dbContext.SaveChangesAsync();
        }
    }
}