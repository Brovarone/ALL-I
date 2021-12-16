using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImTmpWprdetails
    {
        public string UserName { get; set; }
        public string ComputerName { get; set; }
        public int WorksProgressReportId { get; set; }
        public short Position { get; set; }
        public string Job { get; set; }
        public int? JobLineId { get; set; }
        public short? Section { get; set; }
        public short? Line { get; set; }
        public int? ComponentType { get; set; }
        public string Component { get; set; }
        public int? ProgressConfirmMode { get; set; }
        public string BaseUoM { get; set; }
        public double? Quantity { get; set; }
        public double? ProgressPerc { get; set; }
        public double? UnitPrice { get; set; }
        public double? TotalPrice { get; set; }
        public string Specification { get; set; }
        public string SpecificationItem { get; set; }
        public string FromWpr { get; set; }
        public string Printing { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
