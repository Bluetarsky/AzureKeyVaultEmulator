using AzureKeyVaultEmulator.V7.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace AzureKeyVaultEmulator.Filters
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        private ILogger<ExceptionFilter> _logger;

        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            _logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            context.ExceptionHandled = true;

            _logger.LogError(context.Exception, "");

            Error error = null;

            KeyVaultError keyVaultError = new KeyVaultError(error);
            context.Result = new JsonResult(keyVaultError);

            base.OnException(context);
        }
    }
}
