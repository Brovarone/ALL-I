using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaTmpBalanceReclass
    {
        public Guid SessionGuid { get; set; }
        public int Line { get; set; }
        public string DebitSchema { get; set; }
        public string DebitCode { get; set; }
        public string DebitDescription { get; set; }
        public string DebitLineNoCol { get; set; }
        public int? DebitLineType { get; set; }
        public double? Debit { get; set; }
        public double? SecondDebit { get; set; }
        public double? ThirdDebit { get; set; }
        public string CreditSchema { get; set; }
        public string CreditCode { get; set; }
        public string CreditDescription { get; set; }
        public string CreditLineNoCol { get; set; }
        public int? CreditLineType { get; set; }
        public double? Credit { get; set; }
        public double? SecondCredit { get; set; }
        public double? ThirdCredit { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
