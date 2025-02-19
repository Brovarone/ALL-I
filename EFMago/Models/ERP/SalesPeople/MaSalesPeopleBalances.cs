using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaSalesPeopleBalances
    {
        public string Salesperson { get; set; }
        public short BalanceYear { get; set; }
        public short BalanceMonth { get; set; }
        public double? Budget { get; set; }
        public double? Turnover { get; set; }
        public double? AcquiredCommission { get; set; }
        public double? AccruedCommission { get; set; }
        public double? EnasarcotaxableAmount { get; set; }
        public string OneFirmOnly { get; set; }
        public double? EnasarcotoPay { get; set; }
        public double? EnasarcotoPaySalesperson { get; set; }
        public double? Enasarcopayed { get; set; }
        public DateTime? EnasarcopaymentDate { get; set; }
        public double? EnasarcotoPayAss { get; set; }
        public double? EnasarcopayedAss { get; set; }
        public double? EnasarcotoPayGrossAmount { get; set; }
        public double? EnasarcotoPayAssSalesperson { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaSalesPeople SalespersonNavigation { get; set; }
    }
}
