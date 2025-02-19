using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaExtAccTemplate
    {
        public MaExtAccTemplate()
        {
            MaExtAccTemplateDetail = new HashSet<MaExtAccTemplateDetail>();
        }

        public string Template { get; set; }
        public string Description { get; set; }
        public string AccountingTemplate { get; set; }
        public string DocDateFormula { get; set; }
        public string GroupRepeatedLines { get; set; }
        public string SwitchCreditDebit { get; set; }
        public string UseBaseCurrency { get; set; }
        public Guid? Tbguid { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ICollection<MaExtAccTemplateDetail> MaExtAccTemplateDetail { get; set; }
    }
}
