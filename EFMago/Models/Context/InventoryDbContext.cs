using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class InventoryDbContext : DbContext
    {
        public InventoryDbContext()
        {
        }
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaInventoryDefaults> MaInventoryDefaults { get; set; }
        public virtual DbSet<MaInventoryEntries> MaInventoryEntries { get; set; }
        public virtual DbSet<MaInventoryEntriesDetail> MaInventoryEntriesDetail { get; set; }
        public virtual DbSet<MaInventoryEntriesReference> MaInventoryEntriesReference { get; set; }
        public virtual DbSet<MaInventoryJournal> MaInventoryJournal { get; set; }
        public virtual DbSet<MaInventoryParameters> MaInventoryParameters { get; set; }
        public virtual DbSet<MaInventoryReasons> MaInventoryReasons { get; set; }
        public virtual DbSet<MaItemsFifo> MaItemsFifo { get; set; }
        public virtual DbSet<MaItemsFifodomCurr> MaItemsFifodomCurr { get; set; }
        public virtual DbSet<MaItemsFiscalData> MaItemsFiscalData { get; set; }
        public virtual DbSet<MaItemsFiscalDataDomCurr> MaItemsFiscalDataDomCurr { get; set; }
        public virtual DbSet<MaItemsLifo> MaItemsLifo { get; set; }
        public virtual DbSet<MaItemsLifodomCurr> MaItemsLifodomCurr { get; set; }
        public virtual DbSet<MaItemsMonthlyBalances> MaItemsMonthlyBalances { get; set; }
        public virtual DbSet<MaStandardCostHistorical> MaStandardCostHistorical { get; set; }
        public virtual DbSet<MaTmpAbc> MaTmpAbc { get; set; }
        public virtual DbSet<MaTmpConsolidation> MaTmpConsolidation { get; set; }
        public virtual DbSet<MaTmpFifoprogress> MaTmpFifoprogress { get; set; }
        public virtual DbSet<MaTmpInventoryAdjustment> MaTmpInventoryAdjustment { get; set; }
        public virtual DbSet<MaTmpLifoprogress> MaTmpLifoprogress { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaInventoryDefaults>(entity =>
{
                entity.HasKey(e => e.InventoryDefaultsId)
                    .HasName("PK_InventoryDefaults")
                    .IsClustered(false);

                entity.ToTable("MA_InventoryDefaults");

                entity.Property(e => e.InventoryDefaultsId).ValueGeneratedNever();

                entity.Property(e => e.BusinessClosingInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CigcorrInvReason)
                    .HasColumnName("CIGCorrInvReason")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InventoryDecreaseAdjInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InventoryIncreaseAdjInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InventoryInitialInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RevaluationFifoinvRsn)
                    .HasColumnName("RevaluationFIFOInvRsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RevaluationLifoinvRsn)
                    .HasColumnName("RevaluationLIFOInvRsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StockTransferInvRsn)
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
            modelBuilder.Entity<MaInventoryEntries>(entity =>
{
                entity.HasKey(e => e.EntryId)
                    .HasName("PK_InventoryEntries")
                    .IsClustered(false);

                entity.ToTable("MA_InventoryEntries");

                entity.HasIndex(e => e.PickingListNo)
                    .HasName("MA_InventoryEntries6");

                entity.HasIndex(e => new { e.InvRsn, e.PostingDate })
                    .HasName("MA_InventoryEntries3");

                entity.HasIndex(e => new { e.PostingDate, e.EntryId })
                    .HasName("MA_InventoryEntries2");

                entity.HasIndex(e => new { e.PostingDate, e.InvRsn })
                    .HasName("MA_InventoryEntries5");

                entity.HasIndex(e => new { e.PostingDate, e.CustSuppType, e.CustSupp })
                    .HasName("MA_InventoryEntries4");

                entity.Property(e => e.EntryId).ValueGeneratedNever();

                entity.Property(e => e.AccrualDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.AutomaticInvValueOnly)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CancelPhase1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CancelPhase2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CigcorrEntryId)
                    .HasColumnName("CIGCorrEntryID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ClosingEntry)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CorrectionEntry)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CostCenter)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

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

                entity.Property(e => e.CustSupp)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustSuppType).HasDefaultValueSql("((6094850))");

                entity.Property(e => e.DocNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DocumentDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.EntryIdloadVariation)
                    .HasColumnName("EntryIDLoadVariation")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ExtAccTransId)
                    .HasColumnName("ExtAccTransID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Fixing).HasDefaultValueSql("((0))");

                entity.Property(e => e.FixingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.FixingIsManual)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FromManufacturing)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Job)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.JobTicketId).HasDefaultValueSql("((0))");

                entity.Property(e => e.JobTicketNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastSubId).HasDefaultValueSql("((0))");

                entity.Property(e => e.ManufacturingCostCorrection)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ManufacturingEntryType).HasDefaultValueSql("((27525120))");

                entity.Property(e => e.ManufacturingOutsrcRtgStep)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ManufacturingReversedEntry)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PickingListNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PostedToCostAccounting)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PostingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.PreprintedDocNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProductLine)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReceiptPhase1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ReceiptPhase2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Specificator1Type).HasDefaultValueSql("((6750211))");

                entity.Property(e => e.Specificator2Type).HasDefaultValueSql("((6750211))");

                entity.Property(e => e.SpecificatorPhase1)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SpecificatorPhase2)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StoragePhase1)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StoragePhase2)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StubBook)
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

                entity.Property(e => e.UsePhase2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");
            });
            modelBuilder.Entity<MaInventoryEntriesDetail>(entity =>
{
                entity.HasKey(e => new { e.EntryId, e.Line })
                    .HasName("PK_InventoryEntriesDetail")
                    .IsClustered(false);

                entity.ToTable("MA_InventoryEntriesDetail");

                entity.HasIndex(e => e.ExternalIdNo)
                    .HasName("MA_InventoryEntriesDetail6");

                entity.HasIndex(e => e.InternalIdNo)
                    .HasName("MA_InventoryEntriesDetail5");

                entity.HasIndex(e => e.InvRsn)
                    .HasName("MA_InventoryEntriesDetail_IM1");

                entity.HasIndex(e => new { e.BoLid, e.BoLline })
                    .HasName("MA_InventoryEntriesDetail10");

                entity.HasIndex(e => new { e.EntryId, e.Item })
                    .HasName("MA_InventoryEntriesDetail2");

                entity.HasIndex(e => new { e.Item, e.AccrualDate })
                    .HasName("MA_InventoryEntriesDetail8");

                entity.HasIndex(e => new { e.Item, e.PostingDate })
                    .HasName("MA_InventoryEntriesDetail4");

                entity.HasIndex(e => new { e.Item, e.UoM })
                    .HasName("MA_InventoryEntriesDetail13");

                entity.HasIndex(e => new { e.Moid, e.EntryId })
                    .HasName("MA_InventoryEntriesDetail9");

                entity.HasIndex(e => new { e.Moid, e.MocompLine })
                    .HasName("MA_InventoryEntriesDetail14");

                entity.HasIndex(e => new { e.Moid, e.RtgStep })
                    .HasName("MA_InventoryEntriesDetail7");

                entity.HasIndex(e => new { e.PostingDate, e.Item })
                    .HasName("MA_InventoryEntriesDetail3");

                entity.HasIndex(e => new { e.VariationInvEntryId, e.VariationInvEntrySubId })
                    .HasName("MA_InventoryEntriesDetail11");

                entity.HasIndex(e => new { e.Item, e.Lot, e.EntryId })
                    .HasName("IX_MA_InventoryEntriesDetail");

                entity.HasIndex(e => new { e.PostingDate, e.OrderForProcedure, e.EntryId })
                    .HasName("MA_InventoryEntriesDetail12");

                entity.Property(e => e.AccrualDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.ActionOnLifoFifo).HasDefaultValueSql("((26411008))");

                entity.Property(e => e.ActualRetailPrice).HasDefaultValueSql("((0))");

                entity.Property(e => e.ActualRetailPricePhase2).HasDefaultValueSql("((0))");

                entity.Property(e => e.ActualRetailPriceWithTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.AdditionalQty1).HasDefaultValueSql("((0))");

                entity.Property(e => e.AdditionalQty2).HasDefaultValueSql("((0))");

                entity.Property(e => e.AdditionalQty3).HasDefaultValueSql("((0))");

                entity.Property(e => e.AdditionalQty4).HasDefaultValueSql("((0))");

                entity.Property(e => e.AltRtgStep).HasDefaultValueSql("((0))");

                entity.Property(e => e.Alternate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BaseUoMqty)
                    .HasColumnName("BaseUoMQty")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BkinitialCost)
                    .HasColumnName("BKInitialCost")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BklineAmount)
                    .HasColumnName("BKLineAmount")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BklineCost)
                    .HasColumnName("BKLineCost")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Bkqty)
                    .HasColumnName("BKQty")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BkunitValue)
                    .HasColumnName("BKUnitValue")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BoLid)
                    .HasColumnName("BoLId")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BoLline)
                    .HasColumnName("BoLLine")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BoLsubId)
                    .HasColumnName("BoLSubId")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CostAccAccount)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CostCenter)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CrrefId)
                    .HasColumnName("CRRefID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CrrefLine)
                    .HasColumnName("CRRefLine")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CrrefSubId)
                    .HasColumnName("CRRefSubID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CrrefType)
                    .HasColumnName("CRRefType")
                    .HasDefaultValueSql("((27066368))");

                entity.Property(e => e.Department)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Description)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Discount1).HasDefaultValueSql("((0))");

                entity.Property(e => e.Discount2).HasDefaultValueSql("((0))");

                entity.Property(e => e.DiscountAmount).HasDefaultValueSql("((0))");

                entity.Property(e => e.DiscountFormula)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DocumentType).HasDefaultValueSql("((3801088))");

                entity.Property(e => e.Drawing)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EntryTypeForLfbatchEval)
                    .HasColumnName("EntryTypeForLFBatchEval")
                    .HasDefaultValueSql("((12255234))");

                entity.Property(e => e.ExternalIdNo)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExternalLineReference).HasDefaultValueSql("((0))");

                entity.Property(e => e.ImJobWorkingStep)
                    .HasColumnName("IM_JobWorkingStep")
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InternalIdNo)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Job)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LifoFifoLineSource)
                    .HasColumnName("LifoFifo_LineSource")
                    .HasDefaultValueSql("((26476544))");

                entity.Property(e => e.LineAmount).HasDefaultValueSql("((0))");

                entity.Property(e => e.LineCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.Location)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Lot)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ManufacturingCorrection)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ManufacturingDeletion)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ManufacturingProcCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.MocompLine)
                    .HasColumnName("MOCompLine")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Moid)
                    .HasColumnName("MOId")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Mono)
                    .HasColumnName("MONo")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NonConformityReason)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OrderForProcedure).HasDefaultValueSql("((0))");

                entity.Property(e => e.OrderId).HasDefaultValueSql("((0))");

                entity.Property(e => e.OrderLine).HasDefaultValueSql("((0))");

                entity.Property(e => e.OrderType).HasDefaultValueSql("((3801088))");

                entity.Property(e => e.PostingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.ProdJobId).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProdJobNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProductLine)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Qty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReceiptBatchId).HasDefaultValueSql("((0))");

                entity.Property(e => e.RtgStep).HasDefaultValueSql("((0))");

                entity.Property(e => e.SubId).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.Temporary)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UnitValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.UoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Variant)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.VariationExternalId)
                    .HasColumnName("VariationExternalID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.VariationInvEntryId)
                    .HasColumnName("VariationInvEntryID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.VariationInvEntrySubId)
                    .HasColumnName("VariationInvEntrySubID")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Entry)
                    .WithMany(p => p.MaInventoryEntriesDetail)
                    .HasForeignKey(d => d.EntryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InventoryE_InventoryE_00");
            });
            modelBuilder.Entity<MaInventoryEntriesReference>(entity =>
{
                entity.HasKey(e => new { e.InventoryEntriesId, e.Line })
                    .HasName("PK_InventoryEntriesReference")
                    .IsClustered(false);

                entity.ToTable("MA_InventoryEntriesReference");

                entity.HasIndex(e => new { e.DocumentType, e.DocumentId })
                    .HasName("MA_InventoryEntriesReferences2");

                entity.Property(e => e.DocumentDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.DocumentId).HasDefaultValueSql("((0))");

                entity.Property(e => e.DocumentNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DocumentType).HasDefaultValueSql("((6684681))");

                entity.Property(e => e.Notes)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReferenceIsAuto)
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

                entity.Property(e => e.TypeReference)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
            modelBuilder.Entity<MaInventoryJournal>(entity =>
{
                entity.HasKey(e => new { e.FiscalYear, e.BalanceYear, e.MonthBalance })
                    .HasName("PK_InventoryJournal")
                    .IsClustered(false);

                entity.ToTable("MA_InventoryJournal");

                entity.Property(e => e.DefinitivelyPrinted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.LastPrintingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.NoOfPrintedLines).HasDefaultValueSql("('0')");

                entity.Property(e => e.NoOfPrintedPages).HasDefaultValueSql("('0')");

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
            modelBuilder.Entity<MaInventoryParameters>(entity =>
{
                entity.HasKey(e => e.InventoryParametersId)
                    .HasName("PK_InventoryParameters")
                    .IsClustered(false);

                entity.ToTable("MA_InventoryParameters");

                entity.Property(e => e.InventoryParametersId).ValueGeneratedNever();

                entity.Property(e => e.Abccost)
                    .HasColumnName("ABCCost")
                    .HasDefaultValueSql("((6488064))");

                entity.Property(e => e.Abclimit)
                    .HasColumnName("ABCLimit")
                    .HasDefaultValueSql("((20))");

                entity.Property(e => e.AccrualDateManagement)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ActionOnLocation).HasDefaultValueSql("((11599872))");

                entity.Property(e => e.ActionReopeningInvValCons).HasDefaultValueSql("((11599874))");

                entity.Property(e => e.AskForCostInReports)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CustomDescription1)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustomDescription2)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustomDescription3)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustomDescription4)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustomDescription5)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EnableInvValConsolidation)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.EntryAutonumbering)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InvEntryDateCheckType).HasDefaultValueSql("((12386304))");

                entity.Property(e => e.InventoryScarcityCheckType).HasDefaultValueSql("((25100288))");

                entity.Property(e => e.InventoryShortageCheckType).HasDefaultValueSql("((25100288))");

                entity.Property(e => e.LastInvValConsDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.LinkStorageLocation)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PickFromMultipleLocDe)
                    .HasColumnName("PickFromMultipleLocDE")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PromptMinQty)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PunctualLastCostUpdate)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.RoundOffNetPrice)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SearchFormerAverageCost)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ShowCostInReports)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ShowGoodsOwnedStorageOnly)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.StandardCostHistory)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.StorageValuationManage)
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

                entity.Property(e => e.UseInvAdjByLocation)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseSepAccountForStorage)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ValueTypeFinished).HasDefaultValueSql("((11272194))");

                entity.Property(e => e.ValueTypePurchase).HasDefaultValueSql("((11272194))");

                entity.Property(e => e.ValueTypePurchaseNotPost).HasDefaultValueSql("((11272194))");

                entity.Property(e => e.ValueTypeSemiFinished).HasDefaultValueSql("((11272194))");

                entity.Property(e => e.WarningMaximumStock)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");
            });
            modelBuilder.Entity<MaInventoryReasons>(entity =>
{
                entity.HasKey(e => e.Reason)
                    .HasName("PK_InventoryReasons")
                    .IsClustered(false);

                entity.ToTable("MA_InventoryReasons");

                entity.HasIndex(e => e.Description)
                    .HasName("MA_InventoryReasons2");

                entity.Property(e => e.Reason)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Action)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('IIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII')");

                entity.Property(e => e.ActionOnLifoFifo).HasDefaultValueSql("((26411008))");

                entity.Property(e => e.ActionsFiscalDataPhase1)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('IIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII')");

                entity.Property(e => e.ActionsFiscalDataPhase2)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('IIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII')");

                entity.Property(e => e.AlignSpecificator)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CancelReason)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CigcorrInvReason)
                    .HasColumnName("CIGCorrInvReason")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CostAccSign).HasDefaultValueSql("((8912896))");

                entity.Property(e => e.CostAccounting).HasDefaultValueSql("((8519683))");

                entity.Property(e => e.CustSuppType).HasDefaultValueSql("((3866624))");

                entity.Property(e => e.CustomAction)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('IIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII')");

                entity.Property(e => e.DebitCreditSign).HasDefaultValueSql("((4980736))");

                entity.Property(e => e.DefaultReason)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Description)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Disabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DocInfoIsOpt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DocNoIsOpt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.EditableStubBook)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.EditableUnitValue)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.ExtAccountingTemplate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Fifoaction)
                    .HasColumnName("FIFOAction")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('IIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII')");

                entity.Property(e => e.FiscalEnabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.FiscalNumbering)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FiscalPhase1Enabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FiscalPhase2Enabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.GenerateLot)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.GenerateSerialNo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ImPromptInMagoNetSchedule)
                    .HasColumnName("IM_PromptInMagoNetSchedule")
                    .HasDefaultValueSql("((18087936))");

                entity.Property(e => e.InBaseCurrency)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InvoiceFollows)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IsInventoryAdjustement)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IsStorageTransfer)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.LifoFifoLineSource)
                    .HasColumnName("LifoFifo_LineSource")
                    .HasDefaultValueSql("((26476544))");

                entity.Property(e => e.Lifoaction)
                    .HasColumnName("LIFOAction")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('IIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII')");

                entity.Property(e => e.LineCostOrigin).HasDefaultValueSql("((11993091))");

                entity.Property(e => e.LocationsAction)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('IIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII')");

                entity.Property(e => e.LotAction)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('IIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII')");

                entity.Property(e => e.NeedCigcorrection)
                    .HasColumnName("NeedCIGCorrection")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NoChangeExigibility)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NonFiscal)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Predefined)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ProposedValue).HasDefaultValueSql("((3932160))");

                entity.Property(e => e.QtyIsOpt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SearchForBarCode)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ShippingReason)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Specificator1IsMand)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Specificator1Type).HasDefaultValueSql("((6750211))");

                entity.Property(e => e.Specificator2IsMand)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Specificator2Type).HasDefaultValueSql("((6750211))");

                entity.Property(e => e.SpecificatorPhase1)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SpecificatorPhase2)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StoragePhase1)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StoragePhase2)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StubBook)
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

                entity.Property(e => e.UseCommCtgCustomers)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseCommCtgSuppliers)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseCustom)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseFifoaction)
                    .HasColumnName("UseFIFOAction")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseGoodsData)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.UseItemCustomers)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseItemSuppliers)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseLifoaction)
                    .HasColumnName("UseLIFOAction")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseLocations)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseLots)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UsePhase2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseSpecificator1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseSpecificator2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseStorage1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseStorage2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UsedEverywhere)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.UsedInInventory)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UsedInManufacturing)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UsedInPurchases)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UsedInSales)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ValueIsOpt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");
            });
            modelBuilder.Entity<MaItemsFifo>(entity =>
{
                entity.HasKey(e => new { e.Item, e.FiscalYear })
                    .HasName("PK_ItemsFIFO")
                    .IsClustered(false);

                entity.ToTable("MA_ItemsFIFO");

                entity.HasIndex(e => new { e.FiscalYear, e.Item })
                    .HasName("IX_MA_ItemsFIFO_1");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.FinalBookInv).HasDefaultValueSql("((0))");

                entity.Property(e => e.FinalBookInvValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProducedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProducedValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.PurchasesQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.PurchasesValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.RevaluationDone)
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
                    .WithMany(p => p.MaItemsFifo)
                    .HasForeignKey(d => d.Item)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemsFIFO_Items_00");
            });
            modelBuilder.Entity<MaItemsFifodomCurr>(entity =>
{
                entity.HasKey(e => new { e.Item, e.FiscalYear })
                    .HasName("PK_ItemsFIFODomCurr")
                    .IsClustered(false);

                entity.ToTable("MA_ItemsFIFODomCurr");

                entity.HasIndex(e => new { e.FiscalYear, e.Item })
                    .HasName("IX_MA_ItemsFIFODomCurr_1");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.FinalBookInvValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProducedValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.PurchasesValue).HasDefaultValueSql("((0))");

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
                    .WithMany(p => p.MaItemsFifodomCurr)
                    .HasForeignKey(d => d.Item)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemsFIFOD_Items_00");
            });
            modelBuilder.Entity<MaItemsFiscalData>(entity =>
{
                entity.HasKey(e => new { e.FiscalYear, e.FiscalPeriod, e.Storage, e.Item })
                    .HasName("PK_ItemsFiscalData")
                    .IsClustered(false);

                entity.ToTable("MA_ItemsFiscalData");

                entity.HasIndex(e => e.ValueType)
                    .HasName("IX_MA_ItemsFiscalData");

                entity.Property(e => e.FiscalPeriod).HasDefaultValueSql("((1))");

                entity.Property(e => e.Storage)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('-')");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.AllocatedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ApprovedPurchaseReq).HasDefaultValueSql("((0))");

                entity.Property(e => e.Bailment).HasDefaultValueSql("((0))");

                entity.Property(e => e.BookInv).HasDefaultValueSql("((0))");

                entity.Property(e => e.BookInvValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.Cigvalue)
                    .HasColumnName("CIGValue")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CustomQty1).HasDefaultValueSql("((0))");

                entity.Property(e => e.CustomQty2).HasDefaultValueSql("((0))");

                entity.Property(e => e.CustomQty3).HasDefaultValueSql("((0))");

                entity.Property(e => e.CustomQty4).HasDefaultValueSql("((0))");

                entity.Property(e => e.CustomQty5).HasDefaultValueSql("((0))");

                entity.Property(e => e.CustomValue1).HasDefaultValueSql("((0))");

                entity.Property(e => e.CustomValue2).HasDefaultValueSql("((0))");

                entity.Property(e => e.CustomValue3).HasDefaultValueSql("((0))");

                entity.Property(e => e.CustomValue4).HasDefaultValueSql("((0))");

                entity.Property(e => e.CustomValue5).HasDefaultValueSql("((0))");

                entity.Property(e => e.FinalOnHand).HasDefaultValueSql("((0))");

                entity.Property(e => e.ForRepairing).HasDefaultValueSql("((0))");

                entity.Property(e => e.ForSubcontracting).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialBailment).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialBookInv).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialBookInvValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialCustomQty1).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialCustomQty2).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialCustomQty3).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialCustomQty4).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialCustomQty5).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialCustomValue1).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialCustomValue2).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialCustomValue3).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialCustomValue4).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialCustomValue5).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialForRepairing).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialForSubcontracting).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialOnHand).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialOnHandStorageTot).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialReservedCustQuota).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialReservedStorageTot).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialReturnedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialSampleGoods).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialSampling).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialSubcontracting).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialUsedByProduction).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialUsedInProductionValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.InventoryValueCriteria).HasDefaultValueSql("((4259840))");

                entity.Property(e => e.IssuedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.IssuedValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastLotNo).HasDefaultValueSql("((0))");

                entity.Property(e => e.NoAbcvalue)
                    .HasColumnName("NoABCValue")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.OnHandStorageTot).HasDefaultValueSql("((0))");

                entity.Property(e => e.OrderedPurchOrd).HasDefaultValueSql("((0))");

                entity.Property(e => e.OrderedToProd).HasDefaultValueSql("((0))");

                entity.Property(e => e.OrderedToProdIe)
                    .HasColumnName("OrderedToProdIE")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PickedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.PickingValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProducedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProducedValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.PurchasesQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.PurchasesValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReceivedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReceivedValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReservedByProd).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReservedCustQuota).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReservedSaleOrd).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReservedStorageTot).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReturnedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.SalesQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.SalesValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.SampleGoods).HasDefaultValueSql("((0))");

                entity.Property(e => e.Sampling).HasDefaultValueSql("((0))");

                entity.Property(e => e.ScrapQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ScrapsValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.SecondLastCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.StandardCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.Subcontracting).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.UsedInProductionValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.ValueType).HasDefaultValueSql("((11272194))");

                entity.HasOne(d => d.ItemNavigation)
                    .WithMany(p => p.MaItemsFiscalData)
                    .HasForeignKey(d => d.Item)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemsFisca_Items_00");
            });
            modelBuilder.Entity<MaItemsFiscalDataDomCurr>(entity =>
{
                entity.HasKey(e => new { e.FiscalYear, e.FiscalPeriod, e.Item })
                    .HasName("PK_ItemsFiscalDataDomCurr")
                    .IsClustered(false);

                entity.ToTable("MA_ItemsFiscalDataDomCurr");

                entity.Property(e => e.FiscalPeriod).HasDefaultValueSql("((1))");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.BookInvValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialBookInvValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.IssuedValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProducedValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.PurchasesValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReceivedValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.SalesValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.ScrapsValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.SecondLastCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.StandardCost).HasDefaultValueSql("((0))");

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
                    .WithMany(p => p.MaItemsFiscalDataDomCurr)
                    .HasForeignKey(d => d.Item)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemsFisca_Items_01");
            });
            modelBuilder.Entity<MaItemsLifo>(entity =>
{
                entity.HasKey(e => new { e.Item, e.FiscalYear })
                    .HasName("PK_ItemsLIFO")
                    .IsClustered(false);

                entity.ToTable("MA_ItemsLIFO");

                entity.HasIndex(e => new { e.FiscalYear, e.Item })
                    .HasName("IX_MA_ItemsLIFO_1");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.FinalBookInv).HasDefaultValueSql("((0))");

                entity.Property(e => e.FinalBookInvValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RevaluationDone)
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
                    .WithMany(p => p.MaItemsLifo)
                    .HasForeignKey(d => d.Item)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemsLIFO_Items_00");
            });
            modelBuilder.Entity<MaItemsLifodomCurr>(entity =>
{
                entity.HasKey(e => new { e.Item, e.FiscalYear })
                    .HasName("PK_ItemsLIFODomCurr")
                    .IsClustered(false);

                entity.ToTable("MA_ItemsLIFODomCurr");

                entity.HasIndex(e => new { e.FiscalYear, e.Item })
                    .HasName("IX_MA_ItemsLIFODomCurr_1");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.FinalBookInvValue).HasDefaultValueSql("((0))");

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
                    .WithMany(p => p.MaItemsLifodomCurr)
                    .HasForeignKey(d => d.Item)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemsLIFOD_Items_00");
            });
            modelBuilder.Entity<MaItemsMonthlyBalances>(entity =>
{
                entity.HasKey(e => new { e.Storage, e.Item, e.FiscalYear, e.BalanceYear, e.Balance, e.BalanceMonth })
                    .HasName("PK_ItemsMonthlyBalances")
                    .IsClustered(false);

                entity.ToTable("MA_ItemsMonthlyBalances");

                entity.HasIndex(e => new { e.FiscalYear, e.Item })
                    .HasName("IX_MA_ItemsMonthlyBalances_1");

                entity.Property(e => e.Storage)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('-')");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Bailment).HasDefaultValueSql("((0))");

                entity.Property(e => e.BookInv).HasDefaultValueSql("((0))");

                entity.Property(e => e.BookInvValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.Cigvalue)
                    .HasColumnName("CIGValue")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CigvalueForFiscalPeriod)
                    .HasColumnName("CIGValueForFiscalPeriod")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CustomQty1).HasDefaultValueSql("((0))");

                entity.Property(e => e.CustomQty2).HasDefaultValueSql("((0))");

                entity.Property(e => e.CustomQty3).HasDefaultValueSql("((0))");

                entity.Property(e => e.CustomQty4).HasDefaultValueSql("((0))");

                entity.Property(e => e.CustomQty5).HasDefaultValueSql("((0))");

                entity.Property(e => e.CustomValue1).HasDefaultValueSql("((0))");

                entity.Property(e => e.CustomValue2).HasDefaultValueSql("((0))");

                entity.Property(e => e.CustomValue3).HasDefaultValueSql("((0))");

                entity.Property(e => e.CustomValue4).HasDefaultValueSql("((0))");

                entity.Property(e => e.CustomValue5).HasDefaultValueSql("((0))");

                entity.Property(e => e.FinalBookInv).HasDefaultValueSql("((0))");

                entity.Property(e => e.FinalBookInvValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.FinalOnHand).HasDefaultValueSql("((0))");

                entity.Property(e => e.ForRepairing).HasDefaultValueSql("((0))");

                entity.Property(e => e.ForSubcontracting).HasDefaultValueSql("((0))");

                entity.Property(e => e.IssuedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.IssuedValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.OnHandStorageTot).HasDefaultValueSql("((0))");

                entity.Property(e => e.OrderedToProd).HasDefaultValueSql("((0))");

                entity.Property(e => e.PickingValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.PickingValueForFiscalPeriod).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProducedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProducedValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.PurchasesQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.PurchasesValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReceivedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReceivedValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReservedByProd).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReservedStorageTot).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReturnedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.SalesQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.SalesQtyForFiscalPeriod).HasDefaultValueSql("((0))");

                entity.Property(e => e.SalesValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.SalesValueForFiscalPeriod).HasDefaultValueSql("((0))");

                entity.Property(e => e.SampleGoods).HasDefaultValueSql("((0))");

                entity.Property(e => e.Sampling).HasDefaultValueSql("((0))");

                entity.Property(e => e.ScrapQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ScrapsValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.SecondLastCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.Subcontracting).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.UsedInProductionQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.UsedInProductionValue).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.ItemNavigation)
                    .WithMany(p => p.MaItemsMonthlyBalances)
                    .HasForeignKey(d => d.Item)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemsMonth_Items_00");
            });
            modelBuilder.Entity<MaStandardCostHistorical>(entity =>
{
                entity.HasKey(e => new { e.Item, e.ToValueDate })
                    .HasName("PK_StandardCostHistorical")
                    .IsClustered(false);

                entity.ToTable("MA_StandardCostHistorical");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.ToValueDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.FiscalPeriod).HasDefaultValueSql("((1))");

                entity.Property(e => e.OperationType)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.StandardCost).HasDefaultValueSql("((0))");

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
                    .WithMany(p => p.MaStandardCostHistorical)
                    .HasForeignKey(d => d.Item)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StandardCostHi_00");
            });
            modelBuilder.Entity<MaTmpAbc>(entity =>
{
                entity.HasKey(e => e.Item)
                    .HasName("PK_TmpABC")
                    .IsClustered(false);

                entity.ToTable("MA_TmpABC");

                entity.HasIndex(e => e.Value)
                    .HasName("MA_TmpABC2");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Excluded)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Incidence).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.Value).HasDefaultValueSql("((0))");
            });
            modelBuilder.Entity<MaTmpConsolidation>(entity =>
{
                entity.HasKey(e => new { e.EntryId, e.Line })
                    .HasName("PK_TmpConsolidation")
                    .IsClustered(false);

                entity.ToTable("MA_TmpConsolidation");

                entity.Property(e => e.ActionOnLifoFifo).HasDefaultValueSql("((26411008))");

                entity.Property(e => e.ArchiveDocType).HasDefaultValueSql("((3801088))");

                entity.Property(e => e.AutomaticInvValueOnly)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DocNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DocNoForProcedure)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LifoFifoLineSource)
                    .HasColumnName("LifoFifo_LineSource")
                    .HasDefaultValueSql("((26476544))");

                entity.Property(e => e.OrderForProcedure).HasDefaultValueSql("('')");

                entity.Property(e => e.OriginalBoLid)
                    .HasColumnName("OriginalBoLId")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PostingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.StoragePhase1)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StoragePhase2)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SubId).HasDefaultValueSql("((0))");

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
            modelBuilder.Entity<MaTmpFifoprogress>(entity =>
{
                entity.HasKey(e => new { e.Item, e.FiscalYear })
                    .HasName("PK_TmpFIFOProgress")
                    .IsClustered(false);

                entity.ToTable("MA_TmpFIFOProgress");

                entity.Property(e => e.Item)
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

                entity.Property(e => e.Value).HasDefaultValueSql("((0))");
            });
            modelBuilder.Entity<MaTmpInventoryAdjustment>(entity =>
{
                entity.HasKey(e => e.Line)
                    .HasName("PK_TmpInventoryAdjustment")
                    .IsClustered(false);

                entity.ToTable("MA_TmpInventoryAdjustment");

                entity.HasIndex(e => new { e.Item, e.Storage, e.Lot, e.Location })
                    .HasName("MA_TmpInventoryAdjustment3");

                entity.HasIndex(e => new { e.Line, e.Item, e.Storage, e.SpecificatorType, e.Specificator })
                    .HasName("MA_TmpInventoryAdjustment2");

                entity.Property(e => e.Line).ValueGeneratedNever();

                entity.Property(e => e.ActualQty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ActualValue).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.BaseUoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Description)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Difference).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.InUse)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IsSelected)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Item)
                    .IsRequired()
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Lot)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PreviousQty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.PreviousValue).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ProposedValue).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Specificator)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SpecificatorType).HasDefaultValueSql("((6750211))");

                entity.Property(e => e.Storage)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('-')");

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
            modelBuilder.Entity<MaTmpLifoprogress>(entity =>
{
                entity.HasKey(e => new { e.Item, e.FiscalYear })
                    .HasName("PK_TmpLIFOProgress")
                    .IsClustered(false);

                entity.ToTable("MA_TmpLIFOProgress");

                entity.Property(e => e.Item)
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

                entity.Property(e => e.Value).HasDefaultValueSql("((0))");
            });
        }
    }
}
