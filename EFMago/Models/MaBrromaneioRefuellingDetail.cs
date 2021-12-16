using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaBrromaneioRefuellingDetail
    {
        public int RomaneioId { get; set; }
        public int RomaneioSubId { get; set; }
        public DateTime? RefuellingDate { get; set; }
        public double? RefuellingQty { get; set; }
        public double? RefuellingCost { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
