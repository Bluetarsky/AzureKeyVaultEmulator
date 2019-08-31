using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Rest.Azure;
using System.Threading.Tasks;

namespace KeyVaultEmulator.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SecretsController : ControllerBase
    {
        public SecretsController()
        {
        }

        /// <summary>
        /// Backs up the specified secret. Requests that a backup of the specified secret be downloaded to the 
        /// client. All versions of the secret will be downloaded. This operation requires the secrets/backup 
        /// permission.
        /// </summary>
        /// <param name="secretName"></param>
        /// <returns></returns>
        [HttpPost, Route("{secretName}/backup")]
        [ProducesResponseType(typeof(BackupSecretResult), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<IActionResult> BackupSecret([FromRoute] string secretName)
        {
            return Ok();
        }

        /// <summary>
        /// Deletes a secret from a specified key vault. The DELETE operation applies to any secret stored in 
        /// Azure Key Vault. DELETE cannot be applied to an individual version of a secret. This operation 
        /// requires the secrets/delete permission.
        /// </summary>
        /// <param name="secretName"></param>
        /// <returns></returns>
        [HttpDelete, Route("{secretName}")]
        [ProducesResponseType(typeof(DeletedSecretBundle), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<IActionResult> DeleteSecret([FromRoute] string secretName)
        {
            return Ok();
        }

        /// <summary>
        /// Get a specified secret from a given key vault. The GET operation is applicable to any secret stored 
        /// in Azure Key Vault. This operation requires the secrets/get permission.
        /// </summary>
        /// <param name="secretName"></param>
        /// <param name="secretVersion"></param>
        /// <returns></returns>
        [HttpGet, Route("{secretName}/{secretVersion}")]
        [ProducesResponseType(typeof(SecretBundle), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<IActionResult> GetSecret([FromRoute] string secretName, [FromRoute] string secretVersion)
        {
            return Ok();
        }

        /// <summary>
        /// List all versions of the specified secret. The full secret identifier and attributes are provided 
        /// in the response. No values are returned for the secrets. This operations requires the secrets/list 
        /// permission.
        /// </summary>
        /// <param name="secretName"></param>
        /// <param name="maxresults"></param>
        /// <returns></returns>
        [HttpGet, Route("{secretName}/versions")]
        [ProducesResponseType(typeof(AzureOperationResponse<IPage<SecretItem>>), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<IActionResult> GetSecretVersions([FromRoute] string secretName, [FromQuery] int maxresults = 25)
        {
            return Ok();
        }

        /// <summary>
        /// List secrets in a specified key vault. The Get Secrets operation is applicable to the entire vault. 
        /// However, only the base secret identifier and its attributes are provided in the response. Individual 
        /// secret versions are not listed in the response. This operation requires the secrets/list permission.
        /// </summary>
        /// <param name="maxresults"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(AzureOperationResponse<IPage<SecretItem>>), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<IActionResult> GetSecrets([FromQuery] int maxresults = 25)
        {
            return Ok();
        }

        /// <summary>
        /// Restores a backed up secret to a vault. Restores a backed up secret, and all its versions, to 
        /// a vault. This operation requires the secrets/restore permission.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost, Route("restore")]
        [ProducesResponseType(typeof(SecretBundle), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<IActionResult> RestoreSecret([FromBody] string value)
        {
            return Ok();
        }

        /// <summary>
        /// Sets a secret in a specified key vault. The SET operation adds a secret to the Azure Key Vault. If 
        /// the named secret already exists, Azure Key Vault creates a new version of that secret. This operation 
        /// requires the secrets/set permission.
        /// </summary>
        /// <param name="secretName"></param>
        /// <param name="secretSetParameters"></param>
        /// <returns></returns>
        [HttpPut, Route("{secretName}")]
        [ProducesResponseType(typeof(SecretBundle), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<IActionResult> SetSecret([FromRoute] string secretName, [FromBody] SecretSetParameters secretSetParameters)
        {
            return Ok();
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
        [HttpPatch, Route("{secretName}/{secretVersion}")]
        [ProducesResponseType(typeof(SecretBundle), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<IActionResult> UpdateSecret([FromRoute] string secretName, [FromRoute] string secretVersion, [FromBody] SecretUpdateParameters secretUpdateParameters)
        {
            return Ok();
        }
    }
}