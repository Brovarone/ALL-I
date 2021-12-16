using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaLotsTracing
    {
        public string ParentLot { get; set; }
        public string ChildLot { get; set; }
        public string ParentItem { get; set; }
        public string ChildItem { get; set; }
        public string ChildBaseUoM { get; set; }
        public int IdParentMo { get; set; }
        public double? Qty { get; set; }
        public DateTime? PickingDate { get; set; }
        public int IdPlan { get; set; }
        public short? MocompLine { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
