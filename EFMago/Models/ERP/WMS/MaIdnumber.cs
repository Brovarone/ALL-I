using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaIdnumber
    {
        public string InternalIdNo { get; set; }
        public string ExternalIdNo { get; set; }
        public string BarcodeSegment { get; set; }
        public string Item { get; set; }
        public string Lot { get; set; }
        public string OutOfStock { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
