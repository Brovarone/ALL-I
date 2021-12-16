using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaPyblsRcvblsParametersAging
    {
        public int PyblsRcvblsParametersId { get; set; }
        public int? PyblsPeriod1 { get; set; }
        public int? PyblsPeriod2 { get; set; }
        public int? PyblsPeriod3 { get; set; }
        public int? PyblsPeriod4 { get; set; }
        public int? PyblsPeriod5 { get; set; }
        public int? RcvblsPeriod1 { get; set; }
        public int? RcvblsPeriod2 { get; set; }
        public int? RcvblsPeriod3 { get; set; }
        public int? RcvblsPeriod4 { get; set; }
        public int? RcvblsPeriod5 { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
