using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Rest.Azure;
using System.Threading.Tasks;

namespace KeyVaultEmulator.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CertificatesController : ControllerBase
    {
        public CertificatesController()
        {

        }

        /// <summary>
        /// Backs up the specified certificate. Requests that a backup of the specified certificate be downloaded to the client.
        /// All versions of the certificate will be downloaded. This operation requires the certificates/backup permission.
        /// </summary>
        /// <param name="certificateName"></param>
        /// <returns></returns>
        [HttpPost("{certificateName}/backup")]
        [ProducesResponseType(typeof(AzureOperationResponse<BackupCertificateResult>), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<IActionResult> BackupCertificate([FromRoute] string certificateName)
        {
            return Ok();
        }

        /// <summary>
        /// Creates a new certificate. If this is the first version, the certificate resource is created. This operation requires 
        /// the certificates/create permission.
        /// </summary>
        /// <param name="certificateName"></param>
        /// <param name="certificateCreateParameters"></param>
        /// <returns></returns>
        [HttpPost("{certificateName}/create")]
        [ProducesResponseType(typeof(AzureOperationResponse<CertificateOperation>), StatusCodes.Status202Accepted)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<IActionResult> CreateCertificate([FromRoute] string certificateName, [FromBody] CertificateCreateParameters certificateCreateParameters)
        {
            return Accepted();
        }

        /// <summary>
        /// Deletes a certificate from a specified key vault. Deletes all versions of a certificate object along with its associated
        /// policy. Delete certificate cannot be used to remove individual versions of a certificate object. This operation requires
        /// the certificates/delete permission.
        /// </summary>
        /// <param name="certificateName"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(AzureOperationResponse<DeletedCertificateBundle>), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        [HttpDelete("{certificateName}")]
        public async Task<IActionResult> DeleteCertificate([FromRoute] string certificateName)
        {
            return Ok();
        }

        /// <summary>
        /// Deletes the certificate contacts for a specified key vault certificate. This operation requires the 
        /// certificates/managecontacts permission.
        /// </summary>
        /// <returns></returns>
        [HttpDelete("contacts")]
        [ProducesResponseType(typeof(AzureOperationResponse<Contacts>), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<IActionResult> DeleteCertificateContacts()
        {
            return Ok();
        }

        /// <summary>
        /// The DeleteCertificateIssuer operation permanently removes the specified certificate issuer from the vault. This operation 
        /// requires the certificates/manageissuers/deleteissuers permission.
        /// </summary>
        /// <param name="issuerName"></param>
        /// <returns></returns>
        [HttpDelete("issuers/{issuerName}")]
        [ProducesResponseType(typeof(AzureOperationResponse<IPage<CertificateIssuerItem>>), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<IActionResult> DeleteCertificateIssuer([FromRoute] string issuerName)
        {
            return Ok();
        }

        /// <summary>
        /// Deletes the creation operation for a specified certificate that is in the process of being created. The certificate is no 
        /// longer created. This operation requires the certificates/update permission.
        /// </summary>
        /// <param name="certificateName"></param>
        /// <returns></returns>
        [HttpDelete("{certificateName}/pending")]
        [ProducesResponseType(typeof(AzureOperationResponse<CertificateOperation>), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<IActionResult> DeleteCertificateOperation([FromRoute] string certificateName)
        {
            return Ok();
        }

        /// <summary>
        /// Gets information about a specific certificate. This operation requires the certificates/get permission.
        /// </summary>
        /// <param name="certificateName"></param>
        /// <param name="certificateVersion"></param>
        /// <returns></returns>
        [HttpGet("{certificateName}/{certificateVersion}")]
        [ProducesResponseType(typeof(AzureOperationResponse<CertificateBundle>), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<IActionResult> GetCertificate([FromRoute] string certificateName, [FromRoute] string certificateVersion)
        {
            return Ok();
        }

        /// <summary>
        /// The GetCertificateContacts operation returns the set of certificate contact resources in the specified key vault. This operation 
        /// requires the certificates/managecontacts permission.
        /// </summary>
        /// <returns></returns>
        [HttpGet("contacts")]
        [ProducesResponseType(typeof(AzureOperationResponse<Contacts>), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<IActionResult> GetCertificateContacts()
        {
            return Ok();
        }

        /// <summary>
        /// The GetCertificateIssuer operation returns the specified certificate issuer resources in the specified key vault. This operation 
        /// requires the certificates/manageissuers/getissuers permission.
        /// </summary>
        /// <param name="issuerName"></param>
        /// <returns></returns>
        [HttpGet("issuers/{issuerName}")]
        [ProducesResponseType(typeof(AzureOperationResponse<IssuerBundle>), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<IActionResult> GetCertificateIssuer([FromRoute] string issuerName)
        {
            return Ok();
        }

        /// <summary>
        /// The GetCertificateIssuers operation returns the set of certificate issuer resources in the specified key vault. This operation 
        /// requires the certificates/manageissuers/getissuers permission.
        /// </summary>
        /// <param name="maxresult"></param>
        /// <returns></returns>
        [HttpGet("issuers")]
        [ProducesResponseType(typeof(AzureOperationResponse<IPage<CertificateIssuerItem>>), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<IActionResult> GetCertificateIssuers([FromQuery] int maxresult = 25)
        {
            return Ok();
        }

        /// <summary>
        /// Gets the creation operation associated with a specified certificate. This operation requires the certificates/get permission.
        /// </summary>
        /// <param name="certificateName"></param>
        /// <returns></returns>
        [HttpGet("{certificateName}/pending")]
        [ProducesResponseType(typeof(AzureOperationResponse<CertificateOperation>), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<IActionResult> GetCertificateOperation([FromRoute] string certificateName)
        {
            return Ok();
        }

        /// <summary>
        /// The GetCertificatePolicy operation returns the specified certificate policy resources in the specified key vault. This operation 
        /// requires the certificates/get permission.
        /// </summary>
        /// <param name="certificateName"></param>
        /// <returns></returns>
        [HttpGet("{certificateName}/policy")]
        [ProducesResponseType(typeof(AzureOperationResponse<CertificatePolicy>), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<IActionResult> GetCertificatePolicy([FromRoute] string certificateName)
        {
            return Ok();
        }

        /// <summary>
        /// The GetCertificateVersions operation returns the versions of a certificate in the specified key vault. This operation 
        /// requires the certificates/list permission.
        /// </summary>
        /// <param name="certificateName"></param>
        /// <param name="maxresults"></param>
        /// <returns></returns>
        [HttpGet("{certificateName}/versions")]
        [ProducesResponseType(typeof(AzureOperationResponse<IPage<CertificateItem>>), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<IActionResult> GetCertificateVersions([FromRoute] string certificateName, [FromQuery] int maxresults = 25)
        {
            return Ok();
        }

        /// <summary>
        /// The GetCertificates operation returns the set of certificates resources in the specified key vault. This operation requires
        /// the certificates/list permission.
        /// </summary>
        /// <param name="certificateName"></param>
        /// <param name="maxresults"></param>
        /// <param name="includePending"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(AzureOperationResponse<IPage<CertificateItem>>), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<IActionResult> GetCertificates([FromRoute] string certificateName, [FromQuery] int maxresults = 25, [FromQuery] bool includePending = false)
        {
            return Ok();
        }

        /// <summary>
        /// Imports an existing valid certificate, containing a private key, into Azure Key Vault. The certificate to be imported can 
        /// be in either PFX or PEM formaspott. If the certificate is in PEM format the PEM file must contain the key as well as x509 
        /// certificates. This operation requires the certificates/import permission.
        /// </summary>
        /// <param name="certificateName"></param>
        /// <returns></returns>
        [HttpPost("{certificateName}/import")]
        [ProducesResponseType(typeof(AzureOperationResponse<CertificateBundle>), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<IActionResult> ImportCertificate([FromRoute] string certificateName)
        {
            return Ok();
        }

        /// <summary>
        /// The MergeCertificate operation performs the merging of a certificate or certificate chain with a key pair currently available
        /// in the service. This operation requires the certificates/create permission.
        /// </summary>
        /// <param name="certificateName"></param>
        /// <param name="certificateMergeParameters"></param>
        /// <returns></returns>
        [HttpPost("{certificateName}/pending/merge")]
        [ProducesResponseType(typeof(AzureOperationResponse<CertificateBundle>), StatusCodes.Status201Created)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<IActionResult> MergeCertificate([FromRoute] string certificateName, [FromBody] CertificateMergeParameters certificateMergeParameters)
        {
            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        /// Restores a backed up certificate, and all its versions, to a vault. This operation requires the certificates/restore permission.
        /// </summary>
        /// <param name="certificateRestoreParameters"></param>
        /// <returns></returns>
        [HttpPost("restore")]
        [ProducesResponseType(typeof(AzureOperationResponse<CertificateBundle>), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<IActionResult> RestoreCertificate([FromBody] CertificateRestoreParameters certificateRestoreParameters)
        {
            return Ok();
        }

        /// <summary>
        /// Sets the certificate contacts for the specified key vault. This operation requires the certificates/managecontacts permission.
        /// </summary>
        /// <param name="contacts"></param>
        /// <returns></returns>
        [HttpPut("contacts")]
        [ProducesResponseType(typeof(AzureOperationResponse<Contacts>), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<IActionResult> SetCertificateContacts([FromBody] Contacts contacts)
        {
            return Ok();
        }

        /// <summary>
        /// The SetCertificateIssuer operation adds or updates the specified certificate issuer. This operation requires the certificates/setissuers permission.
        /// </summary>
        /// <param name="issuerName"></param>
        /// <param name="certificateIssuerSetParameters"></param>
        /// <returns></returns>
        [HttpPut("issuers/{issuerName}")]
        [ProducesResponseType(typeof(AzureOperationResponse<IssuerBundle>), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<IActionResult> SetCertificateIssuer([FromRoute] string issuerName, [FromBody] CertificateIssuerSetParameters certificateIssuerSetParameters)
        {
            return Ok();
        }

        /// <summary>
        /// The UpdateCertificate operation applies the specified update on the given certificate; the only elements updated are the certificate's attributes. 
        /// This operation requires the certificates/update permission.
        /// </summary>
        /// <param name="certificateName"></param>
        /// <param name="certificateVersion"></param>
        /// <param name="certificateUpdateParameters"></param>
        /// <returns></returns>
        [HttpPatch("{certificateName}/{certificateVersion}")]
        [ProducesResponseType(typeof(AzureOperationResponse<CertificateBundle>), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<IActionResult> UpdateCertificate([FromRoute] string certificateName, [FromRoute] string certificateVersion, [FromBody] CertificateUpdateParameters certificateUpdateParameters)
        {
            return Ok();
        }

        /// <summary>
        /// The UpdateCertificateIssuer operation performs an update on the specified certificate issuer entity. This operation requires the 
        /// certificates/setissuers permission.
        /// </summary>
        /// <param name="issuerName"></param>
        /// <param name="certificateIssuerUpdateParameters"></param>
        /// <returns></returns>
        [HttpPatch("issuers/{issuerName}")]
        [ProducesResponseType(typeof(AzureOperationResponse<IssuerBundle>), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<IActionResult> UpdateCertificateIssuer([FromRoute] string issuerName, [FromBody] CertificateIssuerUpdateParameters certificateIssuerUpdateParameters)
        {
            return Ok();
        }

        /// <summary>
        /// Updates a certificate creation operation that is already in progress. This operation requires the certificates/update permission.
        /// </summary>
        /// <param name="certificateName"></param>
        /// <param name="certificateOperationUpdateParameter"></param>
        /// <returns></returns>
        [HttpPatch("{certificateName}/pending")]
        [ProducesResponseType(typeof(AzureOperationResponse<CertificateOperation>), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<IActionResult> UpdateCertificateOperation([FromRoute] string certificateName, [FromBody] CertificateOperationUpdateParameter certificateOperationUpdateParameter)
        {
            return Ok();
        }

        /// <summary>
        /// Set specified members in the certificate policy. Leave others as null. This operation requires the certificates/update permission.
        /// </summary>
        /// <param name="certificateName"></param>
        /// <param name="certificatePolicy"></param>
        /// <returns></returns>
        [HttpPatch("{certificateName}/policy")]
        [ProducesResponseType(typeof(AzureOperationResponse<CertificatePolicy>), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<IActionResult> UpdateCertificatePolicy([FromRoute] string certificateName, [FromBody] CertificatePolicy certificatePolicy)
        {
            return Ok();
        }
    }
}