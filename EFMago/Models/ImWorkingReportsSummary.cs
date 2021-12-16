using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImWorkingReportsSummary
    {
        public int WorkingReportId { get; set; }
        public int? OrdinaryTotalTime { get; set; }
        public int? OvertimeTotalTime { get; set; }
        public int? VacationLeaveTotalTime { get; set; }
        public int? SickLeaveTotalTime { get; set; }
        public int? TravelTotalTime { get; set; }
        public double? WorkingReportTotalAmount { get; set; }
        public int? WorkingReportTotalTime { get; set; }
        public int? CustomHours1TotalTime { get; set; }
        public int? CustomHours2TotalTime { get; set; }
        public int? CustomHours3TotalTime { get; set; }
        public int? CustomHours4TotalTime { get; set; }
        public string Note { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ImWorkingReports WorkingReport { get; set; }
    }
}
