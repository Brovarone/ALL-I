using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class BarcodeDbContext : DbContext
    {
        public BarcodeDbContext()
        {
        }
        public BarcodeDbContext(DbContextOptions<BarcodeDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaBarcodeLabel> MaBarcodeLabel { get; set; }
        public virtual DbSet<MaBarcodeParameters> MaBarcodeParameters { get; set; }
        public virtual DbSet<MaBarcodeStructure> MaBarcodeStructure { get; set; }
        public virtual DbSet<MaBarcodeStructureDetails> MaBarcodeStructureDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaBarcodeLabel>(entity =>
{
                entity.HasKey(e => e.NamespaceReport);

                entity.ToTable("MA_BarcodeLabel");

                entity.Property(e => e.NamespaceReport)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.BarcodeStructureCode)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BarcodeStructureCodeAlt1)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BarcodeStructureCodeAlt2)
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
            modelBuilder.Entity<MaBarcodeParameters>(entity =>
{
                entity.ToTable("MA_BarcodeParameters");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AcquireIdNoInScannerForm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.BinBarcodeLength).HasDefaultValueSql("((21))");

                entity.Property(e => e.CancelBarcode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('$$$CANC$$$')");

                entity.Property(e => e.CancelKey).HasDefaultValueSql("((116))");

                entity.Property(e => e.CloseBarcode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('$$$CLSE$$$')");

                entity.Property(e => e.CloseKey).HasDefaultValueSql("((115))");

                entity.Property(e => e.ConformingBarcode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('$$$CONF$$$')");

                entity.Property(e => e.ConformingKey).HasDefaultValueSql("((118))");

                entity.Property(e => e.CreateNewNumbersOnCloseSu)
                    .HasColumnName("CreateNewNumbersOnCloseSU")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Gs1lotExpDatePrev)
                    .HasColumnName("GS1LotExpDatePrev")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InternalIdNoBarcodeLength).HasDefaultValueSql("((16))");

                entity.Property(e => e.ItemBarcodeLength).HasDefaultValueSql("((21))");

                entity.Property(e => e.LogoPicture)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LotBarcodeLength).HasDefaultValueSql("((16))");

                entity.Property(e => e.MobarcodeLength)
                    .HasColumnName("MOBarcodeLength")
                    .HasDefaultValueSql("((10))");

                entity.Property(e => e.NotAssignBarcodeInPuchOrd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NotConfigured)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.PackBarcode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('$$$PACK$$$')");

                entity.Property(e => e.PackKey).HasDefaultValueSql("((113))");

                entity.Property(e => e.PrefixBarcodeStructureLength).HasDefaultValueSql("((4))");

                entity.Property(e => e.PurchOrderBarcodeLength).HasDefaultValueSql("((10))");

                entity.Property(e => e.QtyBarcodeLength).HasDefaultValueSql("((4))");

                entity.Property(e => e.QtyDecBarcodeLength).HasDefaultValueSql("((6))");

                entity.Property(e => e.RejectedBarcode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('$$$RJTD$$$')");

                entity.Property(e => e.RejectedKey).HasDefaultValueSql("((119))");

                entity.Property(e => e.ReturnBarcode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('$$$RETN$$$')");

                entity.Property(e => e.ReturnKey).HasDefaultValueSql("((120))");

                entity.Property(e => e.SaveBarcode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('$$$SAVE$$$')");

                entity.Property(e => e.SaveKey).HasDefaultValueSql("((121))");

                entity.Property(e => e.ScanEnd)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('03')");

                entity.Property(e => e.ScanStart)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('02')");

                entity.Property(e => e.ScrapBarcode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('$$$SCRP$$$')");

                entity.Property(e => e.ScrapKey).HasDefaultValueSql("((122))");

                entity.Property(e => e.SubarcodeLength)
                    .HasColumnName("SUBarcodeLength")
                    .HasDefaultValueSql("((16))");

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

                entity.Property(e => e.ToBeInspBarcode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('$$$INSP$$$')");

                entity.Property(e => e.ToBeInspKey).HasDefaultValueSql("((117))");

                entity.Property(e => e.UoMbarcodeLength)
                    .HasColumnName("UoMBarcodeLength")
                    .HasDefaultValueSql("((8))");

                entity.Property(e => e.UseBarcodeStructure)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseGs1)
                    .HasColumnName("UseGS1")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseIdnumber)
                    .HasColumnName("UseIDNumber")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseItemBarcode)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseItemSupplierBarcode)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseScanStartEnd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseStandardTerminator)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.VolumeBarcodeLength).HasDefaultValueSql("((4))");

                entity.Property(e => e.VolumeDecBarcodeLength).HasDefaultValueSql("((6))");

                entity.Property(e => e.WeightBarcodeLength).HasDefaultValueSql("((4))");

                entity.Property(e => e.WeightDecBarcodeLength).HasDefaultValueSql("((6))");
            });
            modelBuilder.Entity<MaBarcodeStructure>(entity =>
{
                entity.HasKey(e => e.Code);

                entity.ToTable("MA_BarcodeStructure");

                entity.Property(e => e.Code)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.BarcodeType).HasDefaultValueSql("((5636118))");

                entity.Property(e => e.Description)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Disabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PreDefined)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Prefix)
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
            modelBuilder.Entity<MaBarcodeStructureDetails>(entity =>
{
                entity.HasKey(e => new { e.Code, e.Position });

                entity.ToTable("MA_BarcodeStructureDetails");

                entity.Property(e => e.Code)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Data).HasDefaultValueSql("((27721728))");

                entity.Property(e => e.FinalSeparator)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InitialSeparator)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Length).HasDefaultValueSql("((0))");

                entity.Property(e => e.Prefix)
                    .HasMaxLength(2)
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
