using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaWmdefaultCodes
    {
        public int WmdefaultCodesId { get; set; }
        public string GrdelConfInvRsn { get; set; }
        public string GrdelRetInvRsn { get; set; }
        public string GrdelScrapInvRsn { get; set; }
        public string GrdelInspInvRsn { get; set; }
        public string GrconsConfInvRsn { get; set; }
        public string GrconsRetInvRsn { get; set; }
        public string GrconsScrapInvRsn { get; set; }
        public string GrconsInspInvRsn { get; set; }
        public string GrretInvRsn { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
