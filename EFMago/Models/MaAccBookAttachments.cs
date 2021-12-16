using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaAccBookAttachments
    {
        public short FiscalYear { get; set; }
        public string AttachCode { get; set; }
        public string Description { get; set; }
        public short? PrintOrder { get; set; }
        public string IsAreport { get; set; }
        public string ReportNamespace { get; set; }
        public string TableTitle { get; set; }
        public string PrintTotal { get; set; }
        public string PrintOnlyColDescri { get; set; }
        public string Disabled { get; set; }
        public string PrintAccountColumns { get; set; }
        public string PrintSignColumn { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
