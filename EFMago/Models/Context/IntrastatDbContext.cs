using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class IntrastatDbContext : DbContext
    {
        public IntrastatDbContext()
        {
        }
        public IntrastatDbContext(DbContextOptions<IntrastatDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaCombinedNomenclature> MaCombinedNomenclature { get; set; }
        public virtual DbSet<MaCpa> MaCpa { get; set; }
        public virtual DbSet<MaCpacountries> MaCpacountries { get; set; }
        public virtual DbSet<MaIntra> MaIntra { get; set; }
        public virtual DbSet<MaIntraArrivals1A> MaIntraArrivals1A { get; set; }
        public virtual DbSet<MaIntraArrivals1B> MaIntraArrivals1B { get; set; }
        public virtual DbSet<MaIntraArrivals1C> MaIntraArrivals1C { get; set; }
        public virtual DbSet<MaIntraArrivals1D> MaIntraArrivals1D { get; set; }
        public virtual DbSet<MaIntraDispatches2A> MaIntraDispatches2A { get; set; }
        public virtual DbSet<MaIntraDispatches2B> MaIntraDispatches2B { get; set; }
        public virtual DbSet<MaIntraDispatches2C> MaIntraDispatches2C { get; set; }
        public virtual DbSet<MaIntraDispatches2D> MaIntraDispatches2D { get; set; }
        public virtual DbSet<MaIntraLogNumber> MaIntraLogNumber { get; set; }
        public virtual DbSet<MaTmpIntra> MaTmpIntra { get; set; }
        public virtual DbSet<MaTmpIntraArrivals1A> MaTmpIntraArrivals1A { get; set; }
        public virtual DbSet<MaTmpIntraArrivals1B> MaTmpIntraArrivals1B { get; set; }
        public virtual DbSet<MaTmpIntraArrivals1C> MaTmpIntraArrivals1C { get; set; }
        public virtual DbSet<MaTmpIntraArrivals1D> MaTmpIntraArrivals1D { get; set; }
        public virtual DbSet<MaTmpIntraDispatches2A> MaTmpIntraDispatches2A { get; set; }
        public virtual DbSet<MaTmpIntraDispatches2B> MaTmpIntraDispatches2B { get; set; }
        public virtual DbSet<MaTmpIntraDispatches2C> MaTmpIntraDispatches2C { get; set; }
        public virtual DbSet<MaTmpIntraDispatches2D> MaTmpIntraDispatches2D { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaCombinedNomenclature>(entity =>
{
                entity.HasKey(e => e.CombinedNomenclature)
                    .HasName("PK_CombinedNomenclature")
                    .IsClustered(false);

                entity.ToTable("MA_CombinedNomenclature");

                entity.Property(e => e.CombinedNomenclature)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Disabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SuppUnitCode)
                    .HasMaxLength(20)
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
            modelBuilder.Entity<MaCpa>(entity =>
{
                entity.HasKey(e => e.Cpacode)
                    .HasName("PK_CPA")
                    .IsClustered(false);

                entity.ToTable("MA_CPA");

                entity.Property(e => e.Cpacode)
                    .HasColumnName("CPACode")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Disabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IntraPurchases)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IntraSales)
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
            });
            modelBuilder.Entity<MaCpacountries>(entity =>
{
                entity.HasKey(e => new { e.Cpacode, e.IsocountryCode })
                    .HasName("PK_CPACountries")
                    .IsClustered(false);

                entity.ToTable("MA_CPACountries");

                entity.Property(e => e.Cpacode)
                    .HasColumnName("CPACode")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.IsocountryCode)
                    .HasColumnName("ISOCountryCode")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.IntraSales)
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
            });
            modelBuilder.Entity<MaIntra>(entity =>
{
                entity.HasKey(e => e.IntrastatId)
                    .HasName("PK_Intra")
                    .IsClustered(false);

                entity.ToTable("MA_Intra");

                entity.HasIndex(e => new { e.CustSuppType, e.BalanceYear, e.CustSupp, e.Quarter, e.BalanceMonth, e.JournalEntryId })
                    .HasName("MA_Intra2");

                entity.Property(e => e.IntrastatId).ValueGeneratedNever();

                entity.Property(e => e.AccrualDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.BalanceMonth).HasDefaultValueSql("((0))");

                entity.Property(e => e.BalanceYear).HasDefaultValueSql("((0))");

                entity.Property(e => e.CrrefId)
                    .HasColumnName("CRRefID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CrrefType)
                    .HasColumnName("CRRefType")
                    .HasDefaultValueSql("((27066368))");

                entity.Property(e => e.Currency)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustSupp)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustSuppType).HasDefaultValueSql("((3211264))");

                entity.Property(e => e.Fixing).HasDefaultValueSql("((0))");

                entity.Property(e => e.FixingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.FixingIsManual)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.JournalEntryId).HasDefaultValueSql("((0))");

                entity.Property(e => e.Quarter).HasDefaultValueSql("((0))");

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
            modelBuilder.Entity<MaIntraArrivals1A>(entity =>
{
                entity.HasKey(e => new { e.IntrastatId, e.Line })
                    .HasName("PK_IntraArrivals1A")
                    .IsClustered(false);

                entity.ToTable("MA_IntraArrivals1A");

                entity.HasIndex(e => new { e.IntrastatId, e.CustSuppType, e.CustSupp })
                    .HasName("MA_IntraArrivals1A2");

                entity.Property(e => e.BalanceMonth).HasDefaultValueSql("((0))");

                entity.Property(e => e.BalanceYear).HasDefaultValueSql("((0))");

                entity.Property(e => e.CombinedNomenclature)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CountryOfConsignment)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CountryOfOrigin)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CountryOfTransport)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CountyOfDestination)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustSupp)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustSuppType).HasDefaultValueSql("((3211265))");

                entity.Property(e => e.DeliveryTerms).HasDefaultValueSql("((6160390))");

                entity.Property(e => e.ModeOfTransport).HasDefaultValueSql("((5832706))");

                entity.Property(e => e.NatureOfTransaction).HasDefaultValueSql("((5767168))");

                entity.Property(e => e.NetMass).HasDefaultValueSql("((0))");

                entity.Property(e => e.Notes)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Operation).HasDefaultValueSql("((5898240))");

                entity.Property(e => e.Quarter).HasDefaultValueSql("((0))");

                entity.Property(e => e.StatisticalPurpose).HasDefaultValueSql("((26017792))");

                entity.Property(e => e.StatisticalValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.SuppUnit).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.TotalAmount).HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalAmountDocCurr).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Intrastat)
                    .WithMany(p => p.MaIntraArrivals1A)
                    .HasForeignKey(d => d.IntrastatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IntraArriv_Intra_00");
            });
            modelBuilder.Entity<MaIntraArrivals1B>(entity =>
{
                entity.HasKey(e => new { e.IntrastatId, e.Line })
                    .HasName("PK_IntraArrivals1B")
                    .IsClustered(false);

                entity.ToTable("MA_IntraArrivals1B");

                entity.HasIndex(e => new { e.IntrastatId, e.CustSuppType, e.CustSupp })
                    .HasName("MA_IntraArrivals1B2");

                entity.Property(e => e.BalanceMonth).HasDefaultValueSql("((0))");

                entity.Property(e => e.BalanceYear).HasDefaultValueSql("((0))");

                entity.Property(e => e.CombinedNomenclature)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CorrectionMonth).HasDefaultValueSql("((0))");

                entity.Property(e => e.CorrectionQuarter).HasDefaultValueSql("((0))");

                entity.Property(e => e.CorrectionYear).HasDefaultValueSql("((0))");

                entity.Property(e => e.CountryOfConsignment)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CountryOfOrigin)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CountryOfTransport)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CountyOfDestination)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustSupp)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustSuppType).HasDefaultValueSql("((3211265))");

                entity.Property(e => e.DebitCreditSign).HasDefaultValueSql("((6029313))");

                entity.Property(e => e.DeliveryTerms).HasDefaultValueSql("((6160394))");

                entity.Property(e => e.ModeOfTransport).HasDefaultValueSql("((5832706))");

                entity.Property(e => e.NatureOfTransaction).HasDefaultValueSql("((5767168))");

                entity.Property(e => e.NetMass).HasDefaultValueSql("((0))");

                entity.Property(e => e.Notes)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Operation).HasDefaultValueSql("((5898240))");

                entity.Property(e => e.Quarter).HasDefaultValueSql("((0))");

                entity.Property(e => e.StatisticalPurpose).HasDefaultValueSql("((26017792))");

                entity.Property(e => e.StatisticalValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.SuppUnit).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.TotalAmount).HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalAmountDocCurr).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Intrastat)
                    .WithMany(p => p.MaIntraArrivals1B)
                    .HasForeignKey(d => d.IntrastatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IntraArriv_Intra_01");
            });
            modelBuilder.Entity<MaIntraArrivals1C>(entity =>
{
                entity.HasKey(e => new { e.IntrastatId, e.Line })
                    .HasName("PK_IntraArrivals1C")
                    .IsClustered(false);

                entity.ToTable("MA_IntraArrivals1C");

                entity.HasIndex(e => new { e.IntrastatId, e.CustSuppType, e.CustSupp })
                    .HasName("MA_IntraArrivals1C2");

                entity.Property(e => e.AccrualDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.CountryOfPayment)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Cpacode)
                    .HasColumnName("CPACode")
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustSupp)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustSuppType).HasDefaultValueSql("((3211265))");

                entity.Property(e => e.DocNo)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DocumentDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.IntrastatCollectionType).HasDefaultValueSql("((655360))");

                entity.Property(e => e.IntrastatSupplyType).HasDefaultValueSql("((589824))");

                entity.Property(e => e.ProgNo).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.TotalAmount).HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalAmountDocCurr).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Intrastat)
                    .WithMany(p => p.MaIntraArrivals1C)
                    .HasForeignKey(d => d.IntrastatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IntraArriv_Intra_02");
            });
            modelBuilder.Entity<MaIntraArrivals1D>(entity =>
{
                entity.HasKey(e => new { e.IntrastatId, e.Line })
                    .HasName("PK_IntraArrivals1D")
                    .IsClustered(false);

                entity.ToTable("MA_IntraArrivals1D");

                entity.HasIndex(e => new { e.IntrastatId, e.CustSuppType, e.CustSupp })
                    .HasName("MA_IntraArrivals1D2");

                entity.Property(e => e.AccrualDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.BalanceYear).HasDefaultValueSql("((0))");

                entity.Property(e => e.CountryOfPayment)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Cpacode)
                    .HasColumnName("CPACode")
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustSupp)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustSuppType).HasDefaultValueSql("((3211265))");

                entity.Property(e => e.CustomsSectionCode)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DocNo)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DocumentDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.IntrastatCollectionType).HasDefaultValueSql("((655360))");

                entity.Property(e => e.IntrastatSupplyType).HasDefaultValueSql("((589824))");

                entity.Property(e => e.LogNo)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProgNo).HasDefaultValueSql("((0))");

                entity.Property(e => e.RefIntrastatId).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.TotalAmount).HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalAmountDocCurr).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Intrastat)
                    .WithMany(p => p.MaIntraArrivals1D)
                    .HasForeignKey(d => d.IntrastatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IntraArriv_Intra_03");
            });
            modelBuilder.Entity<MaIntraDispatches2A>(entity =>
{
                entity.HasKey(e => new { e.IntrastatId, e.Line })
                    .HasName("PK_IntraDispatches2A")
                    .IsClustered(false);

                entity.ToTable("MA_IntraDispatches2A");

                entity.HasIndex(e => new { e.IntrastatId, e.CustSuppType, e.CustSupp })
                    .HasName("MA_IntraDispatches2A2");

                entity.Property(e => e.BalanceMonth).HasDefaultValueSql("((0))");

                entity.Property(e => e.BalanceYear).HasDefaultValueSql("((0))");

                entity.Property(e => e.CombinedNomenclature)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CountryOfDestination)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CountryOfTransport)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CountyOfOrigin)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustSupp)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustSuppType).HasDefaultValueSql("((3211264))");

                entity.Property(e => e.DeliveryTerms).HasDefaultValueSql("((5963782))");

                entity.Property(e => e.ModeOfTransport).HasDefaultValueSql("((5832706))");

                entity.Property(e => e.NatureOfTransaction).HasDefaultValueSql("((5767168))");

                entity.Property(e => e.NetMass).HasDefaultValueSql("((0))");

                entity.Property(e => e.Notes)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Operation).HasDefaultValueSql("((5898240))");

                entity.Property(e => e.Quarter).HasDefaultValueSql("((0))");

                entity.Property(e => e.StatisticalPurpose).HasDefaultValueSql("((26017792))");

                entity.Property(e => e.StatisticalValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.SuppUnit).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.TotalAmount).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Intrastat)
                    .WithMany(p => p.MaIntraDispatches2A)
                    .HasForeignKey(d => d.IntrastatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IntraDispa_Intra_00");
            });
            modelBuilder.Entity<MaIntraDispatches2B>(entity =>
{
                entity.HasKey(e => new { e.IntrastatId, e.Line })
                    .HasName("PK_IntraDispatches2B")
                    .IsClustered(false);

                entity.ToTable("MA_IntraDispatches2B");

                entity.HasIndex(e => new { e.IntrastatId, e.CustSuppType, e.CustSupp })
                    .HasName("MA_IntraDispatches2B2");

                entity.Property(e => e.BalanceMonth).HasDefaultValueSql("((0))");

                entity.Property(e => e.BalanceYear).HasDefaultValueSql("((0))");

                entity.Property(e => e.CombinedNomenclature)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CorrectionMonth).HasDefaultValueSql("((0))");

                entity.Property(e => e.CorrectionQuarter).HasDefaultValueSql("((0))");

                entity.Property(e => e.CorrectionYear).HasDefaultValueSql("((0))");

                entity.Property(e => e.CountryOfDestination)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CountryOfTransport)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CountyOfOrigin)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustSupp)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustSuppType).HasDefaultValueSql("((3211264))");

                entity.Property(e => e.DebitCreditSign).HasDefaultValueSql("((6029313))");

                entity.Property(e => e.DeliveryTerms).HasDefaultValueSql("((5963786))");

                entity.Property(e => e.ModeOfTransport).HasDefaultValueSql("((5832706))");

                entity.Property(e => e.NatureOfTransaction).HasDefaultValueSql("((5767168))");

                entity.Property(e => e.NetMass).HasDefaultValueSql("((0))");

                entity.Property(e => e.Notes)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Operation).HasDefaultValueSql("((5898240))");

                entity.Property(e => e.Quarter).HasDefaultValueSql("((0))");

                entity.Property(e => e.StatisticalPurpose).HasDefaultValueSql("((26017792))");

                entity.Property(e => e.StatisticalValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.SuppUnit).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.TotalAmount).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Intrastat)
                    .WithMany(p => p.MaIntraDispatches2B)
                    .HasForeignKey(d => d.IntrastatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IntraDispa_Intra_01");
            });
            modelBuilder.Entity<MaIntraDispatches2C>(entity =>
{
                entity.HasKey(e => new { e.IntrastatId, e.Line })
                    .HasName("PK_IntraDispatches2C")
                    .IsClustered(false);

                entity.ToTable("MA_IntraDispatches2C");

                entity.HasIndex(e => new { e.IntrastatId, e.CustSuppType, e.CustSupp })
                    .HasName("MA_IntraDispatches2C2");

                entity.Property(e => e.AccrualDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.CountryOfPayment)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Cpacode)
                    .HasColumnName("CPACode")
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustSupp)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustSuppType).HasDefaultValueSql("((3211264))");

                entity.Property(e => e.DocNo)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DocumentDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.IntrastatCollectionType).HasDefaultValueSql("((655360))");

                entity.Property(e => e.IntrastatSupplyType).HasDefaultValueSql("((589824))");

                entity.Property(e => e.ProgNo).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.TotalAmount).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Intrastat)
                    .WithMany(p => p.MaIntraDispatches2C)
                    .HasForeignKey(d => d.IntrastatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IntraDispa_Intra_02");
            });
            modelBuilder.Entity<MaIntraDispatches2D>(entity =>
{
                entity.HasKey(e => new { e.IntrastatId, e.Line })
                    .HasName("PK_IntraDispatches2D")
                    .IsClustered(false);

                entity.ToTable("MA_IntraDispatches2D");

                entity.HasIndex(e => new { e.IntrastatId, e.CustSuppType, e.CustSupp })
                    .HasName("MA_IntraDispatches2D2");

                entity.Property(e => e.AccrualDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.BalanceYear).HasDefaultValueSql("((0))");

                entity.Property(e => e.CountryOfPayment)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Cpacode)
                    .HasColumnName("CPACode")
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustSupp)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustSuppType).HasDefaultValueSql("((3211264))");

                entity.Property(e => e.CustomsSectionCode)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DocNo)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DocumentDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.IntrastatCollectionType).HasDefaultValueSql("((655360))");

                entity.Property(e => e.IntrastatSupplyType).HasDefaultValueSql("((589824))");

                entity.Property(e => e.LogNo)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProgNo).HasDefaultValueSql("((0))");

                entity.Property(e => e.RefIntrastatId).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.TotalAmount).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Intrastat)
                    .WithMany(p => p.MaIntraDispatches2D)
                    .HasForeignKey(d => d.IntrastatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IntraDispa_Intra_03");
            });
            modelBuilder.Entity<MaIntraLogNumber>(entity =>
{
                entity.HasKey(e => new { e.BalanceYear, e.BalanceMonth, e.Dispatches, e.LogNo })
                    .IsClustered(false);

                entity.ToTable("MA_IntraLogNumber");

                entity.Property(e => e.Dispatches)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LogNo)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.SendingDate)
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
            });
            modelBuilder.Entity<MaTmpIntra>(entity =>
{
                entity.HasKey(e => new { e.SessionGuid, e.Line })
                    .HasName("PK_TmpIntra")
                    .IsClustered(false);

                entity.ToTable("MA_TmpIntra");

                entity.Property(e => e.BalanceYear)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Contents)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DelegateTaxId)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DetailsSection1).HasDefaultValueSql("((0))");

                entity.Property(e => e.DetailsSection2).HasDefaultValueSql("((0))");

                entity.Property(e => e.DetailsSection3).HasDefaultValueSql("((0))");

                entity.Property(e => e.DetailsSection4).HasDefaultValueSql("((0))");

                entity.Property(e => e.MonthQuarter)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ParticularCase)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Period)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxId)
                    .HasMaxLength(11)
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

                entity.Property(e => e.TotalSection1).HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalSection2).HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalSection3).HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalSection4).HasDefaultValueSql("((0))");

                entity.Property(e => e.Type)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
            modelBuilder.Entity<MaTmpIntraArrivals1A>(entity =>
{
                entity.HasKey(e => new { e.SessionGuid, e.Line })
                    .IsClustered(false);

                entity.ToTable("MA_TmpIntraArrivals1A");

                entity.Property(e => e.Amount).HasDefaultValueSql("((0))");

                entity.Property(e => e.AmountDocCurr).HasDefaultValueSql("((0))");

                entity.Property(e => e.CombinedNomenclature)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CountryOfConsignment)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CountryOfOrigin)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CountyOfDestination)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DeliveryTerms)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Isocode)
                    .HasColumnName("ISOCode")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ModeOfTransport)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NatureOfTransaction)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NetMass).HasDefaultValueSql("((0))");

                entity.Property(e => e.OperationType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Progressive).HasDefaultValueSql("((0))");

                entity.Property(e => e.StatisticalValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.SuppUnit).HasDefaultValueSql("((0))");

                entity.Property(e => e.TaxId)
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
            });
            modelBuilder.Entity<MaTmpIntraArrivals1B>(entity =>
{
                entity.HasKey(e => new { e.SessionGuid, e.Line })
                    .IsClustered(false);

                entity.ToTable("MA_TmpIntraArrivals1B");

                entity.Property(e => e.Amount).HasDefaultValueSql("((0))");

                entity.Property(e => e.AmountDocCurr).HasDefaultValueSql("((0))");

                entity.Property(e => e.BalanceMonth).HasDefaultValueSql("((0))");

                entity.Property(e => e.BalanceYear).HasDefaultValueSql("((0))");

                entity.Property(e => e.CombinedNomenclature)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DebitCreditSign)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Isocode)
                    .HasColumnName("ISOCode")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NatureOfTransaction)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Progressive).HasDefaultValueSql("((0))");

                entity.Property(e => e.Quarter)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StatisticalValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.TaxId)
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
            });
            modelBuilder.Entity<MaTmpIntraArrivals1C>(entity =>
{
                entity.HasKey(e => new { e.SessionGuid, e.Line })
                    .IsClustered(false);

                entity.ToTable("MA_TmpIntraArrivals1C");

                entity.Property(e => e.Amount).HasDefaultValueSql("((0))");

                entity.Property(e => e.AmountDocCurr).HasDefaultValueSql("((0))");

                entity.Property(e => e.CollectionType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CountryOfPayment)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Cpacode)
                    .HasColumnName("CPACode")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DocNo)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DocumentDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Isocode)
                    .HasColumnName("ISOCode")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Progressive).HasDefaultValueSql("((0))");

                entity.Property(e => e.SupplyType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxId)
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
            });
            modelBuilder.Entity<MaTmpIntraArrivals1D>(entity =>
{
                entity.HasKey(e => new { e.SessionGuid, e.Line })
                    .IsClustered(false);

                entity.ToTable("MA_TmpIntraArrivals1D");

                entity.Property(e => e.Amount).HasDefaultValueSql("((0))");

                entity.Property(e => e.AmountDocCurr).HasDefaultValueSql("((0))");

                entity.Property(e => e.BalanceYear).HasDefaultValueSql("((0))");

                entity.Property(e => e.CollectionType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CountryOfPayment)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Cpacode)
                    .HasColumnName("CPACode")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustomsSectionCode)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DocNo)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DocumentDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Isocode)
                    .HasColumnName("ISOCode")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LogNo)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProgNo).HasDefaultValueSql("((0))");

                entity.Property(e => e.Progressive).HasDefaultValueSql("((0))");

                entity.Property(e => e.SupplyType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxId)
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
            });
            modelBuilder.Entity<MaTmpIntraDispatches2A>(entity =>
{
                entity.HasKey(e => new { e.SessionGuid, e.Line })
                    .IsClustered(false);

                entity.ToTable("MA_TmpIntraDispatches2A");

                entity.Property(e => e.Amount).HasDefaultValueSql("((0))");

                entity.Property(e => e.CombinedNomenclature)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CountryOfDestination)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CountyOfOrigin)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DeliveryTerms)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Isocode)
                    .HasColumnName("ISOCode")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ModeOfTransport)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NatureOfTransaction)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NetMass).HasDefaultValueSql("((0))");

                entity.Property(e => e.OperationType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Progressive).HasDefaultValueSql("((0))");

                entity.Property(e => e.StatisticalValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.SuppUnit).HasDefaultValueSql("((0))");

                entity.Property(e => e.TaxId)
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
            });
            modelBuilder.Entity<MaTmpIntraDispatches2B>(entity =>
{
                entity.HasKey(e => new { e.SessionGuid, e.Line })
                    .IsClustered(false);

                entity.ToTable("MA_TmpIntraDispatches2B");

                entity.Property(e => e.Amount).HasDefaultValueSql("((0))");

                entity.Property(e => e.BalanceMonth).HasDefaultValueSql("((0))");

                entity.Property(e => e.BalanceYear).HasDefaultValueSql("((0))");

                entity.Property(e => e.CombinedNomenclature)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DebitCreditSign)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Isocode)
                    .HasColumnName("ISOCode")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NatureOfTransaction)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Progressive).HasDefaultValueSql("((0))");

                entity.Property(e => e.Quarter)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StatisticalValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.TaxId)
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
            });
            modelBuilder.Entity<MaTmpIntraDispatches2C>(entity =>
{
                entity.HasKey(e => new { e.SessionGuid, e.Line })
                    .IsClustered(false);

                entity.ToTable("MA_TmpIntraDispatches2C");

                entity.Property(e => e.Amount).HasDefaultValueSql("((0))");

                entity.Property(e => e.CollectionType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CountryOfPayment)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Cpacode)
                    .HasColumnName("CPACode")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DocNo)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DocumentDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Isocode)
                    .HasColumnName("ISOCode")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Progressive).HasDefaultValueSql("((0))");

                entity.Property(e => e.SupplyType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxId)
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
            });
            modelBuilder.Entity<MaTmpIntraDispatches2D>(entity =>
{
                entity.HasKey(e => new { e.SessionGuid, e.Line })
                    .IsClustered(false);

                entity.ToTable("MA_TmpIntraDispatches2D");

                entity.Property(e => e.Amount).HasDefaultValueSql("((0))");

                entity.Property(e => e.BalanceYear).HasDefaultValueSql("((0))");

                entity.Property(e => e.CollectionType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CountryOfPayment)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Cpacode)
                    .HasColumnName("CPACode")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustomsSectionCode)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DocNo)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DocumentDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Isocode)
                    .HasColumnName("ISOCode")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LogNo)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProgNo).HasDefaultValueSql("((0))");

                entity.Property(e => e.Progressive).HasDefaultValueSql("((0))");

                entity.Property(e => e.SupplyType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxId)
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
            });
        }
    }
}
