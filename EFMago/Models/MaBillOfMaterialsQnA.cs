using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaBillOfMaterialsQnA
    {
        public string Bom { get; set; }
        public int SubId { get; set; }
        public short Line { get; set; }
        public short? AnswerNo { get; set; }
        public string QuestionNo { get; set; }
        public string Component { get; set; }
        public int? ComponentType { get; set; }
        public string Description { get; set; }
        public string Variant { get; set; }
        public string UoM { get; set; }
        public double? Qty { get; set; }
        public double? ScrapQty { get; set; }
        public string ScrapUm { get; set; }
        public string Notes { get; set; }
        public DateTime? ValidityStartingDate { get; set; }
        public DateTime? ValidityEndingDate { get; set; }
        public string ToExplode { get; set; }
        public string IsAdefault { get; set; }
        public double? WastePerc { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
