using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class QualityInspectionDbContext : DbContext
    {
        public QualityInspectionDbContext()
        {
        }
        public QualityInspectionDbContext(DbContextOptions<QualityInspectionDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaInspectionNotes> MaInspectionNotes { get; set; }
        public virtual DbSet<MaInspectionNotesAnalRes> MaInspectionNotesAnalRes { get; set; }
        public virtual DbSet<MaInspectionNotesDetail> MaInspectionNotesDetail { get; set; }
        public virtual DbSet<MaInspectionNotesReferences> MaInspectionNotesReferences { get; set; }
        public virtual DbSet<MaInspectionOrderAnalRes> MaInspectionOrderAnalRes { get; set; }
        public virtual DbSet<MaInspectionOrderReferences> MaInspectionOrderReferences { get; set; }
        public virtual DbSet<MaInspectionOrders> MaInspectionOrders { get; set; }
        public virtual DbSet<MaInspectionOrdersDetail> MaInspectionOrdersDetail { get; set; }
        public virtual DbSet<MaItemsAnalysisParameters> MaItemsAnalysisParameters { get; set; }
        public virtual DbSet<MaItemsTechDataDefinition> MaItemsTechDataDefinition { get; set; }
        public virtual DbSet<MaItemsTechnicalData> MaItemsTechnicalData { get; set; }
        public virtual DbSet<MaNonConformityReason> MaNonConformityReason { get; set; }
        public virtual DbSet<MaQltCtrlAnalMet> MaQltCtrlAnalMet { get; set; }
        public virtual DbSet<MaQltCtrlAnalysisArea> MaQltCtrlAnalysisArea { get; set; }
        public virtual DbSet<MaQltCtrlParameters> MaQltCtrlParameters { get; set; }
        public virtual DbSet<MaQltCtrlParametersDesc> MaQltCtrlParametersDesc { get; set; }
        public virtual DbSet<MaQltCtrlParametersResults> MaQltCtrlParametersResults { get; set; }
        public virtual DbSet<MaQltCtrlResults> MaQltCtrlResults { get; set; }
        public virtual DbSet<MaQltCtrlResultsDesc> MaQltCtrlResultsDesc { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaInspectionNotes>(entity =>
{
                entity.HasKey(e => e.InspectionNotesId)
                    .HasName("PK_InspectionNotes")
                    .IsClustered(false);

                entity.ToTable("MA_InspectionNotes");

                entity.HasIndex(e => e.InspectionNotesNo)
                    .HasName("MA_InspectionNotes2");

                entity.HasIndex(e => new { e.InspectionNotesDate, e.InspectionNotesNo })
                    .HasName("MA_InspectionNotes4");

                entity.HasIndex(e => new { e.Supplier, e.InspectionNotesDate })
                    .HasName("MA_InspectionNotes3");

                entity.Property(e => e.InspectionNotesId).ValueGeneratedNever();

                entity.Property(e => e.Archived)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.BoLid)
                    .HasColumnName("BoLId")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ConformingSpecificator1)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ConformingSpecificator1Type).HasDefaultValueSql("((6750211))");

                entity.Property(e => e.ConformingSpecificator2)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ConformingSpecificator2Type).HasDefaultValueSql("((6750211))");

                entity.Property(e => e.ConformingStorage1)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ConformingStorage2)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CrrefType)
                    .HasColumnName("CRRefType")
                    .HasDefaultValueSql("((27066368))");

                entity.Property(e => e.InspectionNotesDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.InspectionNotesNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InternalOrder)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InventoryEntryId).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsCancelled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.LastSubId).HasDefaultValueSql("((0))");

                entity.Property(e => e.NotConfSpecificator1Type).HasDefaultValueSql("((6750211))");

                entity.Property(e => e.NotConfSpecificator2Type).HasDefaultValueSql("((6750211))");

                entity.Property(e => e.NotConformingInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NotConformingSpecificator1)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NotConformingSpecificator2)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NotConformingStorage1)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NotConformingStorage2)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Notes)
                    .HasColumnType("ntext")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PostedToInventory)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Printed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Reference)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Rtsgenerated)
                    .HasColumnName("RTSGenerated")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Rtsid)
                    .HasColumnName("RTSId")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ScrapGenerated)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ScrapInvEntryId).HasDefaultValueSql("((0))");

                entity.Property(e => e.ScrapInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ScrapSpecificator1)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ScrapSpecificator1Type).HasDefaultValueSql("((6750211))");

                entity.Property(e => e.ScrapSpecificator2)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ScrapSpecificator2Type).HasDefaultValueSql("((6750211))");

                entity.Property(e => e.ScrapStorage1)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ScrapStorage2)
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

                entity.Property(e => e.Tbguid)
                    .HasColumnName("TBGuid")
                    .HasDefaultValueSql("(0x00)");

                entity.Property(e => e.Tbmodified)
                    .HasColumnName("TBModified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbmodifiedId).HasColumnName("TBModifiedID");
            });
            modelBuilder.Entity<MaInspectionNotesAnalRes>(entity =>
{
                entity.HasKey(e => new { e.InspectionNotesId, e.Line, e.SubId });

                entity.ToTable("MA_InspectionNotesAnalRes");

                entity.Property(e => e.AnalysisArea).HasDefaultValueSql("((0))");

                entity.Property(e => e.CompilationDate).HasColumnType("datetime");

                entity.Property(e => e.Notes)
                    .HasColumnType("ntext")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Parameter)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Result)
                    .HasMaxLength(32)
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
            modelBuilder.Entity<MaInspectionNotesDetail>(entity =>
{
                entity.HasKey(e => new { e.Line, e.InspectionNotesId })
                    .HasName("PK_InspectionNotesDetail")
                    .IsClustered(false);

                entity.ToTable("MA_InspectionNotesDetail");

                entity.Property(e => e.AnalysisStatus).HasDefaultValueSql("((8388608))");

                entity.Property(e => e.BoLid)
                    .HasColumnName("BoLID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BoLline)
                    .HasColumnName("BoLLine")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BoLsubId)
                    .HasColumnName("BoLSubID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ConsignmentPartner)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CorrectiveAction)
                    .HasMaxLength(256)
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

                entity.Property(e => e.Description)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Discount1).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Discount2).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.DiscountAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.DiscountFormula)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EfficiencyValuation)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InspectionOrderId)
                    .HasColumnName("InspectionOrderID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.InspectionOrderLine).HasDefaultValueSql("((0))");

                entity.Property(e => e.InspectionOrderSubId)
                    .HasColumnName("InspectionOrderSubID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.InternalIdNo)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LineType).HasDefaultValueSql("((9895936))");

                entity.Property(e => e.Location)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Lot)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NoPrint)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NonConformityReason)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Notes)
                    .HasColumnType("ntext")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Qty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.QtyConforming).HasDefaultValueSql("((0))");

                entity.Property(e => e.QtySampleToAnalyze).HasDefaultValueSql("((0))");

                entity.Property(e => e.QtyScrap).HasDefaultValueSql("((0))");

                entity.Property(e => e.QtyToBeReturned).HasDefaultValueSql("((0))");

                entity.Property(e => e.SubId)
                    .HasColumnName("SubID")
                    .HasDefaultValueSql("((0))");

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

                entity.Property(e => e.UnitValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.UoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.InspectionNotes)
                    .WithMany(p => p.MaInspectionNotesDetail)
                    .HasForeignKey(d => d.InspectionNotesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InspNotesDet_InspNotes_00");
            });
            modelBuilder.Entity<MaInspectionNotesReferences>(entity =>
{
                entity.HasKey(e => new { e.InspectionNotesId, e.Line })
                    .HasName("PK_InspNotesReferences")
                    .IsClustered(false);

                entity.ToTable("MA_InspectionNotesReferences");

                entity.Property(e => e.DocumentDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.DocumentId).HasDefaultValueSql("((0))");

                entity.Property(e => e.DocumentNumber)
                    .HasMaxLength(10)
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

                entity.HasOne(d => d.InspectionNotes)
                    .WithMany(p => p.MaInspectionNotesReferences)
                    .HasForeignKey(d => d.InspectionNotesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InspNotesRef_InspNotes_00");
            });
            modelBuilder.Entity<MaInspectionOrderAnalRes>(entity =>
{
                entity.HasKey(e => new { e.InspectionOrderId, e.Line, e.SubId });

                entity.ToTable("MA_InspectionOrderAnalRes");

                entity.Property(e => e.AnalysisArea).HasDefaultValueSql("((0))");

                entity.Property(e => e.CompilationDate).HasColumnType("datetime");

                entity.Property(e => e.Notes)
                    .HasColumnType("ntext")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Parameter)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Result)
                    .HasMaxLength(32)
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
            modelBuilder.Entity<MaInspectionOrderReferences>(entity =>
{
                entity.HasKey(e => new { e.InspectionOrderId, e.Line })
                    .HasName("PK_InspOrdReferences")
                    .IsClustered(false);

                entity.ToTable("MA_InspectionOrderReferences");

                entity.Property(e => e.DocumentDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.DocumentId).HasDefaultValueSql("((0))");

                entity.Property(e => e.DocumentNumber)
                    .HasMaxLength(10)
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

                entity.HasOne(d => d.InspectionOrder)
                    .WithMany(p => p.MaInspectionOrderReferences)
                    .HasForeignKey(d => d.InspectionOrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InspOrdRef_InspOrd_00");
            });
            modelBuilder.Entity<MaInspectionOrders>(entity =>
{
                entity.HasKey(e => e.InspectionOrderId)
                    .HasName("PK_InspectionOrders")
                    .IsClustered(false);

                entity.ToTable("MA_InspectionOrders");

                entity.HasIndex(e => e.InspectionOrderNo)
                    .HasName("MA_InspectionOrders2");

                entity.HasIndex(e => new { e.InspectionOrderDate, e.InspectionOrderNo })
                    .HasName("MA_InspectionOrders4");

                entity.HasIndex(e => new { e.Supplier, e.InspectionOrderDate })
                    .HasName("MA_InspectionOrders3");

                entity.Property(e => e.InspectionOrderId).ValueGeneratedNever();

                entity.Property(e => e.Archived)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.BoLid)
                    .HasColumnName("BoLId")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CrrefId)
                    .HasColumnName("CRRefID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CrrefType)
                    .HasColumnName("CRRefType")
                    .HasDefaultValueSql("((27066368))");

                entity.Property(e => e.ExpectedInspectionDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.InspectionClosed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InspectionDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.InspectionOrderDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.InspectionOrderNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InternalOrder)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InventoryEntryId).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsCancelled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.LastSubId).HasDefaultValueSql("((0))");

                entity.Property(e => e.Moid)
                    .HasColumnName("MOId")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Notes)
                    .HasColumnType("ntext")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PostedToInventory)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Printed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Reference)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SpecificatorPhase1)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SpecificatorPhase2)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SpecificatorTypePhase1).HasDefaultValueSql("((6750211))");

                entity.Property(e => e.SpecificatorTypePhase2).HasDefaultValueSql("((6750211))");

                entity.Property(e => e.StoragePhase1)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StoragePhase2)
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

                entity.Property(e => e.Tbguid)
                    .HasColumnName("TBGuid")
                    .HasDefaultValueSql("(0x00)");

                entity.Property(e => e.Tbmodified)
                    .HasColumnName("TBModified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbmodifiedId).HasColumnName("TBModifiedID");
            });
            modelBuilder.Entity<MaInspectionOrdersDetail>(entity =>
{
                entity.HasKey(e => new { e.Line, e.InspectionOrderId })
                    .HasName("PK_InspectionOrdersDetail")
                    .IsClustered(false);

                entity.ToTable("MA_InspectionOrdersDetail");

                entity.Property(e => e.AltRtgStep).HasDefaultValueSql("((0))");

                entity.Property(e => e.Alternate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BoLid)
                    .HasColumnName("BoLID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BoLline)
                    .HasColumnName("BoLLine")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BoLsubId)
                    .HasColumnName("BoLSubID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ConsignmentPartner)
                    .HasMaxLength(12)
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

                entity.Property(e => e.Description)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Discount1).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Discount2).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.DiscountAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.DiscountFormula)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InspectedQty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.InspectionClosed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InspectionNotesId)
                    .HasColumnName("InspectionNotesID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.InspectionNotesLine).HasDefaultValueSql("((0))");

                entity.Property(e => e.InspectionNotesSubId)
                    .HasColumnName("InspectionNotesSubID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.InternalIdNo)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Location)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Lot)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Moid)
                    .HasColumnName("MOId")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NoPrint)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NoRiepOnInspNotes)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Notes)
                    .HasColumnType("ntext")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Qty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.QtySampleToAnalyze).HasDefaultValueSql("((0))");

                entity.Property(e => e.RtgStep).HasDefaultValueSql("((0))");

                entity.Property(e => e.SubId)
                    .HasColumnName("SubID")
                    .HasDefaultValueSql("((0))");

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

                entity.Property(e => e.UnitValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.UoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.InspectionOrder)
                    .WithMany(p => p.MaInspectionOrdersDetail)
                    .HasForeignKey(d => d.InspectionOrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InspOrdDet_InspOrders_00");
            });
            modelBuilder.Entity<MaItemsAnalysisParameters>(entity =>
{
                entity.HasKey(e => new { e.Item, e.Line });

                entity.ToTable("MA_ItemsAnalysisParameters");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AnalysisMethod)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Customer)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DetectableBound)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Disabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DisabledDate).HasColumnType("datetime");

                entity.Property(e => e.ExpectedResult)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.InsertionDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.LowerBound)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Notes)
                    .HasColumnType("ntext")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Parameter)
                    .HasMaxLength(64)
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

                entity.Property(e => e.ToBePrinted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UoM)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.UpperBound)
                    .HasMaxLength(21)
                    .IsUnicode(false);
            });
            modelBuilder.Entity<MaItemsTechDataDefinition>(entity =>
{
                entity.HasKey(e => new { e.CommodityCtg, e.Name })
                    .HasName("PK_ItemsTechDataDefinition")
                    .IsClustered(false);

                entity.ToTable("MA_ItemsTechDataDefinition");

                entity.Property(e => e.CommodityCtg)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.BoolDefault)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DateDefault)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Deletable)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.LineType).HasDefaultValueSql("((25493504))");

                entity.Property(e => e.Mandatory)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.MaxDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.MaxNumber).HasDefaultValueSql("((0))");

                entity.Property(e => e.MaxString)
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MinDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.MinNumber).HasDefaultValueSql("((0))");

                entity.Property(e => e.MinString)
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NumberDefault).HasDefaultValueSql("((0))");

                entity.Property(e => e.PathDefault)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StringDefault)
                    .HasMaxLength(512)
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
            modelBuilder.Entity<MaItemsTechnicalData>(entity =>
{
                entity.HasKey(e => new { e.Item, e.Name })
                    .HasName("PK_ItemsTechnicalData")
                    .IsClustered(false);

                entity.ToTable("MA_ItemsTechnicalData");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.BoolValue)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DateValue)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NumberValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.PathValue)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StringValue)
                    .HasMaxLength(512)
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
            modelBuilder.Entity<MaNonConformityReason>(entity =>
{
                entity.HasKey(e => e.NonConformityReason)
                    .HasName("PK_NonConformityReason")
                    .IsClustered(false);

                entity.ToTable("MA_NonConformityReason");

                entity.Property(e => e.NonConformityReason)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(32)
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
            modelBuilder.Entity<MaQltCtrlAnalMet>(entity =>
{
                entity.HasKey(e => e.AnalysisMet);

                entity.ToTable("MA_QltCtrlAnalMet");

                entity.Property(e => e.AnalysisMet)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(256)
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
            modelBuilder.Entity<MaQltCtrlAnalysisArea>(entity =>
{
                entity.HasKey(e => e.AnalysisArea)
                    .HasName("PK_AnalysisArea")
                    .IsClustered(false);

                entity.ToTable("MA_QltCtrlAnalysisArea");

                entity.Property(e => e.AnalysisArea).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExternalArea)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

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
            });
            modelBuilder.Entity<MaQltCtrlParameters>(entity =>
{
                entity.HasKey(e => e.Parameter);

                entity.ToTable("MA_QltCtrlParameters");

                entity.Property(e => e.Parameter)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AnalysisMethod)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(256)
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

                entity.Property(e => e.UoM)
                    .HasMaxLength(8)
                    .IsUnicode(false);
            });
            modelBuilder.Entity<MaQltCtrlParametersDesc>(entity =>
{
                entity.HasKey(e => new { e.Parameter, e.Language });

                entity.ToTable("MA_QltCtrlParametersDesc");

                entity.Property(e => e.Parameter)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Language)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(256)
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

                entity.HasOne(d => d.ParameterNavigation)
                    .WithMany(p => p.MaQltCtrlParametersDesc)
                    .HasForeignKey(d => d.Parameter)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ParametersDescParameters");
            });
            modelBuilder.Entity<MaQltCtrlParametersResults>(entity =>
{
                entity.HasKey(e => new { e.Parameter, e.Result });

                entity.ToTable("MA_QltCtrlParametersResults");

                entity.Property(e => e.Parameter)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Result)
                    .HasMaxLength(32)
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

                entity.HasOne(d => d.ParameterNavigation)
                    .WithMany(p => p.MaQltCtrlParametersResults)
                    .HasForeignKey(d => d.Parameter)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ParametersResultsParameters");
            });
            modelBuilder.Entity<MaQltCtrlResults>(entity =>
{
                entity.HasKey(e => e.Result);

                entity.ToTable("MA_QltCtrlResults");

                entity.Property(e => e.Result)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(256)
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
            modelBuilder.Entity<MaQltCtrlResultsDesc>(entity =>
{
                entity.HasKey(e => new { e.ResultDesc, e.Language });

                entity.ToTable("MA_QltCtrlResultsDesc");

                entity.Property(e => e.ResultDesc)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Language)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(32)
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

                entity.HasOne(d => d.ResultDescNavigation)
                    .WithMany(p => p.MaQltCtrlResultsDesc)
                    .HasForeignKey(d => d.ResultDesc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ResultsDescResults");
            });
        }
    }
}
