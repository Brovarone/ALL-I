using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImSubcontractWprwithholdingTax
    {
        public int SubcontractWprid { get; set; }
        public short Line { get; set; }
        public string WithholdingTax { get; set; }
        public string Description { get; set; }
        public double? WithholdingTaxPerc { get; set; }
        public double? WithholdingTaxAmount { get; set; }
        public int? ManagementWithholding { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ImSubcontractWorksProgressReport SubcontractWpr { get; set; }
    }
}
