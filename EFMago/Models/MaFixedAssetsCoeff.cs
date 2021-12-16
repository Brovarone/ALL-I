using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaFixedAssetsCoeff
    {
        public int CodeType { get; set; }
        public string FixedAsset { get; set; }
        public short Line { get; set; }
        public short? FromPeriod { get; set; }
        public short? ToPeriod { get; set; }
        public double? RegrCoeff { get; set; }
        public double? Perc { get; set; }
        public double? Activity { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
