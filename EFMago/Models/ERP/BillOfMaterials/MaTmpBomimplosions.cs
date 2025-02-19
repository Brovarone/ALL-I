using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaTmpBomimplosions
    {
        public string UserName { get; set; }
        public string Computer { get; set; }
        public string Document { get; set; }
        public int Line { get; set; }
        public string Component { get; set; }
        public string RefComponent { get; set; }
        public string Description { get; set; }
        public int? ComponentType { get; set; }
        public short? Bomlevel { get; set; }
        public string UoM { get; set; }
        public double? Qty { get; set; }
        public string BaseUoM { get; set; }
        public double? BaseUoMqty { get; set; }
        public short? MaxNoOfLevels { get; set; }
        public string Variant { get; set; }
        public string OriginatorComponent { get; set; }
        public DateTime? ValidityStartingDate { get; set; }
        public DateTime? ValidityEndingDate { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
