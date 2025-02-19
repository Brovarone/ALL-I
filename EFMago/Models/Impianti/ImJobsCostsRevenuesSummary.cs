using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImJobsCostsRevenuesSummary
    {
        public string Job { get; set; }
        public int PeriodMonth { get; set; }
        public int PeriodYear { get; set; }
        public int DocumentType { get; set; }
        public int ComponentType { get; set; }
        public string WorkingStep { get; set; }
        public double? TotalCosts { get; set; }
        public double? TotalRevenues { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
