using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImJobQuotasDetailsVcl
    {
        public int JobQuotationId { get; set; }
        public short JobQuotationSection { get; set; }
        public short JobQuotationLine { get; set; }
        public short Line { get; set; }
        public short? ClparentLine { get; set; }
        public short? Clline { get; set; }
        public short? Clid { get; set; }
        public int? ComponentType { get; set; }
        public string Component { get; set; }
        public string Description { get; set; }
        public string BaseUoM { get; set; }
        public double? Quantity { get; set; }
        public int? CostingType { get; set; }
        public double? UnitCost { get; set; }
        public int? UnitTime { get; set; }
        public int? TotalTime { get; set; }
        public double? LabourCostTotalAmount { get; set; }
        public double? GoodsCostTotalAmount { get; set; }
        public double? LabourUnitCost { get; set; }
        public double? Cost { get; set; }
        public string FitCostFormula { get; set; }
        public double? FitCostPerc1 { get; set; }
        public double? FitCostPerc2 { get; set; }
        public double? AccessoriesCostPerc { get; set; }
        public double? AccessoriesCostValue { get; set; }
        public double? FitCost { get; set; }
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
        public double? AdditionalQty1 { get; set; }
        public double? AdditionalQty2 { get; set; }
        public double? AdditionalQty3 { get; set; }
        public double? AdditionalQty4 { get; set; }
        public string UnitValueIsCalculated { get; set; }
        public string WorkingStep { get; set; }
        public string Note { get; set; }
        public int? SubcontractQuotaId { get; set; }
        public string SubcontractSupplier { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public int? IncidenceType { get; set; }
        public int? ClunitTime { get; set; }
        public int? FixedUnitTime { get; set; }
        public double? Clcost { get; set; }
        public double? FixedCost { get; set; }
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
