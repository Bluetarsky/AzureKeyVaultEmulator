using System.Collections.Generic;
using System.Threading.Tasks;
using AzureKeyVaultEmulator.Configuration;
using AzureKeyVaultEmulator.Data;
using AzureKeyVaultEmulator.Repositories.Secrets;
using AzureKeyVaultEmulator.Services.Secrets;
using Microsoft.Extensions.Options;
using Moq;

namespace AzureKeyVaultEmulator.Tests
{
	public class SecretTests
	{
		private readonly Mock<ISecretsRepository> _mockSecretRepository;
		private readonly ISecretsService _target;
		private readonly IOptions<PortOptions> _portOptions;

		public SecretTests()
		{
			var portConfiguration = new PortOptions
			{
				Port = 1234
			};
			_portOptions = Options.Create(portConfiguration);
			_mockSecretRepository = new Mock<ISecretsRepository>(MockBehavior.Strict);
			_target = new SecretsService(_portOptions, _mockSecretRepository.Object);
		}

		public async Task BackupSecretAsync()
		{
            var secrets = new List<Secret>
            {

            };
            _mockSecretRepository
                .Setup(m => m.GetSecretsAsync(It.IsAny<string>(), It.IsAny<int?>()))
                .ReturnsAsync(secrets);
        }
	}
}