using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics.CodeAnalysis;

namespace AzureKeyVaultEmulator.Data
{
    public class KeyVaultEmulatorContext : DbContext
    {
        public KeyVaultEmulatorContext([NotNull] DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Secret> Secrets { get; set; }

        public DbSet<Key> Keys { get; set; }

        public DbSet<Certificate> Certificates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(KeyVaultEmulatorContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
