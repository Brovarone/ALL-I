using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaInspectionOrdersDetail
    {
        public short Line { get; set; }
        public int InspectionOrderId { get; set; }
        public int? SubId { get; set; }
        public string Description { get; set; }
        public string NoPrint { get; set; }
        public string NoRiepOnInspNotes { get; set; }
        public string Item { get; set; }
        public string Supplier { get; set; }
        public string UoM { get; set; }
        public double? Qty { get; set; }
        public double? InspectedQty { get; set; }
        public string InspectionClosed { get; set; }
        public int? BoLsubId { get; set; }
        public int? BoLid { get; set; }
        public short? BoLline { get; set; }
        public int? InspectionNotesSubId { get; set; }
        public int? InspectionNotesId { get; set; }
        public short? InspectionNotesLine { get; set; }
        public string Notes { get; set; }
        public string Lot { get; set; }
        public double? UnitValue { get; set; }
        public double? Discount1 { get; set; }
        public double? Discount2 { get; set; }
        public string DiscountFormula { get; set; }
        public double? DiscountAmount { get; set; }
        public string Location { get; set; }
        public int? Moid { get; set; }
        public short? RtgStep { get; set; }
        public string Alternate { get; set; }
        public short? AltRtgStep { get; set; }
        public double? QtySampleToAnalyze { get; set; }
        public int? CrrefType { get; set; }
        public int? CrrefId { get; set; }
        public int? CrrefSubId { get; set; }
        public string InternalIdNo { get; set; }
        public string ConsignmentPartner { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaInspectionOrders InspectionOrder { get; set; }
    }
}
