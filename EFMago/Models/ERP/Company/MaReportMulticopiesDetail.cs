using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaReportMulticopiesDetail
    {
        public string Namespace { get; set; }
        public short CopyNo { get; set; }
        public string PrintDescription { get; set; }
        public string ReprintDescription { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaReportMulticopies NamespaceNavigation { get; set; }
    }
}
