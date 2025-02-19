using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaSuppQuotas
    {
        public MaSuppQuotas()
        {
            MaSuppQuotasDetail = new HashSet<MaSuppQuotasDetail>();
            MaSuppQuotasTaxSummary = new HashSet<MaSuppQuotasTaxSummary>();
        }

        public string QuotationNo { get; set; }
        public DateTime? QuotationDate { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }
        public string UseProspSupp { get; set; }
        public string Supplier { get; set; }
        public string ProspectiveSupplier { get; set; }
        public string Language { get; set; }
        public string OurReference { get; set; }
        public string YourReference { get; set; }
        public string Payment { get; set; }
        public string SupplierBank { get; set; }
        public string CompanyBank { get; set; }
        public string SendQuotationTo { get; set; }
        public string NetOfTax { get; set; }
        public string Currency { get; set; }
        public DateTime? FixingDate { get; set; }
        public string FixingIsManual { get; set; }
        public double? Fixing { get; set; }
        public string Notes { get; set; }
        public int SuppQuotaId { get; set; }
        public int? PurchaseOrdId { get; set; }
        public string Printed { get; set; }
        public string SentByEmail { get; set; }
        public string CompanyCa { get; set; }
        public string ClosedOrder { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public DateTime? ValidityEndingDate { get; set; }
        public string SupplierDocNo { get; set; }
        public int? LastSubId { get; set; }
        public string Job { get; set; }
        public string CostCenter { get; set; }
        public string ProductLine { get; set; }
        public int? CustSuppType { get; set; }
        public Guid? Tbguid { get; set; }
        public string SupplierCa { get; set; }
        public string PaymentAddress { get; set; }
        public string ContractCode { get; set; }
        public string ProjectCode { get; set; }
        public string TaxCommunicationGroup { get; set; }
        public string SentByPostaLite { get; set; }
        public string Archived { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaSuppQuotasNote MaSuppQuotasNote { get; set; }
        public virtual MaSuppQuotasShipping MaSuppQuotasShipping { get; set; }
        public virtual MaSuppQuotasSummary MaSuppQuotasSummary { get; set; }
        public virtual ICollection<MaSuppQuotasDetail> MaSuppQuotasDetail { get; set; }
        public virtual ICollection<MaSuppQuotasTaxSummary> MaSuppQuotasTaxSummary { get; set; }
    }
}
