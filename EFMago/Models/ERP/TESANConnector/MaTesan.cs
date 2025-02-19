using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaTesan
    {
        public int Iddoc { get; set; }
        public int Tsyear { get; set; }
        public string TschargeType { get; set; }
        public string TschargeTypeFlag { get; set; }
        public double? TschargeAmount { get; set; }
        public int? TsoperationType { get; set; }
        public DateTime? TsexportDate { get; set; }
        public DateTime? TsinstallmentDate { get; set; }
        public Guid? Tbguid { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public double TaxPerc { get; set; }
        public string TaxEicode { get; set; }
    }
}
