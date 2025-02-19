using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class MultiStorageDbContext : DbContext
    {
        public MultiStorageDbContext()
        {
        }
        public MultiStorageDbContext(DbContextOptions<MultiStorageDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaItemsStorageQty> MaItemsStorageQty { get; set; }
        public virtual DbSet<MaItemsStorageQtyMonthly> MaItemsStorageQtyMonthly { get; set; }
        public virtual DbSet<MaMultiStorageParameters> MaMultiStorageParameters { get; set; }
        public virtual DbSet<MaStorageGroups> MaStorageGroups { get; set; }
        public virtual DbSet<MaStorages> MaStorages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaItemsStorageQty>(entity =>
{
                entity.HasKey(e => new { e.FiscalYear, e.FiscalPeriod, e.Item, e.Storage, e.Specificator, e.SpecificatorType })
                    .HasName("PK_ItemsStorageQty")
                    .IsClustered(false);

                entity.ToTable("MA_ItemsStorageQty");

                entity.HasIndex(e => new { e.FiscalYear, e.FiscalPeriod, e.Storage, e.Item })
                    .HasName("IX_MA_ItemsStorageQty_1");

                entity.HasIndex(e => new { e.FiscalYear, e.FiscalPeriod, e.Storage, e.SpecificatorType, e.Specificator, e.Item })
                    .HasName("IX_MA_ItemsStorageQty_2");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Storage)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Specificator)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.AllocatedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ApprovedPurchaseReq).HasDefaultValueSql("((0))");

                entity.Property(e => e.DefaultLocation)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InitialQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.IssuedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.MathematicRounding)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.MaximumStock).HasDefaultValueSql("((0))");

                entity.Property(e => e.MinimumStock).HasDefaultValueSql("((0))");

                entity.Property(e => e.OrderedPurchOrd).HasDefaultValueSql("((0))");

                entity.Property(e => e.OrderedToProd).HasDefaultValueSql("((0))");

                entity.Property(e => e.PickedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReceivedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReorderingLotSize).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReservedByProd).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReservedSaleOrd).HasDefaultValueSql("((0))");

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
                    .WithMany(p => p.MaItemsStorageQty)
                    .HasForeignKey(d => d.Item)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemsStora_Items_00");
            });
            modelBuilder.Entity<MaItemsStorageQtyMonthly>(entity =>
{
                entity.HasKey(e => new { e.Storage, e.Specificator, e.SpecificatorType, e.Item, e.FiscalYear, e.BalanceYear, e.Balance, e.BalanceMonth })
                    .HasName("PK_ItemsStorageMonthly")
                    .IsClustered(false);

                entity.ToTable("MA_ItemsStorageQtyMonthly");

                entity.HasIndex(e => new { e.FiscalYear, e.Storage, e.Item })
                    .HasName("IX_MA_ItemsStorageMonthly_1");

                entity.HasIndex(e => new { e.FiscalYear, e.Storage, e.SpecificatorType, e.Specificator, e.Item })
                    .HasName("IX_MA_ItemsStorageMonthly_2");

                entity.Property(e => e.Storage)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Specificator)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovedPurchaseReq).HasDefaultValueSql("((0))");

                entity.Property(e => e.IssuedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.OrderedPurchOrd).HasDefaultValueSql("((0))");

                entity.Property(e => e.OrderedToProd).HasDefaultValueSql("((0))");

                entity.Property(e => e.PickedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReceivedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReservedByProd).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReservedSaleOrd).HasDefaultValueSql("((0))");

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
                    .WithMany(p => p.MaItemsStorageQtyMonthly)
                    .HasForeignKey(d => d.Item)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemsStoraMonth_Items_00");
            });
            modelBuilder.Entity<MaMultiStorageParameters>(entity =>
{
                entity.HasKey(e => e.MultiStorageParametersId)
                    .HasName("PK_MultiStorageParameters")
                    .IsClustered(false);

                entity.ToTable("MA_MultiStorageParameters");

                entity.Property(e => e.MultiStorageParametersId).ValueGeneratedNever();

                entity.Property(e => e.AllocationByStorage)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InventoryScarcityCheckType).HasDefaultValueSql("((25100288))");

                entity.Property(e => e.InventoryShortageCheckType).HasDefaultValueSql("((25100288))");

                entity.Property(e => e.InventoryWarningMaximumStock)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PurcOrdWarningMaximumStock)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PurchaseWarningMaximumStock)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SalesOrdersShortageCheckType).HasDefaultValueSql("((25100288))");

                entity.Property(e => e.SalesScarcityCheckType).HasDefaultValueSql("((25100288))");

                entity.Property(e => e.SalesShortageCheckType).HasDefaultValueSql("((25100288))");

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

                entity.Property(e => e.UseReservedByStorage)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");
            });
            modelBuilder.Entity<MaStorageGroups>(entity =>
{
                entity.HasKey(e => e.GroupCode)
                    .HasName("PK_StorageGroups")
                    .IsClustered(false);

                entity.ToTable("MA_StorageGroups");

                entity.HasIndex(e => e.Description)
                    .HasName("MA_StorageGroups2");

                entity.Property(e => e.GroupCode)
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
            modelBuilder.Entity<MaStorages>(entity =>
{
                entity.HasKey(e => e.Storage)
                    .HasName("PK_Storages")
                    .IsClustered(false);

                entity.ToTable("MA_Storages");

                entity.HasIndex(e => e.Description)
                    .HasName("MA_Storages2");

                entity.Property(e => e.Storage)
                    .HasMaxLength(8)
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

                entity.Property(e => e.CodeType).HasDefaultValueSql("((3342336))");

                entity.Property(e => e.ConsignmentStock)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Country)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.County)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CrossDocking)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CrossDockingZone)
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

                entity.Property(e => e.District)
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

                entity.Property(e => e.GoodsIssueZone)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GoodsReceiptZone)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GroupCode)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InspectionZone)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InventoryScarcityCheckType).HasDefaultValueSql("((25100288))");

                entity.Property(e => e.InventoryShortageCheckType).HasDefaultValueSql("((25100288))");

                entity.Property(e => e.IsocountryCode)
                    .HasColumnName("ISOCountryCode")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastSnapshotCertifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.ManTwoStepsPutaway)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.ManufacturingIssuePickZone)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ManufacturingIssueZone)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ManufacturingReceiptZone)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OwnedGoods)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Priority).HasDefaultValueSql("((99))");

                entity.Property(e => e.ReturnZone)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SalesOrdersShortageCheckType).HasDefaultValueSql("((25100288))");

                entity.Property(e => e.SalesScarcityCheckType).HasDefaultValueSql("((25100288))");

                entity.Property(e => e.SalesShortageCheckType).HasDefaultValueSql("((25100288))");

                entity.Property(e => e.ScrapZone)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SearchZoneStrategyPicking)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SearchZoneStrategyPutaway)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SpecTypeReplenishment).HasDefaultValueSql("((6750211))");

                entity.Property(e => e.SpecificatorReplenishment)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StockReturnStrategy).HasDefaultValueSql("('26607618')");

                entity.Property(e => e.StorageBarcodePrefix)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StorageReplenishment)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StreetNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StubBookAdjustment)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StubBookInterStorageIn)
                    .HasColumnName("StubBookInterStorageIN")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StubBookInterStorageOut)
                    .HasColumnName("StubBookInterStorageOUT")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StubBookPurchases)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StubBookSales)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxJournalPurchases)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxJournalSales)
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

                entity.Property(e => e.Telephone1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Telephone2)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TwoStepsPutaway)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.UseLocation)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UsedByMrp)
                    .HasColumnName("UsedByMRP")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UsedByProduction)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UsedForRetail)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Wms)
                    .HasColumnName("WMS")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.WmsactivationDate)
                    .HasColumnName("WMSActivationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.WmsmanActivationDate)
                    .HasColumnName("WMSManActivationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Zipcode)
                    .HasColumnName("ZIPCode")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
        }
    }
}
