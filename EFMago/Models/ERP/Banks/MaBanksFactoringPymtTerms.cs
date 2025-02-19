using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaBanksFactoringPymtTerms
    {
        public string Bank { get; set; }
        public string IsAcompanyBank { get; set; }
        public string Payment { get; set; }
        public string ExternalCode { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaBanks MaBanks { get; set; }
    }
}
