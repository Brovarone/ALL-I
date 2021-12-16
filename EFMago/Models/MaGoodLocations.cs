using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaGoodLocations
    {
        public string Location { get; set; }
        public string Disabled { get; set; }
        public string Description { get; set; }
        public string Coordinate1 { get; set; }
        public string Coordinate2 { get; set; }
        public string Coordinate3 { get; set; }
        public string Coordinate4 { get; set; }
        public string Coordinate5 { get; set; }
        public string Coordinate6 { get; set; }
        public string Coordinate7 { get; set; }
        public string Coordinate8 { get; set; }
        public string Coordinate9 { get; set; }
        public string Coordinate10 { get; set; }
        public Guid? Tbguid { get; set; }
        public string Storage { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
