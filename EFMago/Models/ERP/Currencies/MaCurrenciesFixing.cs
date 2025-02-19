using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaCurrenciesFixing
    {
        public string Currency { get; set; }
        public string ReferredCurrency { get; set; }
        public DateTime FixingDate { get; set; }
        public double? Fixing { get; set; }
        public double? SaleFixing { get; set; }
        public double? PurchaseFixing { get; set; }
        public string Notes { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaCurrencies CurrencyNavigation { get; set; }
    }
}
