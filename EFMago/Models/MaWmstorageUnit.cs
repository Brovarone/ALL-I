using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaWmstorageUnit
    {
        public string Sunumber { get; set; }
        public string Sutcode { get; set; }
        public double? GrossWeight { get; set; }
        public string FixedGrossVolume { get; set; }
        public double? GrossVolume { get; set; }
        public double? MaximumWeight { get; set; }
        public double? MaximumVolume { get; set; }
        public string Dimensions { get; set; }
        public string UsedInWarehouse { get; set; }
        public string UsedInPreShipping { get; set; }
        public string BarcodeSegment { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
