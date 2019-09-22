using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeyVaultEmulator.Data
{
    public class Key
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string PublicKey { get; set; }

        public DateTime? ActivationDateUtc { get; set; }

        public DateTime? ExpirationDateUtc { get; set; }
    }
}
