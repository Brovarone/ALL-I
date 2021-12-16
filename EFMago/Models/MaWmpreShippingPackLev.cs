using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaWmpreShippingPackLev
    {
        public int PackingLine { get; set; }
        public int PreShippingId { get; set; }
        public int PreShippingSubId { get; set; }
        public string Sunumber { get; set; }
        public string SunumberChild { get; set; }
        public string Lot { get; set; }
        public string InternalIdNo { get; set; }
        public short? Lev { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
