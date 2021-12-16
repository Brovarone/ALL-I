using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImComplianceDeclEncloseMat
    {
        public int ComplianceDeclarationId { get; set; }
        public short Line { get; set; }
        public string Job { get; set; }
        public string Customer { get; set; }
        public string Item { get; set; }
        public string Description { get; set; }
        public double? Quantity { get; set; }
        public string Producer { get; set; }
        public string ProductCtg { get; set; }
        public string ProductSubCtg { get; set; }
        public string Changed { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ImComplianceDeclaration ComplianceDeclaration { get; set; }
    }
}
