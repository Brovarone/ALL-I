using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaLotsStoragesQtyMonthly
    {
        public short FiscalYear { get; set; }
        public string Item { get; set; }
        public string Lot { get; set; }
        public string Storage { get; set; }
        public string Specificator { get; set; }
        public int SpecificatorType { get; set; }
        public short BalanceYear { get; set; }
        public int Balance { get; set; }
        public short BalanceMonth { get; set; }
        public double? ReceivedQty { get; set; }
        public double? ReceivedValue { get; set; }
        public double? IssuedQty { get; set; }
        public double? IssuedValue { get; set; }
        public double? CurrentQty { get; set; }
        public double? CurrentValue { get; set; }
        public double? BookedQty { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
