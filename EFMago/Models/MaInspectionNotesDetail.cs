using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaInspectionNotesDetail
    {
        public short Line { get; set; }
        public int InspectionNotesId { get; set; }
        public int? SubId { get; set; }
        public int? LineType { get; set; }
        public string Supplier { get; set; }
        public string Description { get; set; }
        public string NoPrint { get; set; }
        public string Item { get; set; }
        public string UoM { get; set; }
        public double? Qty { get; set; }
        public int? BoLsubId { get; set; }
        public int? BoLid { get; set; }
        public short? BoLline { get; set; }
        public int? InspectionOrderSubId { get; set; }
        public int? InspectionOrderId { get; set; }
        public short? InspectionOrderLine { get; set; }
        public string Notes { get; set; }
        public string Lot { get; set; }
        public string NonConformityReason { get; set; }
        public double? UnitValue { get; set; }
        public double? Discount1 { get; set; }
        public double? Discount2 { get; set; }
        public string DiscountFormula { get; set; }
        public double? DiscountAmount { get; set; }
        public string Location { get; set; }
        public double? QtyConforming { get; set; }
        public double? QtyToBeReturned { get; set; }
        public double? QtyScrap { get; set; }
        public double? QtySampleToAnalyze { get; set; }
        public string EfficiencyValuation { get; set; }
        public string CorrectiveAction { get; set; }
        public string Togenerated { get; set; }
        public int? AnalysisStatus { get; set; }
        public int? CrrefType { get; set; }
        public int? CrrefId { get; set; }
        public int? CrrefSubId { get; set; }
        public string InternalIdNo { get; set; }
        public string ConsignmentPartner { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaInspectionNotes InspectionNotes { get; set; }
    }
}
