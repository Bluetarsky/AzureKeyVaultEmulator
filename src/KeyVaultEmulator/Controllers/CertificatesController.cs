using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.KeyVault.Models;

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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<ActionResult<BackupCertificateResult>> BackupCertificate([FromRoute] string certificateName)
        {
            return Ok();
        }


    }
}