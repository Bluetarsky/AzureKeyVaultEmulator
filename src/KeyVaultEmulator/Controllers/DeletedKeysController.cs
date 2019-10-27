using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Rest.Azure;
using System.Threading.Tasks;

namespace AzureKeyVaultEmulator.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DeletedKeysController : ControllerBase
    {
        public DeletedKeysController()
        {

        }

        /// <summary>
        /// Gets the public part of a deleted key. The Get Deleted Key operation is applicable for soft-delete 
        /// enabled vaults. While the operation can be invoked on any vault, it will return an error if invoked 
        /// on a non soft-delete enabled vault. This operation requires the keys/get permission.
        /// </summary>
        /// <param name="keyName"></param>
        /// <returns></returns>
        [HttpGet("{keyName}")]
        [ProducesResponseType(typeof(DeletedKeyBundle), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<IActionResult> GetDeletedKey([FromRoute] string keyName)
        {
            return Ok();
        }

        /// <summary>
        /// Lists the deleted keys in the specified vault. Retrieves a list of the keys in the Key Vault as JSON 
        /// Web Key structures that contain the public part of a deleted key. This operation includes 
        /// deletion-specific information. The Get Deleted Keys operation is applicable for vaults enabled for 
        /// soft-delete. While the operation can be invoked on any vault, it will return an error if invoked on 
        /// a non soft-delete enabled vault. This operation requires the keys/list permission.
        /// </summary>
        /// <param name="maxresults"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IPage<KeyItem>), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<IActionResult> GetDeletedKeys([FromQuery] int maxresults)
        {
            return Ok();
        }

        /// <summary>
        /// Permanently deletes the specified key. The Purge Deleted Key operation is applicable for soft-delete 
        /// enabled vaults. While the operation can be invoked on any vault, it will return an error if invoked 
        /// on a non soft-delete enabled vault. This operation requires the keys/purge permission.
        /// </summary>
        /// <param name="keyName"></param>
        /// <returns></returns>
        [HttpDelete("{keyName}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<IActionResult> PurgeDeletedKey([FromRoute] string keyName)
        {
            return Ok();
        }

        /// <summary>
        /// The Recover Deleted Key operation is applicable for deleted keys in soft-delete enabled vaults. It 
        /// recovers the deleted key back to its latest version under /keys. An attempt to recover an non-deleted 
        /// key will return an error. Consider this the inverse of the delete operation on soft-delete enabled 
        /// vaults. This operation requires the keys/recover permission.
        /// </summary>
        /// <param name="keyName"></param>
        /// <returns></returns>
        [HttpPost("{keyName}/recover")]
        [ProducesResponseType(typeof(KeyBundle), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<IActionResult> RecoverDeletedKey([FromRoute] string keyName)
        {
            return Ok();
        }
    }
}