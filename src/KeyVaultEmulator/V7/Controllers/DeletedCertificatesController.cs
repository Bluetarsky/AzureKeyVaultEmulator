using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Rest.Azure;
using System.Threading.Tasks;

namespace AzureKeyVaultEmulator.V7.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DeletedCertificatesController : ControllerBase
    {
        public DeletedCertificatesController()
        {

        }

        /// <summary>
        /// The GetDeletedCertificate operation retrieves the deleted certificate information plus its attributes, such as retention 
        /// interval, scheduled permanent deletion and the current deletion recovery level. This operation requires the certificates/get 
        /// permission.
        /// </summary>
        /// <param name="certificateName"></param>
        /// <returns></returns>
        [HttpGet("{certificateName}")]
        [ProducesResponseType(typeof(DeletedCertificateBundle), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<IActionResult> GetDeletedCertificate([FromQuery] string certificateName)
        {
            return Ok();
        }

        /// <summary>
        /// The GetDeletedCertificates operation retrieves the certificates in the current vault which are in a deleted state and ready for 
        /// recovery or purging. This operation includes deletion-specific information. This operation requires the certificates/get/list 
        /// permission. This operation can only be enabled on soft-delete enabled vaults.
        /// </summary>
        /// <param name="maxresults"></param>
        /// <param name="includePending"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IPage<DeletedCertificateItem>), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<IActionResult> GetDeletedCertificates([FromQuery] int maxresults = 25, [FromQuery] bool includePending = false)
        {
            return Ok();
        }

        /// <summary>
        /// The PurgeDeletedCertificate operation performs an irreversible deletion of the specified certificate, without possibility for 
        /// recovery. The operation is not available if the recovery level does not specify 'Purgeable'. This operation requires the 
        /// certificate/purge permission.
        /// </summary>
        /// <param name="certificateName"></param>
        /// <returns></returns>
        [HttpDelete("{certificateName}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<IActionResult> PurgeDeletedCertificate([FromRoute] string certificateName)
        {
            return NoContent();
        }

        /// <summary>
        /// The RecoverDeletedCertificate operation performs the reversal of the Delete operation. The operation is applicable in vaults enabled 
        /// for soft-delete, and must be issued during the retention interval (available in the deleted certificate's attributes). This operation 
        /// requires the certificates/recover permission.
        /// </summary>
        /// <param name="certificateName"></param>
        /// <returns></returns>
        [HttpPost("{certificateName}/recover")]
        [ProducesResponseType(typeof(CertificateBundle), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<IActionResult> RecoverDeletedCertificate([FromRoute] string certificateName)
        {
            return Ok();
        }
    }
}