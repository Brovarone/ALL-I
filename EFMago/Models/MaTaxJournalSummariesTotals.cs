using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaTaxJournalSummariesTotals
    {
        public short BalanceYear { get; set; }
        public short Period { get; set; }
        public int? LastPage { get; set; }
        public string PaymentDetails { get; set; }
        public string DefinitivelyPrinted { get; set; }
        public double? DebitTaxPeriod { get; set; }
        public double? CreditTaxPeriod { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public double? ExigibleTax { get; set; }
        public double? DeductibleTax { get; set; }
        public double? DebitTax { get; set; }
        public double? CreditTax { get; set; }
        public double? PreviousDebitTax { get; set; }
        public double? PreviousCreditTax { get; set; }
        public double? PreviousYearCreditTax { get; set; }
        public double? ExcludedCreditTax { get; set; }
        public double? IncludedCreditTax { get; set; }
        public double? ImportedCarsTaxPaid { get; set; }
        public double? SpecialCreditTax { get; set; }
        public double? Interests { get; set; }
        public int? TransferJeid { get; set; }
    }
}
