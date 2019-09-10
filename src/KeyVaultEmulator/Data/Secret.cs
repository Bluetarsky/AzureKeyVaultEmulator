using System;
using System.Collections.Generic;

namespace KeyVaultEmulator.Data
{
    public class Secret
    {
        public string Name { get; set; }

        public string Value { get; set; }

        public string ContentType { get; set; }

        public DateTime? Created { get; set; }

        public bool? Enabled { get; set; }

        public DateTime? Expires { get; set; }

        public DateTime? NotBefore { get; set; }

        public string RecoveryLevel { get; set; }

        public DateTime? Updated { get; set; }

        public virtual ICollection<SecretTag> Tags { get; set; }
    }
}
