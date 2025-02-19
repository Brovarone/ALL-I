using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImTmpWorksProgressSummary
    {
        public string ComputerName { get; set; }
        public string UserName { get; set; }
        public string ParentJob { get; set; }
        public string Job { get; set; }
        public int ComponentType { get; set; }
        public short? Section { get; set; }
        public string SectionDescription { get; set; }
        public short? Line { get; set; }
        public int JobLineId { get; set; }
        public string Component { get; set; }
        public string ComponentDescription { get; set; }
        public string Specification { get; set; }
        public string SpecificationItem { get; set; }
        public string ShortDescription { get; set; }
        public string UoM { get; set; }
        public double? JobQty { get; set; }
        public double? JobValue { get; set; }
        public double? MeasuresBooksQty { get; set; }
        public double? MeasuresBooksPerc { get; set; }
        public double? MeasuresBooksValue { get; set; }
        public double? Wprqty { get; set; }
        public double? Wprperc { get; set; }
        public double? Wprvalue { get; set; }
        public double? NotInMeasuresBooksQty { get; set; }
        public double? NotInMeasuresBooksPerc { get; set; }
        public double? NotInMeasuresBooksValue { get; set; }
        public double? NotInWprqty { get; set; }
        public double? NotInWprperc { get; set; }
        public double? NotInWprvalue { get; set; }
        public double? BalanceQty { get; set; }
        public double? BalancePerc { get; set; }
        public double? BalanceValue { get; set; }
        public double? AdditionalQty1 { get; set; }
        public double? AdditionalQty2 { get; set; }
        public double? AdditionalQty3 { get; set; }
        public double? AdditionalQty4 { get; set; }
        public int? ProgressConfirmMode { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
