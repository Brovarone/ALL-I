using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaCashSessionsEntries
    {
        public MaCashSessionsEntries()
        {
            MaCashSessionsEntriesDetails = new HashSet<MaCashSessionsEntriesDetails>();
        }

        public int SessionId { get; set; }
        public short Line { get; set; }
        public string IsAcashIn { get; set; }
        public string SessionNo { get; set; }
        public DateTime? PostingDate { get; set; }
        public string Currency { get; set; }
        public double? Amount { get; set; }
        public int? CustSuppType { get; set; }
        public string CustSupp { get; set; }
        public string DocNo { get; set; }
        public string Reason { get; set; }
        public string Notes { get; set; }
        public int? OperationType { get; set; }
        public string Cancelled { get; set; }
        public string Posted { get; set; }
        public string DetailsToBePosted { get; set; }
        public DateTime? OpenFixingDate { get; set; }
        public double? OpenAmountInBaseCurr { get; set; }
        public double? ExchangeRateProfit { get; set; }
        public double? ExchangeRateLoss { get; set; }
        public double? Allowance { get; set; }
        public double? ExigibleTax { get; set; }
        public int? PymtSchedId { get; set; }
        public int? JournalEntryId { get; set; }
        public int? AdvanceSessionId { get; set; }
        public short? AdvanceLine { get; set; }
        public string AdvanceClosed { get; set; }
        public string Printed { get; set; }
        public string CostCenter { get; set; }
        public string Job { get; set; }
        public string ExpenseStatementNo { get; set; }
        public double? Rounding { get; set; }
        public string CashStubBook { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaCashSessions Session { get; set; }
        public virtual ICollection<MaCashSessionsEntriesDetails> MaCashSessionsEntriesDetails { get; set; }
    }
}
