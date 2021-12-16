using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImEmployeesAnnual
    {
        public short FiscalYear { get; set; }
        public string Employee { get; set; }
        public short Month { get; set; }
        public int? Ordinary { get; set; }
        public int? Overtime { get; set; }
        public int? Travel { get; set; }
        public int? VacationLeave { get; set; }
        public int? SickLeave { get; set; }
        public double? MonthlyCost { get; set; }
        public string Consolidated { get; set; }
        public int? CustomHours1 { get; set; }
        public int? CustomHours2 { get; set; }
        public int? CustomHours3 { get; set; }
        public int? CustomHours4 { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ImEmployees EmployeeNavigation { get; set; }
    }
}
