using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaConsolidTemplatesDetail
    {
        public string Template { get; set; }
        public short Line { get; set; }
        public string ExternalCode { get; set; }
        public string Description { get; set; }
        public string AccountGroup { get; set; }
        public int? DebitCredit { get; set; }
        public string IgnoreDifferentBalanceSign { get; set; }
        public double? IncidencePerc { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaConsolidTemplates TemplateNavigation { get; set; }
    }
}
