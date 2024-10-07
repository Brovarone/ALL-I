using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

//Ultimo adeguamento mago.net 3.14.21
//Personalizzazioni
//  ALL_SPA - Ordini - 9
// Le tabelle usate in Mago.Net sono
//  ItemFiscalData
//  ItemStorageQty
//  ItemStorageQtyMonthly
//  ItemMonthlyBalances
//  (Lots e variants) + Monthly


namespace EFMago.Models
{
    public partial class PartiteContext : DbContext
    {
        public PartiteContext()
        {
        }

        public PartiteContext(DbContextOptions<PartiteContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaPyblsRcvbls> MaPyblsRcvbls { get; set; }
        public virtual DbSet<MaPyblsRcvblsDetails> MaPyblsRcvblsDetails { get; set; }
        public virtual DbSet<ImPyblsRcvblsJobIncidence> ImPyblsRcvblsJobIncidence { get; set; }
        public virtual DbSet<ImPyblsRcvblsJobIncidenceDocs> ImPyblsRcvblsJobIncidenceDocs { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // if (!optionsBuilder.IsConfigured)
            //  {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            //       optionsBuilder.UseSqlServer("Server=ACERBO\\SQLEXPRESS; Database=DEMON;User Id=sa;Password=euroufficio");
            //   }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

            modelBuilder.Entity<ImPyblsRcvblsJobIncidence>(entity =>
            {
                entity.HasKey(e => new { e.PymtSchedId, e.Job })
                    .IsClustered(false);

                entity.ToTable("IM_PyblsRcvblsJobIncidence");

                entity.Property(e => e.Job)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.JobIncidence).HasDefaultValueSql("((0))");

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

                entity.HasOne(d => d.PymtSched)
                    .WithMany(p => p.ImPyblsRcvblsJobIncidence)
                    .HasForeignKey(d => d.PymtSchedId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IM_PyblsRcvblsJobIncidence_MA_PyblsRcvbls");
            });

            modelBuilder.Entity<ImPyblsRcvblsJobIncidenceDocs>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("IM_PyblsRcvblsJobIncidenceDocs");

                entity.Property(e => e.CustSupp)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Disabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DocNo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.InstallmentDate).HasColumnType("datetime");

                entity.Property(e => e.Job)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });


        }

    }
}
