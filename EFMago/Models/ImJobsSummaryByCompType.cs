using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImJobsSummaryByCompType
    {
        public string Job { get; set; }
        public int ComponentType { get; set; }
        public double? TotalCost { get; set; }
        public double? TotalMarkupValue { get; set; }
        public double? TotalUnitValue { get; set; }
        public double? DiscountTotalAmount { get; set; }
        public double? TaxableTotalAmount { get; set; }
        public double? PerformanceTotalAmount { get; set; }
        public int? TotalTime { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public double? ExpensesTotalAmount { get; set; }

        public virtual MaJobs JobNavigation { get; set; }
    }
}
