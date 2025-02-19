using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class SmartCodeDbContext : DbContext
    {
        public SmartCodeDbContext()
        {
        }
        public SmartCodeDbContext(DbContextOptions<SmartCodeDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaSegments> MaSegments { get; set; }
        public virtual DbSet<MaSegmentsComb> MaSegmentsComb { get; set; }
        public virtual DbSet<MaSegmentsCombIsocode> MaSegmentsCombIsocode { get; set; }
        public virtual DbSet<MaSmartCodeParameters> MaSmartCodeParameters { get; set; }
        public virtual DbSet<MaSmartCodes> MaSmartCodes { get; set; }
        public virtual DbSet<MaSmartCodesCombinations> MaSmartCodesCombinations { get; set; }
        public virtual DbSet<MaSmartCodesIsocode> MaSmartCodesIsocode { get; set; }
        public virtual DbSet<MaSmartCodesStructure> MaSmartCodesStructure { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaSegments>(entity =>
{
                entity.HasKey(e => e.Segment)
                    .HasName("PK_Segments")
                    .IsClustered(false);

                entity.ToTable("MA_Segments");

                entity.Property(e => e.Segment)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Length).HasDefaultValueSql("((0))");

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
            modelBuilder.Entity<MaSegmentsComb>(entity =>
{
                entity.HasKey(e => new { e.Segment, e.Combination })
                    .HasName("PK_SegmentsComb")
                    .IsClustered(false);

                entity.ToTable("MA_SegmentsComb");

                entity.Property(e => e.Segment)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Combination)
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

                entity.Property(e => e.Price).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.Weight).HasDefaultValueSql("((0))");
            });
            modelBuilder.Entity<MaSegmentsCombIsocode>(entity =>
{
                entity.HasKey(e => new { e.Segment, e.Combination, e.IsocountryCode })
                    .HasName("PK_SegmentsCombISOCode")
                    .IsClustered(false);

                entity.ToTable("MA_SegmentsCombISOCode");

                entity.Property(e => e.Segment)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Combination)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.IsocountryCode)
                    .HasColumnName("ISOCountryCode")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Price).HasDefaultValueSql("((0))");

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
            modelBuilder.Entity<MaSmartCodeParameters>(entity =>
{
                entity.HasKey(e => e.SmartCodeParametersId)
                    .HasName("PK_SmartCodeParameters")
                    .IsClustered(false);

                entity.ToTable("MA_SmartCodeParameters");

                entity.Property(e => e.SmartCodeParametersId).ValueGeneratedNever();

                entity.Property(e => e.RootLength).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.UseSmartCodes)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");
            });
            modelBuilder.Entity<MaSmartCodes>(entity =>
{
                entity.HasKey(e => e.Root)
                    .HasName("PK_SmartCodes")
                    .IsClustered(false);

                entity.ToTable("MA_SmartCodes");

                entity.Property(e => e.Root)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.BaseUoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CalculatePrice)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CalculateWeight)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CommodityCtg)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ComparableUoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ConvertCoefficientsInUoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Description)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DescriptionDelimiter)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DescriptionSeparator).HasDefaultValueSql("((0))");

                entity.Property(e => e.Disabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FactorDescription)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FactorNo).HasDefaultValueSql("((11665408))");

                entity.Property(e => e.FactorValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.GenerateComparableUoM)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.HomogeneousCtg)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Length).HasDefaultValueSql("((0))");

                entity.Property(e => e.NoOfSegments).HasDefaultValueSql("((0))");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Price).HasDefaultValueSql("((0))");

                entity.Property(e => e.PurchaseOffset)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReferenceUoMcalculatedValue)
                    .HasColumnName("ReferenceUoMCalculatedValue")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SaleOffset)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SegmentSeparator)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SeparatorCode)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SetConversionFactor)
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

                entity.Property(e => e.Weight).HasDefaultValueSql("((0))");
            });
            modelBuilder.Entity<MaSmartCodesCombinations>(entity =>
{
                entity.HasKey(e => new { e.Root, e.Segment, e.Combination })
                    .HasName("PK_SmartCodesCombinations")
                    .IsClustered(false);

                entity.ToTable("MA_SmartCodesCombinations");

                entity.Property(e => e.Root)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Segment)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Combination)
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
            modelBuilder.Entity<MaSmartCodesIsocode>(entity =>
{
                entity.HasKey(e => new { e.Root, e.IsocountryCode })
                    .HasName("PK_SmartCodesISOCode")
                    .IsClustered(false);

                entity.ToTable("MA_SmartCodesISOCode");

                entity.Property(e => e.Root)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.IsocountryCode)
                    .HasColumnName("ISOCountryCode")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Price).HasDefaultValueSql("((0))");

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
            modelBuilder.Entity<MaSmartCodesStructure>(entity =>
{
                entity.HasKey(e => new { e.Root, e.Segment })
                    .HasName("PK_SmartCodesStructure")
                    .IsClustered(false);

                entity.ToTable("MA_SmartCodesStructure");

                entity.Property(e => e.Root)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Segment)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.FactorNo).HasDefaultValueSql("((11665408))");

                entity.Property(e => e.Length).HasDefaultValueSql("((0))");

                entity.Property(e => e.Position).HasDefaultValueSql("((0))");

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
