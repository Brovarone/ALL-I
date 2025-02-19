using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaItemCustomersPriceLists
    {
        public string Item { get; set; }
        public string Customer { get; set; }
        public DateTime ValidityStartingDate { get; set; }
        public double Qty { get; set; }
        public DateTime? ValidityEndingDate { get; set; }
        public DateTime? LastModificationDate { get; set; }
        public double? Price { get; set; }
        public double? Discount1 { get; set; }
        public double? Discount2 { get; set; }
        public string DiscountFormula { get; set; }
        public string Notes { get; set; }
        public string WithTax { get; set; }
        public string UoM { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaItemCustomers MaItemCustomers { get; set; }
    }
}
