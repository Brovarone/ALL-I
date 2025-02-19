using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImPoliciesProducers
    {
        public string Policy { get; set; }
        public short Line { get; set; }
        public string Producer { get; set; }
        public string ProductCtg { get; set; }
        public string ProductSubCtg { get; set; }
        public int? GoodsValueType { get; set; }
        public int? GoodsDiscountType { get; set; }
        public double? GoodsDiscount { get; set; }
        public string ReverseGoodsDiscountsOrder { get; set; }
        public double? GoodsMarkup { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ImPolicies PolicyNavigation { get; set; }
    }
}
