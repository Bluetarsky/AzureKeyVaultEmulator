using System.Threading.Tasks;
using KeyVaultEmulator.Repositories;
using Microsoft.Azure.KeyVault.Models;

namespace KeyVaultEmulator.Services
{
    public class SecretsService : ISecretsService
    {
        private readonly string _secretsFolder = "secrets";
        private readonly ISecretsRepository _secretsRepository;
        
        public SecretsService(ISecretsRepository secretsRepository)
        {
            _secretsRepository = secretsRepository;
        }

        public async Task<BackupSecretResult> BackupSecretAsync(string secretName)
        {
            try
            {
                
            }
            catch (System.Exception)
            {
                
            }
            return new BackupSecretResult
            {

            };
        }
    }
}