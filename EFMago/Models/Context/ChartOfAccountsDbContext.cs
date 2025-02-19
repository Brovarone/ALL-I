using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class ChartOfAccountsDbContext : DbContext
    {
        public ChartOfAccountsDbContext()
        {
        }
        public ChartOfAccountsDbContext(DbContextOptions<ChartOfAccountsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaChartOfAccountParameters> MaChartOfAccountParameters { get; set; }
        public virtual DbSet<MaChartOfAccounts> MaChartOfAccounts { get; set; }
        public virtual DbSet<MaChartOfAccountsBalances> MaChartOfAccountsBalances { get; set; }
        public virtual DbSet<MaLedgers> MaLedgers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaChartOfAccountParameters>(entity =>
{
                entity.HasKey(e => e.ChartOfAccountParametersId)
                    .HasName("PK_ChartOfAccountParameters")
                    .IsClustered(false);

                entity.ToTable("MA_ChartOfAccountParameters");

                entity.Property(e => e.ChartOfAccountParametersId).ValueGeneratedNever();

                entity.Property(e => e.AccountLength).HasDefaultValueSql("((0))");

                entity.Property(e => e.LedegerLength).HasDefaultValueSql("((0))");

                entity.Property(e => e.MaxLengthSegment).HasDefaultValueSql("((0))");

                entity.Property(e => e.NoOfSegments).HasDefaultValueSql("((0))");

                entity.Property(e => e.PurchLedgerTypeFilter)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SaleLedgerTypeFilter)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Segment1)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Segment1Length).HasDefaultValueSql("((0))");

                entity.Property(e => e.Segment2)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Segment2Length).HasDefaultValueSql("((0))");

                entity.Property(e => e.Segment3)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Segment3Length).HasDefaultValueSql("((0))");

                entity.Property(e => e.Segment4)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Segment4Length).HasDefaultValueSql("((0))");

                entity.Property(e => e.Segment5)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Segment5Length).HasDefaultValueSql("((0))");

                entity.Property(e => e.Segment6)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Segment6Length).HasDefaultValueSql("((0))");

                entity.Property(e => e.Segment7)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Segment7Length).HasDefaultValueSql("((0))");

                entity.Property(e => e.SummaryAccCheck)
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

                entity.Property(e => e.VariableLength)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");
            });
            modelBuilder.Entity<MaChartOfAccounts>(entity =>
{
                entity.HasKey(e => e.Account)
                    .HasName("PK_ChartOfAccounts")
                    .IsClustered(false);

                entity.ToTable("MA_ChartOfAccounts");

                entity.HasIndex(e => e.Description)
                    .HasName("MA_ChartOfAccounts2");

                entity.HasIndex(e => e.Ledger)
                    .HasName("MA_ChartOfAccounts3");

                entity.Property(e => e.Account)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.AccrualsAccount)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AccrualsDays).HasDefaultValueSql("((0))");

                entity.Property(e => e.Acgcode)
                    .HasColumnName("ACGCode")
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CashFlowType).HasDefaultValueSql("((8781828))");

                entity.Property(e => e.CodeType).HasDefaultValueSql("((3080194))");

                entity.Property(e => e.CostAccAccountGroup)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CostCentersDistribution).HasDefaultValueSql("((8060928))");

                entity.Property(e => e.Currency)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DebitCreditSign).HasDefaultValueSql("((8192002))");

                entity.Property(e => e.DeferralsAccount)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DeferralsDays).HasDefaultValueSql("((0))");

                entity.Property(e => e.Description)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DirectCost).HasDefaultValueSql("((8257540))");

                entity.Property(e => e.Disabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DocToBeIssRecType).HasDefaultValueSql("((30932992))");

                entity.Property(e => e.FullCost).HasDefaultValueSql("((8323077))");

                entity.Property(e => e.InCurrency)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.JobsDistribution).HasDefaultValueSql("((8126464))");

                entity.Property(e => e.Ledger)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OmniaintraCode)
                    .HasColumnName("OMNIAIntraCode")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OmniasubAccount)
                    .HasColumnName("OMNIASubAccount")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PostableInCostAcc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PostableInJe)
                    .HasColumnName("PostableInJE")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PreferredSignForBalance).HasDefaultValueSql("((544276480))");

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

                entity.Property(e => e.UoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
            modelBuilder.Entity<MaChartOfAccountsBalances>(entity =>
{
                entity.HasKey(e => new { e.Account, e.FiscalYear, e.BalanceYear, e.BalanceType, e.BalanceMonth, e.Nature, e.Currency })
                    .HasName("PK_ChartOfAccountsBalances")
                    .IsClustered(false);

                entity.ToTable("MA_ChartOfAccountsBalances");

                entity.Property(e => e.Account)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Currency)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Credit).HasDefaultValueSql("((0))");

                entity.Property(e => e.Debit).HasDefaultValueSql("((0))");

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

                entity.HasOne(d => d.AccountNavigation)
                    .WithMany(p => p.MaChartOfAccountsBalances)
                    .HasForeignKey(d => d.Account)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChartOfAcc_ChartOfAcc_00");
            });
            modelBuilder.Entity<MaLedgers>(entity =>
{
                entity.HasKey(e => e.Ledger)
                    .HasName("PK_Ledgers")
                    .IsClustered(false);

                entity.ToTable("MA_Ledgers");

                entity.Property(e => e.Ledger)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.LedgerType)
                    .HasMaxLength(5)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Nature).HasDefaultValueSql("((3014656))");

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
