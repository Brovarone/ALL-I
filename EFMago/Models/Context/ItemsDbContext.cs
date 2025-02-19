using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class ItemsDbContext : DbContext
    {
        public ItemsDbContext()
        {
        }
        public ItemsDbContext(DbContextOptions<ItemsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaCommodityCtg> MaCommodityCtg { get; set; }
        public virtual DbSet<MaCommodityCtgBudget> MaCommodityCtgBudget { get; set; }
        public virtual DbSet<MaCommodityCtgCustomers> MaCommodityCtgCustomers { get; set; }
        public virtual DbSet<MaCommodityCtgCustomersBudget> MaCommodityCtgCustomersBudget { get; set; }
        public virtual DbSet<MaCommodityCtgCustomersCtg> MaCommodityCtgCustomersCtg { get; set; }
        public virtual DbSet<MaCommodityCtgSuppliers> MaCommodityCtgSuppliers { get; set; }
        public virtual DbSet<MaCommodityCtgSuppliersCtg> MaCommodityCtgSuppliersCtg { get; set; }
        public virtual DbSet<MaDepartments> MaDepartments { get; set; }
        public virtual DbSet<MaHomogeneousCtg> MaHomogeneousCtg { get; set; }
        public virtual DbSet<MaHomogeneousCtgBudget> MaHomogeneousCtgBudget { get; set; }
        public virtual DbSet<MaItemCustomers> MaItemCustomers { get; set; }
        public virtual DbSet<MaItemCustomersBudget> MaItemCustomersBudget { get; set; }
        public virtual DbSet<MaItemNotes> MaItemNotes { get; set; }
        public virtual DbSet<MaItemParameters> MaItemParameters { get; set; }
        public virtual DbSet<MaItemSuppliers> MaItemSuppliers { get; set; }
        public virtual DbSet<MaItemSuppliersOperations> MaItemSuppliersOperations { get; set; }
        public virtual DbSet<MaItemTypeBudget> MaItemTypeBudget { get; set; }
        public virtual DbSet<MaItemTypeCustomers> MaItemTypeCustomers { get; set; }
        public virtual DbSet<MaItemTypeCustomersBudget> MaItemTypeCustomersBudget { get; set; }
        public virtual DbSet<MaItemTypeSuppliers> MaItemTypeSuppliers { get; set; }
        public virtual DbSet<MaItemTypes> MaItemTypes { get; set; }
        public virtual DbSet<MaItems> MaItems { get; set; }
        public virtual DbSet<MaItemsComparableUoM> MaItemsComparableUoM { get; set; }
        public virtual DbSet<MaItemsGoodsData> MaItemsGoodsData { get; set; }
        public virtual DbSet<MaItemsIntrastat> MaItemsIntrastat { get; set; }
        public virtual DbSet<MaItemsKit> MaItemsKit { get; set; }
        public virtual DbSet<MaItemsManufacturingData> MaItemsManufacturingData { get; set; }
        public virtual DbSet<MaItemsPurchaseBarCode> MaItemsPurchaseBarCode { get; set; }
        public virtual DbSet<MaItemsSubstitute> MaItemsSubstitute { get; set; }
        public virtual DbSet<MaProducers> MaProducers { get; set; }
        public virtual DbSet<MaProducersCategories> MaProducersCategories { get; set; }
        public virtual DbSet<MaProductCtg> MaProductCtg { get; set; }
        public virtual DbSet<MaProductCtgSubCtg> MaProductCtgSubCtg { get; set; }
        public virtual DbSet<MaProductSubCtgDefaults> MaProductSubCtgDefaults { get; set; }
        public virtual DbSet<MaUnitOfMeasureDetail> MaUnitOfMeasureDetail { get; set; }
        public virtual DbSet<MaUnitsOfMeasure> MaUnitsOfMeasure { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaCommodityCtg>(entity =>
{
                entity.HasKey(e => e.Category)
                    .HasName("PK_CommodityCtg")
                    .IsClustered(false);

                entity.ToTable("MA_CommodityCtg");

                entity.HasIndex(e => e.Description)
                    .HasName("MA_CommodityCtg2");

                entity.HasIndex(e => e.HasSuppliers)
                    .HasName("MA_CommodityCtg3");

                entity.Property(e => e.Category)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.ConsumptionOffset)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Description)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Discount1).HasDefaultValueSql("((0))");

                entity.Property(e => e.Discount2).HasDefaultValueSql("((0))");

                entity.Property(e => e.DiscountFormula)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.HasCustomers)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.HasSuppliers)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PerishablesType).HasDefaultValueSql("((28966914))");

                entity.Property(e => e.PurchaseOffset)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RctaxCode)
                    .HasColumnName("RCTaxCode")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReverseCharge)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SaleOffset)
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
            modelBuilder.Entity<MaCommodityCtgBudget>(entity =>
{
                entity.HasKey(e => new { e.Category, e.BudgetYear, e.BudgetMonth, e.FiscalYear })
                    .HasName("PK_CommodityCtgBudget")
                    .IsClustered(false);

                entity.ToTable("MA_CommodityCtgBudget");

                entity.Property(e => e.Category)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.PurchaseQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.PurchaseValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.SaleQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.SaleValue).HasDefaultValueSql("((0))");

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

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.MaCommodityCtgBudget)
                    .HasForeignKey(d => d.Category)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CommodityCtgBudget_00");
            });
            modelBuilder.Entity<MaCommodityCtgCustomers>(entity =>
{
                entity.HasKey(e => new { e.Category, e.Customer })
                    .HasName("PK_CommodityCtgCustomers")
                    .IsClustered(false);

                entity.ToTable("MA_CommodityCtgCustomers");

                entity.HasIndex(e => new { e.Customer, e.Category })
                    .HasName("MA_CommodityCtgCustomers2");

                entity.Property(e => e.Category)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Customer)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.AdditionalCharges).HasDefaultValueSql("((0))");

                entity.Property(e => e.DaysForDelivery).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.LastDiscount1).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastDiscount2).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastDiscountFormula)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastPaymentTerm)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastRmadocDate)
                    .HasColumnName("LastRMADocDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.LastRmadocNo)
                    .HasColumnName("LastRMADocNo")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastRmaqty)
                    .HasColumnName("LastRMAQty")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LastRmavalue)
                    .HasColumnName("LastRMAValue")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LastSaleDocDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.LastSaleDocNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastSaleDocType)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastSaleQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastSaleValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.MinOrderQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.Notes)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PriceList)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SaleOffset)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ShippingCost).HasDefaultValueSql("((0))");

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
            modelBuilder.Entity<MaCommodityCtgCustomersBudget>(entity =>
{
                entity.HasKey(e => new { e.Category, e.Customer, e.BudgetYear, e.BudgetMonth, e.FiscalYear })
                    .HasName("PK_CommodityCtgCustomersBudget")
                    .IsClustered(false);

                entity.ToTable("MA_CommodityCtgCustomersBudget");

                entity.Property(e => e.Category)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Customer)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.SaleQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.SaleValue).HasDefaultValueSql("((0))");

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

                entity.HasOne(d => d.C)
                    .WithMany(p => p.MaCommodityCtgCustomersBudget)
                    .HasForeignKey(d => new { d.Category, d.Customer })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CommodityCtgCustomersBudget_00");
            });
            modelBuilder.Entity<MaCommodityCtgCustomersCtg>(entity =>
{
                entity.HasKey(e => new { e.CommodityCtg, e.CustomerCtg })
                    .HasName("PK_CommodityCtgCustomersCtg")
                    .IsClustered(false);

                entity.ToTable("MA_CommodityCtgCustomersCtg");

                entity.HasIndex(e => new { e.CustomerCtg, e.CommodityCtg })
                    .HasName("MA_CommodityCtgCustomersCtg2");

                entity.Property(e => e.CommodityCtg)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerCtg)
                    .HasMaxLength(12)
                    .IsUnicode(false);

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

                entity.Property(e => e.Notes)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReverseCharge)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SaleOffset)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

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
            });
            modelBuilder.Entity<MaCommodityCtgSuppliers>(entity =>
{
                entity.HasKey(e => new { e.Category, e.Supplier })
                    .HasName("PK_CommodityCtgSuppliers")
                    .IsClustered(false);

                entity.ToTable("MA_CommodityCtgSuppliers");

                entity.HasIndex(e => new { e.Supplier, e.Category })
                    .HasName("MA_CommodityCtgSuppliers2");

                entity.Property(e => e.Category)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Supplier)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.AdditionalCharges).HasDefaultValueSql("((0))");

                entity.Property(e => e.DaysForDelivery).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.LastDiscount1).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastDiscount2).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastDiscountFormula)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastPaymentTerm)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastPurchaseDocDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.LastPurchaseDocNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastPurchaseDocType)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastPurchaseQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastPurchaseValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastRmadocDate)
                    .HasColumnName("LastRMADocDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.LastRmadocNo)
                    .HasColumnName("LastRMADocNo")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastRmaqty)
                    .HasColumnName("LastRMAQty")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LastRmavalue)
                    .HasColumnName("LastRMAValue")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MinOrderQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.Notes)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PurchaseOffset)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ShippingCost).HasDefaultValueSql("((0))");

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
            modelBuilder.Entity<MaCommodityCtgSuppliersCtg>(entity =>
{
                entity.HasKey(e => new { e.CommodityCtg, e.SupplierCtg })
                    .HasName("PK_CommodityCtgSuppliersCtg")
                    .IsClustered(false);

                entity.ToTable("MA_CommodityCtgSuppliersCtg");

                entity.HasIndex(e => new { e.SupplierCtg, e.CommodityCtg })
                    .HasName("MA_CommodityCtgSuppliersCtg2");

                entity.Property(e => e.CommodityCtg)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierCtg)
                    .HasMaxLength(12)
                    .IsUnicode(false);

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

                entity.Property(e => e.Notes)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PurchaseOffset)
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
            modelBuilder.Entity<MaDepartments>(entity =>
{
                entity.HasKey(e => e.Department)
                    .HasName("PK_Departments")
                    .IsClustered(false);

                entity.ToTable("MA_Departments");

                entity.HasIndex(e => e.Description)
                    .HasName("MA_Departments2");

                entity.Property(e => e.Department)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Disabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Notes)
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
            modelBuilder.Entity<MaHomogeneousCtg>(entity =>
{
                entity.HasKey(e => e.Category)
                    .HasName("PK_HomogeneousCtg")
                    .IsClustered(false);

                entity.ToTable("MA_HomogeneousCtg");

                entity.HasIndex(e => e.Description)
                    .HasName("MA_HomogeneousCtg2");

                entity.Property(e => e.Category)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Mrppolicy)
                    .HasColumnName("MRPPolicy")
                    .HasDefaultValueSql("((22609920))");

                entity.Property(e => e.NoMrp)
                    .HasColumnName("NoMRP")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Notes)
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
            modelBuilder.Entity<MaHomogeneousCtgBudget>(entity =>
{
                entity.HasKey(e => new { e.Category, e.BudgetYear, e.BudgetMonth, e.FiscalYear })
                    .HasName("PK_HomogeneousCtgBudget")
                    .IsClustered(false);

                entity.ToTable("MA_HomogeneousCtgBudget");

                entity.Property(e => e.Category)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.PurchaseQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.PurchaseValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.SaleQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.SaleValue).HasDefaultValueSql("((0))");

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

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.MaHomogeneousCtgBudget)
                    .HasForeignKey(d => d.Category)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HomogeneousCtgBudget_00");
            });
            modelBuilder.Entity<MaItemCustomers>(entity =>
{
                entity.HasKey(e => new { e.Item, e.Customer })
                    .HasName("PK_ItemCustomers")
                    .IsClustered(false);

                entity.ToTable("MA_ItemCustomers");

                entity.HasIndex(e => new { e.Customer, e.Item })
                    .HasName("MA_ItemCustomers2");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Customer)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.ActiveSubcontractingSupplier)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AdditionalCharges).HasDefaultValueSql("((0))");

                entity.Property(e => e.CustomerBarCode)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustomerCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustomerDescription)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DaysForDelivery).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.EiadminstrativeRef)
                    .HasColumnName("EIAdminstrativeRef")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastDiscount1).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastDiscount2).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastDiscountFormula)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastPaymentTerm)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastPrice).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastPriceCurrency)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastPriceUoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastPriceWithTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.LastRmadocDate)
                    .HasColumnName("LastRMADocDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.LastRmadocNo)
                    .HasColumnName("LastRMADocNo")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastRmaqty)
                    .HasColumnName("LastRMAQty")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LastRmavalue)
                    .HasColumnName("LastRMAValue")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LastSaleDocDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.LastSaleDocNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastSaleDocType)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastSaleQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastSaleValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.MinOrderQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.Notes)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SaleOffset)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ShippingCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.StandardPrice).HasDefaultValueSql("((0))");

                entity.Property(e => e.StandardPriceWithTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SutpreShipping)
                    .HasColumnName("SUTPreShipping")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SutpreShippingQty)
                    .HasColumnName("SUTPreShippingQty")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SutpreShippingUoM)
                    .HasColumnName("SUTPreShippingUoM")
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

                entity.Property(e => e.UoMstandardPrice)
                    .HasColumnName("UoMStandardPrice")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Variant)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
            modelBuilder.Entity<MaItemCustomersBudget>(entity =>
{
                entity.HasKey(e => new { e.Item, e.Customer, e.BudgetYear, e.BudgetMonth, e.FiscalYear })
                    .HasName("PK_ItemCustomersBudget")
                    .IsClustered(false);

                entity.ToTable("MA_ItemCustomersBudget");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Customer)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.SaleQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.SaleValue).HasDefaultValueSql("((0))");

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

                entity.HasOne(d => d.MaItemCustomers)
                    .WithMany(p => p.MaItemCustomersBudget)
                    .HasForeignKey(d => new { d.Item, d.Customer })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemCustomersBudget_00");
            });
            modelBuilder.Entity<MaItemNotes>(entity =>
{
                entity.HasKey(e => new { e.Item, e.Line })
                    .HasName("PK_ItemNotes")
                    .IsClustered(false);

                entity.ToTable("MA_ItemNotes");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ShowInPurchases)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ShowInSales)
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

                entity.HasOne(d => d.ItemNavigation)
                    .WithMany(p => p.MaItemNotes)
                    .HasForeignKey(d => d.Item)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemNo_Item_09");
            });
            modelBuilder.Entity<MaItemParameters>(entity =>
{
                entity.HasKey(e => e.ItemParametersId)
                    .HasName("PK_ItemParameters")
                    .IsClustered(false);

                entity.ToTable("MA_ItemParameters");

                entity.Property(e => e.ItemParametersId).ValueGeneratedNever();

                entity.Property(e => e.AdditionalCodeLength).HasDefaultValueSql("((16))");

                entity.Property(e => e.AutoAddCommCtgCustomers)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.AutoAddCommCtgSuppliers)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.AutoAddItemCustomers)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.AutoAddItemSuppliers)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.BracketMaxQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.CheckExistItem)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CheckItemUoM)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CodeLength).HasDefaultValueSql("((0))");

                entity.Property(e => e.DefaultItemUoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ItemAutoNum)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ItemDraftDefault)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ItemDraftType).HasDefaultValueSql("((25100288))");

                entity.Property(e => e.ItemMaxChars).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastItem).HasDefaultValueSql("((0))");

                entity.Property(e => e.PunctualItemCustSuppUpdate)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.StorageOnHandOnItemComboBox)
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

                entity.Property(e => e.UpdateQtyBracketPrices)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");
            });
            modelBuilder.Entity<MaItemSuppliers>(entity =>
{
                entity.HasKey(e => new { e.Item, e.Supplier })
                    .HasName("PK_ItemSuppliers")
                    .IsClustered(false);

                entity.ToTable("MA_ItemSuppliers");

                entity.HasIndex(e => new { e.Supplier, e.Item })
                    .HasName("MA_ItemSuppliers2");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Supplier)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.AdditionalCharges).HasDefaultValueSql("((0))");

                entity.Property(e => e.Currency)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DaysForDelivery).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.LastDiscount1).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastDiscount2).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastDiscountFormula)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastPaymentTerm)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastPrice).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastPriceCurrency)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastPriceUoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastPriceWithTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.LastPurchaseDocDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.LastPurchaseDocNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastPurchaseDocType)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastPurchaseQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastPurchaseValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastRmadocDate)
                    .HasColumnName("LastRMADocDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.LastRmadocNo)
                    .HasColumnName("LastRMADocNo")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastRmaqty)
                    .HasColumnName("LastRMAQty")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LastRmavalue)
                    .HasColumnName("LastRMAValue")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MinOrderQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.Notes)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OutsrcPriceListUoM)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PostToInspection).HasDefaultValueSql("((20709376))");

                entity.Property(e => e.PurchaseOffset)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ShippingCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.SpecificationsForSupplier)
                    .HasColumnType("ntext")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StandardPrice).HasDefaultValueSql("((0))");

                entity.Property(e => e.StandardPriceWithTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SupplierCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SupplierDescription)
                    .HasMaxLength(256)
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

                entity.Property(e => e.UoMstandardPrice)
                    .HasColumnName("UoMStandardPrice")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
            modelBuilder.Entity<MaItemSuppliersOperations>(entity =>
{
                entity.HasKey(e => new { e.Item, e.Supplier, e.Operation })
                    .HasName("PK_ItemSuppliersOperations")
                    .IsClustered(false);

                entity.ToTable("MA_ItemSuppliersOperations");

                entity.HasIndex(e => new { e.Supplier, e.Item, e.Operation })
                    .HasName("MA_ItemSuppliersOperations2");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Supplier)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Operation)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FixedCost).HasDefaultValueSql("((0))");

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

                entity.HasOne(d => d.MaItemSuppliers)
                    .WithMany(p => p.MaItemSuppliersOperations)
                    .HasForeignKey(d => new { d.Item, d.Supplier })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemSuppli_ItemSuppli_00");
            });
            modelBuilder.Entity<MaItemTypeBudget>(entity =>
{
                entity.HasKey(e => new { e.CodeType, e.BudgetYear, e.BudgetMonth, e.FiscalYear })
                    .HasName("PK_ItemTypeBudget")
                    .IsClustered(false);

                entity.ToTable("MA_ItemTypeBudget");

                entity.Property(e => e.CodeType)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.PurchaseQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.PurchaseValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.SaleQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.SaleValue).HasDefaultValueSql("((0))");

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

                entity.HasOne(d => d.CodeTypeNavigation)
                    .WithMany(p => p.MaItemTypeBudget)
                    .HasForeignKey(d => d.CodeType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemTypeBudget_00");
            });
            modelBuilder.Entity<MaItemTypeCustomers>(entity =>
{
                entity.HasKey(e => new { e.ItemType, e.Customer })
                    .HasName("PK_ItemTypeCustomers")
                    .IsClustered(false);

                entity.ToTable("MA_ItemTypeCustomers");

                entity.Property(e => e.ItemType)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Customer)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Discount1).HasDefaultValueSql("((0))");

                entity.Property(e => e.Discount2).HasDefaultValueSql("((0))");

                entity.Property(e => e.DiscountFormula)
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
            modelBuilder.Entity<MaItemTypeCustomersBudget>(entity =>
{
                entity.HasKey(e => new { e.ItemType, e.Customer, e.BudgetYear, e.BudgetMonth, e.FiscalYear })
                    .HasName("PK_ItemTypeCustomersBudget")
                    .IsClustered(false);

                entity.ToTable("MA_ItemTypeCustomersBudget");

                entity.Property(e => e.ItemType)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Customer)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.SaleQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.SaleValue).HasDefaultValueSql("((0))");

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

                entity.HasOne(d => d.MaItemTypeCustomers)
                    .WithMany(p => p.MaItemTypeCustomersBudget)
                    .HasForeignKey(d => new { d.ItemType, d.Customer })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemTypeCustomersBudget_00");
            });
            modelBuilder.Entity<MaItemTypeSuppliers>(entity =>
{
                entity.HasKey(e => new { e.ItemType, e.Supplier })
                    .HasName("PK_ItemTypeSuppliers")
                    .IsClustered(false);

                entity.ToTable("MA_ItemTypeSuppliers");

                entity.Property(e => e.ItemType)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Supplier)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Discount1).HasDefaultValueSql("((0))");

                entity.Property(e => e.Discount2).HasDefaultValueSql("((0))");

                entity.Property(e => e.DiscountFormula)
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
            modelBuilder.Entity<MaItemTypes>(entity =>
{
                entity.HasKey(e => e.CodeType)
                    .HasName("PK_ItemTypes")
                    .IsClustered(false);

                entity.ToTable("MA_ItemTypes");

                entity.HasIndex(e => e.Description)
                    .HasName("MA_ItemTypes2");

                entity.Property(e => e.CodeType)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Discount1).HasDefaultValueSql("((0))");

                entity.Property(e => e.Discount2).HasDefaultValueSql("((0))");

                entity.Property(e => e.DiscountFormula)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ForfaitOnReturns).HasDefaultValueSql("((0))");

                entity.Property(e => e.HasCustomers)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.HasSuppliers)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Notes)
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
            modelBuilder.Entity<MaItems>(entity =>
{
                entity.HasKey(e => e.Item)
                    .HasName("PK_Items")
                    .IsClustered(false);

                entity.ToTable("MA_Items");

                entity.HasIndex(e => new { e.Disabled, e.Item })
                    .HasName("IX_MA_Items_3");

                entity.HasIndex(e => new { e.IsGood, e.Item })
                    .HasName("IX_MA_Items_2");

                entity.HasIndex(e => new { e.Item, e.IsGood })
                    .HasName("IX_MA_Items_1");

                entity.HasIndex(e => new { e.SaleBarCode, e.Item })
                    .HasName("IX_MA_Items_4");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.AdditionalCharge)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Allcadenza)
                    .HasColumnName("ALLCadenza")
                    .HasDefaultValueSql("((2009399296))");

                entity.Property(e => e.AllesplodiInOrdine)
                    .HasColumnName("ALLEsplodiInOrdine")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.AllisCanone)
                    .HasColumnName("ALLIsCanone")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Allperiodo)
                    .HasColumnName("ALLPeriodo")
                    .HasDefaultValueSql("((1094254592))");

                entity.Property(e => e.AuthorCode)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AvailabilityDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.BarcodeSegment)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BasePrice).HasDefaultValueSql("((0))");

                entity.Property(e => e.BasePriceWithTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.BaseUoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CanBeDisabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CommissionCtg)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CommodityCtg)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ConsuptionOffset)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CostCenter)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CoverPrice).HasDefaultValueSql("((0))");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Description)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DescriptionText)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

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

                entity.Property(e => e.Draft)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.EiadminstrativeRef)
                    .HasColumnName("EIAdminstrativeRef")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EitypeCode)
                    .HasColumnName("EITypeCode")
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EivalueCode)
                    .HasColumnName("EIValueCode")
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.HasCustomers)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.HasSuppliers)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.HomogeneousCtg)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ImGroupCode)
                    .HasColumnName("IM_GroupCode")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ImMacroGroupCode)
                    .HasColumnName("IM_MacroGroupCode")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ImPappAskValue)
                    .HasColumnName("IM_PAppAskValue")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ImPappDontShow)
                    .HasColumnName("IM_PAppDontShow")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ImSubGroupCode)
                    .HasColumnName("IM_SubGroupCode")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ImSubcontractService)
                    .HasColumnName("IM_SubcontractService")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InternalNote)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IsGood)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Isbn)
                    .HasColumnName("ISBN")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ItemCodes)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ItemType)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Job)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.KitExpansion)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Markup).HasDefaultValueSql("((0))");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Nature).HasDefaultValueSql("((22413314))");

                entity.Property(e => e.NoAddDiscountInSaleDoc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NoUoMsearch)
                    .HasColumnName("NoUoMSearch")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NotPostable)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.OldItem)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Picture)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PostKitComponents)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Producer)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProductCtg)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProductLine)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProductSubCtg)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PublicNote)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PurchaseOffset)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PurchaseType).HasDefaultValueSql("((3670020))");

                entity.Property(e => e.RctaxCode)
                    .HasColumnName("RCTaxCode")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RetailCtg)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReverseCharge)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SaleBarCode)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SaleOffset)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SaleType).HasDefaultValueSql("((3670020))");

                entity.Property(e => e.SalespersonComm).HasDefaultValueSql("((0))");

                entity.Property(e => e.SecondRate)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SecondRateUoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ShortDescription)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StandardCostDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.SubjectToWithholdingTax)
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

                entity.Property(e => e.TschargeType)
                    .HasColumnName("TSChargeType")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TschargeTypeFlag)
                    .HasColumnName("TSChargeTypeFlag")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UseSerialNo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Valorize)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                /*
                    entity.HasOne(d => d.AllordCliContratto)
                    .WithOne(p => p.MaItems)
                    .HasForeignKey<AllordCliContratto>(d => d.Servizio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AllordCliContratto_Servizio_00");
                */
            });
            modelBuilder.Entity<MaItemsComparableUoM>(entity =>
{
                entity.HasKey(e => new { e.Item, e.ComparableUoM })
                    .HasName("PK_ItemsComparableUoM")
                    .IsClustered(false);

                entity.ToTable("MA_ItemsComparableUoM");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.ComparableUoM)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.BaseUoMqty)
                    .HasColumnName("BaseUoMQty")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CompUoMqty)
                    .HasColumnName("CompUoMQty")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Factor1).HasDefaultValueSql("((1))");

                entity.Property(e => e.Factor1Description)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Factor2).HasDefaultValueSql("((1))");

                entity.Property(e => e.Factor2Description)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Factor3).HasDefaultValueSql("((1))");

                entity.Property(e => e.Factor3Description)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Factor4).HasDefaultValueSql("((1))");

                entity.Property(e => e.Factor4Description)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GrossVolume).HasDefaultValueSql("((0))");

                entity.Property(e => e.GrossWeight).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsDisabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NoOfPacksCompUoM).HasDefaultValueSql("((0))");

                entity.Property(e => e.Notes)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Packaging)
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

                entity.HasOne(d => d.ItemNavigation)
                    .WithMany(p => p.MaItemsComparableUoM)
                    .HasForeignKey(d => d.Item)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemsCompa_Items_00");
            });
            modelBuilder.Entity<MaItemsGoodsData>(entity =>
{
                entity.HasKey(e => e.Item)
                    .HasName("PK_ItemsGoodsData")
                    .IsClustered(false);

                entity.ToTable("MA_ItemsGoodsData");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Appearance)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DefaultLocation)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Department)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GrossVolume).HasDefaultValueSql("((0))");

                entity.Property(e => e.GrossWeight).HasDefaultValueSql("((0))");

                entity.Property(e => e.ImWeeeamount)
                    .HasColumnName("IM_WEEEAmount")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.InsertAnalParam)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IssueUoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastIssueDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.LastReceiptDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.LastSupplier)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Location)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LotPreexpiringDays).HasDefaultValueSql("((0))");

                entity.Property(e => e.LotValidityDays).HasDefaultValueSql("((0))");

                entity.Property(e => e.ManageSample)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.MaxUnsoldMonths).HasDefaultValueSql("((0))");

                entity.Property(e => e.MaximumStock).HasDefaultValueSql("((0))");

                entity.Property(e => e.MinimumSaleQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.MinimumStock).HasDefaultValueSql("((0))");

                entity.Property(e => e.NetWeight).HasDefaultValueSql("((0))");

                entity.Property(e => e.NoAbc)
                    .HasColumnName("NoABC")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NoOfPacks).HasDefaultValueSql("((0))");

                entity.Property(e => e.OnInventoryLevel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.OnInventorySheets)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PacksIssueUoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PacksReceiptUoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PercSample).HasDefaultValueSql("((100))");

                entity.Property(e => e.PostToInspection)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ReceiptUoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReorderingLotSize).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReportUoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SampleQty).HasDefaultValueSql("((0))");

               // entity.Property(e => e.SpecificationsForSupplier)
               //     .HasColumnType("ntext")
               //     .HasDefaultValueSql("('')");

                entity.Property(e => e.Supplier)
                    .HasMaxLength(12)
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

                entity.Property(e => e.TraceabilityCritical)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseLots)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseSupplierLotAsNewLotNumber).HasDefaultValueSql("((28311552))");

                entity.Property(e => e.Weeeamount)
                    .HasColumnName("WEEEAmount")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Weeeamount2)
                    .HasColumnName("WEEEAmount2")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Weeectg)
                    .HasColumnName("WEEECtg")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Weeectg2)
                    .HasColumnName("WEEECtg2")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.ItemNavigation)
                    .WithOne(p => p.MaItemsGoodsData)
                    .HasForeignKey<MaItemsGoodsData>(d => d.Item)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemsGoods_Items_00");
            });
            modelBuilder.Entity<MaItemsIntrastat>(entity =>
{
                entity.HasKey(e => e.Item)
                    .HasName("PK_ItemsIntrastat")
                    .IsClustered(false);

                entity.ToTable("MA_ItemsIntrastat");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.CombinedNomenclature)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CountyOfOrigin)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Cpacode)
                    .HasColumnName("CPACode")
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IntrastatSupplyType).HasDefaultValueSql("((589824))");

                entity.Property(e => e.IsoofOrigin)
                    .HasColumnName("ISOOfOrigin")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Prodcom)
                    .HasColumnName("PRODCOM")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SpecWeightNetMass).HasDefaultValueSql("((0))");

                entity.Property(e => e.SuppUnitDescription)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SuppUnitSpecWeight).HasDefaultValueSql("((0))");

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

                entity.HasOne(d => d.ItemNavigation)
                    .WithOne(p => p.MaItemsIntrastat)
                    .HasForeignKey<MaItemsIntrastat>(d => d.Item)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemsIntra_ItemsIntra_00");
            });
            modelBuilder.Entity<MaItemsKit>(entity =>
{
                entity.HasKey(e => new { e.Item, e.Line })
                    .HasName("PK_ItemsKit")
                    .IsClustered(false);

                entity.ToTable("MA_ItemsKit");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.BasePrice).HasDefaultValueSql("((0))");

                entity.Property(e => e.Component)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Discount1).HasDefaultValueSql("((0))");

                entity.Property(e => e.Discount2).HasDefaultValueSql("((0))");

                entity.Property(e => e.DiscountFormula)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IssuedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.NoPrint)
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

                entity.Property(e => e.Variant)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.ItemNavigation)
                    .WithMany(p => p.MaItemsKit)
                    .HasForeignKey(d => d.Item)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemsKit_Items_00");
            });
            modelBuilder.Entity<MaItemsManufacturingData>(entity =>
{
                entity.HasKey(e => e.Item)
                    .HasName("PK_ItemsManufacturingData")
                    .IsClustered(false);

                entity.ToTable("MA_ItemsManufacturingData");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.AnticipationDays).HasDefaultValueSql("((0))");

                entity.Property(e => e.Bomcost)
                    .HasColumnName("BOMCost")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ConfirmIntegratePl)
                    .HasColumnName("ConfirmIntegratePL")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ConfirmMajorPicking)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ConfirmMinorPicking)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ConfirmReturnMaterial)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.EconomicOrderQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ExtraordinaryMaintenance)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Factory)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InhouseProcessingCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsKanban)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IsTool)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ItemManQtyDigit).HasDefaultValueSql("((0))");

                entity.Property(e => e.ItemManQtyRounding).HasDefaultValueSql("((786432))");

                entity.Property(e => e.ItemManufStorage)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ItemPickAlsoShortages)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.KanbanCardSize).HasDefaultValueSql("((0))");

                entity.Property(e => e.KanbanCardsNum).HasDefaultValueSql("((0))");

                entity.Property(e => e.KanbanCardsToReorder).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastProductionCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.LeadTime).HasDefaultValueSql("((0))");

                entity.Property(e => e.LoadingCriterionValuation).HasDefaultValueSql("((20643840))");

                entity.Property(e => e.LotGenerationMoment).HasDefaultValueSql("((25821186))");

                entity.Property(e => e.MakeOrBuy)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.MakeOrBuyType).HasDefaultValueSql("((2032140288))");

                entity.Property(e => e.Maker)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MaxProductionQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.MinProductionQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.Model)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MrpconfirmationRank)
                    .HasColumnName("MRPConfirmationRank")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Mrppolicy)
                    .HasColumnName("MRPPolicy")
                    .HasDefaultValueSql("((22609920))");

                entity.Property(e => e.MultipleLots)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.MultipleRoundQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.NetByJobMopurchOrd)
                    .HasColumnName("NetByJobMOPurchOrd")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NetByMoconfirmed)
                    .HasColumnName("NetByMOConfirmed")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NetByMoemptyJob)
                    .HasColumnName("NetByMOEmptyJob")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NoMrp)
                    .HasColumnName("NoMRP")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OrderReleaseDays).HasDefaultValueSql("((0))");

                entity.Property(e => e.OrdinaryMaintenance)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OutsourcedProcessingCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProductionCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProductionCostLastChange)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.ProductionCostMono)
                    .HasColumnName("ProductionCostMONo")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProductionLot).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProportionalLeadTime)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ReferenceLot).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReorderPoint).HasDefaultValueSql("((0))");

                entity.Property(e => e.Rmcost)
                    .HasColumnName("RMCost")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.RoundQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.SamplesQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ScrapPerc).HasDefaultValueSql("((0))");

                entity.Property(e => e.ScrapQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.SetupCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.StockLevelHorizon).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.TimeRoundingType).HasDefaultValueSql("((22544384))");

                entity.Property(e => e.UseItemManufParameters)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.VariantCost).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.ItemNavigation)
                    .WithOne(p => p.MaItemsManufacturingData)
                    .HasForeignKey<MaItemsManufacturingData>(d => d.Item)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemsManuf_Items_00");
            });
            modelBuilder.Entity<MaItemsPurchaseBarCode>(entity =>
{
                entity.HasKey(e => new { e.Item, e.BarCode })
                    .HasName("PK_ItemsPurchaseBarCode")
                    .IsClustered(false);

                entity.ToTable("MA_ItemsPurchaseBarCode");

                entity.HasIndex(e => e.BarCode)
                    .HasName("IX_MA_ItemsPurchaseBarCode_");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.BarCode)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.BarCodeType).HasDefaultValueSql("((5636117))");

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

                entity.Property(e => e.UoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.ItemNavigation)
                    .WithMany(p => p.MaItemsPurchaseBarCode)
                    .HasForeignKey(d => d.Item)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemsPurch_Items_00");
            });
            modelBuilder.Entity<MaItemsSubstitute>(entity =>
{
                entity.HasKey(e => new { e.Item, e.Substitute })
                    .HasName("PK_ItemsSubstitute")
                    .IsClustered(false);

                entity.ToTable("MA_ItemsSubstitute");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Substitute)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.ItemQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.Notes)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SubstituteQty).HasDefaultValueSql("((0))");

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

                entity.HasOne(d => d.ItemNavigation)
                    .WithMany(p => p.MaItemsSubstitute)
                    .HasForeignKey(d => d.Item)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemsSubst_Items_00");
            });
            modelBuilder.Entity<MaProducers>(entity =>
{
                entity.HasKey(e => e.Producer)
                    .HasName("PK_Producers")
                    .IsClustered(false);

                entity.ToTable("MA_Producers");

                entity.HasIndex(e => e.CompanyName)
                    .HasName("MA_Producers2");

                entity.Property(e => e.Producer)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Address2)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.City)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ContactPerson)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Country)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.County)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Disabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.District)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Email)
                    .HasColumnName("EMail")
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Fax)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FederalState)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Internet)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IsocountryCode)
                    .HasColumnName("ISOCountryCode")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StreetNo)
                    .HasMaxLength(10)
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

                entity.Property(e => e.Telephone1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Telephone2)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.WorkingTime)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Zipcode)
                    .HasColumnName("ZIPCode")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
            modelBuilder.Entity<MaProducersCategories>(entity =>
{
                entity.HasKey(e => new { e.Producer, e.Category })
                    .HasName("PK_ProducersCategories")
                    .IsClustered(false);

                entity.ToTable("MA_ProducersCategories");

                entity.HasIndex(e => new { e.Category, e.Producer })
                    .HasName("MA_ProducersCategories2");

                entity.Property(e => e.Producer)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Category)
                    .HasMaxLength(8)
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

                entity.HasOne(d => d.ProducerNavigation)
                    .WithMany(p => p.MaProducersCategories)
                    .HasForeignKey(d => d.Producer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProducersC_Producers_00");
            });
            modelBuilder.Entity<MaProductCtg>(entity =>
{
                entity.HasKey(e => e.Category)
                    .HasName("PK_ProductCtg")
                    .IsClustered(false);

                entity.ToTable("MA_ProductCtg");

                entity.HasIndex(e => e.Description)
                    .HasName("MA_ProductCtg2");

                entity.Property(e => e.Category)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.CodeType).HasDefaultValueSql("((7077888))");

                entity.Property(e => e.Description)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Notes)
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
            modelBuilder.Entity<MaProductCtgSubCtg>(entity =>
{
                entity.HasKey(e => new { e.Category, e.SubCategory })
                    .HasName("PK_ProductCtgSubCtg")
                    .IsClustered(false);

                entity.ToTable("MA_ProductCtgSubCtg");

                entity.HasIndex(e => new { e.SubCategory, e.Category })
                    .HasName("MA_ProductCtgSubCtg2");

                entity.Property(e => e.Category)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.SubCategory)
                    .HasMaxLength(8)
                    .IsUnicode(false);

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

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.MaProductCtgSubCtg)
                    .HasForeignKey(d => d.Category)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductCtg_ProductCtg_00");
            });
            modelBuilder.Entity<MaProductSubCtgDefaults>(entity =>
{
                entity.HasKey(e => new { e.IdDefaultProductSubCtg, e.SubCategory })
                    .HasName("PK_ProductSubCtgDefaults")
                    .IsClustered(false);

                entity.ToTable("MA_ProductSubCtgDefaults");

                entity.Property(e => e.SubCategory)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
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
            modelBuilder.Entity<MaUnitOfMeasureDetail>(entity =>
{
                entity.HasKey(e => new { e.BaseUoM, e.ComparableUoM })
                    .HasName("PK_UnitOfMeasureDetail")
                    .IsClustered(false);

                entity.ToTable("MA_UnitOfMeasureDetail");

                entity.Property(e => e.BaseUoM)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.ComparableUoM)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.BaseUoMqty)
                    .HasColumnName("BaseUoMQty")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CompUoMqty)
                    .HasColumnName("CompUoMQty")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Factor1).HasDefaultValueSql("((1))");

                entity.Property(e => e.Factor1Description)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Factor2).HasDefaultValueSql("((1))");

                entity.Property(e => e.Factor2Description)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Factor3).HasDefaultValueSql("((1))");

                entity.Property(e => e.Factor3Description)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Factor4).HasDefaultValueSql("((1))");

                entity.Property(e => e.Factor4Description)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GrossVolume).HasDefaultValueSql("((0))");

                entity.Property(e => e.GrossWeight).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsDisabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NoOfPacksCompUoM).HasDefaultValueSql("((0))");

                entity.Property(e => e.Notes)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Packaging)
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

                entity.HasOne(d => d.BaseUoMNavigation)
                    .WithMany(p => p.MaUnitOfMeasureDetail)
                    .HasForeignKey(d => d.BaseUoM)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UnitOfMeas_UnitsOfMea_00");
            });
            modelBuilder.Entity<MaUnitsOfMeasure>(entity =>
{
                entity.HasKey(e => e.BaseUoM)
                    .HasName("PK_UnitsOfMeasure")
                    .IsClustered(false);

                entity.ToTable("MA_UnitsOfMeasure");

                entity.Property(e => e.BaseUoM)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.BarcodeSegment)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Description)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Symbol)
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

                entity.Property(e => e.UoMforEi)
                    .HasColumnName("UoMForEI")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
        }
    }
}
