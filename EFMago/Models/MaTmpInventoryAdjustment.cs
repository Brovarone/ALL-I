using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaTmpInventoryAdjustment
    {
        public int Line { get; set; }
        public string Item { get; set; }
        public string Storage { get; set; }
        public int? SpecificatorType { get; set; }
        public string Specificator { get; set; }
        public string Description { get; set; }
        public string BaseUoM { get; set; }
        public string Lot { get; set; }
        public string IsSelected { get; set; }
        public double? PreviousQty { get; set; }
        public double? ActualQty { get; set; }
        public double? Difference { get; set; }
        public double? ProposedValue { get; set; }
        public double? PreviousValue { get; set; }
        public double? ActualValue { get; set; }
        public string InUse { get; set; }
        public string Location { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
