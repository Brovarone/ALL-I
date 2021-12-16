using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaBrromaneioSummary
    {
        public int RomaneioId { get; set; }
        public double? TheoreticalTotWeight { get; set; }
        public double? TotWeight { get; set; }
        public double? OutboundNetWeight { get; set; }
        public double? InboundNetWeight { get; set; }
        public double? ShipTotCharges { get; set; }
        public short? TotNoOfPacks { get; set; }
        public double? TotVolumM3 { get; set; }
        public int? TotalKm { get; set; }
        public double? ShipOutwardVoyage { get; set; }
        public double? ShipBackWay { get; set; }
        public int? GrossTime { get; set; }
        public int? NetTime { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
