using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaProdPlanReplacements
    {
        public string ProductionPlanNo { get; set; }
        public short Line { get; set; }
        public string Component { get; set; }
        public string UoM { get; set; }
        public double? Qty { get; set; }
        public int? SubstType { get; set; }
        public string SubstComp { get; set; }
        public string SubstCompUoM { get; set; }
        public double? SubstCompQty { get; set; }
        public string BaseUoM { get; set; }
        public double? SubstCompSummQty { get; set; }
        public string SubstCompWasteUoM { get; set; }
        public double? SubstCompWasteQty { get; set; }
        public double? SubstCompWasteSummQty { get; set; }
        public int? InventoryValueCriteria { get; set; }
        public Guid? Tbguid { get; set; }
        public string BreakingItem { get; set; }
        public string BreakingVariant { get; set; }
        public string BreakingBom { get; set; }
        public int? ProdPlanLine { get; set; }
        public short Bomlevel { get; set; }
        public string Lot { get; set; }
        public int? SubId { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
