using System;
using System.Collections.Generic;

namespace AzureKeyVaultEmulator.Data
{
    public class Secret
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string VersionId { get; set; }

        public string Value { get; set; }

        public string ContentType { get; set; }

        public DateTime? Created { get; set; }

        public bool? Enabled { get; set; }

        public DateTime? Expires { get; set; }

        public DateTime? NotBefore { get; set; }

        public string RecoveryLevel { get; set; }

        public bool Removed { get; set; }

        public DateTime? Updated { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}
