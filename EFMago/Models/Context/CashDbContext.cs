using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class CashDbContext : DbContext
    {
        public CashDbContext()
        {
        }
        public CashDbContext(DbContextOptions<CashDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaCash> MaCash { get; set; }
        public virtual DbSet<MaCashAccounts> MaCashAccounts { get; set; }
        public virtual DbSet<MaCashParameters> MaCashParameters { get; set; }
        public virtual DbSet<MaCashReasons> MaCashReasons { get; set; }
        public virtual DbSet<MaCashSessions> MaCashSessions { get; set; }
        public virtual DbSet<MaCashSessionsBalance> MaCashSessionsBalance { get; set; }
        public virtual DbSet<MaCashSessionsEntries> MaCashSessionsEntries { get; set; }
        public virtual DbSet<MaCashSessionsEntriesDetails> MaCashSessionsEntriesDetails { get; set; }
        public virtual DbSet<MaCashStubBookNumbers> MaCashStubBookNumbers { get; set; }
        public virtual DbSet<MaCashStubBooks> MaCashStubBooks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaCash>(entity =>
{
                entity.HasKey(e => e.Cash)
                    .HasName("PK_Cash")
                    .IsClustered(false);

                entity.ToTable("MA_Cash");

                entity.Property(e => e.Cash)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.AlternativeCurrency)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CashStubBook)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Description)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PreferredCurrency)
                    .HasMaxLength(8)
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

                entity.Property(e => e.WorkerId)
                    .HasColumnName("WorkerID")
                    .HasDefaultValueSql("((0))");
            });
            modelBuilder.Entity<MaCashAccounts>(entity =>
{
                entity.HasKey(e => new { e.Cash, e.Currency })
                    .HasName("PK_CashAccounts")
                    .IsClustered(false);

                entity.ToTable("MA_CashAccounts");

                entity.Property(e => e.Cash)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Currency)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Account)
                    .IsRequired()
                    .HasMaxLength(16)
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
            modelBuilder.Entity<MaCashParameters>(entity =>
{
                entity.HasKey(e => e.CashParametersId)
                    .HasName("PK_CashParameters")
                    .IsClustered(false);

                entity.ToTable("MA_CashParameters");

                entity.Property(e => e.CashParametersId).ValueGeneratedNever();

                entity.Property(e => e.CashAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CashFromPurchase)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CashFromPurchaseTotal)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CashFromSale)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CashFromSaleTotal)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CashInPrefix)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CashModuleIsDisabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CashOutPrefix)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CashReason)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CashTotalRounded)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ExpenseAutonumbering)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.OneCurrencyForCash)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.OneJeforCashEntry)
                    .HasColumnName("OneJEForCashEntry")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PurchaseCashReason)
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

                entity.Property(e => e.WorkOnMoreSessions)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");
            });
            modelBuilder.Entity<MaCashReasons>(entity =>
{
                entity.HasKey(e => e.Reason)
                    .HasName("PK_CashReason")
                    .IsClustered(false);

                entity.ToTable("MA_CashReasons");

                entity.Property(e => e.Reason)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.AccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Account)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AutoNumbering)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.AutoPrint)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CostCenter)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Description)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DocNoIsMand).HasDefaultValueSql("((4718594))");

                entity.Property(e => e.Job)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OperationType).HasDefaultValueSql("((0))");

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
            modelBuilder.Entity<MaCashSessions>(entity =>
{
                entity.HasKey(e => e.SessionId)
                    .HasName("PK_CashSessions")
                    .IsClustered(false);

                entity.ToTable("MA_CashSessions");

                entity.HasIndex(e => e.SessionNo)
                    .HasName("MA_CashSessions2");

                entity.Property(e => e.SessionId).ValueGeneratedNever();

                entity.Property(e => e.Cash)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ClosingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.OpeningDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Posted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SessionNo)
                    .HasMaxLength(10)
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
            modelBuilder.Entity<MaCashSessionsBalance>(entity =>
{
                entity.HasKey(e => new { e.SessionId, e.Currency })
                    .HasName("PK_CashSessionsBalance")
                    .IsClustered(false);

                entity.ToTable("MA_CashSessionsBalance");

                entity.Property(e => e.Currency)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.ClosingBalance).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.OpeningBalance).HasDefaultValueSql("((0.00))");

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
            modelBuilder.Entity<MaCashSessionsEntries>(entity =>
{
                entity.HasKey(e => new { e.SessionId, e.Line, e.IsAcashIn })
                    .HasName("PK_CashSessionsEntries")
                    .IsClustered(false);

                entity.ToTable("MA_CashSessionsEntries");

                entity.HasIndex(e => new { e.PostingDate, e.Line })
                    .HasName("MA_CashSessionsEntries2");

                entity.Property(e => e.IsAcashIn)
                    .HasColumnName("IsACashIn")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AdvanceClosed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.AdvanceLine).HasDefaultValueSql("((0))");

                entity.Property(e => e.AdvanceSessionId).HasDefaultValueSql("((0))");

                entity.Property(e => e.Allowance).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Amount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Cancelled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CashStubBook)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CostCenter)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Currency)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustSupp)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustSuppType).HasDefaultValueSql("((3211264))");

                entity.Property(e => e.DetailsToBePosted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DocNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExchangeRateLoss).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ExchangeRateProfit).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ExigibleTax).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ExpenseStatementNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Job)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.JournalEntryId).HasDefaultValueSql("((0))");

                entity.Property(e => e.Notes)
                    .HasColumnType("ntext")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OpenAmountInBaseCurr).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.OpenFixingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.OperationType).HasDefaultValueSql("((1703936))");

                entity.Property(e => e.Posted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PostingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Printed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PymtSchedId).HasDefaultValueSql("((0))");

                entity.Property(e => e.Reason)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Rounding).HasDefaultValueSql("((0))");

                entity.Property(e => e.SessionNo)
                    .HasMaxLength(10)
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

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.MaCashSessionsEntries)
                    .HasForeignKey(d => d.SessionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CashSessio_CashSessio_00");
            });
            modelBuilder.Entity<MaCashSessionsEntriesDetails>(entity =>
{
                entity.HasKey(e => new { e.SessionId, e.Line, e.IsAcashIn, e.SubLine })
                    .HasName("PK_CashSessionsEntriesDetails")
                    .IsClustered(false);

                entity.ToTable("MA_CashSessionsEntriesDetails");

                entity.Property(e => e.IsAcashIn)
                    .HasColumnName("IsACashIn")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Amount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.CostCenter)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustSupp)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustSuppType).HasDefaultValueSql("((3211265))");

                entity.Property(e => e.DocNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DocumentDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.DocumentType).HasDefaultValueSql("((1835008))");

                entity.Property(e => e.Job)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.JournalEntryId).HasDefaultValueSql("((0))");

                entity.Property(e => e.Notes)
                    .HasColumnType("ntext")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Posted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Reason)
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

                entity.HasOne(d => d.MaCashSessionsEntries)
                    .WithMany(p => p.MaCashSessionsEntriesDetails)
                    .HasForeignKey(d => new { d.SessionId, d.Line, d.IsAcashIn })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CashSessio_CashSessio_01");
            });
            modelBuilder.Entity<MaCashStubBookNumbers>(entity =>
{
                entity.HasKey(e => new { e.BalanceYear, e.CashStubBook })
                    .HasName("PK_CashStubBookNumbers")
                    .IsClustered(false);

                entity.ToTable("MA_CashStubBookNumbers");

                entity.Property(e => e.CashStubBook)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.LastDocDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.LastDocNo).HasDefaultValueSql("((0))");

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
            modelBuilder.Entity<MaCashStubBooks>(entity =>
{
                entity.HasKey(e => e.CashStubBook)
                    .HasName("PK_CashStubBooks")
                    .IsClustered(false);

                entity.ToTable("MA_CashStubBooks");

                entity.Property(e => e.CashStubBook)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Disabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
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
