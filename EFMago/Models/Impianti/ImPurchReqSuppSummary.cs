using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImPurchReqSuppSummary
    {
        public int PurchaseRequestId { get; set; }
        public short Line { get; set; }
        public string Supplier { get; set; }
        public double? TaxableAmount { get; set; }
        public string TaxCode { get; set; }
        public double? TaxAmount { get; set; }
        public double? Amount { get; set; }
        public double? DiscountAmount { get; set; }
        public double? OnGoodsIncidencePerc { get; set; }
        public double? Value { get; set; }
        public double? DiscountsValueFromQuotas { get; set; }
        public double? AllowancesValueFromQuotas { get; set; }
        public string UseDiscountFromQuotas { get; set; }
        public string UseAllowancesFromQuotas { get; set; }
        public double? ExpectedCostSubTotalAmount { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ImPurchaseRequest PurchaseRequest { get; set; }
    }
}
