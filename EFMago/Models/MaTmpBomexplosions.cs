using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaTmpBomexplosions
    {
        public string UserName { get; set; }
        public string Computer { get; set; }
        public string Document { get; set; }
        public int Line { get; set; }
        public string SimulationBomcost { get; set; }
        public string BreakingItem { get; set; }
        public string BreakingVariant { get; set; }
        public string BreakingBom { get; set; }
        public int? ProdPlanLine { get; set; }
        public string Bom { get; set; }
        public string Bomvariant { get; set; }
        public int? CodeType { get; set; }
        public string Component { get; set; }
        public string ComponentVariant { get; set; }
        public short? Bomlevel { get; set; }
        public string ComponentDescription { get; set; }
        public double? Qty { get; set; }
        public string UoM { get; set; }
        public double? SummaryQty { get; set; }
        public string BaseUoM { get; set; }
        public string IsAbom { get; set; }
        public string IsArtgStep { get; set; }
        public int? InventoryValueCriteria { get; set; }
        public string FixedComponent { get; set; }
        public double? Cost { get; set; }
        public double? ScrapQty { get; set; }
        public string ScrapUm { get; set; }
        public double? ScrapQtySummary { get; set; }
        public DateTime? ValidityStartingDate { get; set; }
        public DateTime? ValidityEndingDate { get; set; }
        public int? RtgStepProcessingTime { get; set; }
        public double? PurchaseCost { get; set; }
        public double? InhouseProcessingCost { get; set; }
        public double? OutsourcedProcessingCost { get; set; }
        public double? SetupCost { get; set; }
        public int? RtgStepSetupTime { get; set; }
        public string Configurable { get; set; }
        public string QuestionNo { get; set; }
        public int? SubId { get; set; }
        public string Lot { get; set; }
        public string Job { get; set; }
        public string CostCenter { get; set; }
        public string IsAsf { get; set; }
        public string Waste { get; set; }
        public string TotalTime { get; set; }
        public string Operation { get; set; }
        public string ParentBom { get; set; }
        public int? ParentBomsubId { get; set; }
        public int? SaleOrdId { get; set; }
        public short? SaleOrdPosition { get; set; }
        public string ParentVariant { get; set; }
        public string IsKanban { get; set; }
        public string FixedQty { get; set; }
        public string IsTool { get; set; }
        public string ParentItem { get; set; }
        public string IsFromVariant { get; set; }
        public string Valorize { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
