using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaTmpIntra
    {
        public Guid SessionGuid { get; set; }
        public int Line { get; set; }
        public string Type { get; set; }
        public string BalanceYear { get; set; }
        public string MonthQuarter { get; set; }
        public string Period { get; set; }
        public string TaxId { get; set; }
        public string Contents { get; set; }
        public string ParticularCase { get; set; }
        public string DelegateTaxId { get; set; }
        public int? DetailsSection1 { get; set; }
        public double? TotalSection1 { get; set; }
        public int? DetailsSection2 { get; set; }
        public double? TotalSection2 { get; set; }
        public int? DetailsSection3 { get; set; }
        public double? TotalSection3 { get; set; }
        public int? DetailsSection4 { get; set; }
        public double? TotalSection4 { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
