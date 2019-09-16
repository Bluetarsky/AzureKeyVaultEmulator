using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Rest.Azure;

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
        [HttpPost, Route("{certificateName}/backup")]
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
        [HttpPost, Route("{certificateName}/create")]
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
        [HttpDelete, Route("{certificateName}")]
        public async Task<IActionResult> DeleteCertificate([FromRoute] string certificateName)
        {
            return Ok();
        }

        /// <summary>
        /// Deletes the certificate contacts for a specified key vault certificate. This operation requires the 
        /// certificates/managecontacts permission.
        /// </summary>
        /// <returns></returns>
        [HttpDelete, Route("contacts")]
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
        [HttpDelete, Route("issuers/{issuerName}")]
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
        [HttpDelete, Route("{certificateName}/pending")]
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
        [HttpGet, Route("{certificateName}/{certificateVersion}")]
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
        [HttpGet, Route("contacts")]
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
        [HttpGet, Route("issuers/{issuerName}")]
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
        [HttpGet, Route("issuers")]
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
        [HttpGet, Route("{certificateName}/pending")]
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
        [HttpGet, Route("{certificateName}/policy")]
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
        [HttpGet, Route("{certificateName}/versions")]
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
        [HttpGet, Route("{certificateName}/versions")]
        [ProducesResponseType(typeof(AzureOperationResponse<IPage<CertificateItem>>), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<IActionResult> GetCertificates([FromRoute] string certificateName, [FromQuery] int maxresults = 25, [FromQuery] bool includePending = false)
        {
            return Ok();
        }

        /// <summary>
        /// Imports an existing valid certificate, containing a private key, into Azure Key Vault. The certificate to be imported can 
        /// be in either PFX or PEM format. If the certificate is in PEM format the PEM file must contain the key as well as x509 
        /// certificates. This operation requires the certificates/import permission.
        /// </summary>
        /// <param name="certificateName"></param>
        /// <returns></returns>
        [HttpPost, Route("{certificateName}/import")]
        [ProducesResponseType(typeof(AzureOperationResponse<CertificateBundle>), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<IActionResult> ImportCertificate([FromRoute] string certificateName)
        {
            return Ok();
        }
    }
}