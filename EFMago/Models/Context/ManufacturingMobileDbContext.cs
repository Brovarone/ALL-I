using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class ManufacturingMobileDbContext : DbContext
    {
        public ManufacturingMobileDbContext()
        {
        }
        public ManufacturingMobileDbContext(DbContextOptions<ManufacturingMobileDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaManMobileParameters> MaManMobileParameters { get; set; }
        public virtual DbSet<MaMttransferData> MaMttransferData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaManMobileParameters>(entity =>
{
                entity.HasKey(e => e.ManMobileParametersId)
                    .HasName("PK_ManMobileParameters")
                    .IsClustered(false);

                entity.ToTable("MA_ManMobileParameters");

                entity.Property(e => e.ManMobileParametersId).ValueGeneratedNever();

                entity.Property(e => e.AllowEmptyItem)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.AllowEmptyLot)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.BlockMo)
                    .HasColumnName("BlockMO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.CheckPickings)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.EditItem)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.EditLot)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.EnableConfirmationByHandHeld)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.MaxThreads).HasDefaultValueSql("((1))");

                entity.Property(e => e.MoconfirmationRetries)
                    .HasColumnName("MOConfirmationRetries")
                    .HasDefaultValueSql("((3))");

                entity.Property(e => e.MoconfirmationSeconds)
                    .HasColumnName("MOConfirmationSeconds")
                    .HasDefaultValueSql("((60))");

                entity.Property(e => e.MonitorRefresh).HasDefaultValueSql("((10))");

                entity.Property(e => e.ReorderUseAvailability)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.RetryBeforeIdle).HasDefaultValueSql("((30))");

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
            modelBuilder.Entity<MaMttransferData>(entity =>
{
                entity.HasKey(e => e.AutoId)
                    .HasName("PK_MTTransferData")
                    .IsClustered(false);

                entity.ToTable("MA_MTTransferData");

                entity.HasIndex(e => e.Guid)
                    .HasName("IX_MA_MTTransferData_2");

                entity.HasIndex(e => new { e.RecordType, e.Mbresource, e.Item, e.AutoId })
                    .HasName("IX_MA_MTTransferData_1");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.AltRtgStep).HasDefaultValueSql("((0))");

                entity.Property(e => e.Alternate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BarcodeSegment)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CloseMo)
                    .HasColumnName("CloseMO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Closed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CostCenter)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DocumentId)
                    .HasColumnName("DocumentID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DocumentNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DueDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.ErrorMsg)
                    .HasColumnType("ntext")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Guid)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InProcess)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InProcessFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ItemType).HasDefaultValueSql("((24641536))");

                entity.Property(e => e.Job)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LeadTime).HasDefaultValueSql("((0))");

                entity.Property(e => e.Line).HasDefaultValueSql("((0))");

                entity.Property(e => e.Lot)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MacAddress)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Mbresource)
                    .HasColumnName("MBResource")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Mostatus)
                    .HasColumnName("MOStatus")
                    .HasDefaultValueSql("((20578308))");

                entity.Property(e => e.Notes)
                    .HasMaxLength(132)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Operation)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProcessingQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProcessingTime).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProductionQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.Qty).HasDefaultValueSql("((0))");

                entity.Property(e => e.RecordType).HasDefaultValueSql("((28639232))");

                entity.Property(e => e.RetryForError).HasDefaultValueSql("((0))");

                entity.Property(e => e.RtgStep).HasDefaultValueSql("((0))");

                entity.Property(e => e.Scrap)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ScrapQuantity).HasDefaultValueSql("((0))");

                entity.Property(e => e.ScrapVariant)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SecondRate)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SecondRateQuantity).HasDefaultValueSql("((0))");

                entity.Property(e => e.SecondRateVariant)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SetupTime).HasDefaultValueSql("((0))");

                entity.Property(e => e.StillToProduceQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.Storage)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SyncStatus).HasDefaultValueSql("((27852801))");

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

                entity.Property(e => e.Transferred)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Variant)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Wc)
                    .HasColumnName("WC")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
        }
    }
}
