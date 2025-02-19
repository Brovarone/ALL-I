using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImJobCorrectionsDetails
    {
        public int Jcid { get; set; }
        public string Job { get; set; }
        public int Jcno { get; set; }
        public int Line { get; set; }
        public string NewItem { get; set; }
        public string TypeCorrection { get; set; }
        public int? ComponentType { get; set; }
        public string Component { get; set; }
        public string BaseUoM { get; set; }
        public double? QtyJob { get; set; }
        public double? QtyCorrected { get; set; }
        public double? QtyToCorrect { get; set; }
        public double? Cost { get; set; }
        public double? Discount1 { get; set; }
        public double? Discount2 { get; set; }
        public string DiscountFormula { get; set; }
        public double? DiscountAmount { get; set; }
        public double? TotCostAmount { get; set; }
        public string WorkingStep { get; set; }
        public string Note { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ImJobCorrections Jc { get; set; }
    }
}
