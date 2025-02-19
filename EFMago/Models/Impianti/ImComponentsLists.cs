using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImComponentsLists
    {
        public ImComponentsLists()
        {
            ImClcomponents = new HashSet<ImClcomponents>();
        }

        public string ComponentsList { get; set; }
        public string Description { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? LastChangeDate { get; set; }
        public double? ReferenceQuantity { get; set; }
        public double? HourlyRate { get; set; }
        public int? UnitTime { get; set; }
        public string BaseUoM { get; set; }
        public string IsUpdated { get; set; }
        public int? ComponentSubListsTotalTime { get; set; }
        public string TimesAndCostsAreBlocked { get; set; }
        public double? AccessoriesCostTotalAmount { get; set; }
        public double? ServicesCostTotalAmount { get; set; }
        public double? ChargesCostTotalAmount { get; set; }
        public double? GoodsCostTotalAmount { get; set; }
        public double? OtherCostTotalAmount { get; set; }
        public double? LabourCostTotalAmount { get; set; }
        public double? ComponentSubListsCost { get; set; }
        public double? GoodsMarkupPerc { get; set; }
        public double? ServicesMarkupPerc { get; set; }
        public double? OtherMarkupPerc { get; set; }
        public double? LabourMarkupPerc { get; set; }
        public double? ChargesMarkupPerc { get; set; }
        public string MarkupIsInDoc { get; set; }
        public double? ComponentCostTotalAmount { get; set; }
        public string Disabled { get; set; }
        public string DisableCreationItem { get; set; }
        public string Note { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public double? FixedComponentCostTotalAmount { get; set; }
        public int? FixedUnitTime { get; set; }

        public virtual ICollection<ImClcomponents> ImClcomponents { get; set; }
    }
}
