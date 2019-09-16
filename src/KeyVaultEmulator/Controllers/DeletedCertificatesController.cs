using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Rest.Azure;
using System.Threading.Tasks;

namespace KeyVaultEmulator.Controllers
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
        [HttpGet, Route("{certificateName")]
        [ProducesResponseType(typeof(AzureOperationResponse<DeletedCertificateBundle>), StatusCodes.Status200OK)]
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
        [ProducesResponseType(typeof(AzureOperationResponse<IPage<DeletedCertificateItem>>), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<IActionResult> GetDeletedCertificates([FromQuery] int maxresults = 25, [FromQuery] bool includePending = false)
        {
            return Ok();
        }
    }
}