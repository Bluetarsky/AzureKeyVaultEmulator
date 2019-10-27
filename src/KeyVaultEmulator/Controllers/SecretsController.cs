using AzureKeyVaultEmulator.Services.Secrets;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Rest.Azure;
using System.Threading.Tasks;

namespace AzureKeyVaultEmulator.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SecretsController : ControllerBase
    {
        private readonly ISecretsService _secretsService;

        public SecretsController(ISecretsService secretsService)
        {
            _secretsService = secretsService;
        }

        /// <summary>
        /// Backs up the specified secret. Requests that a backup of the specified secret be downloaded to the 
        /// client. All versions of the secret will be downloaded. This operation requires the secrets/backup 
        /// permission.
        /// </summary>
        /// <param name="secretName"></param>
        /// <returns></returns>
        [HttpPost("{secretName}/backup")]
        [ProducesResponseType(typeof(BackupSecretResult), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<IActionResult> BackupSecret([FromRoute] string secretName)
        {
            var backedupSecret = await _secretsService.BackupSecretAsync(secretName);
            return Ok(backedupSecret);
        }

        /// <summary>
        /// Deletes a secret from a specified key vault. The DELETE operation applies to any secret stored in 
        /// Azure Key Vault. DELETE cannot be applied to an individual version of a secret. This operation 
        /// requires the secrets/delete permission.
        /// </summary>
        /// <param name="secretName"></param>
        /// <returns></returns>
        [HttpDelete("{secretName}")]
        [ProducesResponseType(typeof(DeletedSecretBundle), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<IActionResult> DeleteSecret([FromRoute] string secretName)
        {
            var deletedSecret = await _secretsService.DeleteSecretAsync(secretName);
            return Ok();
        }

        /// <summary>
        /// Get a specified secret from a given key vault. The GET operation is applicable to any secret stored 
        /// in Azure Key Vault. This operation requires the secrets/get permission.
        /// </summary>
        /// <param name="secretName"></param>
        /// <param name="secretVersion"></param>
        /// <returns></returns>
        [HttpGet("{secretName}/{secretVersion}")]
        [ProducesResponseType(typeof(SecretBundle), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<IActionResult> GetSecret([FromRoute] string secretName, [FromRoute] string secretVersion)
        {
            var secret = await _secretsService.GetSecretAsync(secretName, secretVersion);
            if (secret is null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Not Found");
            }

            return Ok(secret);
        }

        /// <summary>
        /// List all versions of the specified secret. The full secret identifier and attributes are provided 
        /// in the response. No values are returned for the secrets. This operations requires the secrets/list 
        /// permission.
        /// </summary>
        /// <param name="secretName"></param>
        /// <param name="maxresults"></param>
        /// <returns></returns>
        [HttpGet("{secretName}/versions")]
        [ProducesResponseType(typeof(IPage<SecretItem>), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<IActionResult> GetSecretVersions([FromRoute] string secretName, [FromQuery] int maxresults = 25)
        {
            var secrets = await _secretsService.GetSecretVersionsAsync(secretName, maxresults);
            return Ok(secrets);
        }

        /// <summary>
        /// List secrets in a specified key vault. The Get Secrets operation is applicable to the entire vault. 
        /// However, only the base secret identifier and its attributes are provided in the response. Individual 
        /// secret versions are not listed in the response. This operation requires the secrets/list permission.
        /// </summary>
        /// <param name="maxresults"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IPage<SecretItem>), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<IActionResult> GetSecrets([FromQuery] int maxresults = 25)
        {
            var secrets = await _secretsService.GetSecretsAsync(maxresults);
            return Ok(secrets);
        }

        /// <summary>
        /// Restores a backed up secret to a vault. Restores a backed up secret, and all its versions, to 
        /// a vault. This operation requires the secrets/restore permission.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost("restore")]
        [ProducesResponseType(typeof(SecretBundle), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<IActionResult> RestoreSecret([FromBody] string value)
        {
            var restoredSecret = await _secretsService.RestoreSecretAsync(value);
            return Ok(restoredSecret);
        }

        /// <summary>
        /// Sets a secret in a specified key vault. The SET operation adds a secret to the Azure Key Vault. If 
        /// the named secret already exists, Azure Key Vault creates a new version of that secret. This operation 
        /// requires the secrets/set permission.
        /// </summary>
        /// <param name="secretName"></param>
        /// <param name="secretSetParameters"></param>
        /// <returns></returns>
        [HttpPut("{secretName}")]
        [ProducesResponseType(typeof(SecretBundle), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<IActionResult> SetSecret([FromRoute] string secretName, [FromBody] SecretSetParameters secretSetParameters)
        {
            var secret = await _secretsService.SetSecretAsync(secretName, secretSetParameters);
            return Ok(secret);
        }

        /// <summary>
        /// Updates the attributes associated with a specified secret in a given key vault. The UPDATE operation 
        /// changes specified attributes of an existing stored secret. Attributes that are not specified in the 
        /// request are left unchanged. The value of a secret itself cannot be changed. This operation requires 
        /// the secrets/set permission.
        /// </summary>
        /// <param name="secretName"></param>
        /// <param name="secretVersion"></param>
        /// <param name="secretUpdateParameters"></param>
        /// <returns></returns>
        [HttpPatch("{secretName}/{secretVersion}")]
        [ProducesResponseType(typeof(SecretBundle), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<IActionResult> UpdateSecret([FromRoute] string secretName, [FromRoute] string secretVersion, [FromBody] SecretUpdateParameters secretUpdateParameters)
        {
            var updatedSecret = await _secretsService.UpdateSecretAsync(secretName, secretVersion, secretUpdateParameters);
            return Ok();
        }
    }
}