using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaReportMulticopies
    {
        public MaReportMulticopies()
        {
            MaReportMulticopiesDetail = new HashSet<MaReportMulticopiesDetail>();
        }

        public string Namespace { get; set; }
        public short? Copies { get; set; }
        public short? ReprintCopies { get; set; }
        public string OnlyOneOriginal { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ICollection<MaReportMulticopiesDetail> MaReportMulticopiesDetail { get; set; }
    }
}
