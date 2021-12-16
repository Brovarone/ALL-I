using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaBrromaneioExpenses
    {
        public int RomaneioId { get; set; }
        public double? StartingCash { get; set; }
        public double? EndingCash { get; set; }
        public double? EstimatedValue { get; set; }
        public double? ActualValue { get; set; }
        public double? Variation { get; set; }
        public double? Tolls { get; set; }
        public double? Meals { get; set; }
        public double? Overnight { get; set; }
        public double? Mainteinance { get; set; }
        public double? TotalRefLiters { get; set; }
        public double? Fuel { get; set; }
        public double? OtherCharges { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
