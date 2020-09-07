using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Rest.Azure;
using System.Threading.Tasks;

namespace AzureKeyVaultEmulator.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class KeysController : ControllerBase
    {
        public KeysController()
        {

        }

        /// <summary>
        /// Creates a new key, stores it, then returns key parameters and attributes to the client. The create key operation can be used to create any key type in 
        /// Azure Key Vault. If the named key already exists, Azure Key Vault creates a new version of the key. It requires the keys/create permission.
        /// </summary>
        /// <param name="keyName"></param>
        /// <param name="createParameters"></param>
        /// <returns></returns>
        [HttpPost("{keyName}/create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<ActionResult<KeyBundle>> CreateKey([FromRoute] string keyName, [FromBody] KeyCreateParameters createParameters)
        {
            return Ok(default(KeyBundle));
        }

        /// <summary>
        /// List keys in the specified vault. Retrieves a list of the keys in the Key Vault as JSON Web Key structures that contain the public part of a stored 
        /// key.The LIST operation is applicable to all key types, however only the base key identifier, attributes, and tags are provided in the response.
        /// Individual versions of a key are not listed in the response. This operation requires the keys/list permission.
        /// </summary>
        /// <param name="maxResults"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<ActionResult<IPage<KeyItem>>> GetKeys([FromQuery] int maxResults = 25)
        {
            return Ok();
        }

        /// <summary>
        /// Requests that a backup of the specified key be downloaded to the client. The Key Backup operation exports a key from Azure Key Vault in a protected form.
        /// Note that this operation does NOT return key material in a form that can be used outside the Azure Key Vault system, the returned key material is either 
        /// protected to a Azure Key Vault HSM or to Azure Key Vault itself.The intent of this operation is to allow a client to GENERATE a key in one Azure Key Vault 
        /// instance, BACKUP the key, and then RESTORE it into another Azure Key Vault instance. The BACKUP operation may be used to export, in protected form, any 
        /// key type from Azure Key Vault.Individual versions of a key cannot be backed up.BACKUP / RESTORE can be performed within geographical boundaries only; 
        /// meaning that a BACKUP from one geographical area cannot be restored to another geographical area.For example, a backup from the US geographical area 
        /// cannot be restored in an EU geographical area.This operation requires the key/backup permission.
        /// </summary>
        /// <param name="keyName">The name of the key</param>
        /// <returns></returns>
        [HttpPost("{keyName}/backup")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<ActionResult<BackupKeyResult>> BackupKey([FromRoute] string keyName)
        {
            return Ok();
        }

        

        /// <summary>
        /// Decrypts a single block of encrypted data. The DECRYPT operation decrypts a well-formed block of ciphertext using the target encryption key and 
        /// specified algorithm. This operation is the reverse of the ENCRYPT operation; only a single block of data may be decrypted, the size of this block 
        /// is dependent on the target key and the algorithm to be used. The DECRYPT operation applies to asymmetric and symmetric keys stored in Azure Key Vault 
        /// since it uses the private portion of the key. This operation requires the keys/decrypt permission.
        /// </summary>
        /// <param name="keyName"></param>
        /// <param name="operationsParameters"></param>
        /// <returns></returns>
        [HttpPost("{keyName}/decrypt")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<ActionResult<KeyOperationResult>> Decrypt([FromRoute] string keyName, [FromBody] KeyOperationsParameters operationsParameters)
        {
            return Ok();
        }

        /// <summary>
        /// Deletes a key of any type from storage in Azure Key Vault. The delete key operation cannot be used to remove individual versions of a key.This 
        /// operation removes the cryptographic material associated with the key, which means the key is not usable for Sign/Verify, Wrap/Unwrap or 
        /// Encrypt/Decrypt operations. This operation requires the keys/delete permission.
        /// </summary>
        /// <param name="keyName"></param>
        /// <returns></returns>
        [HttpDelete("{keyName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<ActionResult<DeletedKeyBundle>> DeleteKey([FromRoute] string keyName)
        {
            return Ok();
        }

        /// <summary>
        /// Encrypts an arbitrary sequence of bytes using an encryption key that is stored in a key vault. The ENCRYPT operation encrypts an arbitrary sequence 
        /// of bytes using an encryption key that is stored in Azure Key Vault.Note that the ENCRYPT operation only supports a single block of data, the size of 
        /// which is dependent on the target key and the encryption algorithm to be used.The ENCRYPT operation is only strictly necessary for symmetric keys 
        /// stored in Azure Key Vault since protection with an asymmetric key can be performed using public portion of the key.This operation is supported for 
        /// asymmetric keys as a convenience for callers that have a key-reference but do not have access to the public key material.This operation requires 
        /// the keys/encrypt permission.
        /// </summary>
        /// <param name="keyName"></param>
        /// <param name="keyVersion"></param>
        /// <param name="operationsParameters"></param>
        /// <returns></returns>
        [HttpPost("{keyName}/{keyVersion}/encrypt")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<ActionResult<KeyOperationResult>> Encrypt([FromRoute] string keyName, [FromRoute] string keyVersion, [FromBody] KeyOperationsParameters operationsParameters)
        {
            return Ok();
        }

        /// <summary>
        ///  Gets the public part of a stored key.The get key operation is applicable to all key types.If the requested key is symmetric, then no key material 
        ///  is released in the response.This operation requires the keys/get permission.
        /// </summary>
        /// <param name="keyName"></param>
        /// <param name="keyVersion"></param>
        /// <returns></returns>
        [HttpGet("{keyName}/{keyVersion}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<ActionResult<KeyBundle>> GetKey([FromRoute] string keyName, [FromRoute] string keyVersion)
        {
            return Ok();
        }

        /// <summary>
        /// Retrieves a list of individual key versions with the same key name. The full key identifier, attributes, and tags are provided in the response.
        /// This operation requires the keys/list permission.
        /// </summary>
        /// <param name="keyName"></param>
        /// <param name="maxResults"></param>
        /// <returns></returns>
        [HttpGet("{keyName}/versions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<ActionResult<IPage<KeyItem>>> GetKeyVersions([FromRoute] string keyName, [FromQuery] int maxResults = 25)
        {
            return Ok();
        }

        /// <summary>
        /// Imports an externally created key, stores it, and returns key parameters and attributes to the client. The import key operation may be used to import 
        /// any key type into an Azure Key Vault. If the named key already exists, Azure Key Vault creates a new version of the key.This operation requires the 
        /// keys/import permission.
        /// </summary>
        /// <param name="keyName"></param>
        /// <param name="keyImportParameters"></param>
        /// <returns></returns>
        [HttpPut("{keyName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<ActionResult<KeyBundle>> ImportKey([FromRoute] string keyName, [FromBody] KeyImportParameters keyImportParameters)
        {
            return Ok();
        }

        /// <summary>
        /// Restores a backed up key to a vault. Imports a previously backed up key into Azure Key Vault, restoring the key, its key identifier, attributes and access 
        /// control policies.The RESTORE operation may be used to import a previously backed up key.Individual versions of a key cannot be restored. The key is restored 
        /// in its entirety with the same key name as it had when it was backed up.If the key name is not available in the target Key Vault, the RESTORE operation will 
        /// be rejected. While the key name is retained during restore, the final key identifier will change if the key is restored to a different vault.Restore will 
        /// restore all versions and preserve version identifiers.The RESTORE operation is subject to security constraints: The target Key Vault must be owned by the 
        /// same Microsoft Azure Subscription as the source Key Vault The user must have RESTORE permission in the target Key Vault. This operation requires the 
        /// keys/restore permission.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost("restore")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<ActionResult<KeyBundle>> RestoreKey([FromBody] string value)
        {
            return Ok();
        }

        /// <summary>
        /// Creates a signature from a digest using the specified key. The SIGN operation is applicable to asymmetric and symmetric keys stored in Azure Key Vault since 
        /// this operation uses the private portion of the key.This operation requires the keys/sign permission.
        /// </summary>
        /// <param name="keyName"></param>
        /// <param name="keyVersion"></param>
        /// <param name="keySignParameters"></param>
        /// <returns></returns>
        [HttpPost("{keyName}/{keyVersion}/sign")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<ActionResult<KeyOperationResult>> Sign([FromRoute] string keyName, [FromRoute] string keyVersion, [FromBody] KeySignParameters keySignParameters)
        {
            return Ok();
        }

        /// <summary>
        /// Unwraps a symmetric key using the specified key that was initially used for wrapping that key. The UNWRAP operation supports decryption 
        /// of a symmetric key using the target key encryption key.This operation is the reverse of the WRAP operation. The UNWRAP operation applies 
        /// to asymmetric and symmetric keys stored in Azure Key Vault since it uses the private portion of the key.This operation requires the 
        /// keys/unwrapKey permission.
        /// </summary>
        /// <param name="keyName">The name of the key.</param>
        /// <param name="keyVersion">The version of the key.</param>
        /// <param name="keyOperationsParameters"></param>
        /// <returns></returns>
        [HttpPost("{keyName}/{keyVersion}/unwrapkey")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<ActionResult<KeyOperationResult>> UnwrapKey([FromRoute] string keyName, [FromRoute] string keyVersion, [FromBody] KeyOperationsParameters keyOperationsParameters)
        {
            return Ok();
        }

        /// <summary>
        /// The update key operation changes specified attributes of a stored key and can be applied to any key type and key version stored in Azure Key Vault.
        /// In order to perform this operation, the key must already exist in the Key Vault.Note: The cryptographic material of a key itself cannot be changed.
        /// This operation requires the keys/update permission.
        /// </summary>
        /// <param name="keyName">The name of key to update.</param>
        /// <param name="keyVersion">The version of the key to update.</param>
        /// <param name="keyUpdateParameters"></param>
        /// <returns></returns>
        [HttpPatch("{keyName}/{keyVersion}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<ActionResult<KeyBundle>> UpdateKey([FromRoute] string keyName, [FromRoute] string keyVersion, KeyUpdateParameters keyUpdateParameters)
        {
            return Ok();
        }

        /// <summary>
        /// Verifies a signature using a specified key. The VERIFY operation is applicable to symmetric keys stored in Azure Key Vault.VERIFY is 
        /// not strictly necessary for asymmetric keys stored in Azure Key Vault since signature verification can be performed using the public 
        /// portion of the key but this operation is supported as a convenience for callers that only have a key-reference and not the public 
        /// portion of the key.This operation requires the keys/verify permission.
        /// </summary>
        /// <param name="keyName"></param>
        /// <param name="keyVersion"></param>
        /// <param name="keyVerifyParameters"></param>
        /// <returns></returns>
        [HttpPost("{keyName}/{keyVersion}/verify")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<ActionResult<KeyVerifyResult>> Verify([FromRoute] string keyName, [FromRoute] string keyVersion, [FromBody] KeyVerifyParameters keyVerifyParameters)
        {
            return Ok();
        }

        /// <summary>
        /// Wraps a symmetric key using a specified key. The WRAP operation supports encryption of a symmetric key using a key encryption key that 
        /// has previously been stored in an Azure Key Vault. The WRAP operation is only strictly necessary for symmetric keys stored in Azure Key 
        /// Vault since protection with an asymmetric key can be performed using the public portion of the key. This operation is supported for 
        /// asymmetric keys as a convenience for callers that have a key-reference but do not have access to the public key material. This operation 
        /// requires the keys/wrapKey permission.
        /// </summary>
        /// <param name="keyName"></param>
        /// <param name="keyVersion"></param>
        /// <param name="keyOperationsParameters"></param>
        /// <returns></returns>
        [HttpPost("{keyName}/{keyVersion}/wrapkey")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(KeyVaultError))]
        public async Task<ActionResult<KeyOperationResult>> WrapKey([FromRoute] string keyName, [FromRoute] string keyVersion, [FromBody] KeyOperationsParameters keyOperationsParameters)
        {
            return Ok();
        }
    }
}