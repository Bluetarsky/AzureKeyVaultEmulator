using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace KeyVaultEmulator.AcceptanceTests
{
    public class ServiceHandler : IDisposable
    {
        private bool _disposed = false;
        private IWebHost _webHost;

        public void StartService(string baseUrl, RequestDelegate requestDelegate)
        {
            _webHost = new WebHostBuilder()
                .UseUrls(baseUrl)
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .Configure(app =>
                {
                    app.Run(requestDelegate);
                })
                .Build();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _webHost?.Dispose();
                }
                
                _disposed = true;
            }
        }
    }
}
