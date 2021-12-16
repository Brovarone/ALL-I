using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImSuppQuotasDetailSummary
    {
        public string Item { get; set; }
        public string Supplier { get; set; }
        public int SuppQuotaId { get; set; }
        public string DiscountFormula { get; set; }
        public double? SumQuantity { get; set; }
        public double? UnitValue { get; set; }
        public double? SumTaxableAmount { get; set; }
        public double? SumDiscountAmount { get; set; }
        public double? FurtherDiscount { get; set; }
    }
}
