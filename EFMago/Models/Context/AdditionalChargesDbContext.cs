using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class AdditionalChargesDbContext : DbContext
    {
        public AdditionalChargesDbContext()
        {
        }
        public AdditionalChargesDbContext(DbContextOptions<AdditionalChargesDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaAdditionalCharges> MaAdditionalCharges { get; set; }
        public virtual DbSet<MaAdditionalChargesDetail> MaAdditionalChargesDetail { get; set; }
        public virtual DbSet<MaAdditionalChargesParams> MaAdditionalChargesParams { get; set; }
        public virtual DbSet<MaAdditionalChargesRef> MaAdditionalChargesRef { get; set; }
        public virtual DbSet<MaDistribTemplates> MaDistribTemplates { get; set; }
        public virtual DbSet<MaDistribTemplatesDetail> MaDistribTemplatesDetail { get; set; }
        public virtual DbSet<MaItemToCtgAssociations> MaItemToCtgAssociations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaAdditionalCharges>(entity =>
{
                entity.HasKey(e => e.AdditionalChargesId)
                    .HasName("PK_AdditionalCharges")
                    .IsClustered(false);

                entity.ToTable("MA_AdditionalCharges");

                entity.Property(e => e.AdditionalChargesId).ValueGeneratedNever();

                entity.Property(e => e.AccrualDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.CrrefId)
                    .HasColumnName("CRRefID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CrrefType)
                    .HasColumnName("CRRefType")
                    .HasDefaultValueSql("((27066368))");

                entity.Property(e => e.Currency)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Delta).HasDefaultValueSql("((0))");

                entity.Property(e => e.DistributionTemplate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DocumentDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.DocumentNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Fixing).HasDefaultValueSql("((0))");

                entity.Property(e => e.FixingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.FixingIsManual)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastSubId)
                    .HasColumnName("LastSubID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OperationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Supplier)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SupplierDocNo)
                    .HasMaxLength(20)
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

                entity.Property(e => e.TotalCharges).HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalDistributed).HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalPerc).HasDefaultValueSql("((0))");
            });
            modelBuilder.Entity<MaAdditionalChargesDetail>(entity =>
{
                entity.HasKey(e => new { e.AdditionalChargesId, e.Line })
                    .HasName("PK_AdditionalChargesDetail")
                    .IsClustered(false);

                entity.ToTable("MA_AdditionalChargesDetail");

                entity.Property(e => e.BaseUoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CrrefId)
                    .HasColumnName("CRRefID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CrrefSubId)
                    .HasColumnName("CRRefSubID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CrrefType)
                    .HasColumnName("CRRefType")
                    .HasDefaultValueSql("((27066368))");

                entity.Property(e => e.DistributedCharge).HasDefaultValueSql("((0))");

                entity.Property(e => e.DistributionPerc).HasDefaultValueSql("((0))");

                entity.Property(e => e.GrossVolume).HasDefaultValueSql("((0))");

                entity.Property(e => e.GrossWeight).HasDefaultValueSql("((0))");

                entity.Property(e => e.InvEntryCurrency)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InvEntryFixing).HasDefaultValueSql("((0))");

                entity.Property(e => e.InvEntryFixingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.InvEntryFixingIsManual)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InvEntryId).HasDefaultValueSql("((0))");

                entity.Property(e => e.InvEntrySubId)
                    .HasColumnName("InvEntrySubID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Lot)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NetWeight).HasDefaultValueSql("((0))");

                entity.Property(e => e.NoOfPacks).HasDefaultValueSql("((0))");

                entity.Property(e => e.Offset)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Qty).HasDefaultValueSql("((0))");

                entity.Property(e => e.SubId)
                    .HasColumnName("SubID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TaxableAmount).HasDefaultValueSql("((0))");

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

                entity.HasOne(d => d.AdditionalCharges)
                    .WithMany(p => p.MaAdditionalChargesDetail)
                    .HasForeignKey(d => d.AdditionalChargesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Additional_Additional_00");
            });
            modelBuilder.Entity<MaAdditionalChargesParams>(entity =>
{
                entity.HasKey(e => e.AdditionalChargesParamsId)
                    .HasName("PK_AdditionalChargesParams")
                    .IsClustered(false);

                entity.ToTable("MA_AdditionalChargesParams");

                entity.Property(e => e.AdditionalChargesParamsId).ValueGeneratedNever();

                entity.Property(e => e.ActionModifyInvEntry).HasDefaultValueSql("((11599874))");

                entity.Property(e => e.DefaultSpreadingTemplate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ManageLoadOffsetOnAddChRow)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.StartInBackgroundMode)
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
            modelBuilder.Entity<MaAdditionalChargesRef>(entity =>
{
                entity.HasKey(e => new { e.AdditionalChargesId, e.Line })
                    .HasName("PK_AdditionalChargesRef")
                    .IsClustered(false);

                entity.ToTable("MA_AdditionalChargesRef");

                entity.Property(e => e.DocumentDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.DocumentId).HasDefaultValueSql("((0))");

                entity.Property(e => e.DocumentNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DocumentType).HasDefaultValueSql("((6684693))");

                entity.Property(e => e.Notes)
                    .HasMaxLength(32)
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

                entity.Property(e => e.TypeReference)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.AdditionalCharges)
                    .WithMany(p => p.MaAdditionalChargesRef)
                    .HasForeignKey(d => d.AdditionalChargesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Additional_Additional_01");
            });
            modelBuilder.Entity<MaDistribTemplates>(entity =>
{
                entity.HasKey(e => e.DistributionTemplate)
                    .HasName("PK_DistribTemplates")
                    .IsClustered(false);

                entity.ToTable("MA_DistribTemplates");

                entity.Property(e => e.DistributionTemplate)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DistributionBase).HasDefaultValueSql("((39321600))");

                entity.Property(e => e.InvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InvRsnNeg)
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
            });
            modelBuilder.Entity<MaDistribTemplatesDetail>(entity =>
{
                entity.HasKey(e => new { e.DistributionTemplate, e.ChargeCategory })
                    .HasName("PK_DistribTemplatesDetail")
                    .IsClustered(false);

                entity.ToTable("MA_DistribTemplatesDetail");

                entity.Property(e => e.DistributionTemplate)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.ChargeCategory)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.ChargePerc).HasDefaultValueSql("((0))");

                entity.Property(e => e.Description)
                    .HasMaxLength(64)
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

                entity.HasOne(d => d.DistributionTemplateNavigation)
                    .WithMany(p => p.MaDistribTemplatesDetail)
                    .HasForeignKey(d => d.DistributionTemplate)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DistribTem_DistribTem_00");
            });
            modelBuilder.Entity<MaItemToCtgAssociations>(entity =>
{
                entity.HasKey(e => new { e.Item, e.DistributionTemplate })
                    .HasName("PK_ItemToCtgAssociations")
                    .IsClustered(false);

                entity.ToTable("MA_ItemToCtgAssociations");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.DistributionTemplate)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.ChargeCategory)
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
            });
        }
    }
}
