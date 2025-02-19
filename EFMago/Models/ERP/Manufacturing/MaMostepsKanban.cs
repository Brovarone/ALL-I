using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaMostepsKanban
    {
        public int Moid { get; set; }
        public short RtgStep { get; set; }
        public string Alternate { get; set; }
        public short AltRtgStep { get; set; }
        public string Simulation { get; set; }
        public string Mono { get; set; }
        public short ProgRow { get; set; }
        public string Enabled { get; set; }
        public string Bom { get; set; }
        public string Variant { get; set; }
        public string ParentBom { get; set; }
        public string ParentVar { get; set; }
        public string Operation { get; set; }
        public string Wc { get; set; }
        public string IsTotalTime { get; set; }
        public int? ProcessingTime { get; set; }
        public int? SetupTime { get; set; }
        public string Supplier { get; set; }
        public string IsOutsourced { get; set; }
        public double? OutsourcedProcCost { get; set; }
        public double? InHouseProcCost { get; set; }
        public double? SetupCost { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
