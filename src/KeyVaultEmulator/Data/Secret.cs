using Microsoft.Azure.KeyVault.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AzureKeyVaultEmulator.Data
{
    public class Secret
    {
        public string Id { get; set; }

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

        public SecretBundle ToSecretBundle(int port)
        {
            return new SecretBundle
            {
                Attributes = new SecretAttributes(Enabled, NotBefore, Expires, Created, Updated, RecoveryLevel),
                ContentType = ContentType,
                Id = $"http://localhost:{port}/secrets/{Name}/{Id.ToString()}",
                Tags = Tags?.ToDictionary(t => t.Key, t => t.Value),
                Value = Value
            };
        }
    }
}
