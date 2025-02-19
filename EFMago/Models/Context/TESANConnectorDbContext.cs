using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class TESANConnectorDbContext : DbContext
    {
        public TESANConnectorDbContext()
        {
        }
        public TESANConnectorDbContext(DbContextOptions<TESANConnectorDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaTesan> MaTesan { get; set; }
        public virtual DbSet<MaTsconnectorParameters> MaTsconnectorParameters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaTesan>(entity =>
{
                entity.HasKey(e => new { e.Iddoc, e.Tsyear, e.TschargeType, e.TschargeTypeFlag, e.TaxPerc, e.TaxEicode })
                    .HasName("PK_TESAN")
                    .IsClustered(false);

                entity.ToTable("MA_TESAN");

                entity.Property(e => e.Iddoc).HasColumnName("IDDoc");

                entity.Property(e => e.Tsyear).HasColumnName("TSYear");

                entity.Property(e => e.TschargeType)
                    .HasColumnName("TSChargeType")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.TschargeTypeFlag)
                    .HasColumnName("TSChargeTypeFlag")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.TaxEicode)
                    .HasColumnName("TaxEICode")
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

                entity.Property(e => e.TschargeAmount)
                    .HasColumnName("TSChargeAmount")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TsexportDate)
                    .HasColumnName("TSExportDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.TsinstallmentDate)
                    .HasColumnName("TSInstallmentDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.TsoperationType)
                    .HasColumnName("TSOperationType")
                    .HasDefaultValueSql("((32571392))");
            });
            modelBuilder.Entity<MaTsconnectorParameters>(entity =>
{
                entity.HasKey(e => e.TsconnectorParamId)
                    .HasName("PK_TSConnectorParameters")
                    .IsClustered(false);

                entity.ToTable("MA_TSConnectorParameters");

                entity.Property(e => e.TsconnectorParamId)
                    .HasColumnName("TSConnectorParamId")
                    .ValueGeneratedNever();

                entity.Property(e => e.FileName)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FilePath)
                    .HasMaxLength(128)
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
            });
        }
    }
}
