using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImJobsComponents
    {
        public string Job { get; set; }
        public short Line { get; set; }
        public short JobSection { get; set; }
        public short JobLine { get; set; }
        public int? ComponentType { get; set; }
        public string Component { get; set; }
        public string Description { get; set; }
        public string UoM { get; set; }
        public double? Qty { get; set; }
        public int? TotalTime { get; set; }
        public double? TotalCost { get; set; }
        public double? TaxableAmount { get; set; }
        public string WorkingStep { get; set; }
        public string SubcontractService { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
