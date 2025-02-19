using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaTaxJournalTotals
    {
        public string TaxJournal { get; set; }
        public short BalanceYear { get; set; }
        public short BalanceMonth { get; set; }
        public double? TotalAmount { get; set; }
        public double? TaxAmount { get; set; }
        public double? UndeductibleAmount { get; set; }
        public double? Eoydeductible { get; set; }
        public string DefinitivelyPrinted { get; set; }
        public string Updated { get; set; }
        public DateTime? LastPrintingDate { get; set; }
        public int? NoOfPrintedLines { get; set; }
        public int? LastPage { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
