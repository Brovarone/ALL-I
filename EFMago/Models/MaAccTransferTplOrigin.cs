using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaAccTransferTplOrigin
    {
        public string Template { get; set; }
        public short? Line { get; set; }
        public string Account { get; set; }
        public int BalanceSide { get; set; }
        public int BalanceType { get; set; }
        public string IgnoreDifferentSign { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
