using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaChangeRetailDataDetail
    {
        public int ChangeRetailDataId { get; set; }
        public short ChangeRetailDataLine { get; set; }
        public string Item { get; set; }
        public double? Qty { get; set; }
        public double? CurrentPrice { get; set; }
        public double? NewPrice { get; set; }
        public string CurrentTaxCode { get; set; }
        public string NewTaxCode { get; set; }
        public string WithTax { get; set; }
        public string BaseUoM { get; set; }
        public int? CrrefType { get; set; }
        public int? CrrefId { get; set; }
        public short? CrrefLine { get; set; }
        public double? Vatdiff { get; set; }
        public double? TotDiff { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaChangeRetailData ChangeRetailData { get; set; }
    }
}
