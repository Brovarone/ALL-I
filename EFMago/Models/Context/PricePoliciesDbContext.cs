using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class PricePoliciesDbContext : DbContext
    {
        public PricePoliciesDbContext()
        {
        }
        public PricePoliciesDbContext(DbContextOptions<PricePoliciesDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaItemCustomersPriceLists> MaItemCustomersPriceLists { get; set; }
        public virtual DbSet<MaItemSuppliersPriceLists> MaItemSuppliersPriceLists { get; set; }
        public virtual DbSet<MaItemsPriceLists> MaItemsPriceLists { get; set; }
        public virtual DbSet<MaPriceLists> MaPriceLists { get; set; }
        public virtual DbSet<MaPricePolicies> MaPricePolicies { get; set; }
        public virtual DbSet<MaPurchaseIncompatDefaults> MaPurchaseIncompatDefaults { get; set; }
        public virtual DbSet<MaPurchasesDiscDefaults> MaPurchasesDiscDefaults { get; set; }
        public virtual DbSet<MaPurchasesValuesDefaults> MaPurchasesValuesDefaults { get; set; }
        public virtual DbSet<MaSalesDiscDefaults> MaSalesDiscDefaults { get; set; }
        public virtual DbSet<MaSalesIncompatDefaults> MaSalesIncompatDefaults { get; set; }
        public virtual DbSet<MaSalesValuesDefaults> MaSalesValuesDefaults { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaItemCustomersPriceLists>(entity =>
{
                entity.HasKey(e => new { e.Item, e.Customer, e.ValidityStartingDate, e.Qty })
                    .HasName("PK_ItemCustomersPriceLists")
                    .IsClustered(false);

                entity.ToTable("MA_ItemCustomersPriceLists");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Customer)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.ValidityStartingDate).HasColumnType("datetime");

                entity.Property(e => e.Discount1).HasDefaultValueSql("((0))");

                entity.Property(e => e.Discount2).HasDefaultValueSql("((0))");

                entity.Property(e => e.DiscountFormula)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastModificationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Price).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.UoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ValidityEndingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.WithTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.HasOne(d => d.MaItemCustomers)
                    .WithMany(p => p.MaItemCustomersPriceLists)
                    .HasForeignKey(d => new { d.Item, d.Customer })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemCustom_ItemCustom_00");
            });
            modelBuilder.Entity<MaItemSuppliersPriceLists>(entity =>
{
                entity.HasKey(e => new { e.Item, e.Supplier, e.Operation, e.ValidityStartingDate, e.Qty })
                    .HasName("PK_ItemSuppliersPriceLists")
                    .IsClustered(false);

                entity.ToTable("MA_ItemSuppliersPriceLists");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Supplier)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Operation)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.ValidityStartingDate).HasColumnType("datetime");

                entity.Property(e => e.Discount1).HasDefaultValueSql("((0))");

                entity.Property(e => e.Discount2).HasDefaultValueSql("((0))");

                entity.Property(e => e.DiscountFormula)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FixedCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastModificationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Price).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.UoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ValidityEndingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.WithTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.HasOne(d => d.MaItemSuppliers)
                    .WithMany(p => p.MaItemSuppliersPriceLists)
                    .HasForeignKey(d => new { d.Item, d.Supplier })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemSuppli_ItemSuppli_01");
            });
            modelBuilder.Entity<MaItemsPriceLists>(entity =>
{
                entity.HasKey(e => new { e.Item, e.PriceList, e.ValidityStartingDate, e.Qty })
                    .HasName("PK_ItemsPriceLists")
                    .IsClustered(false);

                entity.ToTable("MA_ItemsPriceLists");

                entity.HasIndex(e => new { e.PriceList, e.Item, e.ValidityStartingDate, e.Qty })
                    .HasName("IX_MA_ItemsPriceLists_1");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.PriceList)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.ValidityStartingDate).HasColumnType("datetime");

                entity.Property(e => e.AlwaysShow)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Disabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Discount1).HasDefaultValueSql("((0))");

                entity.Property(e => e.Discount2).HasDefaultValueSql("((0))");

                entity.Property(e => e.DiscountFormula)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Discounted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.LastModificationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Price).HasDefaultValueSql("((0))");

                entity.Property(e => e.PriceListUoM)
                    .HasMaxLength(8)
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

                entity.Property(e => e.ValidityEndingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.WithTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.HasOne(d => d.ItemNavigation)
                    .WithMany(p => p.MaItemsPriceLists)
                    .HasForeignKey(d => d.Item)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemsPrice_Items_00");
            });
            modelBuilder.Entity<MaPriceLists>(entity =>
{
                entity.HasKey(e => e.PriceList)
                    .HasName("PK_PriceLists")
                    .IsClustered(false);

                entity.ToTable("MA_PriceLists");

                entity.HasIndex(e => e.Description)
                    .HasName("MA_PriceLists2");

                entity.Property(e => e.PriceList)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.AlwaysShow)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Currency)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Description)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Disabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.LastModificationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

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
            modelBuilder.Entity<MaPricePolicies>(entity =>
{
                entity.HasKey(e => e.PricePoliciesId)
                    .HasName("PK_PricePolicies")
                    .IsClustered(false);

                entity.ToTable("MA_PricePolicies");

                entity.Property(e => e.PricePoliciesId).ValueGeneratedNever();

                entity.Property(e => e.BelowCostMarginCheck)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.BelowStandardCostMarginCheck)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.BelowWavgCostMarginCheck)
                    .HasColumnName("BelowWAvgCostMarginCheck")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ManageDocumentRowPriceList)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NotSaveZeroValues)
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

                entity.Property(e => e.UpdateDiscount)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.WarnOnBelowCost)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.WarnOnBelowStandardCost)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.WarnOnBelowWavgCost)
                    .HasColumnName("WarnOnBelowWAvgCost")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.WarnOnZeroValues)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");
            });
            modelBuilder.Entity<MaPurchaseIncompatDefaults>(entity =>
{
                entity.HasKey(e => new { e.PurchaseIncompatDefaultsId, e.Line })
                    .HasName("PK_PurchaseIncompatDefaults")
                    .IsClustered(false);

                entity.ToTable("MA_PurchaseIncompatDefaults");

                entity.Property(e => e.DiscountType).HasDefaultValueSql("((9568256))");

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

                entity.Property(e => e.ValueType).HasDefaultValueSql("((9437184))");
            });
            modelBuilder.Entity<MaPurchasesDiscDefaults>(entity =>
{
                entity.HasKey(e => new { e.PurchasesDiscDefaultsId, e.Priority })
                    .HasName("PK_PurchasesDiscDefaults")
                    .IsClustered(false);

                entity.ToTable("MA_PurchasesDiscDefaults");

                entity.Property(e => e.CodeType).HasDefaultValueSql("((9568256))");

                entity.Property(e => e.NotPrompt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

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
            });
            modelBuilder.Entity<MaPurchasesValuesDefaults>(entity =>
{
                entity.HasKey(e => new { e.PurchaseValuesDefaultsId, e.Priority })
                    .HasName("PK_PurchasesValuesDefaults")
                    .IsClustered(false);

                entity.ToTable("MA_PurchasesValuesDefaults");

                entity.Property(e => e.CodeType).HasDefaultValueSql("((9371648))");

                entity.Property(e => e.DiscountType).HasDefaultValueSql("((9502720))");

                entity.Property(e => e.NotPrompt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

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
            });
            modelBuilder.Entity<MaSalesDiscDefaults>(entity =>
{
                entity.HasKey(e => new { e.PurchasesDiscDefaultsId, e.Priority })
                    .HasName("PK_SalesDiscDefaults")
                    .IsClustered(false);

                entity.ToTable("MA_SalesDiscDefaults");

                entity.Property(e => e.CodeType).HasDefaultValueSql("((9502720))");

                entity.Property(e => e.NotPrompt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

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
            });
            modelBuilder.Entity<MaSalesIncompatDefaults>(entity =>
{
                entity.HasKey(e => new { e.SalesIncompatDefaultsId, e.Line })
                    .HasName("PK_SalesIncompatDefaults")
                    .IsClustered(false);

                entity.ToTable("MA_SalesIncompatDefaults");

                entity.Property(e => e.DiscountType).HasDefaultValueSql("((9502720))");

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

                entity.Property(e => e.ValueType).HasDefaultValueSql("((9371648))");
            });
            modelBuilder.Entity<MaSalesValuesDefaults>(entity =>
{
                entity.HasKey(e => new { e.PurchaseValuesDefaultsId, e.Priority })
                    .HasName("PK_SalesValuesDefaults")
                    .IsClustered(false);

                entity.ToTable("MA_SalesValuesDefaults");

                entity.Property(e => e.CodeType).HasDefaultValueSql("((9437184))");

                entity.Property(e => e.DiscountType).HasDefaultValueSql("((9568256))");

                entity.Property(e => e.NotPrompt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

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
            });
        }
    }
}
