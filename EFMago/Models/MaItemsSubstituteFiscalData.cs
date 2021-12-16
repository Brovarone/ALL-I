using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaItemsSubstituteFiscalData
    {
        public string Item { get; set; }
        public string Substitute { get; set; }
        public double? ItemQty { get; set; }
        public double? SubstituteQty { get; set; }
        public string Notes { get; set; }
        public short? FiscalYear { get; set; }
        public double? FinalOnHand { get; set; }
        public double? BookInv { get; set; }
        public short? FiscalPeriod { get; set; }
    }
}
