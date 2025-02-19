using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class SalesDbContext : DbContext
    {
        public SalesDbContext()
        {
        }
        public SalesDbContext(DbContextOptions<SalesDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaInvoiceTypes> MaInvoiceTypes { get; set; }
        public virtual DbSet<MaSaleDoc> MaSaleDoc { get; set; }
        public virtual DbSet<MaSaleDocComponents> MaSaleDocComponents { get; set; }
        public virtual DbSet<MaSaleDocDetail> MaSaleDocDetail { get; set; }
        public virtual DbSet<MaSaleDocManufReasons> MaSaleDocManufReasons { get; set; }
        public virtual DbSet<MaSaleDocNotes> MaSaleDocNotes { get; set; }
        public virtual DbSet<MaSaleDocPymtSched> MaSaleDocPymtSched { get; set; }
        public virtual DbSet<MaSaleDocReferences> MaSaleDocReferences { get; set; }
        public virtual DbSet<MaSaleDocShipping> MaSaleDocShipping { get; set; }
        public virtual DbSet<MaSaleDocSummary> MaSaleDocSummary { get; set; }
        public virtual DbSet<MaSaleDocTaxSummary> MaSaleDocTaxSummary { get; set; }
        public virtual DbSet<MaSaleParameters> MaSaleParameters { get; set; }
        public virtual DbSet<MaSaleParametersParagonFp> MaSaleParametersParagonFp { get; set; }
        public virtual DbSet<MaSaleParametersWithholdTax> MaSaleParametersWithholdTax { get; set; }
        public virtual DbSet<MaSalesDefaults> MaSalesDefaults { get; set; }
        public virtual DbSet<MaTmpSaleOrdFulfilment> MaTmpSaleOrdFulfilment { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaInvoiceTypes>(entity =>
{
                entity.HasKey(e => e.CodeType)
                    .HasName("PK_InvoiceTypes")
                    .IsClustered(false);

                entity.ToTable("MA_InvoiceTypes");

                entity.Property(e => e.CodeType)
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
            modelBuilder.Entity<MaSaleDoc>(entity =>
{
                entity.HasKey(e => e.SaleDocId)
                    .HasName("PK_SaleDoc")
                    .IsClustered(false);

                entity.ToTable("MA_SaleDoc");

                entity.HasIndex(e => e.CorrectionDocument)
                    .HasName("MA_SaleDocc");

                entity.HasIndex(e => e.JournalEntryId)
                    .HasName("MA_SaleDoc8");

                entity.HasIndex(e => new { e.DocumentType, e.DocumentDate, e.DocNo })
                    .HasName("MA_SaleDoc3");

                entity.HasIndex(e => new { e.PostedToCommissionEntries, e.DocumentDate, e.Salesperson })
                    .HasName("MA_SaleDoc6");

                entity.HasIndex(e => new { e.DocumentType, e.DocumentDate, e.CustSuppType, e.CustSupp })
                    .HasName("MA_SaleDoc4");

                entity.HasIndex(e => new { e.IncludedInTurnover, e.CustSuppType, e.CustSupp, e.DocumentDate })
                    .HasName("MA_SaleDoc5");

                entity.HasIndex(e => new { e.StubBook, e.DocNo, e.DocumentDate, e.DocumentType })
                    .HasName("MA_SaleDoca");

                entity.HasIndex(e => new { e.TaxJournal, e.DocNo, e.DocumentDate, e.DocumentType })
                    .HasName("MA_SaleDocb");

                entity.HasIndex(e => new { e.DocumentType, e.Issued, e.InvoiceFollows, e.Summarized, e.DepartureDate, e.CustSuppType, e.CustSupp })
                    .HasName("MA_SaleDoc2");

                entity.HasIndex(e => new { e.DocumentType, e.Issued, e.InvoiceFollows, e.Summarized, e.DepartureDate, e.CustSuppType, e.InvoicingCustomer })
                    .HasName("MA_SaleDoc7");

                entity.Property(e => e.SaleDocId).ValueGeneratedNever();

                entity.Property(e => e.AccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AccrualDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.AccrualPercAtInvoiceDate).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.AccrualType).HasDefaultValueSql("((3473408))");

                entity.Property(e => e.ActionOnLifoFifo).HasDefaultValueSql("((26411014))");

                entity.Property(e => e.AdvancePymtSchedId).HasDefaultValueSql("((0))");

                entity.Property(e => e.AllIban)
                    .HasColumnName("ALL_IBAN")
                    .HasMaxLength(34)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AllUmrcode)
                    .HasColumnName("ALL_UMRCode")
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Archived)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Area)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AreaManager)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AreaManagerCommAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.AreaManagerCommPerc).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.AreaManagerCommPercAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.AreaManagerCommTot).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.AreaManagerPolicy)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BankAuthorization)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BaseAreaManager).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.BaseSalesperson).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Carrier1)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CompanyBank)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CompanyCa)
                    .HasColumnName("CompanyCA")
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CompanyPymtCa)
                    .HasColumnName("CompanyPymtCA")
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ContractCode)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CorrectedDocumentId).HasDefaultValueSql("((0))");

                entity.Property(e => e.CorrectionDocNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CorrectionDocument)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CorrectionDocumentDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

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

                entity.Property(e => e.CountryOfDestination)
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

                entity.Property(e => e.CustSupp)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustSuppType).HasDefaultValueSql("((3211264))");

                entity.Property(e => e.CustomerBank)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustomerDocNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustomerDocumentDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Delivered)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DeliveryTerms).HasDefaultValueSql("((5963780))");

                entity.Property(e => e.DepartureDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.DiscountFormula)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

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

                entity.Property(e => e.DocumentType).HasDefaultValueSql("((3407873))");

                entity.Property(e => e.EidocumentType)
                    .HasColumnName("EIDocumentType")
                    .HasDefaultValueSql("((22151168))");

                entity.Property(e => e.EiprogTransmission)
                    .HasColumnName("EIProgTransmission")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Eistatus)
                    .HasColumnName("EIStatus")
                    .HasDefaultValueSql("((32112640))");

                entity.Property(e => e.ExtAccAeid)
                    .HasColumnName("ExtAccAEID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FiscalPrinted)
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

                entity.Property(e => e.FromExternalProgram).HasDefaultValueSql("((32505856))");

                entity.Property(e => e.GenerateEat)
                    .HasColumnName("GenerateEAT")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IncludedInTurnover)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.InstallmStartDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.InstallmStartDateIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.InterStorageDocumentType).HasDefaultValueSql("((25296896))");

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

                entity.Property(e => e.InvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InvRsnReturn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InventoryIdreturn)
                    .HasColumnName("InventoryIDReturn")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.InvoiceFollows)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.InvoiceForAdvanceLinked)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InvoiceTypes)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InvoicingAccGroup)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InvoicingAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InvoicingCustomer)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InvoicingTaxJournal)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IsParagon)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

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

                entity.Property(e => e.LastSubIdPymtSched).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.NoChangeExigibility)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Notes)
                    .HasColumnType("ntext")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Operation).HasDefaultValueSql("((5898240))");

                entity.Property(e => e.OurReference)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Package)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ParagonId)
                    .HasColumnName("ParagonID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Payment)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PaymentAddress)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PerishablesType).HasDefaultValueSql("((28966914))");

                entity.Property(e => e.Port)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PostedToAccounting)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PostedToCommissionEntries)
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

                entity.Property(e => e.PostedToInventoryReturn)
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

                entity.Property(e => e.PreprintedDocNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Presentation).HasDefaultValueSql("((1376256))");

                entity.Property(e => e.PriceList)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Printed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Priority).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProFormaDdtlinked)
                    .HasColumnName("ProFormaDDTLinked")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ProFormaInvoiceId)
                    .HasColumnName("ProFormaInvoiceID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ProFormaInvoiceLinked)
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

                entity.Property(e => e.ReceiptIsm)
                    .HasColumnName("ReceiptISM")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ReceiptIsmid)
                    .HasColumnName("ReceiptISMID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ReceiptIsmreason)
                    .HasColumnName("ReceiptISMReason")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Salesperson)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SalespersonCommAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.SalespersonCommPerc).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.SalespersonCommPercAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.SalespersonCommTot).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.SalespersonPolicy)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SendDocumentsTo)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SentByEmail)
                    .HasColumnName("SentByEMail")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SentByPostaLite)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ShipToAddress)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ShippingReason)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Sosdone)
                    .HasColumnName("SOSDone")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SpecTypeReplenishment).HasDefaultValueSql("((6750211))");

                entity.Property(e => e.Specificator1Type).HasDefaultValueSql("((6750211))");

                entity.Property(e => e.Specificator2Type).HasDefaultValueSql("((6750211))");

                entity.Property(e => e.SpecificatorPhase1)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SpecificatorPhase1Return)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SpecificatorPhase2)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SpecificatorPhase2Return)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SpecificatorReplenishment)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SpecificatorTypePhase1Return).HasDefaultValueSql("((6750211))");

                entity.Property(e => e.SpecificatorTypePhase2Return).HasDefaultValueSql("((6750211))");

                entity.Property(e => e.SplitPaymentActive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.StatisticalPurpose).HasDefaultValueSql("((26017792))");

                entity.Property(e => e.StoragePhase1)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StoragePhase1Return)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StoragePhase2)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StoragePhase2Return)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StorageReplenishment)
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

                entity.Property(e => e.Transport)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Triangulation)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

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
            modelBuilder.Entity<MaSaleDocComponents>(entity =>
{
                entity.HasKey(e => new { e.SaleDocId, e.SubId, e.Line })
                    .HasName("PK_SaleDocComponents")
                    .IsClustered(false);

                entity.ToTable("MA_SaleDocComponents");

                entity.Property(e => e.Component)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Description)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FixedQty)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NeededQty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.NeededQtyWaste).HasDefaultValueSql("((0.00))");

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

                entity.Property(e => e.UnitValue).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.UoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Waste)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.WasteUnitValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.WasteUoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.SaleDoc)
                    .WithMany(p => p.MaSaleDocComponents)
                    .HasForeignKey(d => d.SaleDocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SaleDocCom_SaleDoc_00");
            });
            modelBuilder.Entity<MaSaleDocDetail>(entity =>
{
                entity.HasKey(e => new { e.SaleDocId, e.Line })
                    .HasName("PK_SaleDocDetail")
                    .IsClustered(false);

                entity.ToTable("MA_SaleDocDetail");

                entity.HasIndex(e => e.Trid)
                    .HasName("MA_SaleDocDetail5");

                entity.HasIndex(e => new { e.DocumentType, e.Job })
                    .HasName("MA_SaleDocDetail_IM1")
                    .IsClustered();

                entity.HasIndex(e => new { e.Moid, e.RtgStep, e.SaleDocId })
                    .HasName("MA_SaleDocDetail4");

                entity.HasIndex(e => new { e.IncludedInTurnover, e.DocumentDate, e.CustSuppType, e.CustSupp, e.Item })
                    .HasName("MA_SaleDocDetail2");

                entity.HasIndex(e => new { e.IncludedInTurnover, e.DocumentDate, e.Item, e.CustSuppType, e.CustSupp })
                    .HasName("MA_SaleDocDetail3");

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

                entity.Property(e => e.AllCanoniDataF)
                    .HasColumnName("ALL_CanoniDataF")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.AllCanoniDataI)
                    .HasColumnName("ALL_CanoniDataI")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.AllNrCanoni)
                    .HasColumnName("ALL_NrCanoni")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AltRtgStep).HasDefaultValueSql("((0))");

                entity.Property(e => e.Alternate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AreaManagerComm).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.AreaManagerCommAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.AreaManagerCommCtg)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AreaManagerCommCtgAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.AreaManagerCommPerc).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.AreaManagerCommPercAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.AuthorCode)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BaseAreaManager).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.BaseSalesperson).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.CancelledInCd)
                    .HasColumnName("CancelledInCD")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CloseSaleOrd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CombinedNomenclature)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CommPerc).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.CommPercAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.CommissionCtg)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Contribution)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

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

                entity.Property(e => e.CrrefLine)
                    .HasColumnName("CRRefLine")
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

                entity.Property(e => e.CustSuppType).HasDefaultValueSql("((3211264))");

                entity.Property(e => e.Delivered)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DeliveredQty).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.DistributedAdvanceAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.DistributedAdvanceAmount2).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.DistributedAdvanceAmount3).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.DistributedAllowances).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.DistributedDiscount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.DistributedInsuranceCharges).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.DistributedShipCharges).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.DocIdToBeUnloaded).HasDefaultValueSql("((0))");

                entity.Property(e => e.DocRowToBeUnloaded).HasDefaultValueSql("((0))");

                entity.Property(e => e.DocumentDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.DocumentType).HasDefaultValueSql("((3407873))");

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

                entity.Property(e => e.ImDelReqLine)
                    .HasColumnName("IM_DelReqLine")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ImDeliveryRequestId)
                    .HasColumnName("IM_DeliveryRequestId")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ImJobGroup)
                    .HasColumnName("IM_JobGroup")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ImJobWorkingStep)
                    .HasColumnName("IM_JobWorkingStep")
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ImStorage)
                    .HasColumnName("IM_Storage")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InEi)
                    .HasColumnName("InEI")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IncludedInTurnover)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.InternalIdNo)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IntrastatSupplyType).HasDefaultValueSql("((589824))");

                entity.Property(e => e.InvoiceAmount).HasDefaultValueSql("((0.00))");

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

                entity.Property(e => e.InvoiceId).HasDefaultValueSql("((0))");

                entity.Property(e => e.InvoiceSubId).HasDefaultValueSql("((0))");

                entity.Property(e => e.Invoiced)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.InvoicedQty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IsAbom)
                    .HasColumnName("IsABOM")
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

                entity.Property(e => e.KitNo).HasDefaultValueSql("((0))");

                entity.Property(e => e.KitQty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.LineCost).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.LineType).HasDefaultValueSql("((3538947))");

                entity.Property(e => e.LoadedInCn)
                    .HasColumnName("LoadedInCN")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Location)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Lot)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Moid)
                    .HasColumnName("MOId")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Mono)
                    .HasColumnName("MONo")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NetPrice).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.NetPriceIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.NetWeight).HasDefaultValueSql("((0.00))");

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

                entity.Property(e => e.NotPostableInInventory)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Notes)
                    .HasColumnType("ntext")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Offset)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

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

                entity.Property(e => e.PerishablesType).HasDefaultValueSql("((28966914))");

                entity.Property(e => e.PriceList)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProFormaInvoiceId)
                    .HasColumnName("ProFormaInvoiceID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ProFormaInvoiceSubId)
                    .HasColumnName("ProFormaInvoiceSubID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ProductLine)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PurchaseUnitValue).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Qty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.QtyLoadedInCn)
                    .HasColumnName("QtyLoadedInCN")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ReferenceDocId).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReferenceDocLine).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReferenceDocNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReferenceDocSubId)
                    .HasColumnName("ReferenceDocSubID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ReferenceDocType).HasDefaultValueSql("((3407873))");

                entity.Property(e => e.ReferenceDocumentId).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReturnFromCustomerId).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReturnFromCustomerQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReturnFromCustomerSubId).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReturnReason)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RtgStep).HasDefaultValueSql("((0))");

                entity.Property(e => e.SaleOrdId).HasDefaultValueSql("((0))");

                entity.Property(e => e.SaleOrdNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SaleOrdPos).HasDefaultValueSql("((0))");

                entity.Property(e => e.SaleOrdSubId).HasDefaultValueSql("((0))");

                entity.Property(e => e.SaleType).HasDefaultValueSql("((3670020))");

                entity.Property(e => e.SalespersonComm).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.SalespersonCommAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.SalespersonCommCtgAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.SalespersonDiscount).HasDefaultValueSql("((0.00))");

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

                entity.Property(e => e.SubjectToWithholdingTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

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

                entity.Property(e => e.Trid)
                    .HasColumnName("TRId")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UnitValue).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.UoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Variant)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.SaleDoc)
                    .WithMany(p => p.MaSaleDocDetail)
                    .HasForeignKey(d => d.SaleDocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SaleDocDet_SaleDoc_00");
            });
            modelBuilder.Entity<MaSaleDocManufReasons>(entity =>
{
                entity.HasKey(e => e.SaleDocId)
                    .HasName("PK_SaleDocManufReasons")
                    .IsClustered(false);

                entity.ToTable("MA_SaleDocManufReasons");

                entity.Property(e => e.SaleDocId).ValueGeneratedNever();

                entity.Property(e => e.FpissueToProdInvRsn)
                    .HasColumnName("FPIssueToProdInvRsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FpissueToProdSpec1Type)
                    .HasColumnName("FPIssueToProdSpec1Type")
                    .HasDefaultValueSql("((6750211))");

                entity.Property(e => e.FpissueToProdSpec2Type)
                    .HasColumnName("FPIssueToProdSpec2Type")
                    .HasDefaultValueSql("((6750211))");

                entity.Property(e => e.FpissueToProdSpecificator1)
                    .HasColumnName("FPIssueToProdSpecificator1")
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FpissueToProdSpecificator2)
                    .HasColumnName("FPIssueToProdSpecificator2")
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FpissueToProdStorage1)
                    .HasColumnName("FPIssueToProdStorage1")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FpissueToProdStorage2)
                    .HasColumnName("FPIssueToProdStorage2")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FpreceiptInvRsn)
                    .HasColumnName("FPReceiptInvRsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FpreceiptSpec1Type)
                    .HasColumnName("FPReceiptSpec1Type")
                    .HasDefaultValueSql("((6750211))");

                entity.Property(e => e.FpreceiptSpec2Type)
                    .HasColumnName("FPReceiptSpec2Type")
                    .HasDefaultValueSql("((6750211))");

                entity.Property(e => e.FpreceiptSpecificator1)
                    .HasColumnName("FPReceiptSpecificator1")
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FpreceiptSpecificator2)
                    .HasColumnName("FPReceiptSpecificator2")
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FpreceiptStorage1)
                    .HasColumnName("FPReceiptStorage1")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FpreceiptStorage2)
                    .HasColumnName("FPReceiptStorage2")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RmclearingInvRsn)
                    .HasColumnName("RMClearingInvRsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RmclearingProdInvRsn)
                    .HasColumnName("RMClearingProdInvRsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RmclearingProdSpec1Type)
                    .HasColumnName("RMClearingProdSpec1Type")
                    .HasDefaultValueSql("((6750211))");

                entity.Property(e => e.RmclearingProdSpec2Type)
                    .HasColumnName("RMClearingProdSpec2Type")
                    .HasDefaultValueSql("((6750211))");

                entity.Property(e => e.RmclearingProdSpecificator1)
                    .HasColumnName("RMClearingProdSpecificator1")
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RmclearingProdSpecificator2)
                    .HasColumnName("RMClearingProdSpecificator2")
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RmclearingProdStorage1)
                    .HasColumnName("RMClearingProdStorage1")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RmclearingProdStorage2)
                    .HasColumnName("RMClearingProdStorage2")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RmclearingSpec1Type)
                    .HasColumnName("RMClearingSpec1Type")
                    .HasDefaultValueSql("((6750211))");

                entity.Property(e => e.RmclearingSpec2Type)
                    .HasColumnName("RMClearingSpec2Type")
                    .HasDefaultValueSql("((6750211))");

                entity.Property(e => e.RmclearingSpecificator1)
                    .HasColumnName("RMClearingSpecificator1")
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RmclearingSpecificator2)
                    .HasColumnName("RMClearingSpecificator2")
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RmclearingStorage1)
                    .HasColumnName("RMClearingStorage1")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RmclearingStorage2)
                    .HasColumnName("RMClearingStorage2")
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

                entity.Property(e => e.WasteDiffItemLoadInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.WasteDiffItemLoadSpec1)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.WasteDiffItemLoadSpec1Type).HasDefaultValueSql("((6750211))");

                entity.Property(e => e.WasteDiffItemLoadSpec2)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.WasteDiffItemLoadSpec2Type).HasDefaultValueSql("((6750211))");

                entity.Property(e => e.WasteDiffItemLoadStorage1)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.WasteDiffItemLoadStorage2)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.WasteLoadInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.WasteLoadSpec1Type).HasDefaultValueSql("((6750211))");

                entity.Property(e => e.WasteLoadSpec2Type).HasDefaultValueSql("((6750211))");

                entity.Property(e => e.WasteLoadSpecificator1)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.WasteLoadSpecificator2)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.WasteLoadStorage1)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.WasteLoadStorage2)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.SaleDoc)
                    .WithOne(p => p.MaSaleDocManufReasons)
                    .HasForeignKey<MaSaleDocManufReasons>(d => d.SaleDocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SaleDocMan_SaleDoc_00");
            });
            modelBuilder.Entity<MaSaleDocNotes>(entity =>
{
                entity.HasKey(e => e.SaleDocId)
                    .HasName("PK_SaleDocNotes")
                    .IsClustered(false);

                entity.ToTable("MA_SaleDocNotes");

                entity.Property(e => e.SaleDocId).ValueGeneratedNever();

                entity.Property(e => e.Notes)
                    .HasMaxLength(251)
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

                entity.HasOne(d => d.SaleDoc)
                    .WithOne(p => p.MaSaleDocNotes)
                    .HasForeignKey<MaSaleDocNotes>(d => d.SaleDocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SaleDocNot_SaleDoc_00");
            });
            modelBuilder.Entity<MaSaleDocPymtSched>(entity =>
{
                entity.HasKey(e => new { e.SaleDocId, e.InstallmentNo })
                    .HasName("PK_SaleDocPymtSched")
                    .IsClustered(false);

                entity.ToTable("MA_SaleDocPymtSched");

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

                entity.HasOne(d => d.SaleDoc)
                    .WithMany(p => p.MaSaleDocPymtSched)
                    .HasForeignKey(d => d.SaleDocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SaleDocPym_SaleDoc_00");
            });
            modelBuilder.Entity<MaSaleDocReferences>(entity =>
{
                entity.HasKey(e => new { e.SaleDocId, e.Line })
                    .HasName("PK_SaleDocReferences")
                    .IsClustered(false);

                entity.ToTable("MA_SaleDocReferences");

                entity.HasIndex(e => new { e.DocumentType, e.DocumentId })
                    .HasName("MA_SaleDocReferences2");

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

                entity.HasOne(d => d.SaleDoc)
                    .WithMany(p => p.MaSaleDocReferences)
                    .HasForeignKey(d => d.SaleDocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SaleDocRef_SaleDoc_00");
            });
            modelBuilder.Entity<MaSaleDocShipping>(entity =>
{
                entity.HasKey(e => e.SaleDocId)
                    .HasName("PK_SaleDocShipping")
                    .IsClustered(false);

                entity.ToTable("MA_SaleDocShipping");

                entity.Property(e => e.SaleDocId).ValueGeneratedNever();

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

                entity.Property(e => e.CompilationData)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CompilationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.CompilationPlace)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustomerBranch)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustomerCode)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustomerType).HasDefaultValueSql("((6094850))");

                entity.Property(e => e.Declarations)
                    .HasMaxLength(128)
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

                entity.Property(e => e.Instructions)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LoaderBranch)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LoaderCode)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LoaderType).HasDefaultValueSql("((26214400))");

                entity.Property(e => e.LoadingPlace)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

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

                entity.Property(e => e.OwnerBranch)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OwnerCode)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OwnerType).HasDefaultValueSql("((26279936))");

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

                entity.Property(e => e.PortAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.RecalculateDisabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ShipToAddress)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

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

                entity.Property(e => e.TransportationForm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UnloadingPlace)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Vehicle)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.SaleDoc)
                    .WithOne(p => p.MaSaleDocShipping)
                    .HasForeignKey<MaSaleDocShipping>(d => d.SaleDocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SaleDocShi_SaleDoc_00");
            });
            modelBuilder.Entity<MaSaleDocSummary>(entity =>
{
                entity.HasKey(e => e.SaleDocId)
                    .HasName("PK_SaleDocSummary")
                    .IsClustered(false);

                entity.ToTable("MA_SaleDocSummary");

                entity.Property(e => e.SaleDocId).ValueGeneratedNever();

                entity.Property(e => e.AdditionalCharges).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.AdditionalChargesIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.Advance).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Advance2).HasDefaultValueSql("((0))");

                entity.Property(e => e.Advance3).HasDefaultValueSql("((0))");

                entity.Property(e => e.AdvanceOffset)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AdvanceOffset2)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AdvanceOffset3)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Allowances).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.AmountsWithWhtax)
                    .HasColumnName("AmountsWithWHTax")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

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

                entity.Property(e => e.Contributions).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.CreditNotePreviousPeriod)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DiscAmountTaxBreak).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.DiscTaxBreakManual)
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

                entity.Property(e => e.EnasarcosalesAmount)
                    .HasColumnName("ENASARCOSalesAmount")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EnasarcosalesPerc)
                    .HasColumnName("ENASARCOSalesPerc")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FreeSamples).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.FreeSamplesDocCurr).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.FreeSamplesTaxAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.GoodsAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.GoodsAmountWithTax).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.PackagingCharges).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.PackagingChargesIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.PayableAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.PayableAmountInBaseCurr).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.PaymentTerm).HasDefaultValueSql("((2686976))");

                entity.Property(e => e.PercDiscTaxBreak).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.PostAdvancesToAcc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PrePayedAdvance).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ProfessionalsCash).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ProfessionalsCashAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.ProfessionalsTaxCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReasonDiscTaxBreakCode)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReturnedMaterial).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ServiceAmounts).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ServiceAmountsWithTax).HasDefaultValueSql("((0.00))");

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

                entity.Property(e => e.VirtualStampFulfilled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.WithholdingTax).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.WithholdingTaxBasePerc).HasDefaultValueSql("((0))");

                entity.Property(e => e.WithholdingTaxManagement)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.WithholdingTaxPerc).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.SaleDoc)
                    .WithOne(p => p.MaSaleDocSummary)
                    .HasForeignKey<MaSaleDocSummary>(d => d.SaleDocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SaleDocSum_SaleDoc_00");
            });
            modelBuilder.Entity<MaSaleDocTaxSummary>(entity =>
{
                entity.HasKey(e => new { e.SaleDocId, e.TaxCode })
                    .HasName("PK_SaleDocTaxSummary")
                    .IsClustered(false);

                entity.ToTable("MA_SaleDocTaxSummary");

                entity.Property(e => e.TaxCode)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.TaxAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TaxAmountDocCurr).HasDefaultValueSql("((0.00))");

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

                entity.HasOne(d => d.SaleDoc)
                    .WithMany(p => p.MaSaleDocTaxSummary)
                    .HasForeignKey(d => d.SaleDocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SaleDocTax_SaleDoc_00");
            });
            modelBuilder.Entity<MaSaleParameters>(entity =>
{
                entity.HasKey(e => e.SaleParametersId)
                    .HasName("PK_SaleParameters")
                    .IsClustered(false);

                entity.ToTable("MA_SaleParameters");

                entity.Property(e => e.SaleParametersId).ValueGeneratedNever();

                entity.Property(e => e.BalanceEutaxSummaryDocCurr)
                    .HasColumnName("BalanceEUTaxSummaryDocCurr")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.BillOfExchStamps).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.BillOfExchStampsMin).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.BillOfExchStampsRounding).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.BlockCustomers)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CheckPerishables)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ClearingDncheck)
                    .HasColumnName("ClearingDNCheck")
                    .HasDefaultValueSql("((11599872))");

                entity.Property(e => e.CombNomenclatureCheckType).HasDefaultValueSql("((11599872))");

                entity.Property(e => e.DefInterStorageDocumentType).HasDefaultValueSql("((25296896))");

                entity.Property(e => e.DeferredInvoiceByArea)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DeferredInvoiceByCig)
                    .HasColumnName("DeferredInvoiceByCIG")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DeferredInvoiceByDiscounts)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DeferredInvoiceByDocBranch)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DeferredInvoiceByGoodBranch)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DeferredInvoiceByInvRsn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DeferredInvoiceByJob)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DeferredInvoiceByPymtTerm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.DeferredInvoiceByShippingRsn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DeferredInvoiceByTaxCommGroup)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DescriptiveLinesAreDelivered)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DisplayItemsInRadar).HasDefaultValueSql("((25231360))");

                entity.Property(e => e.DnupdateData)
                    .HasColumnName("DNUpdateData")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ExemptThreshold).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.FinalDiscountIncluded)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ForeignBillOfExchStamps).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.FreeBorderDefault).HasDefaultValueSql("((25886720))");

                entity.Property(e => e.GeneratePymtSchedInBaseCurr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IncludeCharges)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InvoiceClearsInventory)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InvoiceQtyCheck).HasDefaultValueSql("((11599872))");

                entity.Property(e => e.InvoiceToCustomerBank)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.InvoicingOfPerishables)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.KitComponentsPricePrompt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NegativeValueInLedgerCard)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.NoDeferredInvoice)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.OrderFullCustPrec)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PaymentPeriShablesOver60)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PaymentPeriShablesWithin60)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PerishablesNotes)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PerishablesNotesEi)
                    .HasColumnName("PerishablesNotesEI")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PrintNotOwnedStorageTransfIn)
                    .HasColumnName("PrintNotOwnedStorageTransfIN")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PrintParagonOnFiscalPrinter)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ProFormaUnloadInventory)
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

                entity.Property(e => e.ReferencesPrintType).HasDefaultValueSql("((524289))");

                entity.Property(e => e.ReturnFromCustomerQtyCheck).HasDefaultValueSql("((11599872))");

                entity.Property(e => e.SaleOrderRowFulfillment)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SalesScarcityCheckType).HasDefaultValueSql("((25100288))");

                entity.Property(e => e.SalesShortageCheckType).HasDefaultValueSql("((25100288))");

                entity.Property(e => e.ServicesInDn)
                    .HasColumnName("ServicesInDN")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SetLastDndateInInvoice)
                    .HasColumnName("SetLastDNDateInInvoice")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ShortageCheckType).HasDefaultValueSql("((25100288))");

                entity.Property(e => e.ShowSf)
                    .HasColumnName("ShowSF")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.SplitPaymentNote)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SplitPaymentNoteEnabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SplitPaymentNoteEnabledEi)
                    .HasColumnName("SplitPaymentNoteEnabledEI")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.StampThreshold).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TaxexigibilityCashRegimeNote)
                    .HasColumnName("TAXExigibilityCashRegimeNote")
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxexigibilityOnCollectNote)
                    .HasColumnName("TAXExigibilityOnCollectNote")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.TaxexigibilityOnCollectNoteEi)
                    .HasColumnName("TAXExigibilityOnCollectNoteEI")
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

                entity.Property(e => e.UseAdditionalSupplierCharges)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseCustomerExemption)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseCustomerOffset)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseDndateInDeferredInvoice)
                    .HasColumnName("UseDNDateInDeferredInvoice")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseOrderPort)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.VatonFreeSamplesForEucustomers)
                    .HasColumnName("VATOnFreeSamplesForEUCustomers")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.WarnNoPrintedLine)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.WarnOnCustomerType)
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
            modelBuilder.Entity<MaSaleParametersParagonFp>(entity =>
{
                entity.HasKey(e => new { e.SaleParametersId, e.ComputerName })
                    .HasName("PK_SaleParametersParagonFP")
                    .IsClustered(false);

                entity.ToTable("MA_SaleParametersParagonFP");

                entity.Property(e => e.ComputerName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.ComportNo)
                    .HasColumnName("COMPortNo")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExecutableProgram)
                    .HasMaxLength(256)
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
            modelBuilder.Entity<MaSaleParametersWithholdTax>(entity =>
{
                entity.HasKey(e => e.SaleParametersId)
                    .HasName("PK_SaleParametersWithholdTax")
                    .IsClustered(false);

                entity.ToTable("MA_SaleParametersWithholdTax");

                entity.Property(e => e.SaleParametersId).ValueGeneratedNever();

                entity.Property(e => e.CashOffset)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CashPerc).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.CashTaxCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EnasarcosalesAccRsn)
                    .HasColumnName("ENASARCOSalesAccRsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EnasarcosalesOffset)
                    .HasColumnName("ENASARCOSalesOffset")
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EnasarcosalesPerc)
                    .HasColumnName("ENASARCOSalesPerc")
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

                entity.Property(e => e.WholdingTaxAccRsn)
                    .HasColumnName("WHoldingTaxAccRsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.WholdingTaxOnCollection)
                    .HasColumnName("WHoldingTaxOnCollection")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.WholdingTaxOnCustomer)
                    .HasColumnName("WHoldingTaxOnCustomer")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.WithholdingTaxBasePerc).HasDefaultValueSql("((0))");

                entity.Property(e => e.WithholdingTaxManagement)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.WithholdingTaxOffset)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.WithholdingTaxPerc).HasDefaultValueSql("((0.00))");
            });
            modelBuilder.Entity<MaSalesDefaults>(entity =>
{
                entity.HasKey(e => e.SalesDefaultsId)
                    .HasName("PK_SalesDefaults")
                    .IsClustered(false);

                entity.ToTable("MA_SalesDefaults");

                entity.Property(e => e.SalesDefaultsId).ValueGeneratedNever();

                entity.Property(e => e.AccompanyingInvoiceAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AdditionalCharges)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Advance)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AdvanceAccRsn)
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

                entity.Property(e => e.CorrAccInvoiceAccTpl)
                    .HasMaxLength(8)
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

                entity.Property(e => e.CorrectionReceiptsAccTpl)
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

                entity.Property(e => e.DninvRsn)
                    .HasColumnName("DNInvRsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DummyCustomer)
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

                entity.Property(e => e.FreeOfCharge)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FreeSamplesAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FreeSamplesAmount)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FreeSamplesTaxAmount)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GoodsSalesAccount)
                    .HasMaxLength(16)
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

                entity.Property(e => e.InvoiceCorrectionRsnReturn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InvoiceForAdvanceAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InvoiceForAdvanceAccount)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InvoiceFromParagonAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InvoiceFromParagonTaxJournal)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IrnotOwnedStorageTransferIn)
                    .HasColumnName("IRNotOwnedStorageTransferIn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IrnotOwnedStorageTransferOut)
                    .HasColumnName("IRNotOwnedStorageTransferOut")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IrstorageTransfer)
                    .HasColumnName("IRStorageTransfer")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IrstorageTransferIn)
                    .HasColumnName("IRStorageTransferIn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IrstorageTransferOut)
                    .HasColumnName("IRStorageTransferOut")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IssueInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LoadDnrsn)
                    .HasColumnName("LoadDNRsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NcreceiptsAccTpl)
                    .HasColumnName("NCReceiptsAccTpl")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NcreceiptsTaxJournal)
                    .HasColumnName("NCReceiptsTaxJournal")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PackagingCharges)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PickingListInvRsn)
                    .HasMaxLength(8)
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

                entity.Property(e => e.ReceiptAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReceiptIsminvRsn)
                    .HasColumnName("ReceiptISMInvRsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReceiptsAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReturnFromCustomerInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReturnedMaterialInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ServicesSalesAccount)
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

                entity.Property(e => e.SundryRevenuesAccount)
                    .HasMaxLength(16)
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
            });
            modelBuilder.Entity<MaTmpSaleOrdFulfilment>(entity =>
{
                entity.HasKey(e => new { e.SaleOrdId, e.Line })
                    .HasName("PK_TmpSaleOrdFulfilment")
                    .IsClustered(false);

                entity.ToTable("MA_TmpSaleOrdFulfilment");

                entity.HasIndex(e => new { e.UserName, e.Computer })
                    .HasName("MA_TmpSaleOrdFulfilment4");

                entity.HasIndex(e => new { e.Item, e.ExpectedDeliveryDate, e.Customer, e.SaleOrdNo })
                    .HasName("MA_TmpSaleOrdFulfilment3");

                entity.HasIndex(e => new { e.Item, e.Priority, e.Customer, e.SaleOrdNo })
                    .HasName("MA_TmpSaleOrdFulfilment2");

                entity.Property(e => e.CloseSaleOrdPos)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Computer)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Customer)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Description)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Discount1).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Discount2).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.DiscountAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.DiscountFormula)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExpectedDeliveryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LineType).HasDefaultValueSql("((3538947))");

                entity.Property(e => e.Position).HasDefaultValueSql("((0))");

                entity.Property(e => e.Priority).HasDefaultValueSql("((0))");

                entity.Property(e => e.Qty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.SaleOrdNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SubId).HasDefaultValueSql("((0))");

                entity.Property(e => e.TaxCode)
                    .HasMaxLength(4)
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

                entity.Property(e => e.UnitValue).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.UoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UserName)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
        }
    }
}
