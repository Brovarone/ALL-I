using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class SpecialTaxDbContext : DbContext
    {
        public SpecialTaxDbContext()
        {
        }
        public SpecialTaxDbContext(DbContextOptions<SpecialTaxDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaDeclarationOfIntent> MaDeclarationOfIntent { get; set; }
        public virtual DbSet<MaDeclarationOfIntentNumbers> MaDeclarationOfIntentNumbers { get; set; }
        public virtual DbSet<MaMarginTax> MaMarginTax { get; set; }
        public virtual DbSet<MaPlafond> MaPlafond { get; set; }
        public virtual DbSet<MaTravelAgencyParameters> MaTravelAgencyParameters { get; set; }
        public virtual DbSet<MaTravelAgencyTax> MaTravelAgencyTax { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaDeclarationOfIntent>(entity =>
{
                entity.HasKey(e => e.DeclId)
                    .HasName("PK_DeclarationOfIntent")
                    .IsClustered(false);

                entity.ToTable("MA_DeclarationOfIntent");

                entity.HasIndex(e => new { e.CustSuppType, e.DeclDate, e.LogNo })
                    .HasName("MA_DeclarationOfIntent3");

                entity.HasIndex(e => new { e.CustSuppType, e.DeclYear, e.LogNo })
                    .HasName("MA_DeclarationOfIntent2");

                entity.Property(e => e.DeclId).ValueGeneratedNever();

                entity.Property(e => e.AnnulmentDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.CustSupp)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustSuppType).HasDefaultValueSql("((3211264))");

                entity.Property(e => e.CustomerDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.CustomerNo)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DeclDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.DeclType).HasDefaultValueSql("((1507330))");

                entity.Property(e => e.DeclYear).HasDefaultValueSql("((0))");

                entity.Property(e => e.DocProtocol)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FromDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.LetterNotes)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LimitAmount).HasDefaultValueSql("((0))");

                entity.Property(e => e.LogNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PrintAnnulmentDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.PrintDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.PrintFileDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.PrintLetterDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Printed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PrintedAnnulment)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PrintedLetter)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PrintedOnFile)
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

                entity.Property(e => e.TelProtocol)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ToDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");
            });
            modelBuilder.Entity<MaDeclarationOfIntentNumbers>(entity =>
{
                entity.HasKey(e => new { e.BalanceYear, e.Received })
                    .HasName("PK_DeclarationOfIntentNumbers")
                    .IsClustered(false);

                entity.ToTable("MA_DeclarationOfIntentNumbers");

                entity.Property(e => e.Received)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DefinitivelyPrinted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.LastDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.LastLogNo).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastPrintingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Suffix)
                    .HasMaxLength(4)
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
            modelBuilder.Entity<MaMarginTax>(entity =>
{
                entity.HasKey(e => new { e.BalanceYear, e.BalanceMonth })
                    .HasName("PK_MarginTax")
                    .IsClustered(false);

                entity.ToTable("MA_MarginTax");

                entity.Property(e => e.ActualPeriodCreditCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.PeriodCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.PeriodRevenue).HasDefaultValueSql("((0))");

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
            modelBuilder.Entity<MaPlafond>(entity =>
{
                entity.HasKey(e => new { e.BalanceYear, e.BalanceMonth })
                    .HasName("PK_Plafond")
                    .IsClustered(false);

                entity.ToTable("MA_Plafond");

                entity.Property(e => e.Eupurchases)
                    .HasColumnName("EUPurchases")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ForecastEupurchases)
                    .HasColumnName("ForecastEUPurchases")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ForecastImporting).HasDefaultValueSql("((0))");

                entity.Property(e => e.ForecastInside).HasDefaultValueSql("((0))");

                entity.Property(e => e.Importing).HasDefaultValueSql("((0))");

                entity.Property(e => e.Inside).HasDefaultValueSql("((0))");

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
            modelBuilder.Entity<MaTravelAgencyParameters>(entity =>
{
                entity.HasKey(e => e.TravelAgencyParametersId)
                    .HasName("PK_TravelAgencyParameters")
                    .IsClustered(false);

                entity.ToTable("MA_TravelAgencyParameters");

                entity.Property(e => e.TravelAgencyParametersId).ValueGeneratedNever();

                entity.Property(e => e.IncludeInTravelVatcalc)
                    .HasColumnName("IncludeInTravelVATCalc")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ShiftAccrualDate)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.TaxRegisterForPurchases)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxRegisterForRetailSales)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxRegisterForSales)
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

                entity.Property(e => e.UseTravelAgencyVatregime)
                    .HasColumnName("UseTravelAgencyVATRegime")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");
            });
            modelBuilder.Entity<MaTravelAgencyTax>(entity =>
{
                entity.HasKey(e => new { e.BalanceYear, e.BalanceMonth })
                    .HasName("PK_TravelAgencyTax")
                    .IsClustered(false);

                entity.ToTable("MA_TravelAgencyTax");

                entity.Property(e => e.ActualPeriodCreditCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.PeriodCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.PeriodRevenue).HasDefaultValueSql("((0))");

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
        }
    }
}
