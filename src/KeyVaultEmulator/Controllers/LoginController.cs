using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AzureKeyVaultEmulator.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public async Task<IActionResult> Authenticate()
        {
            
            return Ok();
        }
    }
}