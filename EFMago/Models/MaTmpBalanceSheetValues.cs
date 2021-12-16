using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaTmpBalanceSheetValues
    {
        public string UserName { get; set; }
        public string Computer { get; set; }
        public int Line { get; set; }
        public string DebitAccount { get; set; }
        public string DebitDescription { get; set; }
        public double? Debit { get; set; }
        public double? LastYearDebit { get; set; }
        public double? DebitPerc { get; set; }
        public string CreditAccount { get; set; }
        public string CreditDescription { get; set; }
        public double? Credit { get; set; }
        public double? LastYearCredit { get; set; }
        public double? CreditPerc { get; set; }
        public string AnalyticalCode { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
