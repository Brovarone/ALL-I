using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImPurchReqGenDocRefSuppQuota
    {
        public string DocNo { get; set; }
        public int? DocId { get; set; }
        public string Item { get; set; }
        public string Description { get; set; }
        public string UoM { get; set; }
        public string Producer { get; set; }
        public string ProductCtg { get; set; }
        public string ProductSubCtg { get; set; }
        public string PurchaseRequestNo { get; set; }
        public int PurchaseRequestId { get; set; }
        public string Simulation { get; set; }
        public string Supplier { get; set; }
        public string DiscountFormula { get; set; }
        public double? SumQuantity { get; set; }
        public double? UnitValue { get; set; }
        public double? SumTaxableAmount { get; set; }
        public double? SumDiscountAmount { get; set; }
        public double? FurtherDiscount { get; set; }
    }
}
