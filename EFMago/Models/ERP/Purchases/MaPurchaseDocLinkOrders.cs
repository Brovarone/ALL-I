using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaPurchaseDocLinkOrders
    {
        public int PurchaseDocId { get; set; }
        public int SubId { get; set; }
        public short Line { get; set; }
        public int? PurchaseOrdId { get; set; }
        public int? PurchaseOrdSubId { get; set; }
        public string PurchaseOrdNo { get; set; }
        public short? PurchaseOrdPos { get; set; }
        public string ClosePurchaseOrd { get; set; }
        public string Item { get; set; }
        public double? Quantity { get; set; }
        public string UoM { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaPurchaseDoc PurchaseDoc { get; set; }
    }
}
