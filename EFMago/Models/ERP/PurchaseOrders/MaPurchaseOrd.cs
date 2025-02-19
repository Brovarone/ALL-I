using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaPurchaseOrd
    {
        public MaPurchaseOrd()
        {
            MaPurchaseOrdDetails = new HashSet<MaPurchaseOrdDetails>();
            MaPurchaseOrdPymtSched = new HashSet<MaPurchaseOrdPymtSched>();
            MaPurchaseOrdReferences = new HashSet<MaPurchaseOrdReferences>();
            MaPurchaseOrdTaxSummay = new HashSet<MaPurchaseOrdTaxSummay>();
        }

        public string InternalOrdNo { get; set; }
        public string ExternalOrdNo { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }
        public DateTime? ConfirmedDeliveryDate { get; set; }
        public string Supplier { get; set; }
        public string Language { get; set; }
        public string OurReference { get; set; }
        public string YourReference { get; set; }
        public string Payment { get; set; }
        public string SupplierBank { get; set; }
        public string CompanyBank { get; set; }
        public string SendDocumentsTo { get; set; }
        public string NetOfTax { get; set; }
        public string Currency { get; set; }
        public DateTime? FixingDate { get; set; }
        public string FixingIsManual { get; set; }
        public double? Fixing { get; set; }
        public string Area { get; set; }
        public string Salesperson { get; set; }
        public string Notes { get; set; }
        public string Paid { get; set; }
        public string Delivered { get; set; }
        public string Printed { get; set; }
        public string SentByEmail { get; set; }
        public string Cancelled { get; set; }
        public int PurchaseOrdId { get; set; }
        public string Job { get; set; }
        public string CostCenter { get; set; }
        public string AccTpl { get; set; }
        public string TaxJournal { get; set; }
        public string InvRsn { get; set; }
        public string StubBook { get; set; }
        public string StoragePhase1 { get; set; }
        public string SpecificatorPhase1 { get; set; }
        public string StoragePhase2 { get; set; }
        public string SpecificatorPhase2 { get; set; }
        public string NonStandardPayment { get; set; }
        public string UseBusinessYear { get; set; }
        public string SubcontractorOrder { get; set; }
        public string CompanyCa { get; set; }
        public int? LastSubId { get; set; }
        public int? CustSuppType { get; set; }
        public int? Specificator1Type { get; set; }
        public int? Specificator2Type { get; set; }
        public string ProductLine { get; set; }
        public Guid? Tbguid { get; set; }
        public string AccGroup { get; set; }
        public string SupplierCa { get; set; }
        public string PaymentAddress { get; set; }
        public string Receipt { get; set; }
        public string BarcodeSegment { get; set; }
        public string ContractCode { get; set; }
        public string ProjectCode { get; set; }
        public string TaxCommunicationGroup { get; set; }
        public string SentByPostaLite { get; set; }
        public string Archived { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaPurchaseOrdNotes MaPurchaseOrdNotes { get; set; }
        public virtual MaPurchaseOrdShipping MaPurchaseOrdShipping { get; set; }
        public virtual MaPurchaseOrdSummary MaPurchaseOrdSummary { get; set; }
        public virtual ICollection<MaPurchaseOrdDetails> MaPurchaseOrdDetails { get; set; }
        public virtual ICollection<MaPurchaseOrdPymtSched> MaPurchaseOrdPymtSched { get; set; }
        public virtual ICollection<MaPurchaseOrdReferences> MaPurchaseOrdReferences { get; set; }
        public virtual ICollection<MaPurchaseOrdTaxSummay> MaPurchaseOrdTaxSummay { get; set; }
    }
}
