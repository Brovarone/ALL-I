using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaMohierarchies
    {
        public string Simulation { get; set; }
        public string ParentMo { get; set; }
        public string ChildMo { get; set; }
        public int ParentMoid { get; set; }
        public int ChildMoid { get; set; }
        public string IsAmo { get; set; }
        public string IsApo { get; set; }
        public int ChildPurchaseReqId { get; set; }
        public short ChildPurchaseReqLineNumber { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
