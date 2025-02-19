using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class RoutingDbContext : DbContext
    {
        public RoutingDbContext()
        {
        }
        public RoutingDbContext(DbContextOptions<RoutingDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaFactory> MaFactory { get; set; }
        public virtual DbSet<MaOperations> MaOperations { get; set; }
        public virtual DbSet<MaOperationsLabour> MaOperationsLabour { get; set; }
        public virtual DbSet<MaWcfamilies> MaWcfamilies { get; set; }
        public virtual DbSet<MaWcfamiliesDetails> MaWcfamiliesDetails { get; set; }
        public virtual DbSet<MaWorkCenters> MaWorkCenters { get; set; }
        public virtual DbSet<MaWorkCentersBreakdown> MaWorkCentersBreakdown { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaFactory>(entity =>
{
                entity.HasKey(e => e.Factory)
                    .HasName("PK_Factory")
                    .IsClustered(false);

                entity.ToTable("MA_Factory");

                entity.Property(e => e.Factory)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.DefaultExtScrapStorage)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DefaultExtSecondRateStorage)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DefaultExtSfstorage)
                    .HasColumnName("DefaultExtSFStorage")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DefaultExtStorage)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DefaultScrapStorage)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DefaultSecondRateStorage)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DefaultSfstorage)
                    .HasColumnName("DefaultSFStorage")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DefaultStorage)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Description)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(1024)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PickingExtStorage)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PickingExtStorageSf)
                    .HasColumnName("PickingExtStorageSF")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PickingStorage)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PickingStorageSemifinished)
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

                entity.Property(e => e.WasteDifferentItemStorage)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.WasteStorage)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
            modelBuilder.Entity<MaOperations>(entity =>
{
                entity.HasKey(e => e.Operation)
                    .HasName("PK_Operations")
                    .IsClustered(false);

                entity.ToTable("MA_Operations");

                entity.Property(e => e.Operation)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.AdditionalCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.CostsOnQty)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Description)
                    .HasMaxLength(96)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.HourlyCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsWc)
                    .HasColumnName("IsWC")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastModificationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.NoOfProcessingWorkers).HasDefaultValueSql("((0))");

                entity.Property(e => e.NoOfSetupWorkers).HasDefaultValueSql("((0))");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OperationDescriptionFile)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProcessingAttendancePerc).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProcessingTeam)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProcessingTime).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProcessingWorkingTime).HasDefaultValueSql("((0))");

                entity.Property(e => e.QueueTime).HasDefaultValueSql("((0))");

                entity.Property(e => e.SetupAttendancePerc).HasDefaultValueSql("((0))");

                entity.Property(e => e.SetupTeam)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SetupTime).HasDefaultValueSql("((0))");

                entity.Property(e => e.SetupWorkingTime).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.TotalTime)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UnitCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.Wc)
                    .HasColumnName("WC")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
            modelBuilder.Entity<MaOperationsLabour>(entity =>
{
                entity.HasKey(e => new { e.Operation, e.Line })
                    .HasName("PK_OperationsLabour")
                    .IsClustered(false);

                entity.ToTable("MA_OperationsLabour");

                entity.Property(e => e.Operation)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Line).ValueGeneratedOnAdd();

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

                entity.HasOne(d => d.OperationNavigation)
                    .WithMany(p => p.MaOperationsLabour)
                    .HasForeignKey(d => d.Operation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MA_OperationsLabour_Operations");
            });
            modelBuilder.Entity<MaWcfamilies>(entity =>
{
                entity.HasKey(e => e.Wcfamily)
                    .HasName("PK_WCFamily")
                    .IsClustered(false);

                entity.ToTable("MA_WCFamilies");

                entity.Property(e => e.Wcfamily)
                    .HasColumnName("WCFamily")
                    .HasMaxLength(8)
                    .IsUnicode(false);

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
            modelBuilder.Entity<MaWcfamiliesDetails>(entity =>
{
                entity.HasKey(e => new { e.Wcfamily, e.Wc })
                    .HasName("PK_WCFamiliesDetails")
                    .IsClustered(false);

                entity.ToTable("MA_WCFamiliesDetails");

                entity.Property(e => e.Wcfamily)
                    .HasColumnName("WCFamily")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Wc)
                    .HasColumnName("WC")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Preferential)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

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

                entity.HasOne(d => d.WcNavigation)
                    .WithMany(p => p.MaWcfamiliesDetails)
                    .HasForeignKey(d => d.Wc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WCFamiliesDetails_00");
            });
            modelBuilder.Entity<MaWorkCenters>(entity =>
{
                entity.HasKey(e => e.Wc)
                    .HasName("PK_WorkCenters")
                    .IsClustered(false);

                entity.ToTable("MA_WorkCenters");

                entity.Property(e => e.Wc)
                    .HasColumnName("WC")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.AdditionalCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.AverageCapacity).HasDefaultValueSql("((0))");

                entity.Property(e => e.Calendar)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Description)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.HourlyCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.Make)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ManagerId)
                    .HasColumnName("ManagerID")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Outsourced)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PlacedInServiceDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.PurchaseDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.ResourceNo).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.Template)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UnitCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.WorkType).HasDefaultValueSql("((24772608))");
            });
            modelBuilder.Entity<MaWorkCentersBreakdown>(entity =>
{
                entity.HasKey(e => new { e.Wc, e.ExpectedStarting })
                    .HasName("PK_WorkCentersBreakdown")
                    .IsClustered(false);

                entity.ToTable("MA_WorkCentersBreakdown");

                entity.Property(e => e.Wc)
                    .HasColumnName("WC")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.ExpectedStarting).HasColumnType("datetime");

                entity.Property(e => e.EndingTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.ExpectedEnding)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.ManagerId)
                    .HasColumnName("ManagerID")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Reason)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ResourceNo).HasDefaultValueSql("((0))");

                entity.Property(e => e.StartingTime)
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

                entity.HasOne(d => d.WcNavigation)
                    .WithMany(p => p.MaWorkCentersBreakdown)
                    .HasForeignKey(d => d.Wc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkCenter_WorkCenter_00");
            });
        }
    }
}
