using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaTmpMoexplosion
    {
        public string UserName { get; set; }
        public string Computer { get; set; }
        public string Document { get; set; }
        public int Line { get; set; }
        public string Moroot { get; set; }
        public int? RootMoid { get; set; }
        public string Job { get; set; }
        public string SaleOrdNo { get; set; }
        public short? SaleOrdPos { get; set; }
        public string Customer { get; set; }
        public short? Bomlevel { get; set; }
        public string Moparent { get; set; }
        public int? ParentMoid { get; set; }
        public string Mo { get; set; }
        public int? Moid { get; set; }
        public string Bom { get; set; }
        public string Variant { get; set; }
        public string UoM { get; set; }
        public double? Qty { get; set; }
        public double? Incidence { get; set; }
        public string Error { get; set; }
        public short? LineNumber { get; set; }
        public string IsArtgStep { get; set; }
        public short? RtgStep { get; set; }
        public string Alternate { get; set; }
        public short? AltRtgStep { get; set; }
        public string IsAsubcontractingDoc { get; set; }
        public int? SubcontractingDocType { get; set; }
        public int? SubcontractingDocId { get; set; }
        public string CostCenter { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
