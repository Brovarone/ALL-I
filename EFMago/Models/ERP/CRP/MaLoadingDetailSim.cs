using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaLoadingDetailSim
    {
        public string Simulation { get; set; }
        public string Wc { get; set; }
        public DateTime LoadDate { get; set; }
        public short Line { get; set; }
        public int? Moid { get; set; }
        public string Mono { get; set; }
        public short? RtgStep { get; set; }
        public string Alternate { get; set; }
        public short? AltRtgStep { get; set; }
        public short? MonthPos { get; set; }
        public short? DayPos { get; set; }
        public int? LoadHours { get; set; }
        public string Setup { get; set; }
        public Guid? Tbguid { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
