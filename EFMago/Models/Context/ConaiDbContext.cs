using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class ConaiDbContext : DbContext
    {
        public ConaiDbContext()
        {
        }
        public ConaiDbContext(DbContextOptions<ConaiDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaConaientries> MaConaientries { get; set; }
        public virtual DbSet<MaConaiparameters> MaConaiparameters { get; set; }
        public virtual DbSet<MaCustMaterialsExemptPeriod> MaCustMaterialsExemptPeriod { get; set; }
        public virtual DbSet<MaCustMaterialsExemption> MaCustMaterialsExemption { get; set; }
        public virtual DbSet<MaItemsConai> MaItemsConai { get; set; }
        public virtual DbSet<MaItemsMaterials> MaItemsMaterials { get; set; }
        public virtual DbSet<MaMaterials> MaMaterials { get; set; }
        public virtual DbSet<MaPackageTypes> MaPackageTypes { get; set; }
        public virtual DbSet<MaUnitValuePeriod> MaUnitValuePeriod { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaConaientries>(entity =>
{
                entity.HasKey(e => e.EntryId)
                    .HasName("PK_CONAIEntries")
                    .IsClustered(false);

                entity.ToTable("MA_CONAIEntries");

                entity.Property(e => e.EntryId).ValueGeneratedNever();

                entity.Property(e => e.Customer)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DocumentDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.DocumentId).HasDefaultValueSql("((0))");

                entity.Property(e => e.DocumentLine).HasDefaultValueSql("((0))");

                entity.Property(e => e.DocumentNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DocumentType)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EntryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.ExemptQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ExemptionPerc).HasDefaultValueSql("((0))");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Material)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PackageType)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PackageTypeDescription)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PrimaryPackage)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PrimaryPackageQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.Qty).HasDefaultValueSql("((0))");

                entity.Property(e => e.SecondaryTertiaryPackageQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.SubjectedQty).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.TotalContributionAmount).HasDefaultValueSql("((0))");

                entity.Property(e => e.UnitContribution).HasDefaultValueSql("((0))");
            });
            modelBuilder.Entity<MaConaiparameters>(entity =>
{
                entity.HasKey(e => e.ConaiParametersId)
                    .HasName("PK_CONAIParameters")
                    .IsClustered(false);

                entity.ToTable("MA_CONAIParameters");

                entity.Property(e => e.ConaiParametersId).ValueGeneratedNever();

                entity.Property(e => e.ContributionAcquittedNoteFe)
                    .HasColumnName("ContributionAcquittedNoteFE")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.GroupMaterials)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.GroupTaxCodeMaterial)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ItemDescription)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NoContributionOnDocument)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ShowConfirmDialog)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

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
            modelBuilder.Entity<MaCustMaterialsExemptPeriod>(entity =>
{
                entity.HasKey(e => new { e.Customer, e.Material, e.StartingValidityDate })
                    .HasName("PK_CustMaterialsExemptionPer")
                    .IsClustered(false);

                entity.ToTable("MA_CustMaterialsExemptPeriod");

                entity.Property(e => e.Customer)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Material)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.StartingValidityDate).HasColumnType("datetime");

                entity.Property(e => e.EndingValidityDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.ExemptionNote)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExemptionPerc).HasDefaultValueSql("((0))");

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

                entity.HasOne(d => d.MaCustMaterialsExemption)
                    .WithMany(p => p.MaCustMaterialsExemptPeriod)
                    .HasForeignKey(d => new { d.Customer, d.Material })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustMaterialsExemptionP_00");
            });
            modelBuilder.Entity<MaCustMaterialsExemption>(entity =>
{
                entity.HasKey(e => new { e.Customer, e.Material })
                    .HasName("PK_CustMaterialsExemption")
                    .IsClustered(false);

                entity.ToTable("MA_CustMaterialsExemption");

                entity.Property(e => e.Customer)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Material)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.NoEntryPosting)
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
            modelBuilder.Entity<MaItemsConai>(entity =>
{
                entity.HasKey(e => e.Item)
                    .HasName("PK_ItemsConai")
                    .IsClustered(false);

                entity.ToTable("MA_ItemsConai");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ImportedMaterial)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.TaxCode)
                    .HasMaxLength(4)
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

                entity.Property(e => e.UseDocumentWeight)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");
            });
            modelBuilder.Entity<MaItemsMaterials>(entity =>
{
                entity.HasKey(e => new { e.Item, e.Material })
                    .HasName("PK_ItemsMaterials")
                    .IsClustered(false);

                entity.ToTable("MA_ItemsMaterials");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Material)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.PackageType)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PackageTypeDescription)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PrimaryPackage)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

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

                entity.Property(e => e.UnitWeight).HasDefaultValueSql("((0))");

                entity.Property(e => e.UoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
            modelBuilder.Entity<MaMaterials>(entity =>
{
                entity.HasKey(e => e.Material)
                    .HasName("PK_Materials")
                    .IsClustered(false);

                entity.ToTable("MA_Materials");

                entity.Property(e => e.Material)
                    .HasMaxLength(21)
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

                entity.Property(e => e.Offset)
                    .HasMaxLength(16)
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
            modelBuilder.Entity<MaPackageTypes>(entity =>
{
                entity.HasKey(e => new { e.Material, e.PackageType })
                    .HasName("PK_PackageTypes")
                    .IsClustered(false);

                entity.ToTable("MA_PackageTypes");

                entity.Property(e => e.Material)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.PackageType)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.ExemptionNote)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PackageTypeDescription)
                    .HasMaxLength(64)
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
            modelBuilder.Entity<MaUnitValuePeriod>(entity =>
{
                entity.HasKey(e => new { e.Material, e.StartingValidityDate })
                    .HasName("PK_UnitValuePeriod")
                    .IsClustered(false);

                entity.ToTable("MA_UnitValuePeriod");

                entity.Property(e => e.Material)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.StartingValidityDate).HasColumnType("datetime");

                entity.Property(e => e.EndingValidityDate)
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

                entity.Property(e => e.UnitValue).HasDefaultValueSql("((0))");
            });
        }
    }
}
