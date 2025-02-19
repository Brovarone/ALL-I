using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class WarManDbContext : DbContext
    {
        public WarManDbContext()
        {
        }
        public WarManDbContext(DbContextOptions<WarManDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaStoragesManWms> MaStoragesManWms { get; set; }
        public virtual DbSet<MaWmtransferRequest> MaWmtransferRequest { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaStoragesManWms>(entity =>
{
                entity.HasKey(e => new { e.StorageFather, e.StorageChild })
                    .HasName("PK_StoragesManWMS")
                    .IsClustered(false);

                entity.ToTable("MA_StoragesManWMS");

                entity.Property(e => e.StorageFather)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.StorageChild)
                    .HasMaxLength(8)
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
            modelBuilder.Entity<MaWmtransferRequest>(entity =>
{
                entity.HasKey(e => e.Trid)
                    .HasName("PK_WMTransferRequest")
                    .IsClustered(false);

                entity.ToTable("MA_WMTransferRequest");

                entity.Property(e => e.Trid)
                    .HasColumnName("TRID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ConfirmedToqty)
                    .HasColumnName("ConfirmedTOQty")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.DeliveredQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.DocumentId).HasDefaultValueSql("((0))");

                entity.Property(e => e.DocumentNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DocumentType).HasDefaultValueSql("((6684695))");

                entity.Property(e => e.Item)
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

                entity.Property(e => e.Notes)
                    .HasMaxLength(1024)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PickedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.Position).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProcessedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProcessedQtyDiff).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReleasedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReleasedQtyDiff).HasDefaultValueSql("((0))");

                entity.Property(e => e.RequiredDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.RequiredQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.Storage)
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

                entity.Property(e => e.Trnumber)
                    .HasColumnName("TRNumber")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Trstatus)
                    .HasColumnName("TRStatus")
                    .HasDefaultValueSql("((20578308))");

                entity.Property(e => e.UoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
        }
    }
}
