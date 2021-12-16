using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaOpeningClosingDefaults
    {
        public string ProfitLoss { get; set; }
        public string Profit { get; set; }
        public string LastYearProfit { get; set; }
        public string Loss { get; set; }
        public string LastYearLoss { get; set; }
        public string OpeningBalance { get; set; }
        public string ClosingBalance { get; set; }
        public string PlconversionDifference { get; set; }
        public string AlconversionDifferences { get; set; }
        public string TemporaryPlamount { get; set; }
        public int OpeningClosingDefaultsId { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
