using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaPriparameters
    {
        public int ParameterId { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public DateTime? LastImportDate { get; set; }
        public string CompanyCode { get; set; }
        public string GroupByReason { get; set; }
        public string GroupByElementType { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
