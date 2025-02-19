using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImSubcontractOrdWpr
    {
        public int SubcontractOrdId { get; set; }
        public short Line { get; set; }
        public int? SubcontractWprid { get; set; }
        public string SubcontractWprno { get; set; }
        public DateTime? SubcontractWprdate { get; set; }
        public double? TotTaxableAmount { get; set; }
        public double? PreviousTaxableAmount { get; set; }
        public double? CurrentTaxableAmount { get; set; }
        public string DiscountFormula { get; set; }
        public double? DiscountAmount { get; set; }
        public double? TaxableAmount { get; set; }
        public double? WithholdingDefInvAmount { get; set; }
        public double? InvoiceTaxableAmount { get; set; }
        public double? InvoiceTotalAmount { get; set; }
        public double? AdvanceAmount { get; set; }
        public double? PayableAmount { get; set; }
        public double? WithholdingDefPayAmount { get; set; }
        public double? PayableAmountInBaseCurr { get; set; }
        public double? WithholdingDefPayAmountInBaseCurr { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ImSubcontractOrd SubcontractOrd { get; set; }
    }
}
