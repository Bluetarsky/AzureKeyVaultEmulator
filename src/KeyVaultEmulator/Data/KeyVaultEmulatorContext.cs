using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using NJsonSchema.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeyVaultEmulator.Data
{
    public class KeyVaultEmulatorContext : DbContext
    {
        public KeyVaultEmulatorContext([NotNull] DbContextOptions options) 
            : base(options)
        {
        }

        public DbSet<Secret> Secrets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
