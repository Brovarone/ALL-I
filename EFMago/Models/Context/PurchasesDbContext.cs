using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class PurchasesDbContext : DbContext
    {
        public PurchasesDbContext()
        {
        }
        public PurchasesDbContext(DbContextOptions<PurchasesDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaPurchaseDoc> MaPurchaseDoc { get; set; }
        public virtual DbSet<MaPurchaseDocDetail> MaPurchaseDocDetail { get; set; }
        public virtual DbSet<MaPurchaseDocLinkOrders> MaPurchaseDocLinkOrders { get; set; }
        public virtual DbSet<MaPurchaseDocNotes> MaPurchaseDocNotes { get; set; }
        public virtual DbSet<MaPurchaseDocPymtSched> MaPurchaseDocPymtSched { get; set; }
        public virtual DbSet<MaPurchaseDocReferences> MaPurchaseDocReferences { get; set; }
        public virtual DbSet<MaPurchaseDocShipping> MaPurchaseDocShipping { get; set; }
        public virtual DbSet<MaPurchaseDocSummary> MaPurchaseDocSummary { get; set; }
        public virtual DbSet<MaPurchaseDocTaxSummary> MaPurchaseDocTaxSummary { get; set; }
        public virtual DbSet<MaPurchasesDefaults> MaPurchasesDefaults { get; set; }
        public virtual DbSet<MaPurchasesParameters> MaPurchasesParameters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaPurchaseDoc>(entity =>
{
                entity.HasKey(e => e.PurchaseDocId)
                    .HasName("PK_PurchaseDoc")
                    .IsClustered(false);

                entity.ToTable("MA_PurchaseDoc");

                entity.HasIndex(e => e.CorrectionDocument)
                    .HasName("MA_PurchaseDoc7");

                entity.HasIndex(e => e.JournalEntryId)
                    .HasName("MA_PurchaseDoc6");

                entity.HasIndex(e => new { e.DocumentType, e.DocumentDate, e.DocNo })
                    .HasName("MA_PurchaseDoc3");

                entity.HasIndex(e => new { e.DocumentType, e.DocumentDate, e.Supplier })
                    .HasName("MA_PurchaseDoc4");

                entity.HasIndex(e => new { e.IncludedInTurnover, e.Supplier, e.DocumentDate })
                    .HasName("MA_PurchaseDoc5");

                entity.HasIndex(e => new { e.DocumentType, e.Issued, e.InvoiceFollows, e.Summarized, e.DocumentDate, e.Supplier })
                    .HasName("MA_PurchaseDoc2");

                entity.Property(e => e.PurchaseDocId).ValueGeneratedNever();

                entity.Property(e => e.AccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AccrualDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.ActionOnLifoFifo).HasDefaultValueSql("((26411009))");

                entity.Property(e => e.AdditionalCharge).HasDefaultValueSql("((0))");

                entity.Property(e => e.AdjValueOnlyInvEntryId).HasDefaultValueSql("((0))");

                entity.Property(e => e.AdvancePymtSchedId).HasDefaultValueSql("((0))");

                entity.Property(e => e.Archived)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.BlockInvoices)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.BlockPayments)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.BlockSuppliers)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CompanyBank)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CompanyCa)
                    .HasColumnName("CompanyCA")
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ConfInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ConformingSpecificator1)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ConformingSpecificator1Type).HasDefaultValueSql("((6750211))");

                entity.Property(e => e.ConformingSpecificator2)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ConformingSpecificator2Type).HasDefaultValueSql("((6750211))");

                entity.Property(e => e.ConformingStorage1)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ConformingStorage2)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ContractCode)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CorrectedDocumentId).HasDefaultValueSql("((0))");

                entity.Property(e => e.CorrectionDocument)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CorrectionDocumentId).HasDefaultValueSql("((0))");

                entity.Property(e => e.CorrectionDocumentIdInCn)
                    .HasColumnName("CorrectionDocumentIdInCN")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CorrectionForReturn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CostCenter)
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

                entity.Property(e => e.CountryOfPayment)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CountryOfTransport)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Currency)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustSuppType).HasDefaultValueSql("((3211264))");

                entity.Property(e => e.DeliveryTerms).HasDefaultValueSql("((5963776))");

                entity.Property(e => e.DepartureDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.DocNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DocumentCorrectionInCn)
                    .HasColumnName("DocumentCorrectionInCN")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DocumentDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.DocumentType).HasDefaultValueSql("((9830400))");

                entity.Property(e => e.Eistatus)
                    .HasColumnName("EIStatus")
                    .HasDefaultValueSql("((32112640))");

                entity.Property(e => e.Eoydeductible)
                    .HasColumnName("EOYDeductible")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

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

                entity.Property(e => e.EutaxJournal)
                    .HasColumnName("EUTaxJournal")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExtAccAeid)
                    .HasColumnName("ExtAccAEID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Fixing).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.FixingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.FixingIsManual)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.GenerateEat)
                    .HasColumnName("GenerateEAT")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ImSubcontractDoc)
                    .HasColumnName("IM_SubcontractDoc")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IncludedInTurnover)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.InspectionLoadInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InspectionOrdId).HasDefaultValueSql("((0))");

                entity.Property(e => e.InspectionOrderGenerated)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InspectionSpecificator1)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InspectionSpecificator1Type).HasDefaultValueSql("((6750211))");

                entity.Property(e => e.InspectionSpecificator2)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InspectionSpecificator2Type).HasDefaultValueSql("((6750211))");

                entity.Property(e => e.InspectionStorage1)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InspectionStorage2)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InstallmStartDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.InstallmStartDateIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.IntrastatAccrualDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.IntrastatBis)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IntrastatId).HasDefaultValueSql("((0))");

                entity.Property(e => e.IntrastatTer)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InvEntryId).HasDefaultValueSql("((0))");

                entity.Property(e => e.InvRsnOnlyValue)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InvoiceFollows)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InvoiceForAdvanceLinked)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Invoiced)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InvoicingAccGroup)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InvoicingAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InvoicingTaxJournal)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Issued)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Job)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.JournalEntryId).HasDefaultValueSql("((0))");

                entity.Property(e => e.Language)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastSubId).HasDefaultValueSql("((0))");

                entity.Property(e => e.ModeOfTransport).HasDefaultValueSql("((5832706))");

                entity.Property(e => e.ModifyOriginalPymtSched)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.NatureOfTransaction).HasDefaultValueSql("((5767168))");

                entity.Property(e => e.NetOfTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.NotConfInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NotConfSpecificator1Type).HasDefaultValueSql("((6750211))");

                entity.Property(e => e.NotConfSpecificator2Type).HasDefaultValueSql("((6750211))");

                entity.Property(e => e.NotConformingSpecificator1)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NotConformingSpecificator2)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NotConformingStorage1)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NotConformingStorage2)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Notes)
                    .HasColumnType("ntext")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Operation).HasDefaultValueSql("((5898240))");

                entity.Property(e => e.OurReference)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Payment)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PaymentAddress)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PlafondAccrualDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.PostedToAccounting)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PostedToCostAccounting)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PostedToIntrastat)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PostedToInventory)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PostedToPyblsRcvbls)
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

                entity.Property(e => e.ProductLine)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProjectCode)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PureJecollectionPaymentId)
                    .HasColumnName("PureJECollectionPaymentId")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PureJecollectionPaymentNo)
                    .HasColumnName("PureJECollectionPaymentNo")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PureJetaxTransferId)
                    .HasColumnName("PureJETaxTransferId")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PymtSchedId).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReturnGenerated)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ReturnInvEntryId).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReturnInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReturnSpecificator1)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReturnSpecificator1Type).HasDefaultValueSql("((6750211))");

                entity.Property(e => e.ReturnSpecificator2)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReturnSpecificator2Type).HasDefaultValueSql("((6750211))");

                entity.Property(e => e.ReturnStorage1)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReturnStorage2)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Rmagenerated)
                    .HasColumnName("RMAGenerated")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Rmaid)
                    .HasColumnName("RMAId")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.RmastubBook)
                    .HasColumnName("RMAStubBook")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SaleRecordNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ScrapGenerated)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ScrapInvEntryId).HasDefaultValueSql("((0))");

                entity.Property(e => e.ScrapInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ScrapSpecificator1)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ScrapSpecificator1Type).HasDefaultValueSql("((6750211))");

                entity.Property(e => e.ScrapSpecificator2)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ScrapSpecificator2Type).HasDefaultValueSql("((6750211))");

                entity.Property(e => e.ScrapStorage1)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ScrapStorage2)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SendDocumentsTo)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StatisticalPurpose).HasDefaultValueSql("((26017792))");

                entity.Property(e => e.Storage1OnlyValue)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StubBook)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Summarized)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Supplier)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SupplierBank)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SupplierCa)
                    .HasColumnName("SupplierCA")
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SupplierDocDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.SupplierDocNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxAccrualDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.TaxCommunicationGroup)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxCommunicationOperation).HasDefaultValueSql("((28377088))");

                entity.Property(e => e.TaxJournal)
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

                entity.Property(e => e.ValueDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.WorkerIdissue)
                    .HasColumnName("WorkerIDIssue")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.YourReference)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
            modelBuilder.Entity<MaPurchaseDocDetail>(entity =>
{
                entity.HasKey(e => new { e.PurchaseDocId, e.Line })
                    .HasName("PK_PurchaseDocDetail")
                    .IsClustered(false);

                entity.ToTable("MA_PurchaseDocDetail");

                entity.HasIndex(e => new { e.DocumentType, e.BillOfLadingId, e.DocumentDate, e.PurchaseDocId })
                    .HasName("MA_PurchaseDocDetail_IM2");

                entity.HasIndex(e => new { e.IncludedInTurnover, e.DocumentDate, e.Item, e.Supplier })
                    .HasName("MA_PurchaseDocDetail3");

                entity.HasIndex(e => new { e.IncludedInTurnover, e.DocumentDate, e.Supplier, e.Item })
                    .HasName("MA_PurchaseDocDetail2");

                entity.HasIndex(e => new { e.DocumentType, e.PurchaseOrdId, e.DocumentDate, e.PurchaseDocId, e.BillOfLadingId })
                    .HasName("MA_PurchaseDocDetail_IM1");

                entity.HasIndex(e => new { e.Moid, e.RtgStep, e.Alternate, e.AltRtgStep, e.PurchaseDocId })
                    .HasName("MA_PurchaseDocDetail4");

                entity.Property(e => e.ActualDeliveryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.ActualRetailPrice).HasDefaultValueSql("((0))");

                entity.Property(e => e.ActualRetailPricePhase2).HasDefaultValueSql("((0))");

                entity.Property(e => e.ActualRetailPriceWithTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.AdditionalQty1).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.AdditionalQty2).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.AdditionalQty3).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.AdditionalQty4).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.AltRtgStep).HasDefaultValueSql("((0))");

                entity.Property(e => e.Alternate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BillOfLadingId).HasDefaultValueSql("((0))");

                entity.Property(e => e.BillOfLadingLine).HasDefaultValueSql("((0))");

                entity.Property(e => e.BillOfLadingNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CancelledInCd)
                    .HasColumnName("CancelledInCD")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ClosePurchaseOrd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CombinedNomenclature)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ConformingQty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.CorrectedDocumentLine)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CorrectionDocChargeLine)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CorrectionDocument)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CorrectionQty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.CostCenter)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CountyOfOrigin)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Cpacode)
                    .HasColumnName("CPACode")
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CrrefId)
                    .HasColumnName("CRRefID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CrrefSubId)
                    .HasColumnName("CRRefSubID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CrrefType)
                    .HasColumnName("CRRefType")
                    .HasDefaultValueSql("((27066368))");

                entity.Property(e => e.DbcrLineCalcProp)
                    .HasColumnName("DBCR_LineCalc_Prop")
                    .HasDefaultValueSql("((25952256))");

                entity.Property(e => e.DefaultValueType).HasDefaultValueSql("((9437191))");

                entity.Property(e => e.Department)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DepartureDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Description)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Discount1).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Discount2).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.DiscountAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.DiscountDefaultType).HasDefaultValueSql("((9568262))");

                entity.Property(e => e.DiscountFormula)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DistributeCharges)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.DistributedAdditionalCharges).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.DistributedDiscount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.DistributedInsuranceCharges).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.DistributedShipCharges).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.DocNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DocumentDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.DocumentType).HasDefaultValueSql("((9830400))");

                entity.Property(e => e.Drawing)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExcludeFromTot)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ExcludeIcmsst)
                    .HasColumnName("ExcludeICMSST")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ExpectedDeliveryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.ExternalIdNo)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExternalLineReference).HasDefaultValueSql("((0))");

                entity.Property(e => e.FixedCost)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.GrossVolume).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.GrossWeight).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ImJobWorkingStep)
                    .HasColumnName("IM_JobWorkingStep")
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ImSubcontractOrdId)
                    .HasColumnName("IM_SubcontractOrdId")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ImSubcontractWprid)
                    .HasColumnName("IM_SubcontractWPRId")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IncludedInTurnover)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.Inspected)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InspectionBillId).HasDefaultValueSql("((0))");

                entity.Property(e => e.InspectionBillNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InspectionOrdId).HasDefaultValueSql("((0))");

                entity.Property(e => e.InspectionOrdNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InternalIdNo)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IntrastatSupplyType).HasDefaultValueSql("((589824))");

                entity.Property(e => e.InvoiceAmount).HasDefaultValueSql("((0))");

                entity.Property(e => e.InvoiceForAdvanceId)
                    .HasColumnName("InvoiceForAdvanceID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.InvoiceForAdvanceLinked)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InvoiceForAdvanceSubId)
                    .HasColumnName("InvoiceForAdvanceSubID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Invoiced)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InvoicedQty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IsoofOrigin)
                    .HasColumnName("ISOOfOrigin")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Job)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.KitNo).HasDefaultValueSql("((0))");

                entity.Property(e => e.KitQty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.LineType).HasDefaultValueSql("((3538947))");

                entity.Property(e => e.Location)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Lot)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Moconfirmed)
                    .HasColumnName("MOConfirmed")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Moid)
                    .HasColumnName("MOId")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Mono)
                    .HasColumnName("MONo")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NetWeight).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.NewField).HasDefaultValueSql("((6684681))");

                entity.Property(e => e.NoInvoice)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NoOfPacks).HasDefaultValueSql("((0))");

                entity.Property(e => e.NoPrint)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NotConformingQty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.NotInReverseCharge)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NotPostableInInventory)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Offset)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.OrderedQty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.OriginalQty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.OriginalUnitValue).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Packing)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PacksUoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProductLine)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PurchaseOrdId).HasDefaultValueSql("((0))");

                entity.Property(e => e.PurchaseOrdNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PurchaseOrdPos).HasDefaultValueSql("((0))");

                entity.Property(e => e.PurchaseType).HasDefaultValueSql("((3670020))");

                entity.Property(e => e.Qty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ReferenceDocId).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReferenceDocLine).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReferenceDocNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReferenceDocSubId)
                    .HasColumnName("ReferenceDocSubID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ReferenceDocumentId).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReturnReason)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReturnToSupplierQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.Rmaid)
                    .HasColumnName("RMAId")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Rmano)
                    .HasColumnName("RMANo")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Rmapos).HasColumnName("RMAPos");

                entity.Property(e => e.RtgStep).HasDefaultValueSql("((0))");

                entity.Property(e => e.SaleDocId).HasDefaultValueSql("((0))");

                entity.Property(e => e.SaleDocLine).HasDefaultValueSql("((0))");

                entity.Property(e => e.ScrapQty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ServiceToIncludeInIntrastat)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SpecWeightNetMass).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.SpecWeightNetMassSuppUnit).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.SpecificatorPhase1)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SpecificatorPhase2)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StoragePhase1)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StoragePhase2)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SubId).HasDefaultValueSql("((0))");

                entity.Property(e => e.SuppQuotaId).HasDefaultValueSql("((0))");

                entity.Property(e => e.SuppQuotaLine).HasDefaultValueSql("((0))");

                entity.Property(e => e.Supplier)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SupplierCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SupplierLotExpiryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.SupplierLotNo)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TaxCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxRuleCode)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxRuleCodeCompany)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxableAmount).HasDefaultValueSql("((0.00))");

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

                entity.Property(e => e.TotalAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.UndeductibleAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.UnitValue).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.UoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.PurchaseDoc)
                    .WithMany(p => p.MaPurchaseDocDetail)
                    .HasForeignKey(d => d.PurchaseDocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PurchaseDo_PurchaseDo_06");
            });
            modelBuilder.Entity<MaPurchaseDocLinkOrders>(entity =>
{
                entity.HasKey(e => new { e.PurchaseDocId, e.SubId, e.Line })
                    .HasName("PK_PurchaseDocLinkOrders")
                    .IsClustered(false);

                entity.ToTable("MA_PurchaseDocLinkOrders");

                entity.Property(e => e.ClosePurchaseOrd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PurchaseOrdId).HasDefaultValueSql("((0))");

                entity.Property(e => e.PurchaseOrdNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PurchaseOrdPos).HasDefaultValueSql("((0))");

                entity.Property(e => e.PurchaseOrdSubId).HasDefaultValueSql("((0))");

                entity.Property(e => e.Quantity).HasDefaultValueSql("((0.00))");

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

                entity.Property(e => e.UoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.PurchaseDoc)
                    .WithMany(p => p.MaPurchaseDocLinkOrders)
                    .HasForeignKey(d => d.PurchaseDocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PurchaseDocLinkOrders_01");
            });
            modelBuilder.Entity<MaPurchaseDocNotes>(entity =>
{
                entity.HasKey(e => new { e.PurchaseDocId, e.Line })
                    .HasName("PK_PurchaseDocNotes")
                    .IsClustered(false);

                entity.ToTable("MA_PurchaseDocNotes");

                entity.Property(e => e.ChangeDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.GenByConsistencyCheck)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Notes)
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

                entity.HasOne(d => d.PurchaseDoc)
                    .WithMany(p => p.MaPurchaseDocNotes)
                    .HasForeignKey(d => d.PurchaseDocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PurchaseDo_PurchaseDo_04");
            });
            modelBuilder.Entity<MaPurchaseDocPymtSched>(entity =>
{
                entity.HasKey(e => new { e.PurchaseDocId, e.InstallmentNo })
                    .HasName("PK_PurchaseDocPymtSched")
                    .IsClustered(false);

                entity.ToTable("MA_PurchaseDocPymtSched");

                entity.Property(e => e.CostCenter)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DueDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.InstallmentAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.InstallmentTaxAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.InstallmentType).HasDefaultValueSql("((2686977))");

                entity.Property(e => e.NotUsed)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PymtAccount)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PymtCash)
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

                entity.HasOne(d => d.PurchaseDoc)
                    .WithMany(p => p.MaPurchaseDocPymtSched)
                    .HasForeignKey(d => d.PurchaseDocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PurchaseDo_PurchaseDo_07");
            });
            modelBuilder.Entity<MaPurchaseDocReferences>(entity =>
{
                entity.HasKey(e => new { e.PurchaseDocId, e.Line })
                    .HasName("PK_PurchaseDocReferences")
                    .IsClustered(false);

                entity.ToTable("MA_PurchaseDocReferences");

                entity.HasIndex(e => new { e.DocumentType, e.DocumentId })
                    .HasName("MA_PurchaseDocReferences2");

                entity.Property(e => e.CombNomenclatureCheckType).HasDefaultValueSql("((11599872))");

                entity.Property(e => e.DocumentDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.DocumentId).HasDefaultValueSql("((0))");

                entity.Property(e => e.DocumentNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DocumentType).HasDefaultValueSql("((6684681))");

                entity.Property(e => e.Notes)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReferenceIsAuto)
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

                entity.Property(e => e.TypeReference)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.PurchaseDoc)
                    .WithMany(p => p.MaPurchaseDocReferences)
                    .HasForeignKey(d => d.PurchaseDocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PurchaseDo_PurchaseDo_05");
            });
            modelBuilder.Entity<MaPurchaseDocShipping>(entity =>
{
                entity.HasKey(e => e.PurchaseDocId)
                    .HasName("PK_PurchaseDocShipping")
                    .IsClustered(false);

                entity.ToTable("MA_PurchaseDocShipping");

                entity.Property(e => e.PurchaseDocId).ValueGeneratedNever();

                entity.Property(e => e.Appearance)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Carrier1)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Carrier2)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Carrier3)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DepartureDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.DepartureHr).HasDefaultValueSql("((0))");

                entity.Property(e => e.DepartureMn).HasDefaultValueSql("((0))");

                entity.Property(e => e.ExcludeCharges)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.GrossVolume).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.GrossVolumeIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.GrossWeight).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.GrossWeightIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.NetWeight).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.NetWeightIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.NoOfPacks).HasDefaultValueSql("((0))");

                entity.Property(e => e.NoOfPacksIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.Package)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PackageDescription)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Port)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ShipTo)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ShipToCustSupp)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ShipToCustSuppType).HasDefaultValueSql("((6094850))");

                entity.Property(e => e.Shipping)
                    .HasMaxLength(16)
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

                entity.Property(e => e.Trailer)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Transport)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Vehicle)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.PurchaseDoc)
                    .WithOne(p => p.MaPurchaseDocShipping)
                    .HasForeignKey<MaPurchaseDocShipping>(d => d.PurchaseDocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PurchaseDo_PurchaseDo_08");
            });
            modelBuilder.Entity<MaPurchaseDocSummary>(entity =>
{
                entity.HasKey(e => e.PurchaseDocId)
                    .HasName("PK_PurchaseDocSummary")
                    .IsClustered(false);

                entity.ToTable("MA_PurchaseDocSummary");

                entity.Property(e => e.PurchaseDocId).ValueGeneratedNever();

                entity.Property(e => e.AdditionalCharges).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.AdditionalChargesIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.Advance).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.AdvanceOffset)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Allowances).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.CashOnDeliveryCharges).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.CashOnDeliveryChargesIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.CashOnDeliveryPercentage).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.CollectionCharges).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.CollectionChargesIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.CollectionChargesTaxCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CreditNotePreviousPeriod)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Discount1).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Discount2).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.DiscountFormula)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DiscountOnGoods).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.DiscountOnServices).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Discounts).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.DiscountsIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.DistributedChargesTaxPerc).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.FreeSamples).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.FreeSamplesDocCurr).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.FreeSamplesTaxAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.GoodsAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.GoodsAmountToCheck).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.PackagingCharges).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.PackagingChargesIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.PayableAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.PayableAmountInBaseCurr).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.PayableAmountToCheck).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.PaymentTerm).HasDefaultValueSql("((2686976))");

                entity.Property(e => e.PostAdvancesToAcc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PrePayedAdvance).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ReturnedMaterial).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ServiceAmounts).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ShippingCharges).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ShippingChargesIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.ShippingChargesTaxCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StampsCharges).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.StampsChargesIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.StampsChargesTaxCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StatisticalCharges).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.StatisticalChargesCalc).HasDefaultValueSql("((25886720))");

                entity.Property(e => e.StatisticalChargesIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.TaxAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TaxAmountDocCurr).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TaxSummaryIsManual)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.TaxableAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TaxableAmountDocCurr).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TaxableAmountToCheck).HasDefaultValueSql("((0.00))");

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

                entity.Property(e => e.TotalAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TotalAmountDocCurr).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TotalAmountToCheck).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.UndeductibleAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.UndeductibleAmountDocCurr).HasDefaultValueSql("((0.00))");

                entity.HasOne(d => d.PurchaseDoc)
                    .WithOne(p => p.MaPurchaseDocSummary)
                    .HasForeignKey<MaPurchaseDocSummary>(d => d.PurchaseDocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PurchaseDo_PurchaseDo_00");
            });
            modelBuilder.Entity<MaPurchaseDocTaxSummary>(entity =>
{
                entity.HasKey(e => new { e.PurchaseDocId, e.Line })
                    .HasName("PK_PurchaseDocTaxSummary")
                    .IsClustered(false);

                entity.ToTable("MA_PurchaseDocTaxSummary");

                entity.Property(e => e.NotInReverseCharge)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.TaxAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TaxAmountDocCurr).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TaxCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxableAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TaxableAmountDocCurr).HasDefaultValueSql("((0.00))");

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

                entity.Property(e => e.TotalAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TotalAmountDocCurr).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.UndeductibleAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.UndeductibleAmountDocCurr).HasDefaultValueSql("((0.00))");

                entity.HasOne(d => d.PurchaseDoc)
                    .WithMany(p => p.MaPurchaseDocTaxSummary)
                    .HasForeignKey(d => d.PurchaseDocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PurchaseDo_PurchaseDo_02");
            });
            modelBuilder.Entity<MaPurchasesDefaults>(entity =>
{
                entity.HasKey(e => e.PurchasesDefaultsId)
                    .HasName("PK_PurchasesDefaults")
                    .IsClustered(false);

                entity.ToTable("MA_PurchasesDefaults");

                entity.Property(e => e.PurchasesDefaultsId).ValueGeneratedNever();

                entity.Property(e => e.AdditionalCharges)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AdditionalCosts)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Advance)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BillOfLadingInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BillsOfLadingInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CollectionCharges)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CollectionTaxAmount)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CorrEuinvoiceAccTpl)
                    .HasColumnName("CorrEUInvoiceAccTpl")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CorrExtraEuinvoiceAccTpl)
                    .HasColumnName("CorrExtraEUInvoiceAccTpl")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CorrInvoiceAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CorrSuspInvoiceAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CorrectionInvoiceAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CreditNoteAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CreditNoteAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CreditNoteInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DebitNoteAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DebitNoteAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DebitNoteEuaccTpl)
                    .HasColumnName("DebitNoteEUAccTpl")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DebitNoteExtraEuaccTpl)
                    .HasColumnName("DebitNoteExtraEUAccTpl")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DebitNoteInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DebitNoteSuspAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EucreditNoteAccTpl)
                    .HasColumnName("EUCreditNoteAccTpl")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EuinvoiceAccTpl)
                    .HasColumnName("EUInvoiceAccTpl")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExtraEucreditNoteAccTpl)
                    .HasColumnName("ExtraEUCreditNoteAccTpl")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExtraEuinvoiceAccTpl)
                    .HasColumnName("ExtraEUInvoiceAccTpl")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FreeSamples)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GoodCosts)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InspNotesConformingInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InspNotesRtsinvRsn)
                    .HasColumnName("InspNotesRTSInvRsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InspNotesScrapInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InspectionManufInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InspectionReceiptInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InvoiceAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InvoiceAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InvoiceCorrectionRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InvoiceForAdvanceAccount)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InvoiceGoodReceiptInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InvoiceValueInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PackagingCharges)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProtocolAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProtocolAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProtocolCnaccTpl)
                    .HasColumnName("ProtocolCNAccTpl")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProtocolDnaccTpl)
                    .HasColumnName("ProtocolDNAccTpl")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PurchInvoiceForAdvanceAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReturnMaterialInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReturnedMaterialInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReverseChargeAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReverseChargeCnaccTpl)
                    .HasColumnName("ReverseChargeCNAccTpl")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ScrapInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ServiceCosts)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ShippingCharges)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ShippingTaxCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StampsCharges)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StampsTaxAmount)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SuspCreditNoteAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SuspInvoiceAccTpl)
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

                entity.Property(e => e.ValueInvEntryAdjInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
            modelBuilder.Entity<MaPurchasesParameters>(entity =>
{
                entity.HasKey(e => e.PurchasesParametersId)
                    .HasName("PK_PurchasesParameters")
                    .IsClustered(false);

                entity.ToTable("MA_PurchasesParameters");

                entity.Property(e => e.PurchasesParametersId).ValueGeneratedNever();

                entity.Property(e => e.AllowOnlyItemOfKindPurchase)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.BalanceEutaxSummaryDocCurr)
                    .HasColumnName("BalanceEUTaxSummaryDocCurr")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.BalanceTaxSummaryBaseCurr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ClearingBoLcheck)
                    .HasColumnName("ClearingBoLCheck")
                    .HasDefaultValueSql("((11599872))");

                entity.Property(e => e.CloseOrdOnlyForConforming)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CombNomenclatureCheckType).HasDefaultValueSql("((11599872))");

                entity.Property(e => e.ConsistencyCheckIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DescriptiveLinesAreDelivered)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DiffBlinv)
                    .HasColumnName("DiffBLInv")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DiffCorrBl)
                    .HasColumnName("DiffCorrBL")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.DiffNothing)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FreeBorderDefault).HasDefaultValueSql("((25886720))");

                entity.Property(e => e.GeneratePymtSchedInBaseCurr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InsAnalPar)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InvEntryOnlyValueInNdC)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InvEntryOnlyValueInNdCprop)
                    .HasColumnName("InvEntryOnlyValueInNdCProp")
                    .HasDefaultValueSql("((25952256))");

                entity.Property(e => e.InvoiceNoUpdateLastData)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InvoiceQtyCheck).HasDefaultValueSql("((11599872))");

                entity.Property(e => e.LoadInvEntryNetOfDiscount)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NegativeValueInLedgerCard)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.NoLoadsFromBlockedSupplier)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NoPaymentsToBlockedSupplier)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PurchaseOrderRowFulfillment)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PureJecollectionPaymentMng)
                    .HasColumnName("PureJECollectionPaymentMng")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ReceiptBl)
                    .HasColumnName("ReceiptBL")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.ReceiptInv)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.RecepitBoth)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ReturnToSupplierQtyCheck).HasDefaultValueSql("((11599872))");

                entity.Property(e => e.ServicesOnBillOfLading)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ShowSf)
                    .HasColumnName("ShowSF")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

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

                entity.Property(e => e.UseAdditionalSupplierCharges)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.WarnNoPrintedLine)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.WarningMaximumStock)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ZeroAmountInvoice)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");
            });
        }
    }
}
