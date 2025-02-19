using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class CurrenciesDbContext : DbContext
    {
        public CurrenciesDbContext()
        {
        }
        public CurrenciesDbContext(DbContextOptions<CurrenciesDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaCurrencies> MaCurrencies { get; set; }
        public virtual DbSet<MaCurrenciesFixing> MaCurrenciesFixing { get; set; }
        public virtual DbSet<MaCurrencyParameters> MaCurrencyParameters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaCurrencies>(entity =>
{
                entity.HasKey(e => e.Currency)
                    .HasName("PK_Currencies")
                    .IsClustered(false);

                entity.ToTable("MA_Currencies");

                entity.Property(e => e.Currency)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.AmountRoundingDigit).HasDefaultValueSql("((0))");

                entity.Property(e => e.AmountRoundingType).HasDefaultValueSql("((786436))");

                entity.Property(e => e.Description)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Disabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InternationalCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IsEucurrency)
                    .HasColumnName("IsEUCurrency")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NoOfDecimals).HasDefaultValueSql("((0))");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Symbol)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxAmountRoundingDigit).HasDefaultValueSql("((0))");

                entity.Property(e => e.TaxAmountRoundingType).HasDefaultValueSql("((786433))");

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
            modelBuilder.Entity<MaCurrenciesFixing>(entity =>
{
                entity.HasKey(e => new { e.Currency, e.ReferredCurrency, e.FixingDate })
                    .HasName("PK_CurrenciesFixing")
                    .IsClustered(false);

                entity.ToTable("MA_CurrenciesFixing");

                entity.Property(e => e.Currency)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.ReferredCurrency)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.FixingDate).HasColumnType("datetime");

                entity.Property(e => e.Fixing).HasDefaultValueSql("((0))");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PurchaseFixing).HasDefaultValueSql("((0))");

                entity.Property(e => e.SaleFixing).HasDefaultValueSql("((0))");

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

                entity.HasOne(d => d.CurrencyNavigation)
                    .WithMany(p => p.MaCurrenciesFixing)
                    .HasForeignKey(d => d.Currency)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Currencies_Currencies_00");
            });
            modelBuilder.Entity<MaCurrencyParameters>(entity =>
{
                entity.HasKey(e => e.CurrencyParametersId)
                    .HasName("PK_CurrencyParameters")
                    .IsClustered(false);

                entity.ToTable("MA_CurrencyParameters");

                entity.Property(e => e.CurrencyParametersId).ValueGeneratedNever();

                entity.Property(e => e.AmountRoundingDigit).HasDefaultValueSql("((0))");

                entity.Property(e => e.AmountRoundingType).HasDefaultValueSql("((786436))");

                entity.Property(e => e.CrossChangeFixDecimals).HasDefaultValueSql("((0))");

                entity.Property(e => e.Currency)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Description)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DomesticCurrency)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EuroConversionDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.EuroCrossChange)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.EuroCurrency)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FixingComboEqual)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FixingComboLess)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FixingComboMaxItems).HasDefaultValueSql("((300))");

                entity.Property(e => e.FixingEqualToDate)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NoOfDecimals).HasDefaultValueSql("((0))");

                entity.Property(e => e.Symbol)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxAmountRoundingDigit).HasDefaultValueSql("((0))");

                entity.Property(e => e.TaxAmountRoundingType).HasDefaultValueSql("((786433))");

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

                entity.Property(e => e.TimestampInFixingDate)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseCurrencyAccounts)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseFixDecInCrossChange)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");
            });
        }
    }
}
