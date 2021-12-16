using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImPoliciesQualification
    {
        public string Policy { get; set; }
        public string Qualification { get; set; }
        public double? Price { get; set; }
        public double? OvertimePrice { get; set; }
        public double? TravelPrice { get; set; }
        public double? VacationLeavePrice { get; set; }
        public double? SickLeavePrice { get; set; }
        public double? CustomPrice1 { get; set; }
        public double? CustomPrice2 { get; set; }
        public double? CustomPrice3 { get; set; }
        public double? CustomPrice4 { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ImPolicies PolicyNavigation { get; set; }
    }
}
