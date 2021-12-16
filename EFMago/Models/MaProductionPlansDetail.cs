using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaProductionPlansDetail
    {
        public short Line { get; set; }
        public string Bom { get; set; }
        public double? ProductionQty { get; set; }
        public short? Bomlevel { get; set; }
        public string UseDefaultValue { get; set; }
        public int? InventoryValueCriteria { get; set; }
        public string Lot { get; set; }
        public string Notes { get; set; }
        public int ProductionPlanId { get; set; }
        public string Job { get; set; }
        public string CostCenter { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }
        public string SaleOrdNo { get; set; }
        public short? Position { get; set; }
        public int? SaleOrdId { get; set; }
        public string Variant { get; set; }
        public string Customer { get; set; }
        public double? SaleOrdQty { get; set; }
        public double? ReleasedQty { get; set; }
        public int? PlanStatus { get; set; }
        public DateTime? RunDate { get; set; }
        public string UoM { get; set; }
        public string SaleOrdUoM { get; set; }
        public int? InvEntryId { get; set; }
        public short? InvEntryLine { get; set; }
        public int? InvEntryIdComp { get; set; }
        public string Drawing { get; set; }
        public string GroupSf { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaProductionPlans ProductionPlan { get; set; }
    }
}
