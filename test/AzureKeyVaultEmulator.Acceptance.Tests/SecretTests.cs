using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Azure.KeyVault.Models;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace AzureKeyVaultEmulator.Acceptance.Tests
{
    public class SecretTests : IClassFixture<WebApplicationFactory<Startup>>
	{
        private readonly WebApplicationFactory<Startup> _factory;

        public SecretTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

		[Fact]
		public async Task SetSecret_EndpointCreatesSecret()
		{
            var client = _factory.CreateClient();
            var secretName = "someSecret";
            var secretParameters = new SecretSetParameters
            {
                ContentType = MediaTypeNames.Text.Plain,
                Value = "someSecret"
            };
            var serializedParameters = JsonSerializer.Serialize(secretParameters);
            StringContent request = new StringContent(serializedParameters, Encoding.UTF8, MediaTypeNames.Application.Json);
            var response = await client.PutAsync($"secrets/{secretName}", request);

        }
	}
}
