using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaCommodityCtgCustomersCtg
    {
        public string CommodityCtg { get; set; }
        public string CustomerCtg { get; set; }
        public double? Discount1 { get; set; }
        public double? Discount2 { get; set; }
        public string DiscountFormula { get; set; }
        public string Notes { get; set; }
        public string Disabled { get; set; }
        public string SaleOffset { get; set; }
        public Guid? Tbguid { get; set; }
        public string TaxCode { get; set; }
        public string ReverseCharge { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
