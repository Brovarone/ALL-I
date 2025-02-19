using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImJobsDetailsCategories
    {
        public string Job { get; set; }
        public short Section { get; set; }
        public short Line { get; set; }
        public int? ComponentType { get; set; }
        public string Component { get; set; }
        public string BaseUoM { get; set; }
        public string Description { get; set; }
        public double? Quantity { get; set; }
        public int? UnitTime { get; set; }
        public int? TotalTime { get; set; }
        public string FunctionalCtg { get; set; }
        public int? JobQuotationId { get; set; }
        public short? JobQuotationSection { get; set; }
        public short? JobQuotationLine { get; set; }
        public double? InstalledQty { get; set; }
        public double? AssignedQty { get; set; }
        public string IsOatamb { get; set; }
        public double? Price { get; set; }
        public string ProductCtg { get; set; }
    }
}
