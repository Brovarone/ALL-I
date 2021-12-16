using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImJobsItems
    {
        public string Job { get; set; }
        public string Item { get; set; }
        public string PrefSupplier { get; set; }
        public double? PrefCost { get; set; }
        public string PrefDiscountFormula { get; set; }
        public double? PrefDiscount1 { get; set; }
        public double? PrefDiscount2 { get; set; }
        public double? LastCost { get; set; }
        public double? SecondLastCost { get; set; }
        public double? AverageCost { get; set; }
        public string Note { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
