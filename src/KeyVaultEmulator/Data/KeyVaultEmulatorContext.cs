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
        public KeyVaultEmulatorContext([NotNullAttribute] DbContextOptions options) 
            : base(options)
        {
        }
    }
}
