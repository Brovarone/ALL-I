using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaTravelAgencyTax
    {
        public short BalanceYear { get; set; }
        public short BalanceMonth { get; set; }
        public double? PeriodCost { get; set; }
        public double? PeriodRevenue { get; set; }
        public double? ActualPeriodCreditCost { get; set; }
        public Guid? Tbguid { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
