﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaBrtaxRateDetail
    {
        public string TaxRateCode { get; set; }
        public int TaxType { get; set; }
        public short Line { get; set; }
        public double? TaxRate { get; set; }
        public double? MinAmount { get; set; }
        public double? MaxAmount { get; set; }
        public DateTime ValidityStartingDate { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
