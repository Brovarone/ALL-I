using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class BillOfMaterialsDbContext : DbContext
    {
        public BillOfMaterialsDbContext()
        {
        }
        public BillOfMaterialsDbContext(DbContextOptions<BillOfMaterialsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaBillOfMaterials> MaBillOfMaterials { get; set; }
        public virtual DbSet<MaBillOfMaterialsComp> MaBillOfMaterialsComp { get; set; }
        public virtual DbSet<MaBillOfMaterialsDrawings> MaBillOfMaterialsDrawings { get; set; }
        public virtual DbSet<MaBillOfMaterialsQnA> MaBillOfMaterialsQnA { get; set; }
        public virtual DbSet<MaBillOfMaterialsRouting> MaBillOfMaterialsRouting { get; set; }
        public virtual DbSet<MaBomdocumentsParameters> MaBomdocumentsParameters { get; set; }
        public virtual DbSet<MaBomlabour> MaBomlabour { get; set; }
        public virtual DbSet<MaBomparameters> MaBomparameters { get; set; }
        public virtual DbSet<MaBomsimulationCost> MaBomsimulationCost { get; set; }
        public virtual DbSet<MaDrawings> MaDrawings { get; set; }
        public virtual DbSet<MaProdPlanReplacements> MaProdPlanReplacements { get; set; }
        public virtual DbSet<MaProductionPlans> MaProductionPlans { get; set; }
        public virtual DbSet<MaProductionPlansDetail> MaProductionPlansDetail { get; set; }
        public virtual DbSet<MaProductionPlansReferences> MaProductionPlansReferences { get; set; }
        public virtual DbSet<MaTmpBomexplosions> MaTmpBomexplosions { get; set; }
        public virtual DbSet<MaTmpBomimplosions> MaTmpBomimplosions { get; set; }
        public virtual DbSet<MaTmpProdPlanGeneration> MaTmpProdPlanGeneration { get; set; }
        public virtual DbSet<MaTmpProdPlanGenerationRef> MaTmpProdPlanGenerationRef { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaBillOfMaterials>(entity =>
{
                entity.HasKey(e => e.Bom)
                    .HasName("PK_BillOfMaterials")
                    .IsClustered(false);

                entity.ToTable("MA_BillOfMaterials");

                entity.HasIndex(e => e.Description)
                    .HasName("MA_BillOfMaterials4");

                entity.HasIndex(e => new { e.Bom, e.Sf })
                    .HasName("MA_BillOfMaterials2");

                entity.Property(e => e.Bom)
                    .HasColumnName("BOM")
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.CodeType).HasDefaultValueSql("((7798784))");

                entity.Property(e => e.Configurable)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Description)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Disabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InProduction)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.LastModificationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.LastSubId).HasDefaultValueSql("((0))");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SalesDocOnly)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Sf)
                    .HasColumnName("SF")
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

                entity.Property(e => e.UoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UsePercQty)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");
            });
            modelBuilder.Entity<MaBillOfMaterialsComp>(entity =>
{
                entity.HasKey(e => new { e.Bom, e.Line })
                    .HasName("PK_BillOfMaterialsComp")
                    .IsClustered(false);

                entity.ToTable("MA_BillOfMaterialsComp");

                entity.HasIndex(e => e.Bom)
                    .HasName("MA_BillOfMaterialsComp4");

                entity.HasIndex(e => new { e.Bom, e.SubId })
                    .HasName("MA_BillOfMaterialsComp3");

                entity.HasIndex(e => new { e.Bom, e.Component, e.ComponentType })
                    .HasName("MA_BillOfMaterialsComp2");

                entity.Property(e => e.Bom)
                    .HasColumnName("BOM")
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Component)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ComponentType).HasDefaultValueSql("((7798784))");

                entity.Property(e => e.Configurable)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Description)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DnrtgStep)
                    .HasColumnName("DNRtgStep")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Drawing)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EndUseRtgStep).HasDefaultValueSql("((0))");

                entity.Property(e => e.ExternalLineReference).HasDefaultValueSql("((0))");

                entity.Property(e => e.FixedComponent)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FixedQty)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IsKanban)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ItemType)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NotPostable)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OperationSubId).HasDefaultValueSql("((0))");

                entity.Property(e => e.PercQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.Qty).HasDefaultValueSql("((0))");

                entity.Property(e => e.QuestionNo)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ScrapQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ScrapUm)
                    .HasColumnName("ScrapUM")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SetFixedQtyOnMo)
                    .HasColumnName("SetFixedQtyOnMO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.StructureCode)
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

                entity.Property(e => e.TechnicalData)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ToExplode)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.UoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ValidityEndingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.ValidityStartingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Valorize)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.Variant)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Waste)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.WastePerc).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.BomNavigation)
                    .WithMany(p => p.MaBillOfMaterialsComp)
                    .HasForeignKey(d => d.Bom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BillOfMate_BillOfMate_00");
            });
            modelBuilder.Entity<MaBillOfMaterialsDrawings>(entity =>
{
                entity.HasKey(e => e.Bom)
                    .HasName("PK_BillOfMaterialsDrawings")
                    .IsClustered(false);

                entity.ToTable("MA_BillOfMaterialsDrawings");

                entity.Property(e => e.Bom)
                    .HasColumnName("BOM")
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Correction)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Drawing)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(251)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Position)
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

                entity.HasOne(d => d.BomNavigation)
                    .WithOne(p => p.MaBillOfMaterialsDrawings)
                    .HasForeignKey<MaBillOfMaterialsDrawings>(d => d.Bom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BillOfMate_BillOfMate_02");
            });
            modelBuilder.Entity<MaBillOfMaterialsQnA>(entity =>
{
                entity.HasKey(e => new { e.Bom, e.SubId, e.Line })
                    .HasName("PK_BillOfMaterialsQnA")
                    .IsClustered(false);

                entity.ToTable("MA_BillOfMaterialsQnA");

                entity.HasIndex(e => new { e.Bom, e.SubId })
                    .HasName("IX_MA_BillOfMaterialsQnA_1");

                entity.HasIndex(e => new { e.Bom, e.Component, e.ComponentType })
                    .HasName("IX_MA_BillOfMaterialsQnA");

                entity.Property(e => e.Bom)
                    .HasColumnName("BOM")
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.AnswerNo).HasDefaultValueSql("((0))");

                entity.Property(e => e.Component)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ComponentType).HasDefaultValueSql("((7798784))");

                entity.Property(e => e.Description)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IsAdefault)
                    .HasColumnName("IsADefault")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Qty).HasDefaultValueSql("((0))");

                entity.Property(e => e.QuestionNo)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ScrapQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ScrapUm)
                    .HasColumnName("ScrapUM")
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

                entity.Property(e => e.ToExplode)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.UoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ValidityEndingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.ValidityStartingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Variant)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.WastePerc).HasDefaultValueSql("((0))");
            });
            modelBuilder.Entity<MaBillOfMaterialsRouting>(entity =>
{
                entity.HasKey(e => new { e.Bom, e.RtgStep, e.Alternate, e.AltRtgStep })
                    .HasName("PK_BillOfMaterialsRouting")
                    .IsClustered(false);

                entity.ToTable("MA_BillOfMaterialsRouting");

                entity.Property(e => e.Bom)
                    .HasColumnName("BOM")
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Alternate)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.IsWc)
                    .HasColumnName("IsWC")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.LineTypeInDn)
                    .HasColumnName("LineTypeInDN")
                    .HasDefaultValueSql("((24576000))");

                entity.Property(e => e.NoOfProcessingWorkers).HasDefaultValueSql("((0))");

                entity.Property(e => e.NoOfSetupWorkers).HasDefaultValueSql("((0))");

                entity.Property(e => e.Notes)
                    .HasMaxLength(1024)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Operation)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProcessingAttendancePerc).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProcessingTime).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProcessingWorkingTime).HasDefaultValueSql("((0))");

                entity.Property(e => e.Qty).HasDefaultValueSql("((0))");

                entity.Property(e => e.QueueTime).HasDefaultValueSql("((0))");

                entity.Property(e => e.SetupAttendancePerc).HasDefaultValueSql("((0))");

                entity.Property(e => e.SetupTime).HasDefaultValueSql("((0))");

                entity.Property(e => e.SetupWorkingTime).HasDefaultValueSql("((0))");

                entity.Property(e => e.SubId).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.TotalTime)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Wc)
                    .HasColumnName("WC")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.BomNavigation)
                    .WithMany(p => p.MaBillOfMaterialsRouting)
                    .HasForeignKey(d => d.Bom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BillOfMate_BillOfMate_01");
            });
            modelBuilder.Entity<MaBomdocumentsParameters>(entity =>
{
                entity.HasKey(e => new { e.BomparametersId, e.DocumentType })
                    .HasName("PK_BOMDocPars")
                    .IsClustered(false);

                entity.ToTable("MA_BOMDocumentsParameters");

                entity.Property(e => e.BomparametersId).HasColumnName("BOMParametersId");

                entity.Property(e => e.DocumentType).HasDefaultValueSql("((3407873))");

                entity.Property(e => e.ExpandFirstLevelOnly)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FpissueToProdInvRsn)
                    .HasColumnName("FPIssueToProdInvRsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GenerateShortInvEntriesSet)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.RmclearingInvRsn)
                    .HasColumnName("RMClearingInvRsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RmclearingProdInvRsn)
                    .HasColumnName("RMClearingProdInvRsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RmreceiptInvRsn)
                    .HasColumnName("RMReceiptInvRsn")
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

                entity.Property(e => e.WasteDifferentItemInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.WasteInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
            modelBuilder.Entity<MaBomlabour>(entity =>
{
                entity.HasKey(e => new { e.Bom, e.SubId, e.Line })
                    .HasName("PK_BOMLabour")
                    .IsClustered(false);

                entity.ToTable("MA_BOMLabour");

                entity.Property(e => e.Bom)
                    .HasColumnName("BOM")
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Line).ValueGeneratedOnAdd();

                entity.Property(e => e.AltRtgStep).HasDefaultValueSql("((0))");

                entity.Property(e => e.Alternate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AttendancePerc).HasDefaultValueSql("((0))");

                entity.Property(e => e.LabourDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.LabourType).HasDefaultValueSql("((28508160))");

                entity.Property(e => e.NoOfResources).HasDefaultValueSql("((0))");

                entity.Property(e => e.ResourceCode)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ResourceType).HasDefaultValueSql("((27131908))");

                entity.Property(e => e.RtgStep).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.WorkerId)
                    .HasColumnName("WorkerID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.WorkingTime).HasDefaultValueSql("((0))");
            });
            modelBuilder.Entity<MaBomparameters>(entity =>
{
                entity.HasKey(e => e.BomparametersId)
                    .HasName("PK_BOMParameters")
                    .IsClustered(false);

                entity.ToTable("MA_BOMParameters");

                entity.Property(e => e.BomparametersId)
                    .HasColumnName("BOMParametersId")
                    .ValueGeneratedNever();

                entity.Property(e => e.BomcostsConstraint)
                    .HasColumnName("BOMCostsConstraint")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.BominProduction)
                    .HasColumnName("BOMInProduction")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.BomlevelsNo)
                    .HasColumnName("BOMLevelsNo")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ComponentClearing)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ComponentReservation)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CreateBomFromItems)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Ecomandatory)
                    .HasColumnName("ECOMandatory")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.EnableLotOverload)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ExpandFirstLevelOnly)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FpissueToProdInvRsn)
                    .HasColumnName("FPIssueToProdInvRsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GenerateShortInvEntriesSet)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.LineTypeInDn)
                    .HasColumnName("LineTypeInDN")
                    .HasDefaultValueSql("((21037056))");

                entity.Property(e => e.LotIsMandatory)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.MandatoryRevisionEco)
                    .HasColumnName("MandatoryRevisionECO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.MaxNoOfLines).HasDefaultValueSql("((0))");

                entity.Property(e => e.OperationLength).HasDefaultValueSql("((0))");

                entity.Property(e => e.PreferredAlternate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProductionEndFileName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProductionRunFileName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RevWasteDifferentItemInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RevWasteInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RmclearingInvRsn)
                    .HasColumnName("RMClearingInvRsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RmclearingProdInvRsn)
                    .HasColumnName("RMClearingProdInvRsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RmreceiptInvRsn)
                    .HasColumnName("RMReceiptInvRsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RtgStepNumberingType).HasDefaultValueSql("((21037056))");

                entity.Property(e => e.SfpickingValueType)
                    .HasColumnName("SFPickingValueType")
                    .HasDefaultValueSql("((11272194))");

                entity.Property(e => e.SingleLevelKanban)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SlreceiptValueType)
                    .HasColumnName("SLReceiptValueType")
                    .HasDefaultValueSql("((11272194))");

                entity.Property(e => e.SubtractWasteCost)
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

                entity.Property(e => e.UnloadValueType).HasDefaultValueSql("((11272194))");

                entity.Property(e => e.UseBomCostSimulations)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseDefaultSfpickingValue)
                    .HasColumnName("UseDefaultSFPickingValue")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseDefaultSlreceiptValue)
                    .HasColumnName("UseDefaultSLReceiptValue")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseDefaultUnloadValue)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseDocumentsParameters)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ValidityDateMandatory)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.WasteDifferentItemInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.WasteInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.WmsbillOfMaterialsLink)
                    .HasColumnName("WMSBillOfMaterialsLink")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");
            });
            modelBuilder.Entity<MaBomsimulationCost>(entity =>
{
                entity.HasKey(e => e.SimulationBomcost)
                    .HasName("PK_BOMSimulationCost")
                    .IsClustered(false);

                entity.ToTable("MA_BOMSimulationCost");

                entity.Property(e => e.SimulationBomcost)
                    .HasColumnName("SimulationBOMCost")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.AlsoDisabledBom)
                    .HasColumnName("AlsoDisabledBOM")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.AlsoSemifinished)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Alternate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BanksBomsGhost)
                    .HasColumnName("BanksBOMsGhost")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Bomsel)
                    .HasColumnName("BOMSel")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.BomselNone)
                    .HasColumnName("BOMSelNone")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CompRounding)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DefaultComponentValueType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Ecodate)
                    .HasColumnName("ECODate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Ecorevision)
                    .HasColumnName("ECORevision")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EnableLot)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ExplodeAll)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FromBom)
                    .HasColumnName("FromBOM")
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FromItem)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FromVariant)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ItemVariantSel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.LevelSel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NotExplodeVariant)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NrLevels).HasDefaultValueSql("((0))");

                entity.Property(e => e.OnlyExactMatch)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.OnlyValidComponentsCosting)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PreferredSel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ProdCostMemo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ProdParamValueType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.QuantityToCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.Recalculate)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.RoundingValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.ShowResultGrid)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SimulationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.SpecificValueType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.StdCostMemo)
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

                entity.Property(e => e.ToBom)
                    .HasColumnName("ToBOM")
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ToItem)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ToVariant)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UpdateCostDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.UpdateLoads)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseEco)
                    .HasColumnName("UseECO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ValueType).HasDefaultValueSql("((11272194))");

                entity.Property(e => e.VariantItemSel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.VariantSel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");
            });
            modelBuilder.Entity<MaDrawings>(entity =>
{
                entity.HasKey(e => e.Drawing)
                    .HasName("PK_Drawings")
                    .IsClustered(false);

                entity.ToTable("MA_Drawings");

                entity.Property(e => e.Drawing)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovalSignature)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BarCode)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DateOfSignature)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.DerivedFrom)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Description)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FilePath)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PreferredDrawing)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Revision)
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
            modelBuilder.Entity<MaProdPlanReplacements>(entity =>
{
                entity.HasKey(e => new { e.ProductionPlanNo, e.Line, e.Bomlevel })
                    .HasName("PK_ProdPlanReplacements")
                    .IsClustered(false);

                entity.ToTable("MA_ProdPlanReplacements");

                entity.Property(e => e.ProductionPlanNo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Bomlevel).HasColumnName("BOMLevel");

                entity.Property(e => e.BaseUoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BreakingBom)
                    .HasColumnName("BreakingBOM")
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BreakingItem)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BreakingVariant)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Component)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InventoryValueCriteria).HasDefaultValueSql("((11272194))");

                entity.Property(e => e.Lot)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProdPlanLine).HasDefaultValueSql("((0))");

                entity.Property(e => e.Qty).HasDefaultValueSql("((0))");

                entity.Property(e => e.SubId).HasDefaultValueSql("((0))");

                entity.Property(e => e.SubstComp)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SubstCompQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.SubstCompSummQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.SubstCompUoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SubstCompWasteQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.SubstCompWasteSummQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.SubstCompWasteUoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SubstType).HasDefaultValueSql("((7798784))");

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

                entity.Property(e => e.UoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
            modelBuilder.Entity<MaProductionPlans>(entity =>
{
                entity.HasKey(e => e.ProductionPlanId)
                    .HasName("PK_ProductionPlans")
                    .IsClustered(false);

                entity.ToTable("MA_ProductionPlans");

                entity.HasIndex(e => e.Description)
                    .HasName("MA_ProductionPlans3");

                entity.HasIndex(e => e.ProductionPlanNo)
                    .HasName("MA_ProductionPlans2");

                entity.HasIndex(e => new { e.CreationDate, e.ProductionPlanNo, e.ProductionPlanId })
                    .HasName("MA_ProductionPlans4");

                entity.Property(e => e.ProductionPlanId).ValueGeneratedNever();

                entity.Property(e => e.Closed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Description)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GenerateForShortage)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.GeneratedForMrp)
                    .HasColumnName("GeneratedForMRP")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.LastModificationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProductionConfirmDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.ProductionPlanNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProductionRunDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.SemifinishedNetting)
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
            modelBuilder.Entity<MaProductionPlansDetail>(entity =>
{
                entity.HasKey(e => new { e.ProductionPlanId, e.Line })
                    .HasName("PK_ProductionPlansDetail")
                    .IsClustered(false);

                entity.ToTable("MA_ProductionPlansDetail");

                entity.HasIndex(e => new { e.ProductionPlanId, e.Bom })
                    .HasName("MA_ProductionPlansDetail2");

                entity.Property(e => e.Bom)
                    .HasColumnName("BOM")
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Bomlevel)
                    .HasColumnName("BOMLevel")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CostCenter)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Customer)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Drawing)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExpectedDeliveryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.GroupSf)
                    .HasColumnName("GroupSF")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InvEntryId).HasDefaultValueSql("((0))");

                entity.Property(e => e.InvEntryIdComp).HasDefaultValueSql("((0))");

                entity.Property(e => e.InvEntryLine).HasDefaultValueSql("((0))");

                entity.Property(e => e.InventoryValueCriteria).HasDefaultValueSql("((11272194))");

                entity.Property(e => e.Job)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Lot)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PlanStatus).HasDefaultValueSql("((21364736))");

                entity.Property(e => e.Position).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProductionQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReleasedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.RunDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.SaleOrdId).HasDefaultValueSql("((0))");

                entity.Property(e => e.SaleOrdNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SaleOrdQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.SaleOrdUoM)
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

                entity.Property(e => e.UoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UseDefaultValue)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.Variant)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.ProductionPlan)
                    .WithMany(p => p.MaProductionPlansDetail)
                    .HasForeignKey(d => d.ProductionPlanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Production_Production_00");
            });
            modelBuilder.Entity<MaProductionPlansReferences>(entity =>
{
                entity.HasKey(e => new { e.ProductionPlanId, e.Line })
                    .HasName("PK_ProductionPlansReferences")
                    .IsClustered(false);

                entity.ToTable("MA_ProductionPlansReferences");

                entity.Property(e => e.DocumentDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.DocumentId).HasDefaultValueSql("((0))");

                entity.Property(e => e.DocumentNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DocumentType).HasDefaultValueSql("((6684673))");

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

                entity.HasOne(d => d.ProductionPlan)
                    .WithMany(p => p.MaProductionPlansReferences)
                    .HasForeignKey(d => d.ProductionPlanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Production_Production_01");
            });
            modelBuilder.Entity<MaTmpBomexplosions>(entity =>
{
                entity.HasKey(e => new { e.UserName, e.Computer, e.Document, e.Line, e.SimulationBomcost })
                    .HasName("PK_TmpBOMExplosions")
                    .IsClustered(false);

                entity.ToTable("MA_TmpBOMExplosions");

                entity.HasIndex(e => new { e.UserName, e.Computer, e.Document, e.Component, e.CodeType })
                    .HasName("MA_TmpBOMExplosions3");

                entity.HasIndex(e => new { e.UserName, e.Computer, e.Document, e.Line, e.CodeType })
                    .HasName("MA_TmpBOMExplosions2");

                entity.HasIndex(e => new { e.UserName, e.Computer, e.Document, e.Line, e.SimulationBomcost })
                    .HasName("MA_TmpBOMExplosions5");

                entity.HasIndex(e => new { e.UserName, e.Computer, e.Document, e.BreakingBom, e.Bom, e.FixedComponent, e.Component })
                    .HasName("MA_TmpBOMExplosions4");

                entity.Property(e => e.UserName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Computer)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Document)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.SimulationBomcost)
                    .HasColumnName("SimulationBOMCost")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.BaseUoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Bom)
                    .HasColumnName("BOM")
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Bomlevel)
                    .HasColumnName("BOMLevel")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Bomvariant)
                    .HasColumnName("BOMVariant")
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BreakingBom)
                    .HasColumnName("BreakingBOM")
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BreakingItem)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BreakingVariant)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodeType).HasDefaultValueSql("((7798784))");

                entity.Property(e => e.Component)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ComponentDescription)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ComponentVariant)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Configurable)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Cost).HasDefaultValueSql("((0))");

                entity.Property(e => e.CostCenter)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FixedComponent)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FixedQty)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InhouseProcessingCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.InventoryValueCriteria).HasDefaultValueSql("((11272194))");

                entity.Property(e => e.IsAbom)
                    .HasColumnName("IsABOM")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IsArtgStep)
                    .HasColumnName("IsARtgStep")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IsAsf)
                    .HasColumnName("IsASF")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IsFromVariant)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

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

                entity.Property(e => e.Job)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Lot)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Operation)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OutsourcedProcessingCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.ParentBom)
                    .HasColumnName("ParentBOM")
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ParentBomsubId)
                    .HasColumnName("ParentBOMSubId")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ParentItem)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ParentVariant)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProdPlanLine).HasDefaultValueSql("((0))");

                entity.Property(e => e.PurchaseCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.Qty).HasDefaultValueSql("((0))");

                entity.Property(e => e.QuestionNo)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RtgStepProcessingTime).HasDefaultValueSql("((0))");

                entity.Property(e => e.RtgStepSetupTime).HasDefaultValueSql("((0))");

                entity.Property(e => e.SaleOrdId).HasDefaultValueSql("((0))");

                entity.Property(e => e.SaleOrdPosition).HasDefaultValueSql("((0))");

                entity.Property(e => e.ScrapQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ScrapQtySummary).HasDefaultValueSql("((0))");

                entity.Property(e => e.ScrapUm)
                    .HasColumnName("ScrapUM")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SetupCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.SubId).HasDefaultValueSql("((0))");

                entity.Property(e => e.SummaryQty).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.TotalTime)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ValidityEndingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.ValidityStartingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Valorize)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.Waste)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
            modelBuilder.Entity<MaTmpBomimplosions>(entity =>
{
                entity.HasKey(e => new { e.UserName, e.Computer, e.Document, e.Line })
                    .HasName("PK_TmpBOMImplosions")
                    .IsClustered(false);

                entity.ToTable("MA_TmpBOMImplosions");

                entity.HasIndex(e => new { e.UserName, e.Computer, e.Document, e.Component, e.ComponentType })
                    .HasName("MA_TmpBOMImplosions2");

                entity.Property(e => e.UserName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Computer)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Document)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.BaseUoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BaseUoMqty)
                    .HasColumnName("BaseUoMQty")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Bomlevel)
                    .HasColumnName("BOMLevel")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Component)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ComponentType).HasDefaultValueSql("((0))");

                entity.Property(e => e.Description)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MaxNoOfLevels).HasDefaultValueSql("((0))");

                entity.Property(e => e.OriginatorComponent)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Qty).HasDefaultValueSql("((0))");

                entity.Property(e => e.RefComponent)
                    .HasMaxLength(21)
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

                entity.Property(e => e.ValidityEndingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.ValidityStartingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Variant)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
            modelBuilder.Entity<MaTmpProdPlanGeneration>(entity =>
{
                entity.HasKey(e => new { e.Item, e.Variant, e.ReferenceDocNo, e.Position })
                    .HasName("PK_TmpProdPlanGeneration")
                    .IsClustered(false);

                entity.ToTable("MA_TmpProdPlanGeneration");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Variant)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.ReferenceDocNo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.BaseUoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CostCenter)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Description)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Drawing)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExpectedDeliveryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.InProduction).HasDefaultValueSql("((0))");

                entity.Property(e => e.Job)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MinimumStock).HasDefaultValueSql("((0))");

                entity.Property(e => e.NoProduction)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.OnHand).HasDefaultValueSql("((0))");

                entity.Property(e => e.Production).HasDefaultValueSql("((0))");

                entity.Property(e => e.RefDocDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Reserved).HasDefaultValueSql("((0))");

                entity.Property(e => e.SaleOrdId).HasDefaultValueSql("((0))");

                entity.Property(e => e.SaleOrdQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.SaleOrdUoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ShortageAvoided)
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

                entity.Property(e => e.UoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
            modelBuilder.Entity<MaTmpProdPlanGenerationRef>(entity =>
{
                entity.HasKey(e => new { e.SaleOrdId, e.SaleOrdLine })
                    .HasName("PK_TmpProdPlanGenerationRef")
                    .IsClustered(false);

                entity.ToTable("MA_TmpProdPlanGenerationRef");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RefDocDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.ReferenceDocNo)
                    .HasMaxLength(10)
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
