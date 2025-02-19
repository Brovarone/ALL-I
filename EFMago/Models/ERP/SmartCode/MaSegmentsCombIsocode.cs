using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaSegmentsCombIsocode
    {
        public string Segment { get; set; }
        public string Combination { get; set; }
        public string IsocountryCode { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; }
        public string Notes { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
