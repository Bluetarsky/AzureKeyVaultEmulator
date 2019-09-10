using KeyVaultEmulator.Data;
using Microsoft.Azure.KeyVault.Models;
using System.Threading.Tasks;

namespace KeyVaultEmulator.Repositories
{
    public class SecretsRepository : ISecretsRepository
    {
        private readonly KeyVaultEmulatorContext _context;

        public SecretsRepository(KeyVaultEmulatorContext context)
        {

        }

        public async Task SetSecret(string secretName, SecretSetParameters secretSetParameters)
        {
            
        }
    }
}