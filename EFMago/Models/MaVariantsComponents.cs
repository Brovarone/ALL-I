using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaVariantsComponents
    {
        public string Item { get; set; }
        public string Variant { get; set; }
        public short Line { get; set; }
        public string Bom { get; set; }
        public int? BomcomponentsSubId { get; set; }
        public string Component { get; set; }
        public string ComponentVariant { get; set; }
        public int? ComponentType { get; set; }
        public string Description { get; set; }
        public string UoM { get; set; }
        public double? Qty { get; set; }
        public string FixedComponent { get; set; }
        public double? ScrapQty { get; set; }
        public string ScrapUm { get; set; }
        public string Notes { get; set; }
        public DateTime? ValidityStartingDate { get; set; }
        public DateTime? ValidityEndingDate { get; set; }
        public int? SubId { get; set; }
        public string Formula { get; set; }
        public int? SubstType { get; set; }
        public string ToExplode { get; set; }
        public short? DnrtgStep { get; set; }
        public string Drawing { get; set; }
        public string FixedQty { get; set; }
        public string Valorize { get; set; }
        public string SetFixedQtyOnMo { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaVariants MaVariants { get; set; }
    }
}
