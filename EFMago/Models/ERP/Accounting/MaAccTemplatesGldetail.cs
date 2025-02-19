using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaAccTemplatesGldetail
    {
        public string Template { get; set; }
        public short Line { get; set; }
        public string AccRsn { get; set; }
        public int? AccountType { get; set; }
        public string CustSupp { get; set; }
        public string Account { get; set; }
        public int? AmountType { get; set; }
        public int? DebitCreditSign { get; set; }
        public double? Amount { get; set; }
        public string Automatic { get; set; }
        public string TaxBalancingCheck { get; set; }
        public string Notes { get; set; }
        public string IgnoreSign { get; set; }
        public short? OffsetGroupNo { get; set; }
        public string AutoBalance { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaAccTemplates TemplateNavigation { get; set; }
    }
}
