using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class FixedAssetsDbContext : DbContext
    {
        public FixedAssetsDbContext()
        {
        }
        public FixedAssetsDbContext(DbContextOptions<FixedAssetsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaFixAssetEntries> MaFixAssetEntries { get; set; }
        public virtual DbSet<MaFixAssetEntriesDetail> MaFixAssetEntriesDetail { get; set; }
        public virtual DbSet<MaFixAssetLocations> MaFixAssetLocations { get; set; }
        public virtual DbSet<MaFixAssetsClasses> MaFixAssetsClasses { get; set; }
        public virtual DbSet<MaFixAssetsCtg> MaFixAssetsCtg { get; set; }
        public virtual DbSet<MaFixAssetsDeprTemplates> MaFixAssetsDeprTemplates { get; set; }
        public virtual DbSet<MaFixAssetsDeprTemplatesCoeff> MaFixAssetsDeprTemplatesCoeff { get; set; }
        public virtual DbSet<MaFixAssetsParameters> MaFixAssetsParameters { get; set; }
        public virtual DbSet<MaFixAssetsParametersCoeff> MaFixAssetsParametersCoeff { get; set; }
        public virtual DbSet<MaFixAssetsPeriodData> MaFixAssetsPeriodData { get; set; }
        public virtual DbSet<MaFixAssetsReasons> MaFixAssetsReasons { get; set; }
        public virtual DbSet<MaFixedAssets> MaFixedAssets { get; set; }
        public virtual DbSet<MaFixedAssetsBalance> MaFixedAssetsBalance { get; set; }
        public virtual DbSet<MaFixedAssetsCoeff> MaFixedAssetsCoeff { get; set; }
        public virtual DbSet<MaFixedAssetsFinancial> MaFixedAssetsFinancial { get; set; }
        public virtual DbSet<MaFixedAssetsFiscal> MaFixedAssetsFiscal { get; set; }
        public virtual DbSet<MaFixedAssetsPeriod> MaFixedAssetsPeriod { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaFixAssetEntries>(entity =>
{
                entity.HasKey(e => e.EntryId)
                    .HasName("PK_FixAssetEntries")
                    .IsClustered(false);

                entity.ToTable("MA_FixAssetEntries");

                entity.HasIndex(e => new { e.DepreciationEntry, e.PostingDate })
                    .HasName("MA_FixAssetEntries4");

                entity.HasIndex(e => new { e.PostingDate, e.DocumentDate, e.DocNo, e.EntryId })
                    .HasName("MA_FixAssetEntries2");

                entity.HasIndex(e => new { e.Farsn, e.PostingDate, e.DocumentDate, e.DocNo, e.EntryId })
                    .HasName("MA_FixAssetEntries3");

                entity.Property(e => e.EntryId).ValueGeneratedNever();

                entity.Property(e => e.Alignment)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

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

                entity.Property(e => e.CustSuppType).HasDefaultValueSql("((6094850))");

                entity.Property(e => e.DepreciationEntry)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DisposalEntry)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DocNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DocumentDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Farsn)
                    .HasColumnName("FARsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.JournalEntryId).HasDefaultValueSql("((0))");

                entity.Property(e => e.LogNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PostingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.RefNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Simulated)
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
            modelBuilder.Entity<MaFixAssetEntriesDetail>(entity =>
{
                entity.HasKey(e => new { e.EntryId, e.Line })
                    .HasName("PK_FixAssetEntriesDetail")
                    .IsClustered(false);

                entity.ToTable("MA_FixAssetEntriesDetail");

                entity.HasIndex(e => new { e.CodeType, e.FixedAsset })
                    .HasName("MA_FixAssetEntriesDetail2");

                entity.HasIndex(e => new { e.CodeType, e.FixedAsset, e.PostingDate, e.EntryId })
                    .HasName("MA_FixAssetEntriesDetail3");

                entity.Property(e => e.Amount).HasDefaultValueSql("((0))");

                entity.Property(e => e.AmountDocCurr).HasDefaultValueSql("((0))");

                entity.Property(e => e.CodeType).HasDefaultValueSql("((7012352))");

                entity.Property(e => e.Currency)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FixedAsset)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Perc).HasDefaultValueSql("((0))");

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

                entity.HasOne(d => d.Entry)
                    .WithMany(p => p.MaFixAssetEntriesDetail)
                    .HasForeignKey(d => d.EntryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FixAssetEn_FixAssetEn_00");
            });
            modelBuilder.Entity<MaFixAssetLocations>(entity =>
{
                entity.HasKey(e => e.Location)
                    .HasName("PK_FixAssetLocations")
                    .IsClustered(false);

                entity.ToTable("MA_FixAssetLocations");

                entity.Property(e => e.Location)
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
            modelBuilder.Entity<MaFixAssetsClasses>(entity =>
{
                entity.HasKey(e => e.Class)
                    .HasName("PK_FixAssetsClasses")
                    .IsClustered(false);

                entity.ToTable("MA_FixAssetsClasses");

                entity.Property(e => e.Class)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(32)
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
            modelBuilder.Entity<MaFixAssetsCtg>(entity =>
{
                entity.HasKey(e => new { e.CodeType, e.Category })
                    .HasName("PK_FixAssetsCtg")
                    .IsClustered(false);

                entity.ToTable("MA_FixAssetsCtg");

                entity.Property(e => e.Category)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.AcceleratedAccumDeprAccount)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AcceleratedDeprAccount)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AcceleratedDisabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.AcceleratedNoOfYears).HasDefaultValueSql("((0))");

                entity.Property(e => e.AcceleratedPerc).HasDefaultValueSql("((0))");

                entity.Property(e => e.AccumDeprAccount)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BalancePerc).HasDefaultValueSql("((0))");

                entity.Property(e => e.CategoryAccount)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ChargesNoOfyears).HasDefaultValueSql("((0))");

                entity.Property(e => e.ChargesPerc).HasDefaultValueSql("((0))");

                entity.Property(e => e.DeprAccount)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DepreciateByLifePeriod)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DepreciationMethod).HasDefaultValueSql("((11730944))");

                entity.Property(e => e.Description)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FirstFiscalYearPerc).HasDefaultValueSql("((0))");

                entity.Property(e => e.LifePeriod).HasDefaultValueSql("((0))");

                entity.Property(e => e.MaxLifePeriod).HasDefaultValueSql("((0))");

                entity.Property(e => e.MinLifePeriod).HasDefaultValueSql("((0))");

                entity.Property(e => e.MinimumPerc).HasDefaultValueSql("((0))");

                entity.Property(e => e.OfficialPerc).HasDefaultValueSql("((0))");

                entity.Property(e => e.PartDeprByPerc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PartDeprLimit).HasDefaultValueSql("((0))");

                entity.Property(e => e.PartDeprPerc).HasDefaultValueSql("((0))");

                entity.Property(e => e.PartiallyDepreciable)
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
            modelBuilder.Entity<MaFixAssetsDeprTemplates>(entity =>
{
                entity.HasKey(e => e.Template)
                    .HasName("PK_FixAssetsDeprTemplates")
                    .IsClustered(false);

                entity.ToTable("MA_FixAssetsDeprTemplates");

                entity.Property(e => e.Template)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.DepreciationMethod).HasDefaultValueSql("((11730944))");

                entity.Property(e => e.Description)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LifePeriod).HasDefaultValueSql("((0))");

                entity.Property(e => e.Step).HasDefaultValueSql("((0))");

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
            modelBuilder.Entity<MaFixAssetsDeprTemplatesCoeff>(entity =>
{
                entity.HasKey(e => new { e.Template, e.Line })
                    .HasName("PK_FixAssetsDeprTemplatesCoeff")
                    .IsClustered(false);

                entity.ToTable("MA_FixAssetsDeprTemplatesCoeff");

                entity.Property(e => e.Template)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.FromPeriod).HasDefaultValueSql("((0))");

                entity.Property(e => e.Perc).HasDefaultValueSql("((0))");

                entity.Property(e => e.RegrCoeff).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.ToPeriod).HasDefaultValueSql("((0))");
            });
            modelBuilder.Entity<MaFixAssetsParameters>(entity =>
{
                entity.HasKey(e => e.FixAssetsParametersId)
                    .HasName("PK_FixAssetsParameters")
                    .IsClustered(false);

                entity.ToTable("MA_FixAssetsParameters");

                entity.Property(e => e.FixAssetsParametersId).ValueGeneratedNever();

                entity.Property(e => e.AccAccumDeprReversalFarsn)
                    .HasColumnName("AccAccumDeprReversalFARsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AcceleratedDeprAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AcceleratedDeprFarsn)
                    .HasColumnName("AcceleratedDeprFARsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AcceleratedNoOfYears).HasDefaultValueSql("((0))");

                entity.Property(e => e.AcceleratedPerc).HasDefaultValueSql("((0))");

                entity.Property(e => e.AccumDeprReversalAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AccumDeprReversalFarsn)
                    .HasColumnName("AccumDeprReversalFARsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AlignAccAccumDeprFarsn)
                    .HasColumnName("AlignAccAccumDeprFARsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AlignAccumDeprFarsn)
                    .HasColumnName("AlignAccumDeprFARsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BalAccumDeprReversalFarsn)
                    .HasColumnName("BalAccumDeprReversalFARsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BalanceCalendarYear)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.BalanceCapitalGainFarsn)
                    .HasColumnName("BalanceCapitalGainFARsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BalanceCapitalLossFarsn)
                    .HasColumnName("BalanceCapitalLossFARsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BalanceDeprFarsn)
                    .HasColumnName("BalanceDeprFARsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BalanceDeprInDays)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.BalanceDeprInMonths)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.BalanceDeprUsage100)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.BalancePartialSaleFarsn)
                    .HasColumnName("BalancePartialSaleFARsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BalancePartialScrapFarsn)
                    .HasColumnName("BalancePartialScrapFARsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BalanceSaleFarsn)
                    .HasColumnName("BalanceSaleFARsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BalanceScrapFarsn)
                    .HasColumnName("BalanceScrapFARsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BalanceWindfallLossFarsn)
                    .HasColumnName("BalanceWindfallLossFARsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CapitalGain)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CapitalGainAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CapitalGainFarsn)
                    .HasColumnName("CapitalGainFARsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CapitalLoss)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CapitalLossAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CapitalLossFarsn)
                    .HasColumnName("CapitalLossFARsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ChargesNoOfyears).HasDefaultValueSql("((0))");

                entity.Property(e => e.ChargesPerc).HasDefaultValueSql("((0))");

                entity.Property(e => e.CoAaccount1)
                    .HasColumnName("CoAAccount1")
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CoAaccount10)
                    .HasColumnName("CoAAccount10")
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CoAaccount2)
                    .HasColumnName("CoAAccount2")
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CoAaccount3)
                    .HasColumnName("CoAAccount3")
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CoAaccount4)
                    .HasColumnName("CoAAccount4")
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CoAaccount5)
                    .HasColumnName("CoAAccount5")
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CoAaccount6)
                    .HasColumnName("CoAAccount6")
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CoAaccount7)
                    .HasColumnName("CoAAccount7")
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CoAaccount8)
                    .HasColumnName("CoAAccount8")
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CoAaccount9)
                    .HasColumnName("CoAAccount9")
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CostAccFiscalValue)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.DepreciationAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DepreciationAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DisableAccelerated)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.DisableReduced)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.DisposalDepr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DisposalPostJe)
                    .HasColumnName("DisposalPostJE")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.EntryAutonumbering)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FinancialDeprFarsn)
                    .HasColumnName("FinancialDeprFARsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FirstBalanceYearReduction).HasDefaultValueSql("((11468801))");

                entity.Property(e => e.FirstFiscalYearPerc).HasDefaultValueSql("((0))");

                entity.Property(e => e.FirstFiscalYearReduction).HasDefaultValueSql("((11468800))");

                entity.Property(e => e.FiscalCalendarYear)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FiscalDeprFarsn)
                    .HasColumnName("FiscalDeprFARsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FixedAssetsAutoNum)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.JournalEntryFiscalValue)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.LastFixedAsset).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastFixedAssetMaxChar).HasDefaultValueSql("((0))");

                entity.Property(e => e.LostAccumDeprReversalFarsn)
                    .HasColumnName("LostAccumDeprReversalFARsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LostDeprFarsn)
                    .HasColumnName("LostDeprFARsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MaxLines).HasDefaultValueSql("((0))");

                entity.Property(e => e.MinimumPerc).HasDefaultValueSql("((0))");

                entity.Property(e => e.NoFiscalOverBalance)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NoFiscalOverBalance2008)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PartialSaleFarsn)
                    .HasColumnName("PartialSaleFARsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PartialScrapFarsn)
                    .HasColumnName("PartialScrapFARsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PeriodPosting).HasDefaultValueSql("((65536))");

                entity.Property(e => e.PostOneJeperCategory)
                    .HasColumnName("PostOneJEPerCategory")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PostOneJeperFixedAsset)
                    .HasColumnName("PostOneJEPerFixedAsset")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PrintExtraDed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PurchaseFarsn)
                    .HasColumnName("PurchaseFARsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PurchaseFiscalYear)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.RecalculateInital)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ReducedBalanceDepr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.RenewalDeprFarsn)
                    .HasColumnName("RenewalDeprFARsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SaleAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SaleFarsn)
                    .HasColumnName("SaleFARsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ScrapAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ScrapFarsn)
                    .HasColumnName("ScrapFARsn")
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

                entity.Property(e => e.WindfallLoss)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.WindfallLossAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.WindfallLossFarsn)
                    .HasColumnName("WindfallLossFARsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
            modelBuilder.Entity<MaFixAssetsParametersCoeff>(entity =>
{
                entity.HasKey(e => new { e.FixAssetsParametersId, e.Line })
                    .HasName("PK_FixAssetsParametersCoeff")
                    .IsClustered(false);

                entity.ToTable("MA_FixAssetsParametersCoeff");

                entity.Property(e => e.FromPeriod).HasDefaultValueSql("((0))");

                entity.Property(e => e.RegrCoeff).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.ToPeriod).HasDefaultValueSql("((0))");
            });
            modelBuilder.Entity<MaFixAssetsPeriodData>(entity =>
{
                entity.HasKey(e => new { e.FiscalYear, e.BalanceYear, e.BalanceMonth })
                    .HasName("PK_FixAssetsPeriodData")
                    .IsClustered(false);

                entity.ToTable("MA_FixAssetsPeriodData");

                entity.Property(e => e.BlockFixedAssetsPosting)
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
            modelBuilder.Entity<MaFixAssetsReasons>(entity =>
{
                entity.HasKey(e => e.Reason)
                    .HasName("PK_FixAssetsReasons")
                    .IsClustered(false);

                entity.ToTable("MA_FixAssetsReasons");

                entity.Property(e => e.Reason)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Actions)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BalanceEnabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CustSuppType).HasDefaultValueSql("((3866624))");

                entity.Property(e => e.Description)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Disabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DisposalType).HasDefaultValueSql("((7143424))");

                entity.Property(e => e.ExtendedActions)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FinancialEnabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FiscalEnabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PostDocumentData)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Predefined)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PurchaseDisposalEnabled)
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

                entity.Property(e => e.UserEditablePerc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UserEditableQty)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");
            });
            modelBuilder.Entity<MaFixedAssets>(entity =>
{
                entity.HasKey(e => new { e.CodeType, e.FixedAsset })
                    .HasName("PK_FixedAssets")
                    .IsClustered(false);

                entity.ToTable("MA_FixedAssets");

                entity.HasIndex(e => e.Class)
                    .HasName("MA_FixedAssets3");

                entity.HasIndex(e => e.Location)
                    .HasName("MA_FixedAssets4");

                entity.HasIndex(e => new { e.CodeType, e.Category })
                    .HasName("MA_FixedAssets2");

                entity.Property(e => e.FixedAsset)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AcceleratedCustomized)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.AcceleratedPerc).HasDefaultValueSql("((0))");

                entity.Property(e => e.Acgcode)
                    .HasColumnName("ACGCode")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Activity).HasDefaultValueSql("((0))");

                entity.Property(e => e.Aligned)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.AlignmentDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.ApplyReduced)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.AssignorContribution).HasDefaultValueSql("((0))");

                entity.Property(e => e.AssignorContributionCurr).HasDefaultValueSql("((0))");

                entity.Property(e => e.AuthorizationPeriod).HasDefaultValueSql("((0))");

                entity.Property(e => e.AuthorizeInsufficient)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.BalLifePeriodChangeDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.BalMethodChangeDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.BalWriteOffDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.BalanceCustomized)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.BalanceDepreciationMethod).HasDefaultValueSql("((11730944))");

                entity.Property(e => e.BalanceLifePeriod).HasDefaultValueSql("((0))");

                entity.Property(e => e.BalancePerc).HasDefaultValueSql("((0))");

                entity.Property(e => e.BalanceStep).HasDefaultValueSql("((0))");

                entity.Property(e => e.Category)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Class)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CostCenter)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Customer)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DeprByDate)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DeprTemplate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DepreciationEndingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.DepreciationMethod).HasDefaultValueSql("((11730944))");

                entity.Property(e => e.DepreciationStart).HasDefaultValueSql("((0))");

                entity.Property(e => e.DepreciationStartingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Description)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Disabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DisposalAmount).HasDefaultValueSql("((0))");

                entity.Property(e => e.DisposalAmountDocCurr).HasDefaultValueSql("((0))");

                entity.Property(e => e.DisposalDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.DisposalDocDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.DisposalDocNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DisposalType).HasDefaultValueSql("((7143424))");

                entity.Property(e => e.ExtraDed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FiscalCustomized)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FiscalPerc).HasDefaultValueSql("((0))");

                entity.Property(e => e.IdNumber)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InspectionDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.InstallationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.ItemAdditionalCode)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Job)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastBalDepreciationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.LastDepreciation).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastDepreciationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.LifePeriod).HasDefaultValueSql("((0))");

                entity.Property(e => e.Location)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LogNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NoChargesCalculation)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ParentCodeType).HasDefaultValueSql("((7012352))");

                entity.Property(e => e.ParentFixedAsset)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PartDeprByPerc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PartDeprLimit).HasDefaultValueSql("((0))");

                entity.Property(e => e.PartDeprLimitCustom)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PartDeprPerc).HasDefaultValueSql("((0))");

                entity.Property(e => e.PartDeprPercCustom)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PartiallyDepreciable)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Picture)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PlacedInServiceDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.ProductLine)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PurchaseCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.PurchaseCostDocCurr).HasDefaultValueSql("((0))");

                entity.Property(e => e.PurchaseDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.PurchaseDocDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.PurchaseDocNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PurchaseType).HasDefaultValueSql("((7208960))");

                entity.Property(e => e.PurchaseYear).HasDefaultValueSql("((0))");

                entity.Property(e => e.Qty).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.WriteOffDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");
            });
            modelBuilder.Entity<MaFixedAssetsBalance>(entity =>
{
                entity.HasKey(e => new { e.FiscalYear, e.CodeType, e.FixedAsset, e.Currency })
                    .HasName("PK_FixedAssetsBalance")
                    .IsClustered(false);

                entity.ToTable("MA_FixedAssetsBalance");

                entity.HasIndex(e => new { e.CodeType, e.FixedAsset, e.FiscalYear })
                    .HasName("MA_FixedAssetsBalance3");

                entity.HasIndex(e => new { e.FiscalYear, e.CodeType, e.Category, e.FixedAsset })
                    .HasName("MA_FixedAssetsBalance2");

                entity.Property(e => e.FixedAsset)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Currency)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.AccumDepr).HasDefaultValueSql("((0))");

                entity.Property(e => e.AddDepreciation).HasDefaultValueSql("((0))");

                entity.Property(e => e.CapitalGain).HasDefaultValueSql("((0))");

                entity.Property(e => e.CapitalLoss).HasDefaultValueSql("((0))");

                entity.Property(e => e.Category)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Charges).HasDefaultValueSql("((0))");

                entity.Property(e => e.CurrPeriodsDepreciated).HasDefaultValueSql("((0))");

                entity.Property(e => e.Depreciation).HasDefaultValueSql("((0))");

                entity.Property(e => e.DepreciationMethod).HasDefaultValueSql("((11730944))");

                entity.Property(e => e.DepreciationPlan).HasDefaultValueSql("((0))");

                entity.Property(e => e.IncrementalCharges).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialAccumDepr).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialLiquidation).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialTotalDepreciable).HasDefaultValueSql("((0))");

                entity.Property(e => e.LifePeriod).HasDefaultValueSql("((0))");

                entity.Property(e => e.Liquidation).HasDefaultValueSql("((0))");

                entity.Property(e => e.NewPeriod)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Perc).HasDefaultValueSql("((0))");

                entity.Property(e => e.PurchaseDocDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.PurchaseYear).HasDefaultValueSql("((0))");

                entity.Property(e => e.Revaluation).HasDefaultValueSql("((0))");

                entity.Property(e => e.Sales).HasDefaultValueSql("((0))");

                entity.Property(e => e.Scraps).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.TotPeriodsDepreciated).HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalDepreciable).HasDefaultValueSql("((0))");

                entity.Property(e => e.WindfallLoss).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.MaFixedAssets)
                    .WithMany(p => p.MaFixedAssetsBalance)
                    .HasForeignKey(d => new { d.CodeType, d.FixedAsset })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FixedAsset_FixedAsset_00");
            });
            modelBuilder.Entity<MaFixedAssetsCoeff>(entity =>
{
                entity.HasKey(e => new { e.CodeType, e.FixedAsset, e.Line })
                    .HasName("PK_FixedAssetsCoeff")
                    .IsClustered(false);

                entity.ToTable("MA_FixedAssetsCoeff");

                entity.Property(e => e.FixedAsset)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Activity).HasDefaultValueSql("((0))");

                entity.Property(e => e.FromPeriod).HasDefaultValueSql("((0))");

                entity.Property(e => e.Perc).HasDefaultValueSql("((0))");

                entity.Property(e => e.RegrCoeff).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.ToPeriod).HasDefaultValueSql("((0))");
            });
            modelBuilder.Entity<MaFixedAssetsFinancial>(entity =>
{
                entity.HasKey(e => new { e.FiscalYear, e.CodeType, e.FixedAsset, e.Currency })
                    .HasName("PK_FixedAssetsFinancial")
                    .IsClustered(false);

                entity.ToTable("MA_FixedAssetsFinancial");

                entity.HasIndex(e => new { e.CodeType, e.FixedAsset, e.FiscalYear })
                    .HasName("MA_FixedAssetsFinancial3");

                entity.HasIndex(e => new { e.FiscalYear, e.CodeType, e.Category, e.FixedAsset })
                    .HasName("MA_FixedAssetsFinancial2");

                entity.Property(e => e.FixedAsset)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Currency)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.AccumDepr).HasDefaultValueSql("((0))");

                entity.Property(e => e.Category)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Charges).HasDefaultValueSql("((0))");

                entity.Property(e => e.Depreciation).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialAccumDepr).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialRenewalAccumDepr).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialRenewalReserve).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialTotalDepreciable).HasDefaultValueSql("((0))");

                entity.Property(e => e.RenewalAccumDepr).HasDefaultValueSql("((0))");

                entity.Property(e => e.RenewalDepr).HasDefaultValueSql("((0))");

                entity.Property(e => e.RenewalReserve).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.TotalDepreciable).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.MaFixedAssets)
                    .WithMany(p => p.MaFixedAssetsFinancial)
                    .HasForeignKey(d => new { d.CodeType, d.FixedAsset })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FixedAsset_FixedAsset_01");
            });
            modelBuilder.Entity<MaFixedAssetsFiscal>(entity =>
{
                entity.HasKey(e => new { e.FiscalYear, e.CodeType, e.FixedAsset, e.Currency })
                    .HasName("PK_FixedAssetsFiscal")
                    .IsClustered(false);

                entity.ToTable("MA_FixedAssetsFiscal");

                entity.HasIndex(e => new { e.CodeType, e.FixedAsset, e.FiscalYear })
                    .HasName("MA_FixedAssetsFiscal4");

                entity.HasIndex(e => new { e.FiscalYear, e.CodeType, e.Category, e.FixedAsset })
                    .HasName("MA_FixedAssetsFiscal3");

                entity.HasIndex(e => new { e.FiscalYear, e.PurchaseYear, e.CodeType, e.Category, e.Perc, e.PurchaseDocDate })
                    .HasName("MA_FixedAssetsFiscal2");

                entity.Property(e => e.FixedAsset)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Currency)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.AcceleratedAccumDepr).HasDefaultValueSql("((0))");

                entity.Property(e => e.AcceleratedDepr).HasDefaultValueSql("((0))");

                entity.Property(e => e.AccumDepr).HasDefaultValueSql("((0))");

                entity.Property(e => e.AddDepreciation).HasDefaultValueSql("((0))");

                entity.Property(e => e.CapitalGain).HasDefaultValueSql("((0))");

                entity.Property(e => e.CapitalLoss).HasDefaultValueSql("((0))");

                entity.Property(e => e.Category)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Charges).HasDefaultValueSql("((0))");

                entity.Property(e => e.CurrPeriodsDepreciated).HasDefaultValueSql("((0))");

                entity.Property(e => e.Deductions).HasDefaultValueSql("((0))");

                entity.Property(e => e.Depreciation).HasDefaultValueSql("((0))");

                entity.Property(e => e.DepreciationPlan).HasDefaultValueSql("((0))");

                entity.Property(e => e.IncrementalCharges).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialAcceleratedAccumDepr).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialAccumDepr).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialLostAccumDepr).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialNonDepreciable).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialTotalDepreciable).HasDefaultValueSql("((0))");

                entity.Property(e => e.LostAccumDepr).HasDefaultValueSql("((0))");

                entity.Property(e => e.LostDepr).HasDefaultValueSql("((0))");

                entity.Property(e => e.Maintenance).HasDefaultValueSql("((0))");

                entity.Property(e => e.Modernization).HasDefaultValueSql("((0))");

                entity.Property(e => e.NewPeriod)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NonDepreciable).HasDefaultValueSql("((0))");

                entity.Property(e => e.Perc).HasDefaultValueSql("((0))");

                entity.Property(e => e.PurchaseDocDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.PurchaseYear).HasDefaultValueSql("((0))");

                entity.Property(e => e.Repairs).HasDefaultValueSql("((0))");

                entity.Property(e => e.Revaluation).HasDefaultValueSql("((0))");

                entity.Property(e => e.Sales).HasDefaultValueSql("((0))");

                entity.Property(e => e.Scraps).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.TotPeriodsDepreciated).HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalDepreciable).HasDefaultValueSql("((0))");

                entity.Property(e => e.Transformations).HasDefaultValueSql("((0))");

                entity.Property(e => e.WindfallLoss).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.MaFixedAssets)
                    .WithMany(p => p.MaFixedAssetsFiscal)
                    .HasForeignKey(d => new { d.CodeType, d.FixedAsset })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FixedAsset_FixedAsset_02");
            });
            modelBuilder.Entity<MaFixedAssetsPeriod>(entity =>
{
                entity.HasKey(e => new { e.CodeType, e.FixedAsset, e.FiscalYear, e.FiscalPeriod })
                    .HasName("PK_FixedAssetsPeriod")
                    .IsClustered(false);

                entity.ToTable("MA_FixedAssetsPeriod");

                entity.Property(e => e.FixedAsset)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.BalanceDeprDisabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DeprDisabled)
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
        }
    }
}
