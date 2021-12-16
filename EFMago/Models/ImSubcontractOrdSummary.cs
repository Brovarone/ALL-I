using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImSubcontractOrdSummary
    {
        public int SubcontractOrdId { get; set; }
        public double? TaxableAmount { get; set; }
        public double? TaxAmount { get; set; }
        public double? TotalAmount { get; set; }
        public double? ServicesAmounts { get; set; }
        public double? Clamounts { get; set; }
        public double? ChargesAmounts { get; set; }
        public double? OtherAmounts { get; set; }
        public double? DetailsDiscount { get; set; }
        public double? Discount1 { get; set; }
        public double? Discount2 { get; set; }
        public string DiscountFormula { get; set; }
        public double? DiscountAmount { get; set; }
        public string DiscountsIsAuto { get; set; }
        public double? TaxableAmountDocCurr { get; set; }
        public double? TaxAmountDocCurr { get; set; }
        public double? TotalAmountDocCurr { get; set; }
        public double? AdvanceAmount { get; set; }
        public double? PayableAmountInBaseCurr { get; set; }
        public double? PayableAmount { get; set; }
        public double? InvoicedPayableAmount { get; set; }
        public double? InvoicedTaxableAmount { get; set; }
        public double? BaseCalcWithholdingInBaseCurr { get; set; }
        public double? BaseCalcWithholding { get; set; }
        public double? TotTaxableJob { get; set; }
        public double? TotTaxAmountToOrder { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ImSubcontractOrd SubcontractOrd { get; set; }
    }
}
