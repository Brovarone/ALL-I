using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImJobQuotasSummary
    {
        public int JobQuotationId { get; set; }
        public double? AuctionBase { get; set; }
        public double? Decrease { get; set; }
        public double? DecreasePerc { get; set; }
        public double? LabourTotalAmount { get; set; }
        public double? ExpensesTotalAmount { get; set; }
        public int? TotalTime { get; set; }
        public double? GoodsTotalAmount { get; set; }
        public double? TaxableAmount { get; set; }
        public double? DistributedExpTotAmount { get; set; }
        public double? UndistributableExpTotAmount { get; set; }
        public double? DistributableExpTotAmount { get; set; }
        public double? SpecificationTotalAmount { get; set; }
        public double? QuotedTotalAmount { get; set; }
        public double? TaxAmount { get; set; }
        public double? TotalAmount { get; set; }
        public string GoodsMarkupFormula { get; set; }
        public string LabourMarkupFormula { get; set; }
        public string ServicesMarkupFormula { get; set; }
        public string ChargesMarkupFormula { get; set; }
        public string OtherMarkupFormula { get; set; }
        public double? QuotedTotalAmountDocCurr { get; set; }
        public double? TotalAmountDocCurr { get; set; }
        public double? FreeSamplesDocCurr { get; set; }
        public double? TaxableAmountDocCurr { get; set; }
        public double? TaxAmountDocCurr { get; set; }
        public double? StampsCharges { get; set; }
        public double? CollectionCharges { get; set; }
        public double? FreeSamplesTotalAmount { get; set; }
        public double? PackagingCharges { get; set; }
        public double? ShippingCharges { get; set; }
        public double? AdditionalCharges { get; set; }
        public double? AllowancesTotalAmount { get; set; }
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
        public string TaxNotApplied { get; set; }
        public string TaxCode { get; set; }
        public string FurtherDiscountIsAutomatic { get; set; }
        public string UseMethodPrefTaxCode { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ImJobQuotations JobQuotation { get; set; }
    }
}
