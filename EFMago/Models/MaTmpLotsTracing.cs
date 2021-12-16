using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaTmpLotsTracing
    {
        public string UserName { get; set; }
        public string ComputerName { get; set; }
        public string DocumentName { get; set; }
        public short Line { get; set; }
        public string ParentLot { get; set; }
        public string ChildLot { get; set; }
        public string ParentItem { get; set; }
        public string ChildItem { get; set; }
        public double? Qty { get; set; }
        public string ReferenceLot { get; set; }
        public string ReferenceItem { get; set; }
        public int? DocumentId { get; set; }
        public string FromMo { get; set; }
        public short? TmpMocompLine { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
