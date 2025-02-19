using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class Accounting_ITDbContext : DbContext
    {
        public Accounting_ITDbContext()
        {
        }
        public Accounting_ITDbContext(DbContextOptions<Accounting_ITDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaCustList> MaCustList { get; set; }
        public virtual DbSet<MaCustListNoTaxable> MaCustListNoTaxable { get; set; }
        public virtual DbSet<MaCustSuppBlackList> MaCustSuppBlackList { get; set; }
        public virtual DbSet<MaCustSuppList> MaCustSuppList { get; set; }
        public virtual DbSet<MaCustSuppTaxCommunication> MaCustSuppTaxCommunication { get; set; }
        public virtual DbSet<MaSuppList> MaSuppList { get; set; }
        public virtual DbSet<MaSuppListNoTaxable> MaSuppListNoTaxable { get; set; }
        public virtual DbSet<MaSuppListNoTaxableSummary> MaSuppListNoTaxableSummary { get; set; }
        public virtual DbSet<MaSuppListSummary> MaSuppListSummary { get; set; }
        public virtual DbSet<MaTaxCodesLists> MaTaxCodesLists { get; set; }
        public virtual DbSet<MaTaxCommCninvoices> MaTaxCommCninvoices { get; set; }
        public virtual DbSet<MaTaxCommCntoSplit> MaTaxCommCntoSplit { get; set; }
        public virtual DbSet<MaTaxCommunicationGroup> MaTaxCommunicationGroup { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaCustList>(entity =>
{
                entity.HasKey(e => new { e.Customer, e.BalanceYear, e.IsManual, e.IssuingYear })
                    .HasName("PK_CustList")
                    .IsClustered(false);

                entity.ToTable("MA_CustList");

                entity.HasIndex(e => new { e.Customer, e.IsManual, e.BalanceYear, e.IssuingYear })
                    .HasName("MA_CustList2");

                entity.Property(e => e.Customer)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.IsManual)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ExemptNoTaxable).HasDefaultValueSql("((0))");

                entity.Property(e => e.TaxAmount).HasDefaultValueSql("((0))");

                entity.Property(e => e.TaxableAmount).HasDefaultValueSql("((0))");

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
            modelBuilder.Entity<MaCustListNoTaxable>(entity =>
{
                entity.HasKey(e => new { e.Customer, e.BalanceYear, e.IsManual, e.IssuingYear })
                    .HasName("PK_CustListNoTaxable")
                    .IsClustered(false);

                entity.ToTable("MA_CustListNoTaxable");

                entity.HasIndex(e => new { e.Customer, e.IsManual, e.BalanceYear, e.IssuingYear })
                    .HasName("MA_CustListNoTaxable2");

                entity.Property(e => e.Customer)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.IsManual)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ExemptNoTaxable).HasDefaultValueSql("((0))");

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
            modelBuilder.Entity<MaCustSuppBlackList>(entity =>
{
                entity.HasKey(e => new { e.CustSuppType, e.CustSupp, e.BalanceYear, e.BalanceMonth, e.IsManual, e.CreditNotesPrevPeriod, e.CreditNotesPrevYear })
                    .HasName("PK_CustSuppBlackList")
                    .IsClustered(false);

                entity.ToTable("MA_CustSuppBlackList");

                entity.HasIndex(e => new { e.Grouping, e.CustSuppType, e.CustSupp, e.CreditNotesPrevPeriod, e.CreditNotesPrevYear })
                    .HasName("IX_MA_CustSuppBlackList");

                entity.Property(e => e.CustSupp)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.IsManual)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CreditNotesPrevPeriod)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CreditNotesPrevYear)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Exempt).HasDefaultValueSql("((0))");

                entity.Property(e => e.Grouping)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NoTaxableGoods).HasDefaultValueSql("((0))");

                entity.Property(e => e.NoTaxableServices).HasDefaultValueSql("((0))");

                entity.Property(e => e.NotInBlackListAmount).HasDefaultValueSql("((0))");

                entity.Property(e => e.NotSubjectGoods).HasDefaultValueSql("((0))");

                entity.Property(e => e.NotSubjectServices).HasDefaultValueSql("((0))");

                entity.Property(e => e.TaxAmountGoods).HasDefaultValueSql("((0))");

                entity.Property(e => e.TaxAmountServices).HasDefaultValueSql("((0))");

                entity.Property(e => e.TaxableAmountGoods).HasDefaultValueSql("((0))");

                entity.Property(e => e.TaxableAmountServices).HasDefaultValueSql("((0))");

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
            modelBuilder.Entity<MaCustSuppList>(entity =>
{
                entity.HasKey(e => new { e.CustSuppType, e.CustSupp, e.BalanceYear, e.IsManual, e.CreditNotes })
                    .HasName("PK_CustSuppList")
                    .IsClustered(false);

                entity.ToTable("MA_CustSuppList");

                entity.HasIndex(e => new { e.CustSuppType, e.CustSupp, e.IsManual, e.BalanceYear, e.CreditNotes })
                    .HasName("IX_MA_CustSuppList");

                entity.Property(e => e.CustSupp)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.IsManual)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CreditNotes)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Exempt).HasDefaultValueSql("((0))");

                entity.Property(e => e.Grouping)
                    .HasMaxLength(31)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NoTaxable).HasDefaultValueSql("((0))");

                entity.Property(e => e.NumberOfInvoices).HasDefaultValueSql("((0))");

                entity.Property(e => e.TaxAmount).HasDefaultValueSql("((0))");

                entity.Property(e => e.TaxAmountNotInInvoice).HasDefaultValueSql("((0))");

                entity.Property(e => e.TaxableAmount).HasDefaultValueSql("((0))");

                entity.Property(e => e.TaxableAmountWithTax).HasDefaultValueSql("((0))");

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
            modelBuilder.Entity<MaCustSuppTaxCommunication>(entity =>
{
                entity.HasKey(e => new { e.CustSuppType, e.CustSupp, e.BalanceYear, e.IsManual, e.OperationDate })
                    .HasName("PK_CustSuppTaxComm")
                    .IsClustered(false);

                entity.ToTable("MA_CustSuppTaxCommunication");

                entity.Property(e => e.CustSupp)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.IsManual)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.OperationDate).HasColumnType("datetime");

                entity.Property(e => e.CommunicationForm)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CreditNoteOriginalAmount).HasDefaultValueSql("((0))");

                entity.Property(e => e.CreditNoteOriginalDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.CreditNoteOriginalNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CreditNoteOriginalTax).HasDefaultValueSql("((0))");

                entity.Property(e => e.DocumentDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.DocumentNotes)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DocumentNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GroupPaymentType).HasDefaultValueSql("((28442624))");

                entity.Property(e => e.Grouping)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IsCreditNote)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Jeid)
                    .HasColumnName("JEId")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ReverseCharge)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SelfInvoice)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SummaryDocuments)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.TaxCommunicationGroup)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxNotShown)
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

                entity.Property(e => e.TotalAmount).HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalTaxAmount).HasDefaultValueSql("((0))");
            });
            modelBuilder.Entity<MaSuppList>(entity =>
{
                entity.HasKey(e => new { e.Supplier, e.BalanceYear, e.IsManual, e.IssuingYear })
                    .HasName("PK_SuppList")
                    .IsClustered(false);

                entity.ToTable("MA_SuppList");

                entity.HasIndex(e => new { e.Supplier, e.IsManual, e.BalanceYear, e.IssuingYear })
                    .HasName("MA_SuppList2");

                entity.Property(e => e.Supplier)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.IsManual)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Exempt).HasDefaultValueSql("((0))");

                entity.Property(e => e.NoTaxable).HasDefaultValueSql("((0))");

                entity.Property(e => e.NumberOfInvoices).HasDefaultValueSql("((0))");

                entity.Property(e => e.TaxAmount).HasDefaultValueSql("((0))");

                entity.Property(e => e.TaxableAmount).HasDefaultValueSql("((0))");

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
            modelBuilder.Entity<MaSuppListNoTaxable>(entity =>
{
                entity.HasKey(e => new { e.Supplier, e.BalanceYear, e.IsManual, e.IssuingYear })
                    .HasName("PK_SuppListNoTaxable")
                    .IsClustered(false);

                entity.ToTable("MA_SuppListNoTaxable");

                entity.HasIndex(e => new { e.Supplier, e.IsManual, e.BalanceYear, e.IssuingYear })
                    .HasName("MA_SuppListNoTaxable2");

                entity.Property(e => e.Supplier)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.IsManual)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ExemptNoTaxable).HasDefaultValueSql("((0))");

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
            modelBuilder.Entity<MaSuppListNoTaxableSummary>(entity =>
{
                entity.HasKey(e => new { e.BalanceYear, e.IsManual })
                    .HasName("PK_SuppListNoTaxableSummary")
                    .IsClustered(false);

                entity.ToTable("MA_SuppListNoTaxableSummary");

                entity.Property(e => e.IsManual)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Eupurchases)
                    .HasColumnName("EUPurchases")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ExtraEupurchases)
                    .HasColumnName("ExtraEUPurchases")
                    .HasDefaultValueSql("((0))");

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
            modelBuilder.Entity<MaSuppListSummary>(entity =>
{
                entity.HasKey(e => new { e.BalanceYear, e.IsManual })
                    .HasName("PK_SuppListSummary")
                    .IsClustered(false);

                entity.ToTable("MA_SuppListSummary");

                entity.Property(e => e.IsManual)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NumberOfInvoices).HasDefaultValueSql("((0))");

                entity.Property(e => e.TaxAmount).HasDefaultValueSql("((0))");

                entity.Property(e => e.TaxableAmount).HasDefaultValueSql("((0))");

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
            modelBuilder.Entity<MaTaxCodesLists>(entity =>
{
                entity.HasKey(e => e.TaxCode)
                    .HasName("PK_TaxCodesLists")
                    .IsClustered(false);

                entity.ToTable("MA_TaxCodesLists");

                entity.Property(e => e.TaxCode)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.CustListColumn)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustListColumn1)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustListType).HasDefaultValueSql("((12320768))");

                entity.Property(e => e.Eupurchases)
                    .HasColumnName("EUPurchases")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ExtraEupurchases)
                    .HasColumnName("ExtraEUPurchases")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SuppListColumn)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SuppListColumn1)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SuppListType).HasDefaultValueSql("((12320768))");

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

                entity.HasOne(d => d.TaxCodeNavigation)
                    .WithOne(p => p.MaTaxCodesLists)
                    .HasForeignKey<MaTaxCodesLists>(d => d.TaxCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TaxCodes_TaxCodesLi_00");
            });
            modelBuilder.Entity<MaTaxCommCninvoices>(entity =>
{
                entity.HasKey(e => new { e.Jeid, e.InvJeid })
                    .HasName("PK_TaxCommCNI")
                    .IsClustered(false);

                entity.ToTable("MA_TaxCommCNInvoices");

                entity.Property(e => e.Jeid).HasColumnName("JEId");

                entity.Property(e => e.InvJeid).HasColumnName("InvJEId");

                entity.Property(e => e.InvDocNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InvTaxAssigned).HasDefaultValueSql("((0))");

                entity.Property(e => e.InvTotAssigned).HasDefaultValueSql("((0))");

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
            modelBuilder.Entity<MaTaxCommCntoSplit>(entity =>
{
                entity.HasKey(e => e.Jeid)
                    .HasName("PK_TaxCommCNT")
                    .IsClustered(false);

                entity.ToTable("MA_TaxCommCNToSplit");

                entity.Property(e => e.Jeid)
                    .HasColumnName("JEId")
                    .ValueGeneratedNever();

                entity.Property(e => e.CustSuppType).HasDefaultValueSql("((3211264))");

                entity.Property(e => e.DocNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PostDate)
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

                entity.Property(e => e.TotAssigned).HasDefaultValueSql("((0))");

                entity.Property(e => e.TotTaxAssigned).HasDefaultValueSql("((0))");
            });
            modelBuilder.Entity<MaTaxCommunicationGroup>(entity =>
{
                entity.HasKey(e => e.TaxCommunicationGroup)
                    .HasName("PK_TaxCommuni")
                    .IsClustered(false);

                entity.ToTable("MA_TaxCommunicationGroup");

                entity.Property(e => e.TaxCommunicationGroup)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.CustSupp)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustSuppType).HasDefaultValueSql("((3211264))");

                entity.Property(e => e.Description)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MultiYear)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Summary)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.TaxableAmount).HasDefaultValueSql("((0))");

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
