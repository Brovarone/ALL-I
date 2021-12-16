using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImTmpComponentsListsTree
    {
        public string UserName { get; set; }
        public string ComputerName { get; set; }
        public string DocumentName { get; set; }
        public int TreeType { get; set; }
        public int ReportPosition { get; set; }
        public int DocId { get; set; }
        public string DocNo { get; set; }
        public short DocSection { get; set; }
        public int DocLineId { get; set; }
        public string ComponentsList { get; set; }
        public short? Level { get; set; }
        public int? ComponentType { get; set; }
        public string Component { get; set; }
        public string Description { get; set; }
        public string UoM { get; set; }
        public double? Quantity { get; set; }
        public double? UnitValue { get; set; }
        public int? UnitTime { get; set; }
        public int? TotalTime { get; set; }
        public int? CostingType { get; set; }
        public double? GoodsUnitCost { get; set; }
        public double? GoodsTotalCost { get; set; }
        public double? GoodsMarkup { get; set; }
        public double? GoodsValue { get; set; }
        public double? LabourHourlyRate { get; set; }
        public double? LabourHourlyRateMarkup { get; set; }
        public double? LabourValue { get; set; }
        public double? LabourUnitCost { get; set; }
        public double? AccessoriesPerc { get; set; }
        public double? AccessoriesValue { get; set; }
        public double? CostWithAccessories { get; set; }
        public short? Position { get; set; }
        public string DiscountFormula { get; set; }
        public double? Discount1 { get; set; }
        public double? Discount2 { get; set; }
        public double? DiscountAmount { get; set; }
        public double? Performance { get; set; }
        public double? TaxableAmount { get; set; }
        public string FitCostFormula { get; set; }
        public double? FitCostPerc1 { get; set; }
        public double? FitCostPerc2 { get; set; }
        public double? FitCost { get; set; }
        public double? ExpensesAmount { get; set; }
        public double? ExpensesIncidence { get; set; }
        public string MarkupFormula { get; set; }
        public double? MarkupPerc1 { get; set; }
        public double? MarkupPerc2 { get; set; }
        public double? MarkupValue { get; set; }
        public double? BaseCost { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
