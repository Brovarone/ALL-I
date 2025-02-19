using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImJobsSummary
    {
        public string Job { get; set; }
        public string Storage { get; set; }
        public string UseSpecificationPrice { get; set; }
        public double? JobTotalAmount { get; set; }
        public int? LastJobLineId { get; set; }
        public string Manager { get; set; }
        public string TaxCode { get; set; }
        public string OffSet { get; set; }
        public string TaxJournal { get; set; }
        public string AccTpl { get; set; }
        public string Payment { get; set; }
        public string Policy { get; set; }
        public string CustomerBank { get; set; }
        public string CompanyBank { get; set; }
        public string CompanyCa { get; set; }
        public int? Presentation { get; set; }
        public string Language { get; set; }
        public string PriceList { get; set; }
        public string SendDocumentsTo { get; set; }
        public string SendPaymentsTo { get; set; }
        public string NetOfTax { get; set; }
        public string SalesPerson { get; set; }
        public double? PayableTotalAmount { get; set; }
        public double? QuotedTotalAmountDocCurr { get; set; }
        public double? FreeSamplesDocCurr { get; set; }
        public double? TaxableAmountDocCurr { get; set; }
        public double? TaxAmountDocCurr { get; set; }
        public double? StampsCharges { get; set; }
        public double? CollectionCharges { get; set; }
        public double? FreeSamplesTotalAmount { get; set; }
        public double? PackagingCharges { get; set; }
        public double? ShippingCharges { get; set; }
        public double? AdditionalCharges { get; set; }
        public double? AllowancesAmount { get; set; }
        public double? TotalAmountBaseCurr { get; set; }
        public double? AdvancesTotalAmount { get; set; }
        public double? GoodsDiscountTotalAmount { get; set; }
        public double? ServicesDiscountTotalAmount { get; set; }
        public double? CashOnDeliveryPerc { get; set; }
        public double? CashOnDeliveryCharges { get; set; }
        public double? PriceTotalAmount { get; set; }
        public double? TaxableTotalAmount { get; set; }
        public double? TaxChargedTotalAmount { get; set; }
        public string FurtherDiscountFormula { get; set; }
        public double? FurtherDiscount1 { get; set; }
        public double? FurtherDiscount2 { get; set; }
        public double? DetailsDiscountTotalAmount { get; set; }
        public double? FurtherDiscountTotalAmount { get; set; }
        public double? DiscountTotalAmount { get; set; }
        public double? CostsTotalAmount { get; set; }
        public double? ProceedsTotalAmount { get; set; }
        public double? PerformanceTotalAmount { get; set; }
        public double? DistributedExpensesTotalAmount { get; set; }
        public double? TaxAmount { get; set; }
        public string TaxNotApplied { get; set; }
        public string Currency { get; set; }
        public DateTime? FixingDate { get; set; }
        public double? Fixing { get; set; }
        public string FixingIsManual { get; set; }
        public string PriceIsAutomatic { get; set; }
        public string InvRsn { get; set; }
        public string UseSpecificationQty { get; set; }
        public string Wrreason { get; set; }
        public string MandatoryExpectedDates { get; set; }
        public string UsePercInEconomicCp { get; set; }
        public double? MarginPerc { get; set; }
        public double? ChargingPerc { get; set; }
        public string SiteManager { get; set; }
        public string FurtherDiscountIsAutomatic { get; set; }
        public int? OriginCostsSubcontract { get; set; }
        public string TaxCommunicationGroup { get; set; }
        public string EmployeeReference { get; set; }
        public string InvRsnPdoc { get; set; }
        public string StorageDelReqPo { get; set; }
        public string StorageDelReqPl { get; set; }
        public string UseMethodPrefTaxCode { get; set; }
        public string UseInAdvTools { get; set; }
        public int? MethodCalculationCompRevenues { get; set; }
        public string UseInvoiceInCompRevenues { get; set; }
        public string UseInvForAdvInCompRevenues { get; set; }
        public string UseCreditNoteInCompRevenues { get; set; }
        public string UseReceiptInCompRevenues { get; set; }
        public string UseNonCollReceiptInCompRevenues { get; set; }
        public double? ContractRevenues { get; set; }
        public DateTime? RevenuesFromDate { get; set; }
        public DateTime? RevenuesToDate { get; set; }
        public int? TypeRatePeriodEnjoyment { get; set; }
        public string ExpiryRatePeriodEnjoyment { get; set; }
        public DateTime? AdministrativeClosureDate { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public string UseAccInvInCompRevenues { get; set; }

        public virtual MaJobs JobNavigation { get; set; }
    }
}
