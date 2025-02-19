using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class SingleStepLifoFifoDbContext : DbContext
    {
        public SingleStepLifoFifoDbContext()
        {
        }
        public SingleStepLifoFifoDbContext(DbContextOptions<SingleStepLifoFifoDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaLifofifoparameters> MaLifofifoparameters { get; set; }
        public virtual DbSet<MaReceiptsBatch> MaReceiptsBatch { get; set; }
        public virtual DbSet<MaReceiptsBatchDetail> MaReceiptsBatchDetail { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaLifofifoparameters>(entity =>
{
                entity.HasKey(e => e.LifofifoparametersId)
                    .HasName("PK_LIFOFIFOParameters")
                    .IsClustered(false);

                entity.ToTable("MA_LIFOFIFOParameters");

                entity.Property(e => e.LifofifoparametersId)
                    .HasColumnName("LIFOFIFOParametersId")
                    .ValueGeneratedNever();

                entity.Property(e => e.AllowToModifyUnloadedLoads)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CheckForLoadsAvailaibility).HasDefaultValueSql("((11599872))");

                entity.Property(e => e.ClosingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.EnableBatchTracking)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.RestoreLoadsForRfcasPicking)
                    .HasColumnName("RestoreLoadsForRFCAsPicking")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

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
            modelBuilder.Entity<MaReceiptsBatch>(entity =>
{
                entity.HasKey(e => new { e.ReceiptBatchId, e.IsFifo, e.Storage })
                    .HasName("PK_ReceiptsBatch")
                    .IsClustered(false);

                entity.ToTable("MA_ReceiptsBatch");

                entity.HasIndex(e => e.TotallyConsumedDate)
                    .HasName("MA_ReceiptsBatch3");

                entity.HasIndex(e => new { e.LoadDate, e.TotallyConsumedDate })
                    .HasName("MA_ReceiptsBatch2");

                entity.Property(e => e.IsFifo)
                    .HasColumnName("IsFIFO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Storage)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('-')");

                entity.Property(e => e.ClosedByInvClosing)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.EntryId).HasDefaultValueSql("((0))");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LoadDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Qty).HasDefaultValueSql("((0))");

                entity.Property(e => e.SubId)
                    .HasColumnName("SubID")
                    .HasDefaultValueSql("((0))");

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

                entity.Property(e => e.Temporary)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.TotallyConsumedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");
            });
            modelBuilder.Entity<MaReceiptsBatchDetail>(entity =>
{
                entity.HasKey(e => new { e.ReceiptBatchId, e.IsFifo, e.Storage, e.Line })
                    .HasName("PK_ReceiptsBatchDetail")
                    .IsClustered(false);

                entity.ToTable("MA_ReceiptsBatchDetail");

                entity.Property(e => e.IsFifo)
                    .HasColumnName("IsFIFO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Storage)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('-')");

                entity.Property(e => e.InvEntryId).HasDefaultValueSql("((0))");

                entity.Property(e => e.InvEntrySubId)
                    .HasColumnName("InvEntrySubID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.InvEntryType).HasDefaultValueSql("((11796480))");

                entity.Property(e => e.LineCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.PostingDate)
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

                entity.Property(e => e.Temporary)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");
            });
        }
    }
}
