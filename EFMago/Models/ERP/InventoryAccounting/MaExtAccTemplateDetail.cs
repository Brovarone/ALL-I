using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaExtAccTemplateDetail
    {
        public string Template { get; set; }
        public int Line { get; set; }
        public string Repeat { get; set; }
        public string AccountingReason { get; set; }
        public int? LineType { get; set; }
        public string AccountFormula { get; set; }
        public string CustSuppFormula { get; set; }
        public int? DebitCredit { get; set; }
        public string AmountFormula { get; set; }
        public int? AmountType { get; set; }
        public short? OffsetGroupNo { get; set; }
        public short? StorageNo { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaExtAccTemplate TemplateNavigation { get; set; }
    }
}
