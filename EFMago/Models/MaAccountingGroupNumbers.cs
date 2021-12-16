using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaAccountingGroupNumbers
    {
        public string GroupCode { get; set; }
        public short BalanceYear { get; set; }
        public short BalanceMonth { get; set; }
        public int Nature { get; set; }
        public string Suffix { get; set; }
        public DateTime? LastDocDate { get; set; }
        public int? LastDocNo { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
