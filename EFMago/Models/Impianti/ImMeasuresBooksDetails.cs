using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImMeasuresBooksDetails
    {
        public int MeasuresBookId { get; set; }
        public int Line { get; set; }
        public int? JobLineId { get; set; }
        public string UoM { get; set; }
        public double? InstalledQty { get; set; }
        public string Job { get; set; }
        public string ParentJob { get; set; }
        public int? ComponentType { get; set; }
        public string Component { get; set; }
        public string Description { get; set; }
        public string Specification { get; set; }
        public string SpecificationItem { get; set; }
        public double? SalePrice { get; set; }
        public string ShortDescription { get; set; }
        public double? JobQty { get; set; }
        public double? ProgressValue { get; set; }
        public double? JobLineValue { get; set; }
        public DateTime? MeasurementDate { get; set; }
        public short? Section { get; set; }
        public double? ProgressPerc { get; set; }
        public double? DetailedQty { get; set; }
        public double? AdditionalQty1 { get; set; }
        public double? AdditionalQty2 { get; set; }
        public double? AdditionalQty3 { get; set; }
        public double? AdditionalQty4 { get; set; }
        public string TreeData { get; set; }
        public string Formula { get; set; }
        public int? OriginType { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ImMeasuresBooks MeasuresBook { get; set; }
    }
}
