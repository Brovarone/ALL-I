using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class VariantsDbContext : DbContext
    {
        public VariantsDbContext()
        {
        }
        public VariantsDbContext(DbContextOptions<VariantsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaVariants> MaVariants { get; set; }
        public virtual DbSet<MaVariantsComponents> MaVariantsComponents { get; set; }
        public virtual DbSet<MaVariantsLabour> MaVariantsLabour { get; set; }
        public virtual DbSet<MaVariantsRouting> MaVariantsRouting { get; set; }
        public virtual DbSet<MaVariantsStorageQty> MaVariantsStorageQty { get; set; }
        public virtual DbSet<MaVariantsStorageQtyMonthly> MaVariantsStorageQtyMonthly { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaVariants>(entity =>
{
                entity.HasKey(e => new { e.Item, e.Variant })
                    .HasName("PK_Variants")
                    .IsClustered(false);

                entity.ToTable("MA_Variants");

                entity.HasIndex(e => new { e.Bom, e.Item })
                    .HasName("MA_Variants3");

                entity.HasIndex(e => new { e.Bom, e.Variant, e.Item })
                    .HasName("MA_Variants2");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Variant)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Bom)
                    .HasColumnName("BOM")
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FromConfigurator)
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
            modelBuilder.Entity<MaVariantsComponents>(entity =>
{
                entity.HasKey(e => new { e.Item, e.Variant, e.Line, e.Bom })
                    .HasName("PK_VariantsComponents")
                    .IsClustered(false);

                entity.ToTable("MA_VariantsComponents");

                entity.HasIndex(e => new { e.Item, e.Variant })
                    .HasName("MA_VariantsComponents3");

                entity.HasIndex(e => new { e.Item, e.Variant, e.BomcomponentsSubId })
                    .HasName("MA_VariantsComponents4");

                entity.HasIndex(e => new { e.Bom, e.BomcomponentsSubId, e.Item, e.Variant })
                    .HasName("MA_VariantsComponents2");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Variant)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Bom)
                    .HasColumnName("BOM")
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.BomcomponentsSubId)
                    .HasColumnName("BOMComponentsSubId")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Component)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ComponentType).HasDefaultValueSql("((7798784))");

                entity.Property(e => e.ComponentVariant)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

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

                entity.Property(e => e.Formula)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Qty).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.SubId).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.ToExplode)
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

                entity.HasOne(d => d.MaVariants)
                    .WithMany(p => p.MaVariantsComponents)
                    .HasForeignKey(d => new { d.Item, d.Variant })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VariantsCo_Variants_00");
            });
            modelBuilder.Entity<MaVariantsLabour>(entity =>
{
                entity.HasKey(e => new { e.Item, e.Variant, e.SubId, e.Line })
                    .HasName("PK_VariantsLabour")
                    .IsClustered(false);

                entity.ToTable("MA_VariantsLabour");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Variant)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Line).ValueGeneratedOnAdd();

                entity.Property(e => e.AltRtgStep).HasDefaultValueSql("((0))");

                entity.Property(e => e.Alternate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AttendancePerc).HasDefaultValueSql("((0))");

                entity.Property(e => e.Bom)
                    .HasColumnName("BOM")
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

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
            modelBuilder.Entity<MaVariantsRouting>(entity =>
{
                entity.HasKey(e => new { e.Item, e.Variant, e.Bom, e.RtgStep, e.Alternate, e.AltRtgStep, e.SubstType })
                    .HasName("PK_VariantsRouting")
                    .IsClustered(false);

                entity.ToTable("MA_VariantsRouting");

                entity.HasIndex(e => new { e.Item, e.Variant })
                    .HasName("MA_VariantsRouting4");

                entity.HasIndex(e => new { e.Item, e.Variant, e.BomroutingSubId })
                    .HasName("MA_VariantsRouting3");

                entity.HasIndex(e => new { e.Bom, e.BomroutingSubId, e.Item, e.Variant })
                    .HasName("MA_VariantsRouting2");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Variant)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Bom)
                    .HasColumnName("BOM")
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Alternate)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.BomroutingSubId)
                    .HasColumnName("BOMRoutingSubId")
                    .HasDefaultValueSql("((0))");

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
                    .HasMaxLength(254)
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

                entity.HasOne(d => d.MaVariants)
                    .WithMany(p => p.MaVariantsRouting)
                    .HasForeignKey(d => new { d.Item, d.Variant })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VariantsRo_Variants_00");
            });
            modelBuilder.Entity<MaVariantsStorageQty>(entity =>
{
                entity.HasKey(e => new { e.FiscalYear, e.FiscalPeriod, e.Item, e.Storage, e.SpecificatorType, e.Specificator, e.Lot, e.Variant })
                    .HasName("PK_VariantsStorageQty")
                    .IsClustered(false);

                entity.ToTable("MA_VariantsStorageQty");

                entity.HasIndex(e => new { e.FiscalYear, e.Storage, e.Item, e.Lot, e.Variant })
                    .HasName("MA_VariantsStorageQtyMonth2");

                entity.HasIndex(e => new { e.FiscalYear, e.FiscalPeriod, e.Storage, e.Item, e.Lot, e.Variant })
                    .HasName("MA_VariantsStorageQty2");

                entity.HasIndex(e => new { e.FiscalYear, e.Storage, e.SpecificatorType, e.Specificator, e.Item, e.Lot, e.Variant })
                    .HasName("MA_VariantsStorageQtyMonth3");

                entity.HasIndex(e => new { e.FiscalYear, e.FiscalPeriod, e.Storage, e.SpecificatorType, e.Specificator, e.Item, e.Lot, e.Variant })
                    .HasName("MA_VariantsStorageQty3");

                entity.Property(e => e.FiscalPeriod).HasDefaultValueSql("((1))");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Storage)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Specificator)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Lot)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Variant)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovedPurchaseReq).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.IssuedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.OrderedPurchOrd).HasDefaultValueSql("((0))");

                entity.Property(e => e.OrderedToProd).HasDefaultValueSql("((0))");

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
            });
            modelBuilder.Entity<MaVariantsStorageQtyMonthly>(entity =>
{
                entity.HasKey(e => new { e.FiscalYear, e.Item, e.Storage, e.SpecificatorType, e.Specificator, e.Lot, e.Variant, e.BalanceYear, e.Balance, e.BalanceMonth })
                    .HasName("PK_VariantsStorageQtyMonthly")
                    .IsClustered(false);

                entity.ToTable("MA_VariantsStorageQtyMonthly");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Storage)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Specificator)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Lot)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Variant)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovedPurchaseReq).HasDefaultValueSql("((0))");

                entity.Property(e => e.IssuedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.OrderedPurchOrd).HasDefaultValueSql("((0))");

                entity.Property(e => e.OrderedToProd).HasDefaultValueSql("((0))");

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
            });
        }
    }
}
