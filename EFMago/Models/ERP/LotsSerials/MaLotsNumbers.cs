﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaLotsNumbers
    {
        public short BalanceYear { get; set; }
        public DateTime? LastLotDocDate { get; set; }
        public int? LastLotNo { get; set; }
        public int? PrefixFormat { get; set; }
        public string SeparatorCode { get; set; }
        public short? SuffixChars { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
