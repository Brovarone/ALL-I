﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaItemsFifo
    {
        public string Item { get; set; }
        public short FiscalYear { get; set; }
        public double? FinalBookInv { get; set; }
        public double? FinalBookInvValue { get; set; }
        public double? PurchasesQty { get; set; }
        public double? PurchasesValue { get; set; }
        public string Notes { get; set; }
        public double? ProducedQty { get; set; }
        public double? ProducedValue { get; set; }
        public string RevaluationDone { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaItems ItemNavigation { get; set; }
    }
}
