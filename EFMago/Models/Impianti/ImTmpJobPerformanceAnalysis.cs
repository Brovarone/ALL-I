using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImTmpJobPerformanceAnalysis
    {
        public string UserName { get; set; }
        public string ComputerName { get; set; }
        public string DocumentName { get; set; }
        public string Job { get; set; }
        public short ReportPosition { get; set; }
        public string ParentJob { get; set; }
        public int? JobLineId { get; set; }
        public int? ComponentType { get; set; }
        public string Component { get; set; }
        public string Description { get; set; }
        public string UoM { get; set; }
        public double? ExtectedQty { get; set; }
        public double? ActualQty { get; set; }
        public double? ExpectedCost { get; set; }
        public double? ActualCost { get; set; }
        public int? ActualTime { get; set; }
        public int? ExpectedTime { get; set; }
        public int? ProgressConfirmMode { get; set; }
        public double? Wprqty { get; set; }
        public double? WprprogressPerc { get; set; }
        public double? WprtaxableAmount { get; set; }
        public double? DistributedCharges { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
