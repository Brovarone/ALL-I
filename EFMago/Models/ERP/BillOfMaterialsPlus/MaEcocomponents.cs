using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaEcocomponents
    {
        public int Ecoid { get; set; }
        public short Ecoline { get; set; }
        public int? Ecostatus { get; set; }
        public int? Ecoaction { get; set; }
        public int? EcosubId { get; set; }
        public DateTime? EcoconfirmationDate { get; set; }
        public int? VariationType { get; set; }
        public string Bom { get; set; }
        public short? Line { get; set; }
        public string Component { get; set; }
        public int? ComponentType { get; set; }
        public string Description { get; set; }
        public string UoM { get; set; }
        public double? Qty { get; set; }
        public double? PercQty { get; set; }
        public string FixedComponent { get; set; }
        public double? WasteQty { get; set; }
        public string WasteUoM { get; set; }
        public string Notes { get; set; }
        public string Variant { get; set; }
        public DateTime? ValidityStartingDate { get; set; }
        public DateTime? ValidityEndingDate { get; set; }
        public int? SubId { get; set; }
        public string TechnicalData { get; set; }
        public short? ExternalLineReference { get; set; }
        public string ItemType { get; set; }
        public string StructureCode { get; set; }
        public string ToExplode { get; set; }
        public string Configurable { get; set; }
        public string QuestionNo { get; set; }
        public double? WastePerc { get; set; }
        public short? DnrtgStep { get; set; }
        public string NotPostable { get; set; }
        public string Waste { get; set; }
        public int? OperationSubId { get; set; }
        public string Drawing { get; set; }
        public string IsKanban { get; set; }
        public string FixedQty { get; set; }
        public string OnVariant { get; set; }
        public string Bomvariant { get; set; }
        public string Ecorevision { get; set; }
        public string Valorize { get; set; }
        public string SetFixedQtyOnMo { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaEco Eco { get; set; }
    }
}
