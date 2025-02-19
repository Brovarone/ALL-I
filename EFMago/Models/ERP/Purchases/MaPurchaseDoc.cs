using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaPurchaseDoc
    {
        public MaPurchaseDoc()
        {
            MaBrnotaFiscalForSuppDetail = new HashSet<MaBrnotaFiscalForSuppDetail>();
            MaBrnotaFiscalForSuppRef = new HashSet<MaBrnotaFiscalForSuppRef>();
            MaPurchaseDocDetail = new HashSet<MaPurchaseDocDetail>();
            MaPurchaseDocLinkOrders = new HashSet<MaPurchaseDocLinkOrders>();
            MaPurchaseDocNotes = new HashSet<MaPurchaseDocNotes>();
            MaPurchaseDocPymtSched = new HashSet<MaPurchaseDocPymtSched>();
            MaPurchaseDocReferences = new HashSet<MaPurchaseDocReferences>();
            MaPurchaseDocTaxSummary = new HashSet<MaPurchaseDocTaxSummary>();
        }

        public int? DocumentType { get; set; }
        public string DocNo { get; set; }
        public DateTime? DocumentDate { get; set; }
        public string Supplier { get; set; }
        public string Language { get; set; }
        public string OurReference { get; set; }
        public string YourReference { get; set; }
        public string Payment { get; set; }
        public DateTime? InstallmStartDate { get; set; }
        public string InstallmStartDateIsAuto { get; set; }
        public DateTime? PostingDate { get; set; }
        public string SupplierBank { get; set; }
        public string CompanyBank { get; set; }
        public string CompanyCa { get; set; }
        public string NetOfTax { get; set; }
        public string Summarized { get; set; }
        public string InvoiceFollows { get; set; }
        public string Printed { get; set; }
        public string InvoicingAccTpl { get; set; }
        public string InvoicingTaxJournal { get; set; }
        public string Currency { get; set; }
        public DateTime? FixingDate { get; set; }
        public string FixingIsManual { get; set; }
        public double? Fixing { get; set; }
        public string AccTpl { get; set; }
        public string TaxJournal { get; set; }
        public string EutaxJournal { get; set; }
        public string PostedToAccounting { get; set; }
        public string PostedToInventory { get; set; }
        public string Issued { get; set; }
        public string PostedToIntrastat { get; set; }
        public string PostedToPyblsRcvbls { get; set; }
        public int PurchaseDocId { get; set; }
        public string ConfInvRsn { get; set; }
        public string InspectionLoadInvRsn { get; set; }
        public string NotConfInvRsn { get; set; }
        public string StubBook { get; set; }
        public string ConformingStorage1 { get; set; }
        public string ConformingSpecificator1 { get; set; }
        public string ConformingStorage2 { get; set; }
        public string ConformingSpecificator2 { get; set; }
        public string InspectionStorage1 { get; set; }
        public string InspectionSpecificator1 { get; set; }
        public string InspectionStorage2 { get; set; }
        public string InspectionSpecificator2 { get; set; }
        public string NotConformingStorage1 { get; set; }
        public string NotConformingSpecificator1 { get; set; }
        public string NotConformingStorage2 { get; set; }
        public string NotConformingSpecificator2 { get; set; }
        public string ScrapInvRsn { get; set; }
        public string ScrapStorage1 { get; set; }
        public string ScrapSpecificator1 { get; set; }
        public string ScrapStorage2 { get; set; }
        public string ScrapSpecificator2 { get; set; }
        public string SupplierDocNo { get; set; }
        public DateTime? SupplierDocDate { get; set; }
        public int? PymtSchedId { get; set; }
        public int? JournalEntryId { get; set; }
        public int? IntrastatId { get; set; }
        public int? NatureOfTransaction { get; set; }
        public int? DeliveryTerms { get; set; }
        public int? ModeOfTransport { get; set; }
        public int? Operation { get; set; }
        public string IncludedInTurnover { get; set; }
        public string Job { get; set; }
        public string PostedToCostAccounting { get; set; }
        public string CostCenter { get; set; }
        public string ProductLine { get; set; }
        public DateTime? DepartureDate { get; set; }
        public string Notes { get; set; }
        public string CountryOfConsignment { get; set; }
        public string SendDocumentsTo { get; set; }
        public string Invoiced { get; set; }
        public string BlockInvoices { get; set; }
        public string BlockSuppliers { get; set; }
        public string Eoydeductible { get; set; }
        public string BlockPayments { get; set; }
        public int? InvEntryId { get; set; }
        public int? Rmaid { get; set; }
        public int? InspectionOrdId { get; set; }
        public int? ScrapInvEntryId { get; set; }
        public int? ReturnInvEntryId { get; set; }
        public string CountryOfOrigin { get; set; }
        public string Rmagenerated { get; set; }
        public string InspectionOrderGenerated { get; set; }
        public string ScrapGenerated { get; set; }
        public string ReturnGenerated { get; set; }
        public string RmastubBook { get; set; }
        public string ReturnInvRsn { get; set; }
        public string ReturnStorage1 { get; set; }
        public string ReturnSpecificator1 { get; set; }
        public string ReturnStorage2 { get; set; }
        public string ReturnSpecificator2 { get; set; }
        public DateTime? ValueDate { get; set; }
        public int? LastSubId { get; set; }
        public int? AdvancePymtSchedId { get; set; }
        public DateTime? IntrastatAccrualDate { get; set; }
        public int? CustSuppType { get; set; }
        public int? ConformingSpecificator1Type { get; set; }
        public int? ConformingSpecificator2Type { get; set; }
        public int? InspectionSpecificator1Type { get; set; }
        public int? InspectionSpecificator2Type { get; set; }
        public int? NotConfSpecificator1Type { get; set; }
        public int? NotConfSpecificator2Type { get; set; }
        public int? ScrapSpecificator1Type { get; set; }
        public int? ScrapSpecificator2Type { get; set; }
        public int? ReturnSpecificator1Type { get; set; }
        public int? ReturnSpecificator2Type { get; set; }
        public string IntrastatBis { get; set; }
        public string IntrastatTer { get; set; }
        public Guid? Tbguid { get; set; }
        public int? AdjValueOnlyInvEntryId { get; set; }
        public string CorrectionDocument { get; set; }
        public int? CorrectionDocumentId { get; set; }
        public int? CorrectedDocumentId { get; set; }
        public string InvRsnOnlyValue { get; set; }
        public string Storage1OnlyValue { get; set; }
        public int? PureJecollectionPaymentId { get; set; }
        public string PureJecollectionPaymentNo { get; set; }
        public string InvoicingAccGroup { get; set; }
        public string InvoiceForAdvanceLinked { get; set; }
        public string CorrectionForReturn { get; set; }
        public int? CorrectionDocumentIdInCn { get; set; }
        public string DocumentCorrectionInCn { get; set; }
        public int? WorkerIdissue { get; set; }
        public string SupplierCa { get; set; }
        public int? StatisticalPurpose { get; set; }
        public string CountryOfTransport { get; set; }
        public string SaleRecordNo { get; set; }
        public string PaymentAddress { get; set; }
        public string EsrreferenceNumber { get; set; }
        public string EsrcheckDigit { get; set; }
        public DateTime? PlafondAccrualDate { get; set; }
        public string CountryOfPayment { get; set; }
        public int? ActionOnLifoFifo { get; set; }
        public string ModifyOriginalPymtSched { get; set; }
        public string ContractCode { get; set; }
        public string ProjectCode { get; set; }
        public DateTime? AccrualDate { get; set; }
        public DateTime? TaxAccrualDate { get; set; }
        public int? PureJetaxTransferId { get; set; }
        public int? TaxCommunicationOperation { get; set; }
        public string TaxCommunicationGroup { get; set; }
        public string Archived { get; set; }
        public int? Eistatus { get; set; }
        public int? ExtAccAeid { get; set; }
        public string GenerateEat { get; set; }
        public int? AdditionalCharge { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public string ImSubcontractDoc { get; set; }

        public virtual MaBrnotaFiscalForSuppShipping MaBrnotaFiscalForSuppShipping { get; set; }
        public virtual MaBrnotaFiscalForSuppSummary MaBrnotaFiscalForSuppSummary { get; set; }
        public virtual MaBrnotaFiscalForSupplier MaBrnotaFiscalForSupplier { get; set; }
        public virtual MaPurchaseDocShipping MaPurchaseDocShipping { get; set; }
        public virtual MaPurchaseDocSummary MaPurchaseDocSummary { get; set; }
        public virtual ICollection<MaBrnotaFiscalForSuppDetail> MaBrnotaFiscalForSuppDetail { get; set; }
        public virtual ICollection<MaBrnotaFiscalForSuppRef> MaBrnotaFiscalForSuppRef { get; set; }
        public virtual ICollection<MaPurchaseDocDetail> MaPurchaseDocDetail { get; set; }
        public virtual ICollection<MaPurchaseDocLinkOrders> MaPurchaseDocLinkOrders { get; set; }
        public virtual ICollection<MaPurchaseDocNotes> MaPurchaseDocNotes { get; set; }
        public virtual ICollection<MaPurchaseDocPymtSched> MaPurchaseDocPymtSched { get; set; }
        public virtual ICollection<MaPurchaseDocReferences> MaPurchaseDocReferences { get; set; }
        public virtual ICollection<MaPurchaseDocTaxSummary> MaPurchaseDocTaxSummary { get; set; }
    }
}
