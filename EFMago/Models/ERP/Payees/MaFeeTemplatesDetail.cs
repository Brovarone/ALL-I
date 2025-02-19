using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaFeeTemplatesDetail
    {
        public string Template { get; set; }
        public short Line { get; set; }
        public double? Amount { get; set; }
        public string Tax { get; set; }
        public string WithholdingTax { get; set; }
        public string Inps { get; set; }
        public string Enasarco { get; set; }
        public string IsAnAdvanceExpense { get; set; }
        public string Description { get; set; }
        public string WithholdingTaxExcluded { get; set; }
        public string Cpa { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaFeeTemplates TemplateNavigation { get; set; }
    }
}
