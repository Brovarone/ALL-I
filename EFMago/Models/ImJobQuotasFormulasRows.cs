using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImJobQuotasFormulasRows
    {
        public int FormulaId { get; set; }
        public short Line { get; set; }
        public string DescriptionCode { get; set; }
        public string Description { get; set; }
        public string Formula { get; set; }
        public double? Result { get; set; }
        public string IsSubTotal { get; set; }
        public string ToBeChecked { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ImJobQuotasFormulas FormulaNavigation { get; set; }
    }
}
