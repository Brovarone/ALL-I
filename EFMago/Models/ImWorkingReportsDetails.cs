using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImWorkingReportsDetails
    {
        public int WorkingReportId { get; set; }
        public short Line { get; set; }
        public string Employee { get; set; }
        public string Name { get; set; }
        public int? OrdinaryHours { get; set; }
        public int? OvertimeHours { get; set; }
        public int? TravelHours { get; set; }
        public string Customer { get; set; }
        public int? VacationLeaveHours { get; set; }
        public int? SickLeaveHours { get; set; }
        public int? TotalHours { get; set; }
        public string Job { get; set; }
        public DateTime? WorkingReportDate { get; set; }
        public string WorkingReportNo { get; set; }
        public string Qualification { get; set; }
        public double? EmployeeCost { get; set; }
        public double? OrdinaryCost { get; set; }
        public double? OvertimeCost { get; set; }
        public double? TravelCost { get; set; }
        public double? VacationLeaveCost { get; set; }
        public double? SickLeaveCost { get; set; }
        public double? CustomCost1 { get; set; }
        public double? CustomCost2 { get; set; }
        public double? CustomCost3 { get; set; }
        public double? CustomCost4 { get; set; }
        public double? TotalCustomCost { get; set; }
        public int? CustomHours1 { get; set; }
        public int? CustomHours2 { get; set; }
        public int? CustomHours3 { get; set; }
        public int? CustomHours4 { get; set; }
        public int? TotalCustomHours { get; set; }
        public string Note { get; set; }
        public string IsOnJobEconomicAnalysis { get; set; }
        public int? StartHour { get; set; }
        public int? EndHour { get; set; }
        public string WorkingStep { get; set; }
        public string PostedToAccounting { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public int? CrrefType { get; set; }
        public int? CrrefId { get; set; }
        public short? CrrefLine { get; set; }

        public virtual ImWorkingReports WorkingReport { get; set; }
    }
}
