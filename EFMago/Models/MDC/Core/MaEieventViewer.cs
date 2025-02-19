using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaEieventViewer
    {
        public int DocCrtype { get; set; }
        public int DocId { get; set; }
        public short Line { get; set; }
        public DateTime? EventDate { get; set; }
        public int? EventType { get; set; }
        public string EventDescription { get; set; }
        public string EventXml { get; set; }
        public string EventString1 { get; set; }
        public string EventString2 { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
