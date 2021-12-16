using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImSchedulesRequirements
    {
        public int ScheduleId { get; set; }
        public short Line { get; set; }
        public string Job { get; set; }
        public int? JobLineId { get; set; }
        public int? ComponentType { get; set; }
        public string Component { get; set; }
        public string Description { get; set; }
        public string UoM { get; set; }
        public double? Quantity { get; set; }
        public int? Time { get; set; }
        public short? SchedulesDetailsLine { get; set; }
        public string NotOnDn { get; set; }
        public string JobWorkingStep { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ImSchedules Schedule { get; set; }
    }
}
