using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaWorkCentersBreakdown
    {
        public string Wc { get; set; }
        public DateTime ExpectedStarting { get; set; }
        public DateTime? ExpectedEnding { get; set; }
        public DateTime? StartingTime { get; set; }
        public DateTime? EndingTime { get; set; }
        public string Reason { get; set; }
        public int? ManagerId { get; set; }
        public short? ResourceNo { get; set; }
        public string Notes { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaWorkCenters WcNavigation { get; set; }
    }
}
