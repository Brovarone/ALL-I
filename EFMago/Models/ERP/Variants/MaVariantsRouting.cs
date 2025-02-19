using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaVariantsRouting
    {
        public string Item { get; set; }
        public string Variant { get; set; }
        public int? BomroutingSubId { get; set; }
        public short RtgStep { get; set; }
        public string Alternate { get; set; }
        public short AltRtgStep { get; set; }
        public string Bom { get; set; }
        public string Operation { get; set; }
        public double? ProcessingAttendancePerc { get; set; }
        public double? SetupAttendancePerc { get; set; }
        public string Notes { get; set; }
        public string Wc { get; set; }
        public int? ProcessingTime { get; set; }
        public int? ProcessingWorkingTime { get; set; }
        public int? SetupTime { get; set; }
        public int? SetupWorkingTime { get; set; }
        public int? LineTypeInDn { get; set; }
        public short? NoOfProcessingWorkers { get; set; }
        public short? NoOfSetupWorkers { get; set; }
        public int? QueueTime { get; set; }
        public int? SubId { get; set; }
        public int SubstType { get; set; }
        public double? Qty { get; set; }
        public string TotalTime { get; set; }
        public string IsWc { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaVariants MaVariants { get; set; }
    }
}
