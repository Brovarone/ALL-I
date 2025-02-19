using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class CostAccountingDbContext : DbContext
    {
        public CostAccountingDbContext()
        {
        }
        public CostAccountingDbContext(DbContextOptions<CostAccountingDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaChartOfAccountsCostAccTpl> MaChartOfAccountsCostAccTpl { get; set; }
        public virtual DbSet<MaCostAccEntries> MaCostAccEntries { get; set; }
        public virtual DbSet<MaCostAccEntriesDetail> MaCostAccEntriesDetail { get; set; }
        public virtual DbSet<MaCostAccParameters> MaCostAccParameters { get; set; }
        public virtual DbSet<MaCostCenterGroups> MaCostCenterGroups { get; set; }
        public virtual DbSet<MaCostCenters> MaCostCenters { get; set; }
        public virtual DbSet<MaCostCentersBalances> MaCostCentersBalances { get; set; }
        public virtual DbSet<MaTransferTpl> MaTransferTpl { get; set; }
        public virtual DbSet<MaTransferTplDest> MaTransferTplDest { get; set; }
        public virtual DbSet<MaTransferTplOrigin> MaTransferTplOrigin { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaChartOfAccountsCostAccTpl>(entity =>
{
                entity.HasKey(e => new { e.Account, e.Line })
                    .HasName("PK_ChartOfAccountsCostAccTpl")
                    .IsClustered(false);

                entity.ToTable("MA_ChartOfAccountsCostAccTpl");

                entity.HasIndex(e => new { e.HasCostCenter, e.CostCenter, e.Account, e.Line })
                    .HasName("MA_ChartOfAccountsCostAccTpl2");

                entity.HasIndex(e => new { e.HasJob, e.Job, e.Account, e.Line })
                    .HasName("MA_ChartOfAccountsCostAccTpl3");

                entity.Property(e => e.Account)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.CostCenter)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DebitCreditSign).HasDefaultValueSql("((4980736))");

                entity.Property(e => e.HasCostCenter)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.HasJob)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.HasProductLine)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Job)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Perc).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProductLine)
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
            modelBuilder.Entity<MaCostAccEntries>(entity =>
{
                entity.HasKey(e => e.EntryId)
                    .HasName("PK_CostAccEntries")
                    .IsClustered(false);

                entity.ToTable("MA_CostAccEntries");

                entity.HasIndex(e => e.JournalEntryId)
                    .HasName("MA_CostAccEntries6");

                entity.HasIndex(e => new { e.AccrualDate, e.CodeType, e.EntryId })
                    .HasName("MA_CostAccEntries5");

                entity.HasIndex(e => new { e.Account, e.PostingDate, e.DocumentDate, e.DocNo, e.EntryId })
                    .HasName("MA_CostAccEntries3");

                entity.HasIndex(e => new { e.PostingDate, e.CodeType, e.DocumentDate, e.DocNo, e.EntryId })
                    .HasName("MA_CostAccEntries4");

                entity.HasIndex(e => new { e.PostingDate, e.DocumentDate, e.LogNo, e.DocNo, e.EntryId })
                    .HasName("MA_CostAccEntries2");

                entity.Property(e => e.EntryId).ValueGeneratedNever();

                entity.Property(e => e.Account)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AccrualDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.CodeType).HasDefaultValueSql("((7995392))");

                entity.Property(e => e.CrrefId)
                    .HasColumnName("CRRefID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CrrefSubId)
                    .HasColumnName("CRRefSubID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CrrefType)
                    .HasColumnName("CRRefType")
                    .HasDefaultValueSql("((27066368))");

                entity.Property(e => e.CustSupp)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustSuppType).HasDefaultValueSql("((6094850))");

                entity.Property(e => e.DebitCreditSign).HasDefaultValueSql("((8192002))");

                entity.Property(e => e.DocNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DocumentDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.GenByDepreciation)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InvEntryId).HasDefaultValueSql("((0))");

                entity.Property(e => e.JournalEntryId).HasDefaultValueSql("((0))");

                entity.Property(e => e.LogNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PostingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.PurchaseDocId).HasDefaultValueSql("((0))");

                entity.Property(e => e.RefDocNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RefNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Reversing)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SaleDocId).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.TotalAmount).HasDefaultValueSql("((0))");
            });
            modelBuilder.Entity<MaCostAccEntriesDetail>(entity =>
{
                entity.HasKey(e => new { e.EntryId, e.Line })
                    .HasName("PK_CostAccEntriesDetail")
                    .IsClustered(false);

                entity.ToTable("MA_CostAccEntriesDetail");

                entity.HasIndex(e => new { e.HasCostCenter, e.CostCenter, e.AccrualDate, e.Account, e.EntryId })
                    .HasName("MA_CostAccEntriesDetail2");

                entity.HasIndex(e => new { e.HasJob, e.Job, e.AccrualDate, e.Account, e.EntryId })
                    .HasName("MA_CostAccEntriesDetail3");

                entity.HasIndex(e => new { e.HasProductLine, e.ProductLine, e.AccrualDate, e.Account, e.EntryId })
                    .HasName("MA_CostAccEntriesDetail4");

                entity.Property(e => e.Account)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AccrualDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Amount).HasDefaultValueSql("((0))");

                entity.Property(e => e.CodeType).HasDefaultValueSql("((7995392))");

                entity.Property(e => e.CostCenter)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DebitCreditSign).HasDefaultValueSql("((4980736))");

                entity.Property(e => e.HasCostCenter)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.HasJob)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.HasProductLine)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Job)
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

                entity.Property(e => e.ProductLine)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

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
                    .WithMany(p => p.MaCostAccEntriesDetail)
                    .HasForeignKey(d => d.EntryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CostAccEnt_CostAccEnt_00");
            });
            modelBuilder.Entity<MaCostAccParameters>(entity =>
{
                entity.HasKey(e => e.CostAccParametersId)
                    .HasName("PK_CostAccParameters")
                    .IsClustered(false);

                entity.ToTable("MA_CostAccParameters");

                entity.Property(e => e.CostAccParametersId).ValueGeneratedNever();

                entity.Property(e => e.AccountsGroupLength).HasDefaultValueSql("((0))");

                entity.Property(e => e.CostCentersDescription1)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CostCentersDescription2)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CostCentersGroupLength).HasDefaultValueSql("((0))");

                entity.Property(e => e.CostCentersJobsMandatory)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CostsFromInventoryEntry)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.EntryAutonumbering)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.GenEntryFromIssuedDoc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.GenEntryFromReceivedDoc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.GroupAutoGenLines)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.JobsGroupDescpition2)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.JobsGroupDescription1)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.JobsGroupLength).HasDefaultValueSql("((0))");

                entity.Property(e => e.NotesFromAccountingEntry)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PurchCheckSpreading)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.RevenuesFromInventoryEntry)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SalesCheckSpreading)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SkipJobsOnPurchases)
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
            modelBuilder.Entity<MaCostCenterGroups>(entity =>
{
                entity.HasKey(e => e.GroupCode)
                    .HasName("PK_CostCenterGroups")
                    .IsClustered(false);

                entity.ToTable("MA_CostCenterGroups");

                entity.HasIndex(e => e.Description)
                    .HasName("MA_CostCenterGroups2");

                entity.Property(e => e.GroupCode)
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

                entity.Property(e => e.Tbguid)
                    .HasColumnName("TBGuid")
                    .HasDefaultValueSql("(0x00)");

                entity.Property(e => e.Tbmodified)
                    .HasColumnName("TBModified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbmodifiedId).HasColumnName("TBModifiedID");
            });
            modelBuilder.Entity<MaCostCenters>(entity =>
{
                entity.HasKey(e => e.CostCenter)
                    .HasName("PK_CostCenters")
                    .IsClustered(false);

                entity.ToTable("MA_CostCenters");

                entity.HasIndex(e => e.Description)
                    .HasName("MA_CostCenters2");

                entity.HasIndex(e => new { e.CodeType, e.CostCenter })
                    .HasName("MA_CostCenters4");

                entity.HasIndex(e => new { e.GroupCode, e.CostCenter })
                    .HasName("MA_CostCenters5");

                entity.HasIndex(e => new { e.Nature, e.CostCenter })
                    .HasName("MA_CostCenters3");

                entity.Property(e => e.CostCenter)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Account)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BarcodeSegment)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodeType).HasDefaultValueSql("((7929856))");

                entity.Property(e => e.CostCenterManager)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DepreciationPerc).HasDefaultValueSql("((0))");

                entity.Property(e => e.Description)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DirectEmployeesNo).HasDefaultValueSql("((0))");

                entity.Property(e => e.Disabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DummyCostCenter)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.GroupCode)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IndirectEmployeesNo).HasDefaultValueSql("((0))");

                entity.Property(e => e.Nature).HasDefaultValueSql("((8585218))");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SqMtSurfaceArea).HasDefaultValueSql("((0))");

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
            modelBuilder.Entity<MaCostCentersBalances>(entity =>
{
                entity.HasKey(e => new { e.CostCenter, e.Account, e.FiscalYear, e.BalanceYear, e.BalanceType, e.BalanceMonth })
                    .HasName("PK_CostCentersBalances")
                    .IsClustered(false);

                entity.ToTable("MA_CostCentersBalances");

                entity.Property(e => e.CostCenter)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Account)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.ActualCredit).HasDefaultValueSql("((0))");

                entity.Property(e => e.ActualCreditQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ActualDebit).HasDefaultValueSql("((0))");

                entity.Property(e => e.ActualDebitQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.BudgetCredit).HasDefaultValueSql("((0))");

                entity.Property(e => e.BudgetCreditQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.BudgetDebit).HasDefaultValueSql("((0))");

                entity.Property(e => e.BudgetDebitQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ForecastCredit).HasDefaultValueSql("((0))");

                entity.Property(e => e.ForecastCreditQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ForecastDebit).HasDefaultValueSql("((0))");

                entity.Property(e => e.ForecastDebitQty).HasDefaultValueSql("((0))");

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

                entity.HasOne(d => d.CostCenterNavigation)
                    .WithMany(p => p.MaCostCentersBalances)
                    .HasForeignKey(d => d.CostCenter)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CostCenter_CostCenter_00");
            });
            modelBuilder.Entity<MaTransferTpl>(entity =>
{
                entity.HasKey(e => e.Template)
                    .HasName("PK_TransferTpl")
                    .IsClustered(false);

                entity.ToTable("MA_TransferTpl");

                entity.Property(e => e.Template)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Priority).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.ValidityEndingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.ValidityStartingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");
            });
            modelBuilder.Entity<MaTransferTplDest>(entity =>
{
                entity.HasKey(e => new { e.Template, e.CostCenter, e.Job, e.ProductLine })
                    .HasName("PK_TransferTplDest")
                    .IsClustered(false);

                entity.ToTable("MA_TransferTplDest");

                entity.HasIndex(e => new { e.Template, e.Line })
                    .HasName("MA_TransferTplDest2");

                entity.Property(e => e.Template)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.CostCenter)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Job)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ProductLine)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Line).HasDefaultValueSql("((0))");

                entity.Property(e => e.NotToBePosted)
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

                entity.Property(e => e.TransferPerc).HasDefaultValueSql("((0))");
            });
            modelBuilder.Entity<MaTransferTplOrigin>(entity =>
{
                entity.HasKey(e => new { e.Template, e.CostCenter })
                    .HasName("PK_TransferTplOrigin")
                    .IsClustered(false);

                entity.ToTable("MA_TransferTplOrigin");

                entity.HasIndex(e => new { e.Template, e.Line })
                    .HasName("MA_TransferTplOrigin2");

                entity.Property(e => e.Template)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.CostCenter)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Detailed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Line).HasDefaultValueSql("((0))");

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
