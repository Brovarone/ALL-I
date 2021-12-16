using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImPurchaseOrdOrdDetails
    {
        public string InternalOrdNo { get; set; }
        public string Description { get; set; }
        public string Item { get; set; }
        public string Supplier { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }
        public double? DeliveredQty { get; set; }
        public double? Qty { get; set; }
        public string Job { get; set; }
        public string UoM { get; set; }
        public string Delivered { get; set; }
        public double? UnitValue { get; set; }
        public double? TaxableAmount { get; set; }
        public double? DiscountAmount { get; set; }
        public string DiscountFormula { get; set; }
        public double? Discount1 { get; set; }
        public double? Discount2 { get; set; }
        public int? ExpectedDeliveryMonth { get; set; }
        public int? ExpectedDeliveryYear { get; set; }
        public int? LineType { get; set; }
        public string Currency { get; set; }
        public DateTime? FixingDate { get; set; }
        public string FixingIsManual { get; set; }
        public double? Fixing { get; set; }
        public string Cancelled { get; set; }
        public int PurchaseOrdId { get; set; }
    }
}
