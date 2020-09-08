using AzureKeyVaultEmulator.Configuration;
using AzureKeyVaultEmulator.Data;
using AzureKeyVaultEmulator.Services.Secrets;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureKeyVaultEmulator.Tests
{
    public class SecretTests
	{
        private readonly ILogger<SecretsService> _logger;
		private readonly ISecretsService _target;
		private readonly IOptions<PortOptions> _portOptions;
		private readonly Mock<KeyVaultEmulatorContext> _mockKeyVaultEmulatorContext;

		public SecretTests()
		{
            _logger = new NullLogger<SecretsService>();
			var portConfiguration = new PortOptions
			{
				Port = 1234
			};
			_portOptions = Options.Create(portConfiguration);
			_mockKeyVaultEmulatorContext = new Mock<KeyVaultEmulatorContext>(MockBehavior.Strict);
			_target = new SecretsService(_logger, _portOptions, _mockKeyVaultEmulatorContext.Object);
		}

		public async Task BackupSecretAsync()
		{
            var secrets = new List<Secret>
            {

            };
            
        }
	}
}