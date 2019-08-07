using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.KeyVault.Models;
using System.Threading.Tasks;

namespace KeyVaultEmulator.Controllers
{
	[Route("[controller]")]
    [ApiController]
    public class KeysController : ControllerBase
    {
		public KeysController()
		{

		}

		[HttpPost, Route("{keyName}/backup")]
		public async Task<IActionResult> BackupKey([FromRoute] string keyName)
		{
			return Ok();
		}

		[HttpPost, Route("{keyName}/create")]
		[ProducesResponseType(typeof(KeyBundle), StatusCodes.Status200OK)]
		public async Task<IActionResult> CreateKey([FromRoute] string keyName, [FromBody] KeyCreateParameters createParameters)
		{
			return Ok(default(KeyBundle));
		}

		[HttpPost, Route("{keyName}/decrypt")]
		[ProducesResponseType(typeof(KeyOperationResult), StatusCodes.Status200OK)]
		public async Task<IActionResult> Decrypt([FromRoute] string keyName, [FromBody] KeyOperationsParameters operationsParameters)
		{
			return Ok();
		}

		[HttpDelete, Route("{keyName}")]
		[ProducesResponseType(typeof(DeletedKeyBundle), StatusCodes.Status200OK)]
		public async Task<IActionResult> DeleteKey([FromRoute] string keyName)
		{
			return Ok();
		}
		
		[HttpPost, Route("{keyName}/{keyVersion/encrypt")]
		[ProducesResponseType(typeof(KeyOperationResult), StatusCodes.Status200OK)]
		public async Task<IActionResult> Encrypt([FromRoute] string keyName, [FromRoute] string keyVersion, [FromBody] KeyOperationsParameters operationsParameters)
		{
			return Ok();
		}
    }
}