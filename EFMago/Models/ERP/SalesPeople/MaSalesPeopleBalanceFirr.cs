using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaSalesPeopleBalanceFirr
    {
        public string Salesperson { get; set; }
        public short BalanceYear { get; set; }
        public int CodeType { get; set; }
        public double? Base { get; set; }
        public double? AccruedAmount { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string Currency { get; set; }
        public string IsManual { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaSalesPeople SalespersonNavigation { get; set; }
    }
}
