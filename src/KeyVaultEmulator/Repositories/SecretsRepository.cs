using KeyVaultEmulator.Data;
using Microsoft.Azure.KeyVault.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace KeyVaultEmulator.Repositories
{
    public class SecretsRepository : ISecretsRepository
    {
        private readonly KeyVaultEmulatorContext _dbContext;

        public SecretsRepository(KeyVaultEmulatorContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Secret> SetSecretAsync(string secretName, SecretSetParameters secretSetParameters)
        {
            if (secretSetParameters is null)
            {
                throw new ArgumentNullException(nameof(secretSetParameters));
            }

            var secret = new Secret
            {
                Name = secretName,
                ContentType = secretSetParameters.ContentType,
                Created = secretSetParameters.SecretAttributes?.Created,
                Enabled = secretSetParameters.SecretAttributes?.Enabled,
                Expires = secretSetParameters.SecretAttributes?.Expires,
                NotBefore = secretSetParameters?.SecretAttributes?.NotBefore,
                RecoveryLevel = DeletionRecoveryLevel.Purgeable,
                Tags = secretSetParameters.Tags?.Select(t => new SecretTag
                {
                    Key = t.Key,
                    Value = t.Value
                }).ToList(),
                Updated = secretSetParameters.SecretAttributes?.Updated,
                Value = secretSetParameters.Value
            };

            var entity = _dbContext.Add(secret);
            _ = _dbContext.SaveChangesAsync();

            return secret;
        }

        public async Task GetSecret(string secretName, string secretVersion)
        {

        }
    }
}