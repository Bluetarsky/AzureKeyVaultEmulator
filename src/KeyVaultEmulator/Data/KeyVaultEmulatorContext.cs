using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace KeyVaultEmulator.Data
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
            modelBuilder.Entity<Secret>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<SecretTag>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Key>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Certificate>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
