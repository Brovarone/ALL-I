using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class XBRLDbContext : DbContext
    {
        public XBRLDbContext()
        {
        }
        public XBRLDbContext(DbContextOptions<XBRLDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaXbrlparameters> MaXbrlparameters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaXbrlparameters>(entity =>
{
                entity.HasKey(e => e.XbrlparametersId)
                    .HasName("PK_XBRLParameters")
                    .IsClustered(false);

                entity.ToTable("MA_XBRLParameters");

                entity.Property(e => e.XbrlparametersId)
                    .HasColumnName("XBRLParametersId")
                    .ValueGeneratedNever();

                entity.Property(e => e.ReferenceSchemaCode)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Tbcreated)
                    .HasColumnName("TBCreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbcreatedId).HasColumnName("TBCreatedID");

                entity.Property(e => e.Tbguid)
                    .HasColumnName("TBGuid")
                    .HasDefaultValueSql("(0x00)");

                entity.Property(e => e.Tbmodified)
                    .HasColumnName("TBModified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbmodifiedId).HasColumnName("TBModifiedID");

                entity.Property(e => e.XbrlLinkInfocamereSite)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.XbrlLinkInfocamereWs)
                    .HasColumnName("XbrlLinkInfocamereWS")
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.XbrlLinkUrl)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.XbrlLinkWebService)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.XbrlOutputPath)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.XbrlTaxonomy)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
        }
    }
}
