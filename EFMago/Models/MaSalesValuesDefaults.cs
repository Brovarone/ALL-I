﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaSalesValuesDefaults
    {
        public int PurchaseValuesDefaultsId { get; set; }
        public short Priority { get; set; }
        public int? CodeType { get; set; }
        public int? DiscountType { get; set; }
        public string Notes { get; set; }
        public string NotPrompt { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
