using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaIbcagingPeriods
    {
        public string Configuration { get; set; }
        public short Line { get; set; }
        public int CustSuppType { get; set; }
        public int AgingPeriodsType { get; set; }
        public int? AgingPeriod { get; set; }
        public string AgingPeriodDescription { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
