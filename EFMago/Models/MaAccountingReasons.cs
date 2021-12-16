using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaAccountingReasons
    {
        public string Reason { get; set; }
        public string Description { get; set; }
        public string UseForPureEntry { get; set; }
        public string UseForSaleEntry { get; set; }
        public string UseForPurchaseEntry { get; set; }
        public string UseForRetailSaleEntry { get; set; }
        public string Predefined { get; set; }
        public Guid? Tbguid { get; set; }
        public string OmniaaccReason { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
