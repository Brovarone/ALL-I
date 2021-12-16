using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaItemsAnalysisParameters
    {
        public string Item { get; set; }
        public short Line { get; set; }
        public string Parameter { get; set; }
        public string UoM { get; set; }
        public string AnalysisMethod { get; set; }
        public short? AnalysisArea { get; set; }
        public string UpperBound { get; set; }
        public string LowerBound { get; set; }
        public string DetectableBound { get; set; }
        public double? ExpectedNumResult { get; set; }
        public string ExpectedResult { get; set; }
        public string ToBePrinted { get; set; }
        public double? Revision { get; set; }
        public string Disabled { get; set; }
        public DateTime? DisabledDate { get; set; }
        public string Notes { get; set; }
        public DateTime? InsertionDate { get; set; }
        public string Customer { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
