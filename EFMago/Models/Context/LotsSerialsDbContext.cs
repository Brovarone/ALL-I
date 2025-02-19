using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class LotsSerialsDbContext : DbContext
    {
        public LotsSerialsDbContext()
        {
        }
        public LotsSerialsDbContext(DbContextOptions<LotsSerialsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaLotSerialParameters> MaLotSerialParameters { get; set; }
        public virtual DbSet<MaLots> MaLots { get; set; }
        public virtual DbSet<MaLotsMonthly> MaLotsMonthly { get; set; }
        public virtual DbSet<MaLotsNumbers> MaLotsNumbers { get; set; }
        public virtual DbSet<MaLotsStoragesQty> MaLotsStoragesQty { get; set; }
        public virtual DbSet<MaLotsStoragesQtyMonthly> MaLotsStoragesQtyMonthly { get; set; }
        public virtual DbSet<MaLotsTracing> MaLotsTracing { get; set; }
        public virtual DbSet<MaSerialNumbers> MaSerialNumbers { get; set; }
        public virtual DbSet<MaTmpLotsTracing> MaTmpLotsTracing { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaLotSerialParameters>(entity =>
{
                entity.HasKey(e => e.LotSerialParametersId)
                    .HasName("PK_LotSerialParameters")
                    .IsClustered(false);

                entity.ToTable("MA_LotSerialParameters");

                entity.Property(e => e.LotSerialParametersId).ValueGeneratedNever();

                entity.Property(e => e.AutoCreation)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ChooseLotOnPicking).HasDefaultValueSql("((8454144))");

                entity.Property(e => e.DisplayOutofStocksLots)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DisplaySupplierLot)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.EnableLotsOnNewItems)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.EnableLotsTracing)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ExcludedFromOnHand)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.HideLotDescription)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.LotMaxDigits).HasDefaultValueSql("((0))");

                entity.Property(e => e.LotOnInvEntryIsMand)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.LotOnPurchaseIsMand)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.LotOnSaleIsMand)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.LotSelection).HasDefaultValueSql("((8454144))");

                entity.Property(e => e.LotsAutoNum)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.LotsTracingActionInBom)
                    .HasColumnName("LotsTracingActionInBOM")
                    .HasDefaultValueSql("((11599874))");

                entity.Property(e => e.LotsValuesAreUpdatedByCost)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.OldLot)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SerialMaxDigits).HasDefaultValueSql("((16))");

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

                entity.Property(e => e.TraceAlsoWithoutParent)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UniqueLotNumbering)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseLots)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseSupplierLotAsNewLotNumber)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.WarnNoLotInInvEntry)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.WarnNoLotInPurch)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.WarnNoLotInSale)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");
            });
            modelBuilder.Entity<MaLots>(entity =>
{
                entity.HasKey(e => new { e.Item, e.Lot })
                    .HasName("PK_Lots")
                    .IsClustered(false);

                entity.ToTable("MA_Lots");

                entity.HasIndex(e => new { e.Disabled, e.Item })
                    .HasName("MA_Lots3");

                entity.HasIndex(e => new { e.Item, e.Description })
                    .HasName("MA_Lots2");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Lot)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.AnalysisDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.AnalysisPerson)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AnalysisRefNo)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AnalysisStatus).HasDefaultValueSql("((8388608))");

                entity.Property(e => e.BarcodeSegment)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BookedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.Cost).HasDefaultValueSql("((0))");

                entity.Property(e => e.Description)
                    .HasMaxLength(32)
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

                entity.Property(e => e.FinalBookInv).HasDefaultValueSql("((0))");

                entity.Property(e => e.FinalOnHand).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialBookInv).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialOnHand).HasDefaultValueSql("((0))");

                entity.Property(e => e.InternallyProduced)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IssuedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.IssuedValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastMaintenance)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.LastMaintenanceExtra)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.LoadDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Location)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Moid)
                    .HasColumnName("MOId")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Mono)
                    .HasColumnName("MONo")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NoOfPacks).HasDefaultValueSql("((0))");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OutOfStockDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.ParentLotNo)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProductionDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.PurchaseDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.PurchaseOrdNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReceiptDocNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReceiptInvTransId).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReceiptLastCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReceivedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReceivedValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReservedByMo)
                    .HasColumnName("ReservedByMO")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Storage)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Supplier)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SupplierLotNo)
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

                entity.Property(e => e.ThresholdQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ThresholdQtyTot).HasDefaultValueSql("((0))");

                entity.Property(e => e.TotallyConsumed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UsedByProduction).HasDefaultValueSql("((0))");

                entity.Property(e => e.UsedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.UsedQtyTot).HasDefaultValueSql("((0))");

                entity.Property(e => e.ValidFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.ValidTo)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");
            });
            modelBuilder.Entity<MaLotsMonthly>(entity =>
{
                entity.HasKey(e => new { e.Item, e.Lot, e.FiscalYear, e.BalanceYear, e.Balance, e.BalanceMonth })
                    .HasName("PK_LotsMonthly")
                    .IsClustered(false);

                entity.ToTable("MA_LotsMonthly");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Lot)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.BookedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.FinalBookInv).HasDefaultValueSql("((0))");

                entity.Property(e => e.FinalOnHand).HasDefaultValueSql("((0))");

                entity.Property(e => e.IssuedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.IssuedValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReceivedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReceivedValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReservedByMo)
                    .HasColumnName("ReservedByMO")
                    .HasDefaultValueSql("((0))");

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

                entity.Property(e => e.UsedByProduction).HasDefaultValueSql("((0))");
            });
            modelBuilder.Entity<MaLotsNumbers>(entity =>
{
                entity.HasKey(e => e.BalanceYear)
                    .HasName("PK_LotsNumbers")
                    .IsClustered(false);

                entity.ToTable("MA_LotsNumbers");

                entity.Property(e => e.BalanceYear).ValueGeneratedNever();

                entity.Property(e => e.LastLotDocDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.LastLotNo).HasDefaultValueSql("((0))");

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
            modelBuilder.Entity<MaLotsStoragesQty>(entity =>
{
                entity.HasKey(e => new { e.FiscalYear, e.FiscalPeriod, e.Item, e.Lot, e.Storage, e.Specificator, e.SpecificatorType })
                    .HasName("PK_LotsStoragesQty")
                    .IsClustered(false);

                entity.ToTable("MA_LotsStoragesQty");

                entity.HasIndex(e => new { e.FiscalYear, e.FiscalPeriod, e.Item, e.Storage, e.Lot, e.SpecificatorType, e.Specificator })
                    .HasName("MA_LotsStoragesQty2");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Lot)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Storage)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Specificator)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.BookedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.CurrentQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.CurrentValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.IssuedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.IssuedValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.MinimumStock).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReceivedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReceivedValue).HasDefaultValueSql("((0))");

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
            modelBuilder.Entity<MaLotsStoragesQtyMonthly>(entity =>
{
                entity.HasKey(e => new { e.FiscalYear, e.Item, e.Lot, e.Storage, e.Specificator, e.SpecificatorType, e.BalanceYear, e.Balance, e.BalanceMonth })
                    .HasName("PK_LotsStoragesQtyMonthly")
                    .IsClustered(false);

                entity.ToTable("MA_LotsStoragesQtyMonthly");

                entity.HasIndex(e => new { e.FiscalYear, e.Item, e.Storage, e.Lot, e.SpecificatorType, e.Specificator })
                    .HasName("MA_LotsStoragesQtyMonthly2");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Lot)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Storage)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Specificator)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.BookedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.CurrentQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.CurrentValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.IssuedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.IssuedValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReceivedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReceivedValue).HasDefaultValueSql("((0))");

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
            modelBuilder.Entity<MaLotsTracing>(entity =>
{
                entity.HasKey(e => new { e.ParentLot, e.ChildLot, e.ParentItem, e.ChildItem, e.IdParentMo, e.IdPlan })
                    .HasName("PK_LotsTracing")
                    .IsClustered(false);

                entity.ToTable("MA_LotsTracing");

                entity.Property(e => e.ParentLot)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.ChildLot)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.ParentItem)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.ChildItem)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.IdParentMo).HasColumnName("IdParentMO");

                entity.Property(e => e.ChildBaseUoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MocompLine)
                    .HasColumnName("MOCompLine")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PickingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

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
            modelBuilder.Entity<MaSerialNumbers>(entity =>
{
                entity.HasKey(e => e.BalanceYear)
                    .HasName("PK_SerialNumbers")
                    .IsClustered(false);

                entity.ToTable("MA_SerialNumbers");

                entity.Property(e => e.BalanceYear).ValueGeneratedNever();

                entity.Property(e => e.LastDocDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.LastDocNo).HasDefaultValueSql("((0))");

                entity.Property(e => e.NoPrefix)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PrefixFormat).HasDefaultValueSql("((24969216))");

                entity.Property(e => e.SeparatorCode)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('/')");

                entity.Property(e => e.Suffix)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SuffixChars).HasDefaultValueSql("((3))");

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
            modelBuilder.Entity<MaTmpLotsTracing>(entity =>
{
                entity.HasKey(e => new { e.UserName, e.ComputerName, e.DocumentName, e.Line })
                    .HasName("PK_TmpLotsTracing")
                    .IsClustered(false);

                entity.ToTable("MA_TmpLotsTracing");

                entity.Property(e => e.UserName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.ComputerName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.DocumentName)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.ChildItem)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ChildLot)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DocumentId).HasDefaultValueSql("((0))");

                entity.Property(e => e.FromMo)
                    .HasColumnName("FromMO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.ParentItem)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ParentLot)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Qty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReferenceItem)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReferenceLot)
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

                entity.Property(e => e.TmpMocompLine)
                    .HasColumnName("TmpMOCompLine")
                    .HasDefaultValueSql("((0))");
            });
        }
    }
}
