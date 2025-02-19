using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaCustQuotas
    {
        public MaCustQuotas()
        {
            MaCustQuotasDetail = new HashSet<MaCustQuotasDetail>();
            MaCustQuotasTaxSummary = new HashSet<MaCustQuotasTaxSummary>();
        }

        public int? SaleOrdId { get; set; }
        public string QuotationNo { get; set; }
        public DateTime? QuotationDate { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }
        public string UseContact { get; set; }
        public string Customer { get; set; }
        public string Contact { get; set; }
        public string Language { get; set; }
        public string OurReference { get; set; }
        public string YourReference { get; set; }
        public string Payment { get; set; }
        public string PriceList { get; set; }
        public string CustomerBank { get; set; }
        public string CompanyBank { get; set; }
        public string SendQuotationTo { get; set; }
        public string PaymentAddress { get; set; }
        public string NetOfTax { get; set; }
        public string Currency { get; set; }
        public DateTime? FixingDate { get; set; }
        public string FixingIsManual { get; set; }
        public double? Fixing { get; set; }
        public string Salesperson { get; set; }
        public string AreaManager { get; set; }
        public string Notes { get; set; }
        public int CustQuotaId { get; set; }
        public string Printed { get; set; }
        public string SentByEmail { get; set; }
        public string CompanyCa { get; set; }
        public int? Presentation { get; set; }
        public DateTime? ValidityEndingDate { get; set; }
        public short? ValidityDays { get; set; }
        public string DueDateFromOrderDate { get; set; }
        public int? LastSubId { get; set; }
        public string Job { get; set; }
        public string CostCenter { get; set; }
        public string ProductLine { get; set; }
        public string ActiveSubcontracting { get; set; }
        public string RequestNo { get; set; }
        public DateTime? RequestDate { get; set; }
        public int? CustSuppType { get; set; }
        public Guid? Tbguid { get; set; }
        public string TaxJournal { get; set; }
        public string StubBook { get; set; }
        public string InvRsn { get; set; }
        public string StoragePhase1 { get; set; }
        public string SpecificatorPhase1 { get; set; }
        public string StoragePhase2 { get; set; }
        public string SpecificatorPhase2 { get; set; }
        public int? Specificator1Type { get; set; }
        public int? Specificator2Type { get; set; }
        public string ContractCode { get; set; }
        public string ProjectCode { get; set; }
        public string TaxCommunicationGroup { get; set; }
        public string CompanyPymtCa { get; set; }
        public string SentByPostaLite { get; set; }
        public string Archived { get; set; }
        public int? FromExternalProgram { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public int? ImQuotationRequestId { get; set; }

        public virtual MaCustQuotasNote MaCustQuotasNote { get; set; }
        public virtual MaCustQuotasShipping MaCustQuotasShipping { get; set; }
        public virtual MaCustQuotasSummary MaCustQuotasSummary { get; set; }
        public virtual ICollection<MaCustQuotasDetail> MaCustQuotasDetail { get; set; }
        public virtual ICollection<MaCustQuotasTaxSummary> MaCustQuotasTaxSummary { get; set; }
    }
}
