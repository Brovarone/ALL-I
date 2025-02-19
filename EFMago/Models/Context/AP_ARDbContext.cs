using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class AP_ARDbContext : DbContext
    {
        public AP_ARDbContext()
        {
        }
        public AP_ARDbContext(DbContextOptions<AP_ARDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaBills> MaBills { get; set; }
        public virtual DbSet<MaBoletos> MaBoletos { get; set; }
        public virtual DbSet<MaCashFlowParameters> MaCashFlowParameters { get; set; }
        public virtual DbSet<MaCheckReturnReason> MaCheckReturnReason { get; set; }
        public virtual DbSet<MaCollectionParameters> MaCollectionParameters { get; set; }
        public virtual DbSet<MaPaymentAccounts> MaPaymentAccounts { get; set; }
        public virtual DbSet<MaPaymentCashes> MaPaymentCashes { get; set; }
        public virtual DbSet<MaPaymentParameters> MaPaymentParameters { get; set; }
        public virtual DbSet<MaPaymentTermsDefaults> MaPaymentTermsDefaults { get; set; }
        public virtual DbSet<MaPyblsRcvbls> MaPyblsRcvbls { get; set; }
        public virtual DbSet<MaPyblsRcvblsDetails> MaPyblsRcvblsDetails { get; set; }
        public virtual DbSet<MaPyblsRcvblsParameters> MaPyblsRcvblsParameters { get; set; }
        public virtual DbSet<MaPyblsRcvblsParametersRate> MaPyblsRcvblsParametersRate { get; set; }
        public virtual DbSet<MaPyblsRcvblsParamsReqPymt> MaPyblsRcvblsParamsReqPymt { get; set; }
        public virtual DbSet<MaSddmandate> MaSddmandate { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaBills>(entity =>
{
                entity.HasKey(e => e.BillCode)
                    .HasName("PK_Bills")
                    .IsClustered(false);

                entity.ToTable("MA_Bills");

                entity.HasIndex(e => new { e.Customer, e.DueDate })
                    .HasName("MA_Bills3");

                entity.HasIndex(e => new { e.DueDate, e.Customer })
                    .HasName("MA_Bills2");

                entity.HasIndex(e => new { e.DueDate, e.PresentationBank, e.PresentationCa })
                    .HasName("MA_Bills4");

                entity.HasIndex(e => new { e.PresentationBank, e.PresentationCa, e.DueDate })
                    .HasName("MA_Bills5");

                entity.HasIndex(e => new { e.PresentationDate, e.PresentationBank, e.PresentationCa, e.DueDate })
                    .HasName("MA_Bills6");

                entity.Property(e => e.BillCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Amount).HasDefaultValueSql("((0))");

                entity.Property(e => e.BillStatus).HasDefaultValueSql("((5701632))");

                entity.Property(e => e.BillType).HasDefaultValueSql("((5373953))");

                entity.Property(e => e.CollectionDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.CollectionJeid)
                    .HasColumnName("CollectionJEId")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Customer)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Description)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Disabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DueDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.FiscalNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IsAblankCheck)
                    .HasColumnName("IsABlankCheck")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IsAnIssuedBill)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IssueDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.IssuePlace)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IssuerBank)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IssuerBankCa)
                    .HasColumnName("IssuerBankCA")
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IssuerFiscalCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IssuerName)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IssuerTaxIdNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OutstandingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.OutstandingJeid)
                    .HasColumnName("OutstandingJEId")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PresentationBank)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PresentationCa)
                    .HasColumnName("PresentationCA")
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PresentationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.PresentationJeid)
                    .HasColumnName("PresentationJEId")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.RePresentationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.RePresentationJeid)
                    .HasColumnName("RePresentationJEId")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ReceiptDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.ReceiptJeid)
                    .HasColumnName("ReceiptJEId")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Return1Date)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Return1Jeid)
                    .HasColumnName("Return1JEId")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Return1Reason)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Return2Date)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Return2Jeid)
                    .HasColumnName("Return2JEId")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Return2Reason)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Supplier)
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

                entity.Property(e => e.TransferDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.TransferJeid)
                    .HasColumnName("TransferJEId")
                    .HasDefaultValueSql("((0))");
            });
            modelBuilder.Entity<MaBoletos>(entity =>
{
                entity.HasKey(e => e.BoletoNo)
                    .HasName("PK_Boletos")
                    .IsClustered(false);

                entity.ToTable("MA_Boletos");

                entity.HasIndex(e => new { e.Customer, e.DueDate })
                    .HasName("MA_Boletos3");

                entity.HasIndex(e => new { e.DueDate, e.Customer })
                    .HasName("MA_Boletos2");

                entity.Property(e => e.BoletoNo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Amount).HasDefaultValueSql("((0))");

                entity.Property(e => e.BarCode)
                    .HasMaxLength(54)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Cancelled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Collected)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CollectedAmount).HasDefaultValueSql("((0))");

                entity.Property(e => e.CollectionDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.CollectionJeid)
                    .HasColumnName("CollectionJEId")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ConditionCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Customer)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DiscountRate).HasDefaultValueSql("((0))");

                entity.Property(e => e.DueDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Instruction)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InterestPenality).HasDefaultValueSql("((0))");

                entity.Property(e => e.InterestRate).HasDefaultValueSql("((0))");

                entity.Property(e => e.IssuerBank)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IssuingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.OriginalAmount).HasDefaultValueSql("((0))");

                entity.Property(e => e.OurNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PenalityRate).HasDefaultValueSql("((0))");

                entity.Property(e => e.PrintedOnFile)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PrintedOnPaper)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PrintedOurNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProtestDays).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.UpdateNo).HasDefaultValueSql("((0))");
            });
            modelBuilder.Entity<MaCashFlowParameters>(entity =>
{
                entity.HasKey(e => e.CashFlowParametersId)
                    .HasName("PK_CashFlowParameters")
                    .IsClustered(false);

                entity.ToTable("MA_CashFlowParameters");

                entity.Property(e => e.CashFlowParametersId).ValueGeneratedNever();

                entity.Property(e => e.CustAdvancePymtAccount)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustAdvancePymtCash)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NegAllowancePymtAccount)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NegAllowancePymtCash)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NegRoundingPymtAccount)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PosAllowancePymtAccount)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PosAllowancePymtCash)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PosRoundingPymtAccount)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SuppAdvancePymtAccount)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SuppAdvancePymtCash)
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
            modelBuilder.Entity<MaCheckReturnReason>(entity =>
{
                entity.HasKey(e => e.ReturnReason)
                    .HasName("PK_CheckReturnReason")
                    .IsClustered(false);

                entity.ToTable("MA_CheckReturnReason");

                entity.Property(e => e.ReturnReason)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Disabled)
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
            modelBuilder.Entity<MaCollectionParameters>(entity =>
{
                entity.HasKey(e => e.CollectionParametersId)
                    .HasName("PK_CollectionParameters")
                    .IsClustered(false);

                entity.ToTable("MA_CollectionParameters");

                entity.Property(e => e.CollectionParametersId).ValueGeneratedNever();

                entity.Property(e => e.AfterCollection)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AlignRcvblInstDateToBoleto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Bank)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BillOfExchToBePresented)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BillOfExchUponCollection)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BillsAreVouchers)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.BlockOutstandingCustomers)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Ca)
                    .HasColumnName("CA")
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CashOrderToBePresented)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CashOrderUponCollection)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ChargesAccount)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ClosedInstallmentPresentable)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CustClosingInCollection)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CustClosingInInvoicing)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CustClosingInPresentation)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CustClosingOnBankAccount)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DdtoBePresented)
                    .HasColumnName("DDToBePresented")
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DduponCollection)
                    .HasColumnName("DDUponCollection")
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DebitBankForOutstanding)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DefaultBoletoBankCode)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DefaultBoletoBankCondition)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExcludeWithHoldingTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FactoringAdvAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FactoringAdvAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FactoringBank)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FactoringCa)
                    .HasColumnName("FactoringCA")
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FactoringCollAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FactoringCollAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FactoringPresAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FactoringPresAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FactoringToBePresented)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Glnotes)
                    .HasColumnName("GLNotes")
                    .HasDefaultValueSql("((10813440))");

                entity.Property(e => e.IssuedChecks)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NotClosedInExposure)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.OneGllineForEachBill)
                    .HasColumnName("OneGLLineForEachBill")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.OneGllineForEachCustomer)
                    .HasColumnName("OneGLLineForEachCustomer")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.OpenedAdmCasesManagement)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.OutstandingAccount)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OutstandingReopening)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PancustClosingInCollection)
                    .HasColumnName("PANCustClosingInCollection")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PantoBePresented)
                    .HasColumnName("PANToBePresented")
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PanuponCollection)
                    .HasColumnName("PANUponCollection")
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Presentation).HasDefaultValueSql("((1376256))");

                entity.Property(e => e.ReopPymtTerm).HasDefaultValueSql("((2686977))");

                entity.Property(e => e.ReopenAtDueDate)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ReopenTransferOnBillAccount)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ReopeningAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReopeningAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SddmandateType)
                    .HasColumnName("SDDMandateType")
                    .HasDefaultValueSql("((2686997))");

                entity.Property(e => e.SlipWithDifferentPymtTerm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SubjectToCollection)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxExigibilityOnAdvance)
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

                entity.Property(e => e.TransInPresDebitBank)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.TransferInPresentation)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseApproval)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseBank)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseFactoringBank)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UsePymtScheduleBank)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseVouchersBank)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.VouchersBank)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.VouchersCa)
                    .HasColumnName("VouchersCA")
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.VouchersManagement)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.VouchersPresentation).HasDefaultValueSql("((1376256))");
            });
            modelBuilder.Entity<MaPaymentAccounts>(entity =>
{
                entity.HasKey(e => e.PymtAccount)
                    .HasName("PK_PaymentAccounts")
                    .IsClustered(false);

                entity.ToTable("MA_PaymentAccounts");

                entity.HasIndex(e => e.Description)
                    .HasName("MA_PaymentAccounts2");

                entity.Property(e => e.PymtAccount)
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

                entity.Property(e => e.Nature).HasDefaultValueSql("((3014656))");

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
            modelBuilder.Entity<MaPaymentCashes>(entity =>
{
                entity.HasKey(e => e.PymtCash)
                    .HasName("PK_PaymentCashes")
                    .IsClustered(false);

                entity.ToTable("MA_PaymentCashes");

                entity.HasIndex(e => e.Description)
                    .HasName("MA_PaymentCashes2");

                entity.Property(e => e.PymtCash)
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
            modelBuilder.Entity<MaPaymentParameters>(entity =>
{
                entity.HasKey(e => e.PaymentParametersId)
                    .HasName("PK_PaymentParameters")
                    .IsClustered(false);

                entity.ToTable("MA_PaymentParameters");

                entity.Property(e => e.PaymentParametersId).ValueGeneratedNever();

                entity.Property(e => e.AllPymtTerms)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Bank)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Ca)
                    .HasColumnName("CA")
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Charges)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Glnotes)
                    .HasColumnName("GLNotes")
                    .HasDefaultValueSql("((10813440))");

                entity.Property(e => e.OneGllineForEachInstallment)
                    .HasColumnName("OneGLLineForEachInstallment")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PaymentInIssue)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SlipWithDifferentPymtTerm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.StatisticAmount).HasDefaultValueSql("((0))");

                entity.Property(e => e.StatisticReason)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StatisticReasonOver)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StatisticType)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StatisticTypeOver)
                    .HasMaxLength(3)
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

                entity.Property(e => e.UseBank)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseProcessingDate)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UsePymtScheduleBank)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");
            });
            modelBuilder.Entity<MaPaymentTermsDefaults>(entity =>
{
                entity.HasKey(e => new { e.PaymentTermsDefaultsId, e.PaymentTerm })
                    .HasName("PK_PaymentTermsDefaults")
                    .IsClustered(false);

                entity.ToTable("MA_PaymentTermsDefaults");

                entity.Property(e => e.CollectionAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CollectionAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PaymentAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PaymentAccTpl)
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
            modelBuilder.Entity<MaPyblsRcvbls>(entity =>
{
                entity.HasKey(e => e.PymtSchedId)
                    .HasName("PK_PyblsRcvbls")
                    .IsClustered(false);

                entity.ToTable("MA_PyblsRcvbls");

                entity.HasIndex(e => e.JournalEntryId)
                    .HasName("MA_PyblsRcvbls3");

                entity.HasIndex(e => new { e.DocumentDate, e.DocNo, e.PymtSchedId })
                    .HasName("MA_PyblsRcvbls2");

                entity.Property(e => e.PymtSchedId).ValueGeneratedNever();

                entity.Property(e => e.Advance)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.AmountsWithWhtax)
                    .HasColumnName("AmountsWithWHTax")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Area)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Blocked)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ContractCode)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CreditNote)
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

                entity.Property(e => e.CustSuppType).HasDefaultValueSql("((3211264))");

                entity.Property(e => e.Description)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DocNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DocumentDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.EsrcheckDigit)
                    .HasColumnName("ESRCheckDigit")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EsrreferenceNumber)
                    .HasColumnName("ESRReferenceNumber")
                    .HasMaxLength(27)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Group1)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Group2)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ImIncidenceIsManual)
                    .HasColumnName("IM_IncidenceIsManual")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InstallmStartDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.JournalEntryId).HasDefaultValueSql("('0')");

                entity.Property(e => e.LogNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Payment)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProjectCode)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Salesperson)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SendDocumentsTo)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Settled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.TaxAmount).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.TotalAmountCn)
                    .HasColumnName("TotalAmountCN")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Whtaxable)
                    .HasColumnName("WHTaxable")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.WhtaxableCn)
                    .HasColumnName("WHTaxableCN")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.WithholdingTaxManagement)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");
            });
            modelBuilder.Entity<MaPyblsRcvblsDetails>(entity =>
{
                entity.HasKey(e => new { e.PymtSchedId, e.InstallmentNo, e.InstallmentType, e.ClosingType, e.InstallmentDate })
                    .HasName("PK_PyblsRcvblsDetails")
                    .IsClustered(false);

                entity.ToTable("MA_PyblsRcvblsDetails");

                entity.HasIndex(e => e.BillCode)
                    .HasName("MA_PyblsRcvblsDetailsd");

                entity.HasIndex(e => new { e.JournalEntryId, e.ClosingType })
                    .HasName("MA_PyblsRcvblsDetailsf");

                entity.HasIndex(e => new { e.PresentationJeid, e.InstallmentType })
                    .HasName("MA_PyblsRcvblsDetailse");

                entity.HasIndex(e => new { e.CustSuppType, e.CustSupp, e.OpeningDate })
                    .HasName("MA_PyblsRcvblsDetailsb");

                entity.HasIndex(e => new { e.CustSuppType, e.InstallmentDate, e.Closed })
                    .HasName("MA_PyblsRcvblsDetails4");

                entity.HasIndex(e => new { e.InstallmentDate, e.CustSuppType, e.CustSupp })
                    .HasName("MA_PyblsRcvblsDetails3");

                entity.HasIndex(e => new { e.OpeningDate, e.CustSuppType, e.CustSupp })
                    .HasName("MA_PyblsRcvblsDetailsa");

                entity.HasIndex(e => new { e.PresentationJeid, e.PymtSchedId, e.InstallmentNo })
                    .HasName("MA_PyblsRcvblsDetails2");

                entity.HasIndex(e => new { e.Slip, e.BillNo, e.PymtSchedId })
                    .HasName("MA_PyblsRcvblsDetailsc");

                entity.HasIndex(e => new { e.InstallmentType, e.CustSuppType, e.CustSupp, e.InstallmentDate })
                    .HasName("MA_PyblsRcvblsDetails5");

                entity.HasIndex(e => new { e.CustSuppType, e.InstallmentType, e.BillNo, e.Closed, e.InstallmentDate })
                    .HasName("MA_PyblsRcvblsDetails7");

                entity.HasIndex(e => new { e.CustSuppType, e.CustSupp, e.PymtSchedId, e.InstallmentNo, e.InstallmentType, e.InstallmentDate })
                    .HasName("MA_PyblsRcvblsDetails6");

                entity.HasIndex(e => new { e.InstallmentType, e.CustSuppType, e.PaymentTerm, e.Closed, e.PresentationDate, e.BillNo, e.InstallmentDate })
                    .HasName("MA_PyblsRcvblsDetails9");

                entity.HasIndex(e => new { e.InstallmentType, e.PaymentTerm, e.BillNo, e.PresentationBank, e.PresentationDate, e.Closed, e.CustSuppType, e.CustSuppBank })
                    .HasName("MA_PyblsRcvblsDetails8");

                entity.Property(e => e.InstallmentDate).HasColumnType("datetime");

                entity.Property(e => e.Advance)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Amount).HasDefaultValueSql("((0))");

                entity.Property(e => e.AmountType).HasDefaultValueSql("((6356995))");

                entity.Property(e => e.ApprovalDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.ApprovalJeid)
                    .HasColumnName("ApprovalJEId")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Approved)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ApprovedAmount).HasDefaultValueSql("((0))");

                entity.Property(e => e.ApprovedAmountBaseCurr).HasDefaultValueSql("((0))");

                entity.Property(e => e.Area)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AtSight)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.BillCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BillNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Blocked)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Ca)
                    .HasColumnName("CA")
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ChargesType).HasDefaultValueSql("((25559040))");

                entity.Property(e => e.Cin)
                    .HasColumnName("CIN")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Closed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Collected)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CollectionDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.CollectionJeid)
                    .HasColumnName("CollectionJEId")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CompensationAmount).HasDefaultValueSql("((0))");

                entity.Property(e => e.CompensationNo)
                    .HasMaxLength(10)
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

                entity.Property(e => e.CustSuppBank)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustSuppType).HasDefaultValueSql("((3211264))");

                entity.Property(e => e.CustomTariff)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DebitCa)
                    .HasColumnName("DebitCA")
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DebitCreditSign).HasDefaultValueSql("((4980736))");

                entity.Property(e => e.DocumentId).HasDefaultValueSql("('0')");

                entity.Property(e => e.DocumentType).HasDefaultValueSql("((3801088))");

                entity.Property(e => e.Fixing).HasDefaultValueSql("((0))");

                entity.Property(e => e.FixingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.FixingIsManual)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.JournalEntryId).HasDefaultValueSql("('0')");

                entity.Property(e => e.MandateCode)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MandateSequenceType).HasDefaultValueSql("('29425665')");

                entity.Property(e => e.NotPresentable)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OpenedAdmCases)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.OpeningDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.OpeningDateBeforePres)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Outstanding)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.OutstandingAmount).HasDefaultValueSql("((0))");

                entity.Property(e => e.OutstandingAmountBaseCurr).HasDefaultValueSql("((0))");

                entity.Property(e => e.OutstandingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.PayableAmountInBaseCurr).HasDefaultValueSql("((0))");

                entity.Property(e => e.PaymentTerm).HasDefaultValueSql("((2686977))");

                entity.Property(e => e.PresAmountWithWhtax)
                    .HasColumnName("PresAmountWithWHTax")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Presentation).HasDefaultValueSql("((1376256))");

                entity.Property(e => e.PresentationAmount).HasDefaultValueSql("((0))");

                entity.Property(e => e.PresentationAmountBaseCurr).HasDefaultValueSql("((0))");

                entity.Property(e => e.PresentationBank)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PresentationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.PresentationJeid)
                    .HasColumnName("PresentationJEId")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PresentationNotes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Presented)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Printed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PymtAccount)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PymtCash)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReopeningInstallmentNo).HasDefaultValueSql("((0))");

                entity.Property(e => e.Salesperson)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SepacategoryPurpose)
                    .HasColumnName("SEPACategoryPurpose")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Slip)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StatisticReason)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StatisticType)
                    .HasMaxLength(3)
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

                entity.Property(e => e.ToBeCompensated)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ValueDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.HasOne(d => d.PymtSched)
                    .WithMany(p => p.MaPyblsRcvblsDetails)
                    .HasForeignKey(d => d.PymtSchedId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PyblsRcvbl_PyblsRcvbl_00");
            });
            modelBuilder.Entity<MaPyblsRcvblsParameters>(entity =>
{
                entity.HasKey(e => e.PyblsRcvblsParametersId)
                    .HasName("PK_PyblsRcvblsParameters")
                    .IsClustered(false);

                entity.ToTable("MA_PyblsRcvblsParameters");

                entity.Property(e => e.PyblsRcvblsParametersId).ValueGeneratedNever();

                entity.Property(e => e.AdvancePaymentTerm)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BillsAndPaymentsExtension)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BillsAndPaymentsFolder)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Calendar)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0000')");

                entity.Property(e => e.ConfirmPymtTerm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CustClearingPymtType).HasDefaultValueSql("((2686977))");

                entity.Property(e => e.CustOverpymtAmount).HasDefaultValueSql("((0))");

                entity.Property(e => e.CustOverpymtEnabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CustomDescription1)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustomDescription2)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NoBillsInClearing)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NoPaymentsToBlockedSupplier)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NoPymtOrdersInClearing)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NoSelBlockedInClearing)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NoSelLitigInClearing)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ReqForPymtFile)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReqForPymtMaxLevel).HasDefaultValueSql("((0))");

                entity.Property(e => e.SuppClearingPymtType).HasDefaultValueSql("((2686977))");

                entity.Property(e => e.SuppOverpymtAmount).HasDefaultValueSql("((0))");

                entity.Property(e => e.SuppOverpymtEnabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.TaxTransferInClearing)
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

                entity.Property(e => e.UnblockCustInClearing)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.WtaxTransferInCollection)
                    .HasColumnName("WTaxTransferInCollection")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");
            });
            modelBuilder.Entity<MaPyblsRcvblsParametersRate>(entity =>
{
                entity.HasKey(e => new { e.PyblsRcvblsParametersId, e.Line })
                    .HasName("PK_PyblsRcvblsParametersRate")
                    .IsClustered(false);

                entity.ToTable("MA_PyblsRcvblsParametersRate");

                entity.Property(e => e.Disabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FromDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.InterestRate).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.ToDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");
            });
            modelBuilder.Entity<MaPyblsRcvblsParamsReqPymt>(entity =>
{
                entity.HasKey(e => new { e.PyblsRcvblsParamsReqPymtId, e.Line })
                    .HasName("PK_PyblsRcvblsParamsReqPymt")
                    .IsClustered(false);

                entity.ToTable("MA_PyblsRcvblsParamsReqPymt");

                entity.Property(e => e.DescriptiveText)
                    .HasMaxLength(128)
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
            modelBuilder.Entity<MaSddmandate>(entity =>
{
                entity.HasKey(e => e.MandateCode)
                    .HasName("PK_SDDMandate")
                    .IsClustered(false);

                entity.ToTable("MA_SDDMandate");

                entity.Property(e => e.MandateCode)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Customer)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustomerBank)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustomerCa)
                    .HasColumnName("CustomerCA")
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustomerIban)
                    .HasColumnName("CustomerIBAN")
                    .HasMaxLength(34)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustomerIbanisManual)
                    .HasColumnName("CustomerIBANIsManual")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Ddmandate)
                    .HasColumnName("DDMandate")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Draft)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.MandateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.MandateFirstDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.MandateLastDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.MandateOneOff)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.MandateType).HasDefaultValueSql("((2686997))");

                entity.Property(e => e.Notes)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PrintDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Printed)
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

                entity.Property(e => e.Umrcode)
                    .HasColumnName("UMRCode")
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
        }
    }
}
