using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImBudgetIndexDetails
    {
        public short IndexId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Disabled { get; set; }
        public double? Period1 { get; set; }
        public double? Period2 { get; set; }
        public double? Period3 { get; set; }
        public double? Period4 { get; set; }
        public double? Period5 { get; set; }
        public double? Period6 { get; set; }
        public double? Period7 { get; set; }
        public double? Period8 { get; set; }
        public double? Period9 { get; set; }
        public double? Period10 { get; set; }
        public double? Period11 { get; set; }
        public double? Period12 { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ImBudgetIndex Index { get; set; }
    }
}
