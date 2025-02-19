using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImJobItemsOrder
    {
        public string JobTypeOrder { get; set; }
        public string Job { get; set; }
        public string ParentJob { get; set; }
        public string JobDescription { get; set; }
        public string PrefSupplier { get; set; }
        public double? PrefCost { get; set; }
        public string PrefDiscountFormula { get; set; }
        public double? LastCost { get; set; }
        public double? SecondLastCost { get; set; }
        public double? AverageCost { get; set; }
        public string Item { get; set; }
        public string Producer { get; set; }
        public string CommodityCtg { get; set; }
        public string ProductCtg { get; set; }
        public string ItemDescription { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}
