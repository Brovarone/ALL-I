using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class PayeesDbContext : DbContext
    {
        public PayeesDbContext()
        {
        }
        public PayeesDbContext(DbContextOptions<PayeesDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaDutyCodes> MaDutyCodes { get; set; }
        public virtual DbSet<MaFeeTemplates> MaFeeTemplates { get; set; }
        public virtual DbSet<MaFeeTemplatesDetail> MaFeeTemplatesDetail { get; set; }
        public virtual DbSet<MaFees> MaFees { get; set; }
        public virtual DbSet<MaFeesDetails> MaFeesDetails { get; set; }
        public virtual DbSet<MaPayeesParameters> MaPayeesParameters { get; set; }
        public virtual DbSet<MaPayeesParametersAllowance> MaPayeesParametersAllowance { get; set; }
        public virtual DbSet<MaPayeesParametersFirrmulti> MaPayeesParametersFirrmulti { get; set; }
        public virtual DbSet<MaPayeesParametersFirrone> MaPayeesParametersFirrone { get; set; }
        public virtual DbSet<MaPayeesParametersInps> MaPayeesParametersInps { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaDutyCodes>(entity =>
{
                entity.HasKey(e => new { e.DutyType, e.Reason })
                    .HasName("PK_DutyCodes")
                    .IsClustered(false);

                entity.ToTable("MA_DutyCodes");

                entity.HasIndex(e => e.Description)
                    .HasName("IX_MA_DutyCodes_1");

                entity.Property(e => e.Reason)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Form770Letter)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NeedMonth)
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

                entity.Property(e => e.WithholdingTaxDebitForDuty)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
            modelBuilder.Entity<MaFeeTemplates>(entity =>
{
                entity.HasKey(e => e.FeeTpl)
                    .HasName("PK_FeeTemplates")
                    .IsClustered(false);

                entity.ToTable("MA_FeeTemplates");

                entity.Property(e => e.FeeTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DirectorRemuneration)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Duty)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DutyType).HasDefaultValueSql("((10616832))");

                entity.Property(e => e.EnasarcoassPerc)
                    .HasColumnName("ENASARCOAssPerc")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.EnasarcoassPercSp)
                    .HasColumnName("ENASARCOAssPercSP")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Enasarcoperc)
                    .HasColumnName("ENASARCOPerc")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.EnasarcopercSalesPerson)
                    .HasColumnName("ENASARCOPercSalesPerson")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Form770Frame)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InpscalculationType)
                    .HasColumnName("INPSCalculationType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TaxPerc).HasDefaultValueSql("((0.00))");

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

                entity.Property(e => e.WithholdingTaxAsTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.WithholdingTaxBasePerc).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.WithholdingTaxPerc).HasDefaultValueSql("((0.00))");
            });
            modelBuilder.Entity<MaFeeTemplatesDetail>(entity =>
{
                entity.HasKey(e => new { e.Template, e.Line })
                    .HasName("PK_FeeTemplatesDetail")
                    .IsClustered(false);

                entity.ToTable("MA_FeeTemplatesDetail");

                entity.Property(e => e.Template)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Amount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Cpa)
                    .HasColumnName("CPA")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Description)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Enasarco)
                    .HasColumnName("ENASARCO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Inps)
                    .HasColumnName("INPS")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IsAnAdvanceExpense)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Tax)
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

                entity.Property(e => e.WithholdingTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.WithholdingTaxExcluded)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.HasOne(d => d.TemplateNavigation)
                    .WithMany(p => p.MaFeeTemplatesDetail)
                    .HasForeignKey(d => d.Template)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FeeTemplat_FeeTemplat_00");
            });
            modelBuilder.Entity<MaFees>(entity =>
{
                entity.HasKey(e => e.FeeId)
                    .HasName("PK_Fees")
                    .IsClustered(false);

                entity.ToTable("MA_Fees");

                entity.HasIndex(e => e.JournalEntryId)
                    .HasName("IX_MA_Fees5");

                entity.HasIndex(e => e.PaymentDate)
                    .HasName("IX_MA_Fees3");

                entity.HasIndex(e => new { e.CustSuppType, e.CustSupp, e.DocumentDate })
                    .HasName("IX_MA_Fees2");

                entity.HasIndex(e => new { e.DocumentDate, e.LogNo, e.DocNo })
                    .HasName("IX_MA_Fees1");

                entity.HasIndex(e => new { e.WithholdingTaxDate, e.Duty, e.WithholdingTaxPaid, e.WithholdingTaxSuspended })
                    .HasName("IX_MA_Fees4");

                entity.Property(e => e.FeeId).ValueGeneratedNever();

                entity.Property(e => e.AccrualDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.ClosingJournalEntryId).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.CustSuppType).HasDefaultValueSql("((3211265))");

                entity.Property(e => e.Description)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DirectorRemuneration)
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

                entity.Property(e => e.Duty)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DutyType).HasDefaultValueSql("((10616832))");

                entity.Property(e => e.Enasarco)
                    .HasColumnName("ENASARCO")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Enasarcoass)
                    .HasColumnName("ENASARCOAss")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.EnasarcoassPerc)
                    .HasColumnName("ENASARCOAssPerc")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.EnasarcoassPercSp)
                    .HasColumnName("ENASARCOAssPercSP")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.EnasarcoassSp)
                    .HasColumnName("ENASARCOAssSP")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Enasarcoperc)
                    .HasColumnName("ENASARCOPerc")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.EnasarcopercSalesPerson)
                    .HasColumnName("ENASARCOPercSalesPerson")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.EnasarcopymtDate)
                    .HasColumnName("ENASARCOPymtDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.EnasarcopymtMethod)
                    .HasColumnName("ENASARCOPymtMethod")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Enasarcosalesperson)
                    .HasColumnName("ENASARCOSalesperson")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.EnasarcotaxableAmount)
                    .HasColumnName("ENASARCOTaxableAmount")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Enasarcotransfer)
                    .HasColumnName("ENASARCOTransfer")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FeePaid)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Fixing).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.FixingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.FixingIsManual)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Form770Frame)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Form770Letter)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Inps)
                    .HasColumnName("INPS")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.InpscalculationType)
                    .HasColumnName("INPSCalculationType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Inpsemployees)
                    .HasColumnName("INPSEmployees")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Inpspaid)
                    .HasColumnName("INPSPaid")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InpspymtDate)
                    .HasColumnName("INPSPymtDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.InpspymtMethod)
                    .HasColumnName("INPSPymtMethod")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Inpstransfer)
                    .HasColumnName("INPSTransfer")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.JournalEntryId).HasDefaultValueSql("((0))");

                entity.Property(e => e.LogNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OneFirmOnly)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Paid).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.PayableAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Payment)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PaymentDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.ProForma)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ProgrNumber).HasDefaultValueSql("((0))");

                entity.Property(e => e.PymtMethod).HasDefaultValueSql("((0))");

                entity.Property(e => e.PymtNumber).HasDefaultValueSql("((0))");

                entity.Property(e => e.PymtSchedId).HasDefaultValueSql("((0))");

                entity.Property(e => e.Series)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StandardLetter)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Tax).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TaxPerc).HasDefaultValueSql("((0.00))");

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

                entity.Property(e => e.Template)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TransferJournalEntryId).HasDefaultValueSql("((0))");

                entity.Property(e => e.WithholdingTax).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.WithholdingTaxAccrualYear).HasDefaultValueSql("((0))");

                entity.Property(e => e.WithholdingTaxBasePerc).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.WithholdingTaxDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.WithholdingTaxPaid)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.WithholdingTaxPerc).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.WithholdingTaxPymMethod)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.WithholdingTaxPymtDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.WithholdingTaxSuspended)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.WithholdingTaxTransfer)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");
            });
            modelBuilder.Entity<MaFeesDetails>(entity =>
{
                entity.HasKey(e => new { e.FeeId, e.Line })
                    .HasName("PK_FeesDetails")
                    .IsClustered(false);

                entity.ToTable("MA_FeesDetails");

                entity.HasIndex(e => new { e.CustSuppType, e.CustSupp })
                    .HasName("IX_MA_FeesDetails1");

                entity.Property(e => e.Amount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Cpa)
                    .HasColumnName("CPA")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CustSupp)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustSuppType).HasDefaultValueSql("((3211265))");

                entity.Property(e => e.Description)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Enasarco)
                    .HasColumnName("ENASARCO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Inps)
                    .HasColumnName("INPS")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IsAnAdvanceExpense)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Tax)
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

                entity.Property(e => e.WithholdingTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.WithholdingTaxExcluded)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.HasOne(d => d.Fee)
                    .WithMany(p => p.MaFeesDetails)
                    .HasForeignKey(d => d.FeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FeesDetail_Fees_00");
            });
            modelBuilder.Entity<MaPayeesParameters>(entity =>
{
                entity.HasKey(e => e.PayeesParametersId)
                    .HasName("PK_PayeesParameters")
                    .IsClustered(false);

                entity.ToTable("MA_PayeesParameters");

                entity.Property(e => e.PayeesParametersId).ValueGeneratedNever();

                entity.Property(e => e.ContributionTransferSplitted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ContributionsDebitTransfer)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Enasarcoaccount)
                    .HasColumnName("ENASARCOAccount")
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Enasarcocost)
                    .HasColumnName("ENASARCOCost")
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InpsatypicalPerc)
                    .HasColumnName("INPSAtypicalPerc")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Inpscost)
                    .HasColumnName("INPSCost")
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Inpsdebit)
                    .HasColumnName("INPSDebit")
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InpsdebitProfessional)
                    .HasColumnName("INPSDebitProfessional")
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Inpsdenominator)
                    .HasColumnName("INPSDenominator")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.InpsdenominatorProfessional)
                    .HasColumnName("INPSDenominatorProfessional")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Inpsnumerator)
                    .HasColumnName("INPSNumerator")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.InpsnumeratorProfessional)
                    .HasColumnName("INPSNumeratorProfessional")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Inpsoffice)
                    .HasColumnName("INPSOffice")
                    .HasMaxLength(32)
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

                entity.Property(e => e.PymtScheduleNetContribution)
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

                entity.Property(e => e.TransfBySuppContrib)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.TransfBySuppFeeContrib)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.TransferAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TransferAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.WithholdTaxExemptThreshold).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.WithholdingTaxBasePerc).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.WithholdingTaxDebit)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.WithholdingTaxPerc).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.WithholdingTaxPymtDay).HasDefaultValueSql("((0))");

                entity.Property(e => e.WithholdingTaxPymtMonths).HasDefaultValueSql("((0))");
            });
            modelBuilder.Entity<MaPayeesParametersAllowance>(entity =>
{
                entity.HasKey(e => e.Line)
                    .HasName("PK_PayeesParametersAllowance")
                    .IsClustered(false);

                entity.ToTable("MA_PayeesParametersAllowance");

                entity.Property(e => e.Line).ValueGeneratedNever();

                entity.Property(e => e.FromYear).HasDefaultValueSql("((0))");

                entity.Property(e => e.MaxValue).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Perc).HasDefaultValueSql("((0.00))");

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

                entity.Property(e => e.ToYear).HasDefaultValueSql("((0))");
            });
            modelBuilder.Entity<MaPayeesParametersFirrmulti>(entity =>
{
                entity.HasKey(e => e.Line)
                    .HasName("PK_PayeesParametersFIRRMulti")
                    .IsClustered(false);

                entity.ToTable("MA_PayeesParametersFIRRMulti");

                entity.Property(e => e.Line).ValueGeneratedNever();

                entity.Property(e => e.Amount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Description)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FromAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Perc).HasDefaultValueSql("((0.00))");

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

                entity.Property(e => e.ToAmount).HasDefaultValueSql("((0.00))");
            });
            modelBuilder.Entity<MaPayeesParametersFirrone>(entity =>
{
                entity.HasKey(e => e.Line)
                    .HasName("PK_PayeesParametersFIRROne")
                    .IsClustered(false);

                entity.ToTable("MA_PayeesParametersFIRROne");

                entity.Property(e => e.Line).ValueGeneratedNever();

                entity.Property(e => e.Amount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Description)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FromAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Perc).HasDefaultValueSql("((0.00))");

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

                entity.Property(e => e.ToAmount).HasDefaultValueSql("((0.00))");
            });
            modelBuilder.Entity<MaPayeesParametersInps>(entity =>
{
                entity.HasKey(e => e.Line)
                    .HasName("PK_PayeesParametersINPS")
                    .IsClustered(false);

                entity.ToTable("MA_PayeesParametersINPS");

                entity.Property(e => e.Line).ValueGeneratedNever();

                entity.Property(e => e.BasePerc).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Description)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FromAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Perc).HasDefaultValueSql("((0.00))");

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

                entity.Property(e => e.ToAmount).HasDefaultValueSql("((0.00))");
            });
        }
    }
}
