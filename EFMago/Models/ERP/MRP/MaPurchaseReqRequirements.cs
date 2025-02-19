using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaPurchaseReqRequirements
    {
        public int PurchaseReqId { get; set; }
        public short Line { get; set; }
        public short MocompLine { get; set; }
        public int? ParentMoid { get; set; }
        public string PurchaseReqNo { get; set; }
        public string ParentMono { get; set; }
        public int? PurchaseOrdId { get; set; }
        public string PurchaseOrdNo { get; set; }
        public short? PurchaseOrdPos { get; set; }
        public string Item { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaPurchaseReqDetail MaPurchaseReqDetail { get; set; }
    }
}
