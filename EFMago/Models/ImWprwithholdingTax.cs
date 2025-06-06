﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImWprwithholdingTax
    {
        public int Wprid { get; set; }
        public int Line { get; set; }
        public string WithholdingTax { get; set; }
        public double? Amount { get; set; }
        public string OnTaxableAmount { get; set; }
        public double? Percentage { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ImWorksProgressReport Wpr { get; set; }
    }
}
