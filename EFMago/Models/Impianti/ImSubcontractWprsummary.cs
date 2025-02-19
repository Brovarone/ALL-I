using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImSubcontractWprsummary
    {
        public int SubcontractWprid { get; set; }
        public double? TotTaxableAmount { get; set; }
        public double? PreviousTaxableAmount { get; set; }
        public double? CurrentTaxableAmount { get; set; }
        public double? Discount1 { get; set; }
        public double? Discount2 { get; set; }
        public string DiscountFormula { get; set; }
        public double? DiscountAmount { get; set; }
        public double? TaxableAmount { get; set; }
        public double? WithholdingDefInvAmount { get; set; }
        public double? InvoiceTaxableAmount { get; set; }
        public double? InvoiceTaxAmount { get; set; }
        public double? InvoiceTotalAmount { get; set; }
        public double? InvoiceTaxableAmountDocCurr { get; set; }
        public double? InvoiceTaxAmountDocCurr { get; set; }
        public double? InvoiceTotalAmountDocCurr { get; set; }
        public double? AdvanceAmount { get; set; }
        public double? PayableAmount { get; set; }
        public double? PayableAmountInBaseCurr { get; set; }
        public double? WithholdingDefPayAmount { get; set; }
        public double? WithholdingDefPayAmountInBaseCurr { get; set; }
        public string UseTaxableJobInPc { get; set; }
        public double? TaxableJob { get; set; }
        public double? InvoicedPayableAmount { get; set; }
        public double? InvoicedTaxableAmount { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ImSubcontractWorksProgressReport SubcontractWpr { get; set; }
    }
}
