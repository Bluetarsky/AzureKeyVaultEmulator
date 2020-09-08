using AzureKeyVaultEmulator.Data;
using AzureKeyVaultEmulator.Services.Secrets;
using KeyVaultEmulator;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using NSwag;
using System.IO;

namespace AzureKeyVaultEmulator
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //string port = Configuration.GetValue<string>("PORT");
            //if (string.IsNullOrWhiteSpace(port))
            //{
            //    throw new ArgumentNullException(nameof(port));
            //}


            if (!Directory.Exists(Constants.VOLUME_PATH))
            {
                Directory.CreateDirectory(Constants.VOLUME_PATH);
            }

            services.AddRazorPages();
            services.AddControllers().AddControllersAsServices();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(new byte[1]),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddAuthorization(options =>
            {

            });
            services.AddTransient<ISecretsService, SecretsService>();

            services.AddDbContextPool<KeyVaultEmulatorContext>(ctx =>
            {
                ctx.UseSqlite($"Data Source={Path.Combine(Constants.VOLUME_PATH, "KeyVaultEmulator.sqlite")}", o =>
                {

                });
            });

            services.AddOpenApiDocument(options =>
            {
                options.PostProcess = doc =>
                {
                    doc.Info = new OpenApiInfo
                    {
                        Title = "Azure Key Vault Emulator",
                        Version = "7.0",
                        Description = "The key vault client performs cryptographic key operations and vault operations against the Key Vault service."
                    };
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var dbContext = serviceScope.ServiceProvider.GetService<KeyVaultEmulatorContext>())
                {
                    dbContext.Database.Migrate();
                }
            }
            app.UseOpenApi();
            app.UseSwaggerUi3();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }
    }
}
