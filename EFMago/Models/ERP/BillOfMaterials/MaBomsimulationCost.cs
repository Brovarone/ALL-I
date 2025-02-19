using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaBomsimulationCost
    {
        public string SimulationBomcost { get; set; }
        public string LevelSel { get; set; }
        public short? NrLevels { get; set; }
        public string OnlyValidComponentsCosting { get; set; }
        public DateTime? SimulationDate { get; set; }
        public string Bomsel { get; set; }
        public string BomselNone { get; set; }
        public string FromBom { get; set; }
        public string ToBom { get; set; }
        public string NotExplodeVariant { get; set; }
        public string VariantSel { get; set; }
        public string ItemVariantSel { get; set; }
        public string FromItem { get; set; }
        public string ToItem { get; set; }
        public string VariantItemSel { get; set; }
        public string FromVariant { get; set; }
        public string ToVariant { get; set; }
        public string ProdParamValueType { get; set; }
        public string DefaultComponentValueType { get; set; }
        public string SpecificValueType { get; set; }
        public int? ValueType { get; set; }
        public double? RoundingValue { get; set; }
        public string CompRounding { get; set; }
        public string PreferredSel { get; set; }
        public string Alternate { get; set; }
        public string AlsoSemifinished { get; set; }
        public string BanksBomsGhost { get; set; }
        public string ExplodeAll { get; set; }
        public string EnableLot { get; set; }
        public double? QuantityToCost { get; set; }
        public string AlsoDisabledBom { get; set; }
        public string ShowResultGrid { get; set; }
        public DateTime? UpdateCostDate { get; set; }
        public string ProdCostMemo { get; set; }
        public string UpdateLoads { get; set; }
        public string StdCostMemo { get; set; }
        public string UseEco { get; set; }
        public DateTime? Ecodate { get; set; }
        public string Ecorevision { get; set; }
        public string Recalculate { get; set; }
        public string OnlyExactMatch { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
