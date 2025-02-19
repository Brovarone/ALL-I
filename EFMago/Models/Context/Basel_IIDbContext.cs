using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class Basel_IIDbContext : DbContext
    {
        public Basel_IIDbContext()
        {
        }
        public Basel_IIDbContext(DbContextOptions<Basel_IIDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaBaselIiparameters> MaBaselIiparameters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaBaselIiparameters>(entity =>
{
                entity.HasKey(e => e.BaselIiparametersId)
                    .HasName("PK_Basel_IIParameters")
                    .IsClustered(false);

                entity.ToTable("MA_Basel_IIParameters");

                entity.Property(e => e.BaselIiparametersId)
                    .HasColumnName("Basel_IIParametersId")
                    .ValueGeneratedNever();

                entity.Property(e => e.AssetsSchemaCode)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.LiabilitiesSchemaCode)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.ProfitLossSchemaCode)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.Tbcreated)
                    .HasColumnName("TBCreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbcreatedId).HasColumnName("TBCreatedID");

                entity.Property(e => e.Tbmodified)
                    .HasColumnName("TBModified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbmodifiedId).HasColumnName("TBModifiedID");
            });
        }
    }
}
