using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImClcomponents
    {
        public string ComponentsList { get; set; }
        public short Line { get; set; }
        public int? ComponentType { get; set; }
        public string Component { get; set; }
        public string Description { get; set; }
        public string BaseUoM { get; set; }
        public double? Quantity { get; set; }
        public int? CostingType { get; set; }
        public double? UnitCost { get; set; }
        public int? UnitTime { get; set; }
        public string UpdateCost { get; set; }
        public int? TotalTime { get; set; }
        public double? GoodsCostTotalAmount { get; set; }
        public double? AccessoriesCostPerc { get; set; }
        public double? AccessoriesCostValue { get; set; }
        public double? CostIncludingAccessories { get; set; }
        public string WorkingStep { get; set; }
        public string Note { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public int? IncidenceType { get; set; }
        public double? ClbaseCost { get; set; }
        public int? ClunitTime { get; set; }
        public double? FixedBaseCost { get; set; }
        public int? FixedUnitTime { get; set; }

        public virtual ImComponentsLists ComponentsListNavigation { get; set; }
    }
}
