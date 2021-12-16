using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImJobCorrectionsList
    {
        public string Approver { get; set; }
        public string Job { get; set; }
        public string ParentJob { get; set; }
        public string JobDescription { get; set; }
        public int Jcno { get; set; }
        public DateTime? CreationDate { get; set; }
        public string TypeCorrection { get; set; }
        public string Component { get; set; }
        public string ItemDescription { get; set; }
        public string BaseUoM { get; set; }
        public double? QtyJob { get; set; }
        public double? QtyCorrected { get; set; }
        public double? QtyTot { get; set; }
        public double? QtyToCorrect { get; set; }
        public double? Cost { get; set; }
        public string DiscountFormula { get; set; }
        public double? TotCostAmount { get; set; }
        public int? Jcid { get; set; }
        public int? Line { get; set; }
        public string NewItem { get; set; }
        public string Customer { get; set; }
        public string JobTypeOrder { get; set; }
    }
}
