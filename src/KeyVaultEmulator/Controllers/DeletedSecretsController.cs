using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KeyVaultEmulator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeletedSecretsController : ControllerBase
    {
        public DeletedSecretsController()
        {

        }

        [HttpGet, Route("{secretName}")]
        public async Task<IActionResult> GetDeletedSecret()
        {
            return Ok();
        }
    }
}