using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class BillOfMaterialsPlusDbContext : DbContext
    {
        public BillOfMaterialsPlusDbContext()
        {
        }
        public BillOfMaterialsPlusDbContext(DbContextOptions<BillOfMaterialsPlusDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaDrawingsDescription> MaDrawingsDescription { get; set; }
        public virtual DbSet<MaDrawingsRevisions> MaDrawingsRevisions { get; set; }
        public virtual DbSet<MaEco> MaEco { get; set; }
        public virtual DbSet<MaEcocomponents> MaEcocomponents { get; set; }
        public virtual DbSet<MaEcohistory> MaEcohistory { get; set; }
        public virtual DbSet<MaEcolabour> MaEcolabour { get; set; }
        public virtual DbSet<MaEcorouting> MaEcorouting { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaDrawingsDescription>(entity =>
{
                entity.HasKey(e => new { e.Drawing, e.Language })
                    .HasName("PK_DrawingsDescription")
                    .IsClustered(false);

                entity.ToTable("MA_DrawingsDescription");

                entity.HasIndex(e => e.Drawing)
                    .HasName("MA_DrawingsDescription2");

                entity.HasIndex(e => e.Language)
                    .HasName("MA_DrawingsDescription3");

                entity.Property(e => e.Drawing)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Language)
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

                entity.HasOne(d => d.DrawingNavigation)
                    .WithMany(p => p.MaDrawingsDescription)
                    .HasForeignKey(d => d.Drawing)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Drawings_Drawings_01");
            });
            modelBuilder.Entity<MaDrawingsRevisions>(entity =>
{
                entity.HasKey(e => new { e.Drawing, e.Revision })
                    .HasName("PK_DrawingsRevisions")
                    .IsClustered(false);

                entity.ToTable("MA_DrawingsRevisions");

                entity.HasIndex(e => e.Drawing)
                    .HasName("MA_DrawingsRevisions2");

                entity.HasIndex(e => e.Revision)
                    .HasName("MA_DrawingsRevisions3");

                entity.Property(e => e.Drawing)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Revision)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovalDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.ApprovalSignature)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BarCode)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CheckDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.CheckSignature)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExecutionDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.ExecutionSignature)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RevisionDescription)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RevisionDrawingPath)
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

                entity.HasOne(d => d.DrawingNavigation)
                    .WithMany(p => p.MaDrawingsRevisions)
                    .HasForeignKey(d => d.Drawing)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Drawings_Drawings_00");
            });
            modelBuilder.Entity<MaEco>(entity =>
{
                entity.HasKey(e => e.Ecoid)
                    .HasName("PK_ECO")
                    .IsClustered(false);

                entity.ToTable("MA_ECO");

                entity.HasIndex(e => new { e.Bom, e.EcoconfirmationDate })
                    .HasName("MA_ECO2");

                entity.HasIndex(e => new { e.Ecostatus, e.EcoautomaticallyGenerated, e.Ecoid })
                    .HasName("MA_ECO3");

                entity.HasIndex(e => new { e.Bom, e.Variant, e.EcoconfirmationDate, e.Ecorevision })
                    .HasName("MA_ECO4");

                entity.Property(e => e.Ecoid)
                    .HasColumnName("ECOId")
                    .ValueGeneratedNever();

                entity.Property(e => e.Bom)
                    .HasColumnName("BOM")
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

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

                entity.Property(e => e.DwgDrawing)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DwgNotes)
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DwgPosition)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EcoapprovalDate)
                    .HasColumnName("ECOApprovalDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.EcoapprovalSignature)
                    .HasColumnName("ECOApprovalSignature")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EcoautomaticallyGenerated)
                    .HasColumnName("ECOAutomaticallyGenerated")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.EcocheckDate)
                    .HasColumnName("ECOCheckDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.EcocheckSignature)
                    .HasColumnName("ECOCheckSignature")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EcoconfirmationDate)
                    .HasColumnName("ECOConfirmationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.EcocreationDate)
                    .HasColumnName("ECOCreationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.EcoexecutionDate)
                    .HasColumnName("ECOExecutionDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.EcoexecutionSignature)
                    .HasColumnName("ECOExecutionSignature")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EcoimagePath)
                    .HasColumnName("ECOImagePath")
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Econo)
                    .HasColumnName("ECONo")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Econotes)
                    .HasColumnName("ECONotes")
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Ecorevision)
                    .HasColumnName("ECORevision")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Ecostatus)
                    .HasColumnName("ECOStatus")
                    .HasDefaultValueSql("((524288000))");

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

                entity.Property(e => e.Variant)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
            modelBuilder.Entity<MaEcocomponents>(entity =>
{
                entity.HasKey(e => new { e.Ecoid, e.Ecoline })
                    .HasName("PK_ECOComponents")
                    .IsClustered(false);

                entity.ToTable("MA_ECOComponents");

                entity.HasIndex(e => new { e.Bom, e.Bomvariant, e.EcoconfirmationDate, e.Ecoaction })
                    .HasName("MA_ECOComponents_2");

                entity.HasIndex(e => new { e.Bom, e.Bomvariant, e.EcoconfirmationDate, e.Ecorevision })
                    .HasName("MA_ECOComponents_3");

                entity.Property(e => e.Ecoid).HasColumnName("ECOId");

                entity.Property(e => e.Ecoline).HasColumnName("ECOLine");

                entity.Property(e => e.Bom)
                    .HasColumnName("BOM")
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Bomvariant)
                    .HasColumnName("BOMVariant")
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

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

                entity.Property(e => e.Ecoaction)
                    .HasColumnName("ECOAction")
                    .HasDefaultValueSql("((10551296))");

                entity.Property(e => e.EcoconfirmationDate)
                    .HasColumnName("ECOConfirmationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Ecorevision)
                    .HasColumnName("ECORevision")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Ecostatus)
                    .HasColumnName("ECOStatus")
                    .HasDefaultValueSql("((524288000))");

                entity.Property(e => e.EcosubId)
                    .HasColumnName("ECOSubId")
                    .HasDefaultValueSql("((0))");

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

                entity.Property(e => e.Line).HasDefaultValueSql("('0')");

                entity.Property(e => e.NotPostable)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OnVariant)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.OperationSubId).HasDefaultValueSql("((0))");

                entity.Property(e => e.PercQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.Qty).HasDefaultValueSql("((0))");

                entity.Property(e => e.QuestionNo)
                    .HasMaxLength(12)
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

                entity.Property(e => e.VariationType).HasDefaultValueSql("((10551296))");

                entity.Property(e => e.Waste)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.WastePerc).HasDefaultValueSql("((0))");

                entity.Property(e => e.WasteQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.WasteUoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.Eco)
                    .WithMany(p => p.MaEcocomponents)
                    .HasForeignKey(d => d.Ecoid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ECO_Components_00");
            });
            modelBuilder.Entity<MaEcohistory>(entity =>
{
                entity.HasKey(e => e.Ecoid)
                    .HasName("PK_ECOHistory")
                    .IsClustered(false);

                entity.ToTable("MA_ECOHistory");

                entity.Property(e => e.Ecoid)
                    .HasColumnName("ECOId")
                    .ValueGeneratedNever();

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

                entity.Property(e => e.DwgDrawing)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DwgNotes)
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DwgPosition)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

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

                entity.HasOne(d => d.Eco)
                    .WithOne(p => p.MaEcohistory)
                    .HasForeignKey<MaEcohistory>(d => d.Ecoid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ECO_History_00");
            });
            modelBuilder.Entity<MaEcolabour>(entity =>
{
                entity.HasKey(e => new { e.Ecoid, e.EcosubId, e.Line })
                    .HasName("PK_ECOLabour")
                    .IsClustered(false);

                entity.ToTable("MA_ECOLabour");

                entity.Property(e => e.Ecoid).HasColumnName("ECOId");

                entity.Property(e => e.EcosubId).HasColumnName("ECOSubId");

                entity.Property(e => e.Line).ValueGeneratedOnAdd();

                entity.Property(e => e.AltRtgStep).HasDefaultValueSql("((0))");

                entity.Property(e => e.Alternate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AttendancePerc).HasDefaultValueSql("((0))");

                entity.Property(e => e.Ecoaction)
                    .HasColumnName("ECOAction")
                    .HasDefaultValueSql("((10551296))");

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

                entity.Property(e => e.SubstType).HasDefaultValueSql("((10551296))");

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
            modelBuilder.Entity<MaEcorouting>(entity =>
{
                entity.HasKey(e => new { e.Ecoid, e.Ecoline })
                    .HasName("PK_ECORouting")
                    .IsClustered(false);

                entity.ToTable("MA_ECORouting");

                entity.HasIndex(e => new { e.Bom, e.Bomvariant, e.EcoconfirmationDate, e.Ecoaction })
                    .HasName("MA_ECORouting_2");

                entity.HasIndex(e => new { e.Bom, e.Bomvariant, e.EcoconfirmationDate, e.Ecorevision })
                    .HasName("MA_ECORouting_3");

                entity.Property(e => e.Ecoid).HasColumnName("ECOId");

                entity.Property(e => e.Ecoline).HasColumnName("ECOLine");

                entity.Property(e => e.AltRtgStep).HasDefaultValueSql("((0))");

                entity.Property(e => e.Alternate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Bom)
                    .HasColumnName("BOM")
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Bomvariant)
                    .HasColumnName("BOMVariant")
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Ecoaction)
                    .HasColumnName("ECOAction")
                    .HasDefaultValueSql("((10551296))");

                entity.Property(e => e.EcoconfirmationDate)
                    .HasColumnName("ECOConfirmationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Ecorevision)
                    .HasColumnName("ECORevision")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Ecostatus)
                    .HasColumnName("ECOStatus")
                    .HasDefaultValueSql("((524288000))");

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

                entity.Property(e => e.OnVariant)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Operation)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProcessingAttendancePerc).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProcessingTime).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProcessingWorkingTime).HasDefaultValueSql("((0))");

                entity.Property(e => e.Qty).HasDefaultValueSql("((0))");

                entity.Property(e => e.QueueTime).HasDefaultValueSql("((0))");

                entity.Property(e => e.RtgStep).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.VariationType).HasDefaultValueSql("((10551296))");

                entity.Property(e => e.Wc)
                    .HasColumnName("WC")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.Eco)
                    .WithMany(p => p.MaEcorouting)
                    .HasForeignKey(d => d.Ecoid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ECO_Routing_00");
            });
        }
    }
}
