using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Rest.Azure;
using System.Threading.Tasks;

namespace KeyVaultEmulator.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DeletedSecretsController : ControllerBase
    {
        public DeletedSecretsController()
        {

        }

        /// <summary>
        /// The Get Deleted Secret operation returns the specified deleted secret along with its attributes. 
        /// This operation requires the secrets/get permission.
        /// </summary>
        /// <param name="secretName"></param>
        /// <returns></returns>
        [HttpGet("{secretName}")]
        [ProducesResponseType(typeof(DeletedSecretBundle), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<IActionResult> GetDeletedSecret([FromRoute] string secretName)
        {
            return Ok();
        }

        /// <summary>
        /// The Get Deleted Secrets operation returns the secrets that have been deleted for a vault enabled 
        /// for soft-delete. This operation requires the secrets/list permission.
        /// </summary>
        /// <param name="maxresults"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IPage<DeletedSecretItem>), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<IActionResult> GetDeletedSecrets([FromQuery] int maxresults = 25)
        {
            return Ok();
        }

        /// <summary>
        /// The purge deleted secret operation removes the secret permanently, without the possibility of recovery. 
        /// This operation can only be enabled on a soft-delete enabled vault. This operation requires the 
        /// secrets/purge permission.
        /// </summary>
        /// <param name="secretName"></param>
        /// <returns></returns>
        [HttpDelete("{secretName}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<IActionResult> PurgeDeletedSecret([FromRoute] string secretName)
        {
            return NoContent();
        }

        /// <summary>
        /// Recovers the deleted secret in the specified vault. This operation can only be performed on a soft-delete 
        /// enabled vault. This operation requires the secrets/recover permission.
        /// </summary>
        /// <param name="secretName"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(SecretBundle), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        [HttpPost("{secretName}/recover")]
        public async Task<IActionResult> RecoverDeletedSecret([FromRoute] string secretName)
        {
            return Ok();
        }
    }
}