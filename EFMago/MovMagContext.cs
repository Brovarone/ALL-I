using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

//Ultimo adeguamento mago.net 3.14.21
//Personalizzazioni
//  ALL_SPA - Ordini - 9
// Le tabelle usate in Mago.Net sono
//  ItemFiscalData
//  ItemStorageQty
//  ItemStorageQtyMonthly
//  ItemMonthlyBalances
//  (Lots e variants) + Monthly


namespace EFMago.Models
{
    public partial class MovMagContext : DbContext
    {
        public MovMagContext()
        {
        }

        public MovMagContext(DbContextOptions<MovMagContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaInventoryEntries> MaInventoryEntries { get; set; }
        public virtual DbSet<MaInventoryEntriesDetail> MaInventoryEntriesDetail { get; set; }
        public virtual DbSet<MaInventoryEntriesPhases> MaInventoryEntriesPhases { get; set; }
        public virtual DbSet<MaInventoryEntriesReference> MaInventoryEntriesReference { get; set; }
        public virtual DbSet<MaItemsNoRef> MaItems { get; set; }
        public virtual DbSet<MaItemsFiscalDataNoRef> MaItemsFiscalData { get; set; }
        public virtual DbSet<MaItemsMonthlyBalancesNoRef> MaItemsMonthlyBalances { get; set; }
        public virtual DbSet<MaItemsStorageQtyNoRef> MaItemsStorageQty { get; set; }
        public virtual DbSet<MaItemsStorageQtyMonthlyNoRef> MaItemsStorageQtyMonthly { get; set; }
        public virtual DbSet<MaIdnumbers> MaIdnumbers { get; set; }
    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // if (!optionsBuilder.IsConfigured)
            //  {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            //       optionsBuilder.UseSqlServer("Server=ACERBO\\SQLEXPRESS; Database=DEMON;User Id=sa;Password=euroufficio");
            //   }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

            modelBuilder.Entity<MaInventoryEntriesPhases>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("MA_InventoryEntriesPhases");

                entity.Property(e => e.Cancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CustSupp)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Department)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.DepartureDate).HasColumnType("datetime");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.PostingDate).HasColumnType("datetime");

                entity.Property(e => e.Receipted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Specificator)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Storage)
                    .HasMaxLength(8)
                    .IsUnicode(false);
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
                   
            modelBuilder.Entity<MaItemsNoRef>(entity =>
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
                               
            });

            modelBuilder.Entity<MaItemsFiscalDataNoRef>(entity =>
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
                    .WithMany(p => p.MaItemsFiscalDataNoRef)
                    .HasForeignKey(d => d.Item)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemsFisca_Items_00");
            });

            modelBuilder.Entity<MaItemsMonthlyBalancesNoRef>(entity =>
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
                    .WithMany(p => p.MaItemsMonthlyBalancesNoRef)
                    .HasForeignKey(d => d.Item)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemsMonth_Items_00");
            });
                    
            modelBuilder.Entity<MaItemsStorageQtyNoRef>(entity =>
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
                    .WithMany(p => p.MaItemsStorageQtyNoRef)
                    .HasForeignKey(d => d.Item)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemsStora_Items_00");
                              
            });

            modelBuilder.Entity<MaItemsStorageQtyMonthlyNoRef>(entity =>
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
                    .WithMany(p => p.MaItemsStorageQtyMonthlyNoRef)
                    .HasForeignKey(d => d.Item)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemsStoraMonth_Items_00");
            });

            modelBuilder.Entity<MaIdnumbers>(entity =>
            {
                entity.HasKey(e => e.CodeType)
                    .HasName("PK_IDNumbers")
                    .IsClustered(false);

                entity.ToTable("MA_IDNumbers");

                entity.Property(e => e.CodeType).ValueGeneratedNever();

                entity.Property(e => e.LastId).HasDefaultValueSql("((0))");

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
