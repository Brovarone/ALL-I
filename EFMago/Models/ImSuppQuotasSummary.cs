using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImSuppQuotasSummary
    {
        public int SuppQuotaId { get; set; }
        public double? GoodsAmount { get; set; }
        public double? ServiceAmounts { get; set; }
        public double? DiscountOnGoods { get; set; }
        public double? DiscountOnServices { get; set; }
        public double? Discounts { get; set; }
        public double? Allowances { get; set; }
        public double? Advance { get; set; }
        public double? FurtherDiscount { get; set; }
    }
}
