using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaTaxJournalSummaries
    {
        public string TaxJournal { get; set; }
        public short BalanceYear { get; set; }
        public string TaxCode { get; set; }
        public string IntrastatTax { get; set; }
        public short BalanceMonth { get; set; }
        public string IsManual { get; set; }
        public string Temporary { get; set; }
        public double? TaxableAmount { get; set; }
        public double? TaxAmount { get; set; }
        public double? TotalAmount { get; set; }
        public double? UndeductibleAmount { get; set; }
        public double? Eoydeductible { get; set; }
        public Guid? Tbguid { get; set; }
        public double? NotExTaxableAmount { get; set; }
        public double? NotExTaxAmount { get; set; }
        public double? ExTaxableAmount { get; set; }
        public double? ExTaxAmount { get; set; }
        public double? ExTaxableRegPrev { get; set; }
        public double? ExTaxRegPrev { get; set; }
        public double? NotExTaxableExNext { get; set; }
        public double? NotExCashTaxableExNext { get; set; }
        public double? NotExTaxExNext { get; set; }
        public double? NotExCashTaxExNext { get; set; }
        public double? NotExSplitPaymentTaxable { get; set; }
        public double? NotExSplitPaymentTax { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
