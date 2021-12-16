using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaPlanTeamsSim
    {
        public string Simulation { get; set; }
        public string Team { get; set; }
        public string OrderNo { get; set; }
        public short RtgStep { get; set; }
        public string Alternate { get; set; }
        public short AltRtgStep { get; set; }
        public DateTime? SimStartDate { get; set; }
        public DateTime? SimEndDate { get; set; }
        public short? WorkersNo { get; set; }
        public int? ProcessingTime { get; set; }
        public int? SetupTime { get; set; }
        public Guid? Tbguid { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
