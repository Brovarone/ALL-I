﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaWmsutpackaging
    {
        public string Sutcode { get; set; }
        public short Line { get; set; }
        public string Item { get; set; }
        public double? Qty { get; set; }
        public string UnitOfMeasure { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaWmstorageUnitType SutcodeNavigation { get; set; }
    }
}