﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaWmcategoryDetails
    {
        public string Category { get; set; }
        public string Storage { get; set; }
        public string SearchZoneStrategyPutaway { get; set; }
        public string SearchZoneStrategyPicking { get; set; }
        public int? StockReturnStrategy { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
