using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaItemsLocationsMonthly
    {
        public short FiscalYear { get; set; }
        public string Item { get; set; }
        public string Location { get; set; }
        public string Lot { get; set; }
        public short BalanceYear { get; set; }
        public int Balance { get; set; }
        public short BalanceMonth { get; set; }
        public double? Qty { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
