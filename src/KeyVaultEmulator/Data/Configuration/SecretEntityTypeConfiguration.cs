using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AzureKeyVaultEmulator.Data.Configuration
{
    public class SecretEntityTypeConfiguration : IEntityTypeConfiguration<Secret>
    {
        public void Configure(EntityTypeBuilder<Secret> builder)
        {
            if (builder is null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
