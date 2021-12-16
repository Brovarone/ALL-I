using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaEcorouting
    {
        public int Ecoid { get; set; }
        public short Ecoline { get; set; }
        public int? Ecostatus { get; set; }
        public int? Ecoaction { get; set; }
        public DateTime? EcoconfirmationDate { get; set; }
        public int? VariationType { get; set; }
        public string Bom { get; set; }
        public short? RtgStep { get; set; }
        public string Alternate { get; set; }
        public short? AltRtgStep { get; set; }
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
        public string Supplier { get; set; }
        public double? Qty { get; set; }
        public string TotalTime { get; set; }
        public string IsWc { get; set; }
        public string OnVariant { get; set; }
        public string Bomvariant { get; set; }
        public string Ecorevision { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaEco Eco { get; set; }
    }
}
