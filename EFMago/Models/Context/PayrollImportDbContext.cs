using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class PayrollImportDbContext : DbContext
    {
        public PayrollImportDbContext()
        {
        }
        public PayrollImportDbContext(DbContextOptions<PayrollImportDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaPriexcludedReasons> MaPriexcludedReasons { get; set; }
        public virtual DbSet<MaPriparameters> MaPriparameters { get; set; }
        public virtual DbSet<MaPrireasons> MaPrireasons { get; set; }
        public virtual DbSet<MaPritemplates> MaPritemplates { get; set; }
        public virtual DbSet<MaPritemplatesDetails> MaPritemplatesDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaPriexcludedReasons>(entity =>
{
                entity.HasKey(e => new { e.ParameterId, e.Reason })
                    .HasName("PK_PRIExcludedReasons")
                    .IsClustered(false);

                entity.ToTable("MA_PRIExcludedReasons");

                entity.Property(e => e.Reason)
                    .HasMaxLength(16)
                    .IsUnicode(false);

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
            modelBuilder.Entity<MaPriparameters>(entity =>
{
                entity.HasKey(e => e.ParameterId)
                    .HasName("PK_PRIParameters")
                    .IsClustered(false);

                entity.ToTable("MA_PRIParameters");

                entity.Property(e => e.ParameterId).ValueGeneratedNever();

                entity.Property(e => e.CompanyCode)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FileName)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FilePath)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GroupByElementType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.GroupByReason)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.LastImportDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

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
            modelBuilder.Entity<MaPrireasons>(entity =>
{
                entity.HasKey(e => e.Reason)
                    .HasName("PK_PRIReasons")
                    .IsClustered(false);

                entity.ToTable("MA_PRIReasons");

                entity.Property(e => e.Reason)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Disabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

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
            modelBuilder.Entity<MaPritemplates>(entity =>
{
                entity.HasKey(e => e.Template)
                    .HasName("PK_PRITemplates")
                    .IsClustered(false);

                entity.ToTable("MA_PRITemplates");

                entity.Property(e => e.Template)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.AccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Description)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Nature).HasDefaultValueSql("((9306112))");

                entity.Property(e => e.Priority).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.ValidityEndingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.ValidityStartingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");
            });
            modelBuilder.Entity<MaPritemplatesDetails>(entity =>
{
                entity.HasKey(e => new { e.Template, e.Line })
                    .HasName("PK_PRITemplatesDetails")
                    .IsClustered(false);

                entity.ToTable("MA_PRITemplatesDetails");

                entity.Property(e => e.Template)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.AccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Reason)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

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
