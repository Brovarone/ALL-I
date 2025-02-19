using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class BalanceAnalysisDbContext : DbContext
    {
        public BalanceAnalysisDbContext()
        {
        }
        public BalanceAnalysisDbContext(DbContextOptions<BalanceAnalysisDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaBalanceAnalysisParameters> MaBalanceAnalysisParameters { get; set; }
        public virtual DbSet<MaBalanceReclass> MaBalanceReclass { get; set; }
        public virtual DbSet<MaBalanceReclassDetail> MaBalanceReclassDetail { get; set; }
        public virtual DbSet<MaTmpBalanceReclass> MaTmpBalanceReclass { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaBalanceAnalysisParameters>(entity =>
{
                entity.HasKey(e => e.BalanceAnalysisParameterId)
                    .HasName("PK_BalanceAnalysisParameters")
                    .IsClustered(false);

                entity.ToTable("MA_BalanceAnalysisParameters");

                entity.Property(e => e.BalanceAnalysisParameterId).ValueGeneratedNever();

                entity.Property(e => e.AssetsSchemaCode)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BeOoutputPath)
                    .HasColumnName("BeOOutputPath")
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CapitalSchemaCode)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CashPayablesSchemaCode)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CashReceivablesSchemaCode)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LiabilitiesSchemaCode)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LossSchemaCode)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProfitLossSchemaCode)
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

                entity.Property(e => e.UseLineNoCol)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");
            });
            modelBuilder.Entity<MaBalanceReclass>(entity =>
{
                entity.HasKey(e => e.SchemaCode)
                    .HasName("PK_BalanceReclass")
                    .IsClustered(false);

                entity.ToTable("MA_BalanceReclass");

                entity.Property(e => e.SchemaCode)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Currency)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Description)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Disabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IsBalance)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IsBeO)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IsXbrl)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NegativeRoundingCode)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PositiveRoundingCode)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Predefined)
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

                entity.Property(e => e.XbrlBalanceType).HasDefaultValueSql("((25755648))");

                entity.Property(e => e.XbrlMap)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.XbrlRoundingFinStat)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.XbrlRoundingLoss)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.XbrlRoundingProfit)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
            modelBuilder.Entity<MaBalanceReclassDetail>(entity =>
{
                entity.HasKey(e => new { e.SchemaCode, e.Line })
                    .HasName("PK_BalanceReclassDetail")
                    .IsClustered(false);

                entity.ToTable("MA_BalanceReclassDetail");

                entity.HasIndex(e => new { e.SchemaCode, e.Code })
                    .HasName("MA_BalanceReclassDetail2");

                entity.Property(e => e.SchemaCode)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Account)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AllKind)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.BalanceSection).HasDefaultValueSql("((3014656))");

                entity.Property(e => e.BalanceSign).HasDefaultValueSql("((8912896))");

                entity.Property(e => e.BalanceType).HasDefaultValueSql("((8847360))");

                entity.Property(e => e.Code)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Currency)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DebitCreditSign).HasDefaultValueSql("((4980736))");

                entity.Property(e => e.Description)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Disabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IgnoreDifferentSign)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.LineNoCol)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LineType).HasDefaultValueSql("((12058624))");

                entity.Property(e => e.Nature).HasDefaultValueSql("((9306112))");

                entity.Property(e => e.OffsetAccount)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OffsetAccountType).HasDefaultValueSql("((3080194))");

                entity.Property(e => e.OffsetCashType).HasDefaultValueSql("((8781828))");

                entity.Property(e => e.OffsetCustSupp)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReferenceCode)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReferenceSchemaCode)
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

                entity.Property(e => e.Xbrldepth)
                    .HasColumnName("XBRLDepth")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.SchemaCodeNavigation)
                    .WithMany(p => p.MaBalanceReclassDetail)
                    .HasForeignKey(d => d.SchemaCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BalanceRec_BalanceRec_00");
            });
            modelBuilder.Entity<MaTmpBalanceReclass>(entity =>
{
                entity.HasKey(e => new { e.SessionGuid, e.Line })
                    .HasName("PK_TmpBalanceReclass")
                    .IsClustered(false);

                entity.ToTable("MA_TmpBalanceReclass");

                entity.Property(e => e.Credit).HasDefaultValueSql("((0))");

                entity.Property(e => e.CreditCode)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CreditDescription)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CreditLineNoCol)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CreditLineType).HasDefaultValueSql("((12058624))");

                entity.Property(e => e.CreditSchema)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Debit).HasDefaultValueSql("((0))");

                entity.Property(e => e.DebitCode)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DebitDescription)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DebitLineNoCol)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DebitLineType).HasDefaultValueSql("((12058624))");

                entity.Property(e => e.DebitSchema)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SecondCredit).HasDefaultValueSql("((0))");

                entity.Property(e => e.SecondDebit).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.ThirdCredit).HasDefaultValueSql("((0))");

                entity.Property(e => e.ThirdDebit).HasDefaultValueSql("((0))");
            });
        }
    }
}
