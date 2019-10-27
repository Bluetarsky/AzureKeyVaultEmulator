using Microsoft.EntityFrameworkCore;
using System;

namespace AzureKeyVaultEmulator.Data
{
    [Owned]
    public class Tag
    {
        public string Key { get; set; }

        public string Value { get; set; }
    }
}
