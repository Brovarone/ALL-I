using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImJobQuotasDetails
    {
        public int JobQuotationId { get; set; }
        public short Section { get; set; }
        public short Line { get; set; }
        public int? ComponentType { get; set; }
        public string Component { get; set; }
        public string BaseUoM { get; set; }
        public string Description { get; set; }
        public double? Quantity { get; set; }
        public int? UnitTime { get; set; }
        public int? TotalTime { get; set; }
        public string FunctionalCtg { get; set; }
        public string Specification { get; set; }
        public string SpecificationItem { get; set; }
        public string IsAvariableCl { get; set; }
        public string BlockTimeVcl { get; set; }
        public double? GoodsCost { get; set; }
        public double? LabourCost { get; set; }
        public double? ComponentPrice { get; set; }
        public double? QuotedTotalAmount { get; set; }
        public double? GoodsCostTotalAmount { get; set; }
        public double? GoodsMarkupPerc { get; set; }
        public string CanBeUpdated { get; set; }
        public double? HourlyRate { get; set; }
        public short? Position { get; set; }
        public double? ExpensesAmount { get; set; }
        public double? ExpensesIncidence { get; set; }
        public double? GoodsValue { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public double? LabourMarkupPerc { get; set; }
        public double? QuotedPrice { get; set; }
        public double? SpecificationPrice { get; set; }
        public double? Variance { get; set; }
        public double? VariancePerc { get; set; }
        public double? LabourUnitCost { get; set; }
        public double? BaseCost { get; set; }
        public string FitCostFormula { get; set; }
        public double? FitCostPerc1 { get; set; }
        public double? FitCostPerc2 { get; set; }
        public double? AccessoriesCostPerc { get; set; }
        public double? AccessoriesCostValue { get; set; }
        public double? FitCost { get; set; }
        public double? UnitCost { get; set; }
        public double? CostTotalAmount { get; set; }
        public string MarkupFormula { get; set; }
        public double? MarkupPerc1 { get; set; }
        public double? MarkupPerc2 { get; set; }
        public double? MarkupValue { get; set; }
        public double? UnitValue { get; set; }
        public string DiscountFormula { get; set; }
        public double? Discount1 { get; set; }
        public double? Discount2 { get; set; }
        public double? DiscountAmount { get; set; }
        public double? TaxableAmount { get; set; }
        public double? TotalAmount { get; set; }
        public double? Performance { get; set; }
        public string TaxCode { get; set; }
        public double? AdditionalQty1 { get; set; }
        public double? AdditionalQty2 { get; set; }
        public double? AdditionalQty3 { get; set; }
        public double? AdditionalQty4 { get; set; }
        public string UnitValueIsCalculated { get; set; }
        public string MarkupIsOnCharges { get; set; }
        public int? CostingType { get; set; }
        public double? DistributedDiscount { get; set; }
        public double? DiscountedValue { get; set; }
        public string ExternalReference { get; set; }
        public string WorkingStep { get; set; }
        public int? FormulaId { get; set; }
        public string ToBeChecked { get; set; }
        public string NoteVcl { get; set; }
        public int? SubcontractQuotaId { get; set; }
        public string SubcontractSupplier { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public int? ClunitTime { get; set; }
        public int? FixedUnitTime { get; set; }
        public double? ClbaseCost { get; set; }
        public double? FixedBaseCost { get; set; }
        public double? ClaccessoriesCostValue { get; set; }
        public double? FixedAccessoriesCostValue { get; set; }
        public double? ClfitCost { get; set; }
        public double? FixedFitCost { get; set; }
        public double? ClunitCost { get; set; }
        public double? ClunitValue { get; set; }
        public double? FixedUnitValue { get; set; }

        public virtual ImJobQuotations JobQuotation { get; set; }
    }
}
