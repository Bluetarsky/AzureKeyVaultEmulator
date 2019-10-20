using Microsoft.EntityFrameworkCore;
using System;

namespace KeyVaultEmulator.Data
{
    [Owned]
    public class Tag
    {
        public string Key { get; set; }

        public string Value { get; set; }
    }
}
