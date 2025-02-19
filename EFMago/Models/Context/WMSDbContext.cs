using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class WMSDbContext : DbContext
    {
        public WMSDbContext()
        {
        }
        public WMSDbContext(DbContextOptions<WMSDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaIdnumber> MaIdnumber { get; set; }
        public virtual DbSet<MaItemsWms> MaItemsWms { get; set; }
        public virtual DbSet<MaItemsWmszones> MaItemsWmszones { get; set; }
        public virtual DbSet<MaWmbin> MaWmbin { get; set; }
        public virtual DbSet<MaWmbinStocks> MaWmbinStocks { get; set; }
        public virtual DbSet<MaWmbinStocksSu> MaWmbinStocksSu { get; set; }
        public virtual DbSet<MaWmbinStruct> MaWmbinStruct { get; set; }
        public virtual DbSet<MaWmbinStructDetail> MaWmbinStructDetail { get; set; }
        public virtual DbSet<MaWmbinType> MaWmbinType { get; set; }
        public virtual DbSet<MaWmbinTypeSut> MaWmbinTypeSut { get; set; }
        public virtual DbSet<MaWmcategory> MaWmcategory { get; set; }
        public virtual DbSet<MaWmcategoryCrossSut> MaWmcategoryCrossSut { get; set; }
        public virtual DbSet<MaWmcategoryDetails> MaWmcategoryDetails { get; set; }
        public virtual DbSet<MaWmcrossDocking> MaWmcrossDocking { get; set; }
        public virtual DbSet<MaWmdefaultCodes> MaWmdefaultCodes { get; set; }
        public virtual DbSet<MaWmgoodsReceipt> MaWmgoodsReceipt { get; set; }
        public virtual DbSet<MaWmgoodsReceiptCrossRef> MaWmgoodsReceiptCrossRef { get; set; }
        public virtual DbSet<MaWmgoodsReceiptDetail> MaWmgoodsReceiptDetail { get; set; }
        public virtual DbSet<MaWminventory> MaWminventory { get; set; }
        public virtual DbSet<MaWminventoryDetail> MaWminventoryDetail { get; set; }
        public virtual DbSet<MaWmparameters> MaWmparameters { get; set; }
        public virtual DbSet<MaWmpreShipping> MaWmpreShipping { get; set; }
        public virtual DbSet<MaWmpreShippingComponents> MaWmpreShippingComponents { get; set; }
        public virtual DbSet<MaWmpreShippingDetails> MaWmpreShippingDetails { get; set; }
        public virtual DbSet<MaWmpreShippingDetailsByLot> MaWmpreShippingDetailsByLot { get; set; }
        public virtual DbSet<MaWmpreShippingPack> MaWmpreShippingPack { get; set; }
        public virtual DbSet<MaWmpreShippingPackLev> MaWmpreShippingPackLev { get; set; }
        public virtual DbSet<MaWmreason> MaWmreason { get; set; }
        public virtual DbSet<MaWmsearchZoneStrategy> MaWmsearchZoneStrategy { get; set; }
        public virtual DbSet<MaWmsearchZoneStrategyDet> MaWmsearchZoneStrategyDet { get; set; }
        public virtual DbSet<MaWmsection> MaWmsection { get; set; }
        public virtual DbSet<MaWmsectionCategory> MaWmsectionCategory { get; set; }
        public virtual DbSet<MaWmsectionDetail> MaWmsectionDetail { get; set; }
        public virtual DbSet<MaWmstorageUnit> MaWmstorageUnit { get; set; }
        public virtual DbSet<MaWmstorageUnitNumbers> MaWmstorageUnitNumbers { get; set; }
        public virtual DbSet<MaWmstorageUnitType> MaWmstorageUnitType { get; set; }
        public virtual DbSet<MaWmsutpackaging> MaWmsutpackaging { get; set; }
        public virtual DbSet<MaWmtransferOrder> MaWmtransferOrder { get; set; }
        public virtual DbSet<MaWmtransferOrderDetails> MaWmtransferOrderDetails { get; set; }
        public virtual DbSet<MaWmzone> MaWmzone { get; set; }
        public virtual DbSet<MaWmzoneResources> MaWmzoneResources { get; set; }
        public virtual DbSet<MaWmzoneSection> MaWmzoneSection { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaIdnumber>(entity =>
{
                entity.HasKey(e => e.InternalIdNo);

                entity.ToTable("MA_IDNumber");

                entity.HasIndex(e => e.BarcodeSegment)
                    .HasName("IX_MA_IDNumber_1");

                entity.Property(e => e.InternalIdNo)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.BarcodeSegment)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExternalIdNo)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Lot)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OutOfStock)
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
            modelBuilder.Entity<MaItemsWms>(entity =>
{
                entity.HasKey(e => e.Item)
                    .IsClustered(false);

                entity.ToTable("MA_ItemsWMS");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Category)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CategoryForPutaway)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ConsignmentPartner)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CrossDocking)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.HazardousMaterial)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PrintBarcodeInGr)
                    .HasColumnName("PrintBarcodeInGR")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ScanItemInPicking)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ScanItemInPutaway)
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

                entity.Property(e => e.Tbmodified)
                    .HasColumnName("TBModified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbmodifiedId).HasColumnName("TBModifiedID");

                entity.Property(e => e.UsedInWmsmobile)
                    .HasColumnName("UsedInWMSMobile")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");
            });
            modelBuilder.Entity<MaItemsWmszones>(entity =>
{
                entity.HasKey(e => new { e.Item, e.Storage, e.Zone })
                    .IsClustered(false);

                entity.ToTable("MA_ItemsWMSZones");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Storage)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Zone)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.AutoReplenishment)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FixedBinPicking)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FixedBinPutaway)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MaxStock).HasDefaultValueSql("((0))");

                entity.Property(e => e.MinStock).HasDefaultValueSql("((0))");

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
                    .WithMany(p => p.MaItemsWmszones)
                    .HasForeignKey(d => d.Item)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MA_ItemsWMSZones_MA_Items");
            });
            modelBuilder.Entity<MaWmbin>(entity =>
{
                entity.HasKey(e => new { e.Bin, e.Storage, e.Zone });

                entity.ToTable("MA_WMBin");

                entity.HasIndex(e => e.BinType)
                    .HasName("MA_WMBin2");

                entity.Property(e => e.Bin)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Storage)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Zone)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Barcode)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BarcodeSegment)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BinType)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BlockDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.BlockReason)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BlockType).HasDefaultValueSql("((27590656))");

                entity.Property(e => e.BlockWorker).HasDefaultValueSql("((0))");

                entity.Property(e => e.Blocked)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Disabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ForPicking)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.ForPutaway)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.IsEmpty)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.IsFull)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.LastEmptying)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.LastEntry)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.LastInventory)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.MaxStorageUnit).HasDefaultValueSql("((0))");

                entity.Property(e => e.MaxWeight).HasDefaultValueSql("((0))");

                entity.Property(e => e.NumOfSu)
                    .HasColumnName("NumOfSU")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PathSequence).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReservedCapacity).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReservedNumOfSu)
                    .HasColumnName("ReservedNumOfSU")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ReservedWeight).HasDefaultValueSql("((0))");

                entity.Property(e => e.Section)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Suspect)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SuspectDate)
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

                entity.Property(e => e.TotalCapacity).HasDefaultValueSql("((0))");

                entity.Property(e => e.UsedCapacity).HasDefaultValueSql("((0))");

                entity.Property(e => e.UsedWeight).HasDefaultValueSql("((0))");
            });
            modelBuilder.Entity<MaWmbinStocks>(entity =>
{
                entity.HasKey(e => new { e.Bin, e.Storage, e.Zone, e.StockNumber })
                    .HasName("PK_MA_WMBinStock");

                entity.ToTable("MA_WMBinStocks");

                entity.HasIndex(e => new { e.SnapshotToid, e.SnapshotDate })
                    .HasName("MA_WMBinStocks2");

                entity.HasIndex(e => new { e.Bin, e.Storage, e.Zone, e.Item, e.Lot, e.InternalIdNo })
                    .HasName("IX_MA_WMBinStocks");

                entity.Property(e => e.Bin)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Storage)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Zone)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Capacity).HasDefaultValueSql("((0))");

                entity.Property(e => e.ConsignmentPartner)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.InternalIdNo)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IsMultilevelStorageUnit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Lot)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LotValidTo)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Qty).HasDefaultValueSql("((0))");

                entity.Property(e => e.QtyBaseUoM).HasDefaultValueSql("((0))");

                entity.Property(e => e.QtyIncoming).HasDefaultValueSql("((0))");

                entity.Property(e => e.QtyReserved).HasDefaultValueSql("((0))");

                entity.Property(e => e.Snapshot)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SnapshotCert)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SnapshotDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.SnapshotToid)
                    .HasColumnName("SnapshotTOId")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SnapshotWorker).HasDefaultValueSql("((0))");

                entity.Property(e => e.SpecialStock).HasDefaultValueSql("((26869760))");

                entity.Property(e => e.SpecialStockCode)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StorageUnit)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StorageUnitType)
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

                entity.Property(e => e.UnitOfMeasure)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Weight).HasDefaultValueSql("((0))");
            });
            modelBuilder.Entity<MaWmbinStocksSu>(entity =>
{
                entity.HasKey(e => new { e.StockNumber, e.Sunumber })
                    .HasName("PK_MA_WMBinStSU");

                entity.ToTable("MA_WMBinStocksSU");

                entity.HasIndex(e => new { e.SnapshotToid, e.SnapshotDate })
                    .HasName("MA_WMBinStocksSU2");

                entity.Property(e => e.Sunumber)
                    .HasColumnName("SUNumber")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Snapshot)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.SnapshotCert)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SnapshotDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.SnapshotToid)
                    .HasColumnName("SnapshotTOId")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SnapshotWorker).HasDefaultValueSql("((0))");

                entity.Property(e => e.Storage)
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
            });
            modelBuilder.Entity<MaWmbinStruct>(entity =>
{
                entity.HasKey(e => e.BinStructure);

                entity.ToTable("MA_WMBinStruct");

                entity.Property(e => e.BinStructure)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Separator)
                    .HasMaxLength(1)
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
            modelBuilder.Entity<MaWmbinStructDetail>(entity =>
{
                entity.HasKey(e => new { e.BinStructure, e.Position });

                entity.ToTable("MA_WMBinStructDetail");

                entity.Property(e => e.BinStructure)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Length).HasDefaultValueSql("((0))");

                entity.Property(e => e.SortSequence).HasDefaultValueSql("((0))");

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
            modelBuilder.Entity<MaWmbinType>(entity =>
{
                entity.HasKey(e => e.Code);

                entity.ToTable("MA_WMBinType");

                entity.Property(e => e.Code)
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

                entity.Property(e => e.LooseStock)
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
            modelBuilder.Entity<MaWmbinTypeSut>(entity =>
{
                entity.HasKey(e => new { e.BinTypeCode, e.Sutcode });

                entity.ToTable("MA_WMBinTypeSUT");

                entity.Property(e => e.BinTypeCode)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Sutcode)
                    .HasColumnName("SUTCode")
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

                entity.HasOne(d => d.BinTypeCodeNavigation)
                    .WithMany(p => p.MaWmbinTypeSut)
                    .HasForeignKey(d => d.BinTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MA_WMBinTypeSUT_WMBinType");

                entity.HasOne(d => d.SutcodeNavigation)
                    .WithMany(p => p.MaWmbinTypeSut)
                    .HasForeignKey(d => d.Sutcode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MA_WMBinTypeSUT_WMUnitType");
            });
            modelBuilder.Entity<MaWmcategory>(entity =>
{
                entity.HasKey(e => e.Category);

                entity.ToTable("MA_WMCategory");

                entity.Property(e => e.Category)
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
            });
            modelBuilder.Entity<MaWmcategoryCrossSut>(entity =>
{
                entity.HasKey(e => new { e.Category, e.Sut })
                    .IsClustered(false);

                entity.ToTable("MA_WMCategoryCrossSUT");

                entity.Property(e => e.Category)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Sut)
                    .HasColumnName("SUT")
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
            });
            modelBuilder.Entity<MaWmcategoryDetails>(entity =>
{
                entity.HasKey(e => new { e.Category, e.Storage })
                    .HasName("PK_WMCategoryDetails");

                entity.ToTable("MA_WMCategoryDetails");

                entity.Property(e => e.Category)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Storage)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.SearchZoneStrategyPicking)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SearchZoneStrategyPutaway)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StockReturnStrategy).HasDefaultValueSql("((26607618))");

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
            modelBuilder.Entity<MaWmcrossDocking>(entity =>
{
                entity.HasKey(e => new { e.Storage, e.Zone, e.CrossDockingNumber });

                entity.ToTable("MA_WMCrossDocking");

                entity.HasIndex(e => new { e.Storage, e.Zone, e.Item, e.Lot, e.SpecialStock, e.SpecialStockCode })
                    .HasName("MA_WMCrossDocking2");

                entity.Property(e => e.Storage)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Zone)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.ConsignmentPartner)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InternalIdNo)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Lot)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.QtyBaseUoM).HasDefaultValueSql("((0))");

                entity.Property(e => e.SpecialStock).HasDefaultValueSql("((26869760))");

                entity.Property(e => e.SpecialStockCode)
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
            });
            modelBuilder.Entity<MaWmdefaultCodes>(entity =>
{
                entity.HasKey(e => e.WmdefaultCodesId)
                    .HasName("PK_WMDefaultCodes")
                    .IsClustered(false);

                entity.ToTable("MA_WMDefaultCodes");

                entity.Property(e => e.WmdefaultCodesId)
                    .HasColumnName("WMDefaultCodesId")
                    .ValueGeneratedNever();

                entity.Property(e => e.GrconsConfInvRsn)
                    .HasColumnName("GRConsConfInvRsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GrconsInspInvRsn)
                    .HasColumnName("GRConsInspInvRsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GrconsRetInvRsn)
                    .HasColumnName("GRConsRetInvRsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GrconsScrapInvRsn)
                    .HasColumnName("GRConsScrapInvRsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GrdelConfInvRsn)
                    .HasColumnName("GRDelConfInvRsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GrdelInspInvRsn)
                    .HasColumnName("GRDelInspInvRsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GrdelRetInvRsn)
                    .HasColumnName("GRDelRetInvRsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GrdelScrapInvRsn)
                    .HasColumnName("GRDelScrapInvRsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GrretInvRsn)
                    .HasColumnName("GRRetInvRsn")
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
            });
            modelBuilder.Entity<MaWmgoodsReceipt>(entity =>
{
                entity.HasKey(e => e.GoodsReceiptId)
                    .HasName("PK_WMGoodsRec")
                    .IsClustered(false);

                entity.ToTable("MA_WMGoodsReceipt");

                entity.Property(e => e.GoodsReceiptId)
                    .HasColumnName("GoodsReceiptID")
                    .ValueGeneratedNever();

                entity.Property(e => e.BillOfLadingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.BillOfLadingGenerated)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.BillOfLadingId)
                    .HasColumnName("BillOfLadingID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BillOfLadingNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Cancelled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ConfInvEntryGenerated)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ConfInvEntryId)
                    .HasColumnName("ConfInvEntryID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ConfInvReason)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ConfSpecialStock).HasDefaultValueSql("((26869760))");

                entity.Property(e => e.ConfSpecialStockCode)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ConfSpecificator)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ConfSpecificatorType).HasDefaultValueSql("((6750211))");

                entity.Property(e => e.ConfStorage)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ConfZone)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GoodsReceiptDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.GoodsReceiptNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GoodsReceiptType).HasDefaultValueSql("((27262976))");

                entity.Property(e => e.InspNoteGenerated)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InspOrderGenerated)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InspectInvEntryGenerated)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InspectInvEntryId)
                    .HasColumnName("InspectInvEntryID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.InspectInvReason)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InspectSpecialStock).HasDefaultValueSql("((26869760))");

                entity.Property(e => e.InspectSpecialStockCode)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InspectSpecificator)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InspectSpecificatorType).HasDefaultValueSql("((6750211))");

                entity.Property(e => e.InspectStorage)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InspectZone)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InspectionOrderId)
                    .HasColumnName("InspectionOrderID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LastSubId)
                    .HasColumnName("LastSubID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NoOfSu)
                    .HasColumnName("NoOfSU")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Printed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ReturnInvEntryGenerated)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ReturnInvEntryId)
                    .HasColumnName("ReturnInvEntryID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ReturnInvReason)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReturnSpecialStock).HasDefaultValueSql("((26869760))");

                entity.Property(e => e.ReturnSpecialStockCode)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReturnSpecificator)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReturnSpecificatorType).HasDefaultValueSql("((6750211))");

                entity.Property(e => e.ReturnStorage)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReturnZone)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ScrapInvEntryGenerated)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ScrapInvEntryId)
                    .HasColumnName("ScrapInvEntryID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ScrapInvReason)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ScrapSpecialStock).HasDefaultValueSql("((26869760))");

                entity.Property(e => e.ScrapSpecialStockCode)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ScrapSpecificator)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ScrapSpecificatorType).HasDefaultValueSql("((6750211))");

                entity.Property(e => e.ScrapStorage)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ScrapZone)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SourceStorage)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

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

                entity.Property(e => e.Togenerated)
                    .HasColumnName("TOGenerated")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.TotalGrossVolume).HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalGrossWeight).HasDefaultValueSql("((0))");

                entity.Property(e => e.TwoStepsPutaway)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");
            });
            modelBuilder.Entity<MaWmgoodsReceiptCrossRef>(entity =>
{
                entity.HasKey(e => new { e.GoodsReceiptId, e.GoodsReceiptSubId, e.CrrefType, e.CrrefId, e.CrrefSubId })
                    .HasName("PK_WMGoodsReceiptCrossRef")
                    .IsClustered(false);

                entity.ToTable("MA_WMGoodsReceiptCrossRef");

                entity.Property(e => e.GoodsReceiptId).HasColumnName("GoodsReceiptID");

                entity.Property(e => e.GoodsReceiptSubId).HasColumnName("GoodsReceiptSubID");

                entity.Property(e => e.CrrefType)
                    .HasColumnName("CRRefType")
                    .HasDefaultValueSql("((27066368))");

                entity.Property(e => e.CrrefId).HasColumnName("CRRefID");

                entity.Property(e => e.CrrefSubId).HasColumnName("CRRefSubID");

                entity.Property(e => e.ExternalIdNo)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GoodsReceiptLine).HasDefaultValueSql("((0))");

                entity.Property(e => e.InternalIdNo)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ItemStatus).HasDefaultValueSql("((9895936))");

                entity.Property(e => e.Lot)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReceiptQty).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.UnitOfMeasure)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
            modelBuilder.Entity<MaWmgoodsReceiptDetail>(entity =>
{
                entity.HasKey(e => new { e.GoodsReceiptId, e.GoodsReceiptLine })
                    .HasName("PK_WMGoodsRecDetail")
                    .IsClustered(false);

                entity.ToTable("MA_WMGoodsReceiptDetail");

                entity.Property(e => e.GoodsReceiptId).HasColumnName("GoodsReceiptID");

                entity.Property(e => e.Cancelled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ConsignmentPartner)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExternalIdNo)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ForcedBin)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ForcedZone)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GoodsReceiptSubId).HasColumnName("GoodsReceiptSubID");

                entity.Property(e => e.GoodsReceiptType).HasDefaultValueSql("((27262976))");

                entity.Property(e => e.InternalIdNo)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IsManual)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ItemStatus).HasDefaultValueSql("((9895936))");

                entity.Property(e => e.Lot)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NotTransactable)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.OriginDocId)
                    .HasColumnName("OriginDocID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OriginDocNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OriginDocType).HasDefaultValueSql("((27066368))");

                entity.Property(e => e.OriginSubId).HasDefaultValueSql("((0))");

                entity.Property(e => e.Printed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Qty).HasDefaultValueSql("((0))");

                entity.Property(e => e.StorageUnit)
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

                entity.Property(e => e.Togenerated)
                    .HasColumnName("TOGenerated")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Toqty)
                    .HasColumnName("TOQty")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UnitOfMeasure)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
            modelBuilder.Entity<MaWminventory>(entity =>
{
                entity.HasKey(e => e.InventoryId)
                    .HasName("PK_WMInventory")
                    .IsClustered(false);

                entity.ToTable("MA_WMInventory");

                entity.HasIndex(e => new { e.InventoryDate, e.InventoryId })
                    .HasName("MA_WMInventory2");

                entity.Property(e => e.InventoryId)
                    .HasColumnName("InventoryID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AdjNegativeReason)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AdjPositiveReason)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BalancesDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.BlockExtractedBins)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DisplayItemsAvailable)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InitialReason)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InventoryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.InventoryDescription)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InventoryNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InventoryType).HasDefaultValueSql("((27328512))");

                entity.Property(e => e.OperationType).HasDefaultValueSql("((27394048))");

                entity.Property(e => e.PostingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.ProposedValue).HasDefaultValueSql("((3932160))");

                entity.Property(e => e.Storage)
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

                entity.Property(e => e.Zone)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
            modelBuilder.Entity<MaWminventoryDetail>(entity =>
{
                entity.HasKey(e => new { e.InventoryId, e.Storage, e.Zone, e.Bin, e.Item, e.Lot, e.UoM, e.SpecialStock, e.SpecialStockCode, e.StorageUnit, e.InternalIdNo, e.ConsignmentPartner })
                    .HasName("PK_WMInventoryDetail")
                    .IsClustered(false);

                entity.ToTable("MA_WMInventoryDetail");

                entity.HasIndex(e => new { e.InventoryId, e.Item })
                    .HasName("MA_WMInventoryDetail2");

                entity.Property(e => e.InventoryId).HasColumnName("InventoryID");

                entity.Property(e => e.Storage)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Zone)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Bin)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Lot)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.UoM)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.SpecialStockCode)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.StorageUnit)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.InternalIdNo)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.ConsignmentPartner)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.ActualQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.Difference).HasDefaultValueSql("((0))");

                entity.Property(e => e.EmptyBin)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.EmptyBinOtherCount)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FinalEmptyBin)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FinalQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.HandheldStatus).HasDefaultValueSql("((27983873))");

                entity.Property(e => e.HandheldStatusOtherCount).HasDefaultValueSql("((27983873))");

                entity.Property(e => e.InitialInventoryGenerated)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InterimDiffTogenerated)
                    .HasColumnName("InterimDiffTOGenerated")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InventoryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.InventoryNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InventoryToHandheld)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.LineReadyToBeProcessed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ProposedValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.ResultingQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ResultingQtyOtherCount).HasDefaultValueSql("((0))");

                entity.Property(e => e.Selected)
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

                entity.Property(e => e.Team)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TeamOtherCount)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Togenerated)
                    .HasColumnName("TOGenerated")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Worker).HasDefaultValueSql("((0))");

                entity.Property(e => e.WorkerOtherCount).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.MaWminventoryDetail)
                    .HasForeignKey(d => d.InventoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WMInventor_WMInventor_00");
            });
            modelBuilder.Entity<MaWmparameters>(entity =>
{
                entity.ToTable("MA_WMParameters");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AllowHigherQtyInPicking)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.AllowHigherQtyInPreShipping)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ApplyUoMsameItem)
                    .HasColumnName("ApplyUoMSameItem")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.AutomaticAssignResource)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.AutomaticChargesRec)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.CheckAvailabilityInPsgen)
                    .HasColumnName("CheckAvailabilityInPSGen")
                    .HasDefaultValueSql("((29884416))");

                entity.Property(e => e.CheckStorageUnitType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.CheckTotoBeConfInDelDocGen)
                    .HasColumnName("CheckTOtoBeConfInDelDocGen")
                    .HasDefaultValueSql("((25100289))");

                entity.Property(e => e.CrossDockingPutCd)
                    .HasColumnName("CrossDockingPutCD")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.CrossDockingPutStock)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DefaultResource).HasDefaultValueSql("((0))");

                entity.Property(e => e.DenyPickQtyNotTotallyAvail)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.EditBin)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.EditInternalIdNo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.EditInventory)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.EditItemInPicking)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.EditLot)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.EditPackInPicking)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.EditPurchaseDoc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.EditSaleDoc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.GoodReceiptGroupByItem)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.GoodReceiptGroupByNone)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InsertBroken)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InsertForDifference)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InsertMissing)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.MaintainCharges)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ManualBinAssignment)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.PreShipGroupByCustItem)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PreShipGroupByItem)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.PreShipGroupByNone)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PreShipNotGroupBySu)
                    .HasColumnName("PreShipNotGroupBySU")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PreShippingBreakByCarrier)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PreShippingBreakByCustShipTo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PreShippingBreakByCustomer)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PreShippingBreakBySaleOrdNo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PsautomaticChargesRec)
                    .HasColumnName("PSAutomaticChargesRec")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.PsmaintainCharges)
                    .HasColumnName("PSMaintainCharges")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ReasonBroken)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReasonGi)
                    .HasColumnName("ReasonGI")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReasonGr)
                    .HasColumnName("ReasonGR")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReasonInterim)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReasonInv)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReasonInvClosing)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReasonManufacturingGi)
                    .HasColumnName("ReasonManufacturingGI")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReasonManufacturingGr)
                    .HasColumnName("ReasonManufacturingGR")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReasonManufacturingInterim)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReasonManufacturingPk)
                    .HasColumnName("ReasonManufacturingPK")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReasonManufacturingPutaway)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReasonManufacturingReorder)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReasonMissing)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReasonPacking)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReasonPicking)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReasonPickingCrossDocking)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReasonPutaway)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReasonPutawayCrossDocking)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReasonReplenishment)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReasonReturn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReasonReturnFromInspection)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReasonStockTransfer)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReasonTransferRequest)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReasonUnPacking)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Section)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StorageUnitLength).HasDefaultValueSql("((16))");

                entity.Property(e => e.StorageUnitType)
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

                entity.Property(e => e.Team)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UseSuppSerialAsNewSerialNo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");
            });
            modelBuilder.Entity<MaWmpreShipping>(entity =>
{
                entity.HasKey(e => e.PreShippingId)
                    .HasName("PK_WMPreShipping")
                    .IsClustered(false);

                entity.ToTable("MA_WMPreShipping");

                entity.HasIndex(e => e.DeliveryDocumentGenerated)
                    .HasName("MA_WMPreShipping4");

                entity.HasIndex(e => e.PreShippingNo)
                    .HasName("MA_WMPreShipping5");

                entity.HasIndex(e => e.Toconfirmed)
                    .HasName("MA_WMPreShipping3");

                entity.HasIndex(e => e.Togenerated)
                    .HasName("MA_WMPreShipping2");

                entity.HasIndex(e => new { e.PreShippingDate, e.PreShippingNo })
                    .HasName("MA_WMPreShipping6");

                entity.Property(e => e.PreShippingId)
                    .HasColumnName("PreShippingID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cancelled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DeliveryDocumentGenerated)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DestinationStorage)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastSubId).HasDefaultValueSql("((0))");

                entity.Property(e => e.Notes)
                    .HasColumnType("ntext")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Packed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PreShippingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.PreShippingNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PreShippingType).HasDefaultValueSql("((27197440))");

                entity.Property(e => e.Printed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ReturnPickingNormal)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ReturnPickingReturn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ReturnZone)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Storage)
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

                entity.Property(e => e.Toconfirmed)
                    .HasColumnName("TOConfirmed")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Togenerated)
                    .HasColumnName("TOGenerated")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Zone)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
            modelBuilder.Entity<MaWmpreShippingComponents>(entity =>
{
                entity.HasKey(e => new { e.PreShippingId, e.SubId, e.Line })
                    .HasName("PK_WMPreShippingComponents")
                    .IsClustered(false);

                entity.ToTable("MA_WMPreShippingComponents");

                entity.Property(e => e.PreShippingId).HasColumnName("PreShippingID");

                entity.Property(e => e.Bomquantity)
                    .HasColumnName("BOMQuantity")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Component)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Description)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FixedQty)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PickedQty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.PickingRequestQty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Quantity).HasDefaultValueSql("((0.00))");

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

                entity.HasOne(d => d.PreShipping)
                    .WithMany(p => p.MaWmpreShippingComponents)
                    .HasForeignKey(d => d.PreShippingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PreShippinCom_PreShippin_00");
            });
            modelBuilder.Entity<MaWmpreShippingDetails>(entity =>
{
                entity.HasKey(e => new { e.PreShippingId, e.PreShippingLine })
                    .HasName("PK_WMPreShippingDetails")
                    .IsClustered(false);

                entity.ToTable("MA_WMPreShippingDetails");

                entity.HasIndex(e => e.Item)
                    .HasName("MA_WMPreShippingDetails2");

                entity.HasIndex(e => new { e.DeliveryDocumentGenerated, e.Cancelled })
                    .HasName("MA_WMPreShippingDetails4");

                entity.HasIndex(e => new { e.Togenerated, e.Item })
                    .HasName("MA_WMPreShippingDetails3");

                entity.Property(e => e.PreShippingId).HasColumnName("PreShippingID");

                entity.Property(e => e.Cancelled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Carrier)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CloseSaleOrd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ConfirmedDeliveryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.ConsignmentPartner)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CrossDocking)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CrrefId)
                    .HasColumnName("CRRefID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CrrefSubId)
                    .HasColumnName("CRRefSubID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CrrefType)
                    .HasColumnName("CRRefType")
                    .HasDefaultValueSql("((27066368))");

                entity.Property(e => e.CustSupp)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustSuppType).HasDefaultValueSql("((3211264))");

                entity.Property(e => e.DeliveryDocumentGenerated)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Description)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExpectedDeliveryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.InternalIdNo)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InvoiceTypes)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IsAbom)
                    .HasColumnName("IsABOM")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Lot)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NoInvoice)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NoPrint)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NotTransactable)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Package)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Packed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PickedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.PickingRequestQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.Port)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PreShippingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.PreShippingParentSubId)
                    .HasColumnName("PreShippingParentSubID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PreShippingSubId)
                    .HasColumnName("PreShippingSubID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PreShippingType).HasDefaultValueSql("((27197440))");

                entity.Property(e => e.Qty).HasDefaultValueSql("((0))");

                entity.Property(e => e.QtyDelivered).HasDefaultValueSql("((0))");

                entity.Property(e => e.QtyPacked).HasDefaultValueSql("((0))");

                entity.Property(e => e.QtyToDeliver).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReturnZone)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SaleDocId)
                    .HasColumnName("SaleDocID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SaleDocSubId).HasDefaultValueSql("((0))");

                entity.Property(e => e.ShipToAddress)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Storage)
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

                entity.Property(e => e.Toconfirmed)
                    .HasColumnName("TOConfirmed")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Togenerated)
                    .HasColumnName("TOGenerated")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Transport)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UnitOfMeasure)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Zone)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
            modelBuilder.Entity<MaWmpreShippingDetailsByLot>(entity =>
{
                entity.HasKey(e => new { e.PreShippingId, e.PreShippingSubId, e.Lot, e.InternalIdNo })
                    .HasName("PK_WMPreShippingDetailsByLot")
                    .IsClustered(false);

                entity.ToTable("MA_WMPreShippingDetailsByLot");

                entity.Property(e => e.PreShippingId).HasColumnName("PreShippingID");

                entity.Property(e => e.PreShippingSubId).HasColumnName("PreShippingSubID");

                entity.Property(e => e.Lot)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.InternalIdNo)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Consumed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.LotQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.LotQtyConsumed).HasDefaultValueSql("((0))");

                entity.Property(e => e.LotQtyPacked).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.UnitOfMeasure)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
            modelBuilder.Entity<MaWmpreShippingPack>(entity =>
{
                entity.HasKey(e => new { e.PackingLine, e.PreShippingId, e.PreShippingSubId, e.Sunumber, e.Lot, e.InternalIdNo })
                    .HasName("PK_WMPreShippingPack")
                    .IsClustered(false);

                entity.ToTable("MA_WMPreShippingPack");

                entity.Property(e => e.PreShippingId).HasColumnName("PreShippingID");

                entity.Property(e => e.PreShippingSubId).HasColumnName("PreShippingSubID");

                entity.Property(e => e.Sunumber)
                    .HasColumnName("SUNumber")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Lot)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.InternalIdNo)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Qty).HasDefaultValueSql("((0))");

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
            modelBuilder.Entity<MaWmpreShippingPackLev>(entity =>
{
                entity.HasKey(e => new { e.PackingLine, e.PreShippingId, e.PreShippingSubId, e.Sunumber, e.SunumberChild, e.Lot, e.InternalIdNo })
                    .HasName("PK_WMPreShippingPackLev")
                    .IsClustered(false);

                entity.ToTable("MA_WMPreShippingPackLev");

                entity.Property(e => e.PreShippingId).HasColumnName("PreShippingID");

                entity.Property(e => e.PreShippingSubId).HasColumnName("PreShippingSubID");

                entity.Property(e => e.Sunumber)
                    .HasColumnName("SUNumber")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.SunumberChild)
                    .HasColumnName("SUNumberChild")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Lot)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.InternalIdNo)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Lev).HasDefaultValueSql("((0))");

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
            modelBuilder.Entity<MaWmreason>(entity =>
{
                entity.HasKey(e => e.Reason);

                entity.ToTable("MA_WMReason");

                entity.Property(e => e.Reason)
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
            });
            modelBuilder.Entity<MaWmsearchZoneStrategy>(entity =>
{
                entity.HasKey(e => new { e.Code, e.Storage })
                    .HasName("PK_WMSearchZoneStrategy")
                    .IsClustered(false);

                entity.ToTable("MA_WMSearchZoneStrategy");

                entity.Property(e => e.Code)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Storage)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(128)
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
            modelBuilder.Entity<MaWmsearchZoneStrategyDet>(entity =>
{
                entity.HasKey(e => new { e.Code, e.Storage, e.Zone })
                    .HasName("PK_WMSearchZoneStrategyDet")
                    .IsClustered(false);

                entity.ToTable("MA_WMSearchZoneStrategyDet");

                entity.Property(e => e.Code)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Storage)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Zone)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Priority).HasDefaultValueSql("((0))");

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
            modelBuilder.Entity<MaWmsection>(entity =>
{
                entity.HasKey(e => e.Section);

                entity.ToTable("MA_WMSection");

                entity.Property(e => e.Section)
                    .HasMaxLength(8)
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

                entity.Property(e => e.Tbmodified)
                    .HasColumnName("TBModified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbmodifiedId).HasColumnName("TBModifiedID");

                entity.Property(e => e.ValidForAllMaterials)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");
            });
            modelBuilder.Entity<MaWmsectionCategory>(entity =>
{
                entity.HasKey(e => e.SectionCategory);

                entity.ToTable("MA_WMSectionCategory");

                entity.Property(e => e.SectionCategory)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.HazardousMaterial)
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
            modelBuilder.Entity<MaWmsectionDetail>(entity =>
{
                entity.HasKey(e => new { e.Section, e.SectionCategory });

                entity.ToTable("MA_WMSectionDetail");

                entity.Property(e => e.Section)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.SectionCategory)
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
            });
            modelBuilder.Entity<MaWmstorageUnit>(entity =>
{
                entity.HasKey(e => e.Sunumber);

                entity.ToTable("MA_WMStorageUnit");

                entity.Property(e => e.Sunumber)
                    .HasColumnName("SUNumber")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.BarcodeSegment)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Dimensions)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FixedGrossVolume)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.GrossVolume).HasDefaultValueSql("((0))");

                entity.Property(e => e.GrossWeight).HasDefaultValueSql("((0))");

                entity.Property(e => e.MaximumVolume).HasDefaultValueSql("((0))");

                entity.Property(e => e.MaximumWeight).HasDefaultValueSql("((0))");

                entity.Property(e => e.Sutcode)
                    .HasColumnName("SUTCode")
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

                entity.Property(e => e.UsedInPreShipping)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UsedInWarehouse)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");
            });
            modelBuilder.Entity<MaWmstorageUnitNumbers>(entity =>
{
                entity.HasKey(e => e.BalanceYear)
                    .HasName("PK_WMStorageUnitNumbers")
                    .IsClustered(false);

                entity.ToTable("MA_WMStorageUnitNumbers");

                entity.Property(e => e.BalanceYear).ValueGeneratedNever();

                entity.Property(e => e.LastSudocDate)
                    .HasColumnName("LastSUDocDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.LastSuno)
                    .HasColumnName("LastSUNo")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PrefixFormat).HasDefaultValueSql("((24969216))");

                entity.Property(e => e.SeparatorCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SuffixChars).HasDefaultValueSql("((0))");

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
            modelBuilder.Entity<MaWmstorageUnitType>(entity =>
{
                entity.HasKey(e => e.Sutcode)
                    .HasName("PK_MA_WMSUnitType")
                    .IsClustered(false);

                entity.ToTable("MA_WMStorageUnitType");

                entity.Property(e => e.Sutcode)
                    .HasColumnName("SUTCode")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Category)
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

                entity.Property(e => e.MaximumVolume).HasDefaultValueSql("((0))");

                entity.Property(e => e.MaximumWeight).HasDefaultValueSql("((0))");

                entity.Property(e => e.MixedItems)
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
            modelBuilder.Entity<MaWmsutpackaging>(entity =>
{
                entity.HasKey(e => new { e.Sutcode, e.Line })
                    .IsClustered(false);

                entity.ToTable("MA_WMSUTPackaging");

                entity.Property(e => e.Sutcode)
                    .HasColumnName("SUTCode")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Qty).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.UnitOfMeasure)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.SutcodeNavigation)
                    .WithMany(p => p.MaWmsutpackaging)
                    .HasForeignKey(d => d.Sutcode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MA_WMSUTPackaging_WMSUnitType");
            });
            modelBuilder.Entity<MaWmtransferOrder>(entity =>
{
                entity.ToTable("MA_WMTransferOrder");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AutoConfirmed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ConfirmationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.ConsignmentPartner)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedFromInventory)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.DestBin)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DestSpecialStock).HasDefaultValueSql("((26935296))");

                entity.Property(e => e.DestSpecialStockCode)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DestStorageUnit)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DestZone)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Idparent)
                    .HasColumnName("IDParent")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.InternalIdNo)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IsManualInternalIdNo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IsManualLot)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Lot)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MovementType).HasDefaultValueSql("((26542084))");

                entity.Property(e => e.Notes)
                    .HasMaxLength(132)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OriginalItem)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PackingUnit)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PickFromPackUoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.QtyMoved).HasDefaultValueSql("((0))");

                entity.Property(e => e.QtyNeeded).HasDefaultValueSql("((0))");

                entity.Property(e => e.QtyToMove).HasDefaultValueSql("((0))");

                entity.Property(e => e.Reason)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SourceBin)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SourceSpecialStock).HasDefaultValueSql("((26935296))");

                entity.Property(e => e.SourceSpecialStockCode)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SourceStorageUnit)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SourceZone)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Storage)
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

                entity.Property(e => e.Team)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ToResource).HasDefaultValueSql("('0')");

                entity.Property(e => e.Tonumber)
                    .HasColumnName("TONumber")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Tostatus)
                    .HasColumnName("TOStatus")
                    .HasDefaultValueSql("((27000832))");

                entity.Property(e => e.UoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
            modelBuilder.Entity<MaWmtransferOrderDetails>(entity =>
{
                entity.HasKey(e => new { e.Id, e.StockNumber });

                entity.ToTable("MA_WMTransferOrderDetails");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Bin)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ConsignmentPartner)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InternalIdNo)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Lot)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LotValidTo)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Qty).HasDefaultValueSql("((0))");

                entity.Property(e => e.QtyBaseUoM).HasDefaultValueSql("((0))");

                entity.Property(e => e.QtyPreShipping).HasDefaultValueSql("((0))");

                entity.Property(e => e.SpecialStock).HasDefaultValueSql("((26869760))");

                entity.Property(e => e.SpecialStockCode)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Storage)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StorageUnit)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StorageUnitType)
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

                entity.Property(e => e.UnitOfMeasure)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Zone)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
            modelBuilder.Entity<MaWmzone>(entity =>
{
                entity.HasKey(e => new { e.Zone, e.Storage });

                entity.ToTable("MA_WMZone");

                entity.Property(e => e.Zone)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Storage)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.AddToStock)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.AllowNegativeStock)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.BinStructure)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BlockDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.BlockReason)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BlockWorker).HasDefaultValueSql("((0))");

                entity.Property(e => e.Blocked)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.CapacityCheck)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ContInvOnPutaway)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ContInvOnQtyStock)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ContInvOnZeroStock)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ContInvQuantity).HasDefaultValueSql("((0))");

                entity.Property(e => e.ContinuousInventory)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.CrossDocking)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Description)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Disabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ForPicking)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.ForPutaway)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.Gizone)
                    .HasColumnName("GIZone")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Grzone)
                    .HasColumnName("GRZone")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.HazardousMaterial).HasDefaultValueSql("((26673154))");

                entity.Property(e => e.Interim)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InventoryBinAssignment)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.LastInventory)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.LastSubId).HasDefaultValueSql("((0))");

                entity.Property(e => e.Mipzone)
                    .HasColumnName("MIPZone")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.MixedItem)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.MixedLots)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Mizone)
                    .HasColumnName("MIZone")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Mrzone)
                    .HasColumnName("MRZone")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PathSequence).HasDefaultValueSql("((0))");

                entity.Property(e => e.PeriodicInventory)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.PickingStrategy).HasDefaultValueSql("((26804224))");

                entity.Property(e => e.PickingStrategyItemWithLot).HasDefaultValueSql("((26804229))");

                entity.Property(e => e.PutawayNearFixedBin)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PutawayStrategy).HasDefaultValueSql("((26738690))");

                entity.Property(e => e.QualityInspectionZone)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ReplenishmentZone)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Rtszone)
                    .HasColumnName("RTSZone")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ScrapsZone)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.StorageUnit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.StorageUnitNumberCheck)
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

                entity.Property(e => e.TotalRemoval)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UniqueLot)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseBinStructure)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.UseSection)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.WeightCheck)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ZoneBarcodePrefix)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
            modelBuilder.Entity<MaWmzoneResources>(entity =>
{
                entity.HasKey(e => new { e.Storage, e.Zone, e.Line });

                entity.ToTable("MA_WMZoneResources");

                entity.Property(e => e.Storage)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Zone)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.DefaultTeam)
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

                entity.Property(e => e.Team)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((0))");
            });
            modelBuilder.Entity<MaWmzoneSection>(entity =>
{
                entity.HasKey(e => new { e.Storage, e.Zone, e.Section });

                entity.ToTable("MA_WMZoneSection");

                entity.Property(e => e.Storage)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Zone)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Section)
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
            });
        }
    }
}
