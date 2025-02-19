using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImQualifications
    {
        public string Qualification { get; set; }
        public string Description { get; set; }
        public double? OrdinaryCost { get; set; }
        public double? OvertimeCost { get; set; }
        public double? TravelExpenses { get; set; }
        public double? VacationLeaveCost { get; set; }
        public double? SickLeaveCost { get; set; }
        public double? CustomCost1 { get; set; }
        public double? CustomCost2 { get; set; }
        public double? CustomCost3 { get; set; }
        public double? CustomCost4 { get; set; }
        public string Service { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public string Disabled { get; set; }
    }
}
