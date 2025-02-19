using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaJournalEntriesGldetail
    {
        public int JournalEntryId { get; set; }
        public short Line { get; set; }
        public string AccRsn { get; set; }
        public DateTime? PostingDate { get; set; }
        public DateTime? AccrualDate { get; set; }
        public int? CodeType { get; set; }
        public string Account { get; set; }
        public int? AmountType { get; set; }
        public int? CustSuppType { get; set; }
        public string CustSupp { get; set; }
        public string TaxBalancingCheck { get; set; }
        public int? DebitCreditSign { get; set; }
        public double? Amount { get; set; }
        public string Notes { get; set; }
        public string Checked { get; set; }
        public int? Nature { get; set; }
        public string Currency { get; set; }
        public double? DocCurrAmount { get; set; }
        public DateTime? FixingDate { get; set; }
        public double? Fixing { get; set; }
        public string FixingIsManual { get; set; }
        public double? FiscalAmount { get; set; }
        public DateTime? ValueDate { get; set; }
        public double? AccrualDeferralTot { get; set; }
        public DateTime? StartingOfUseDate { get; set; }
        public DateTime? EndingOfUseDate { get; set; }
        public string UseBusinessYear { get; set; }
        public string AccrualDeferralPosted { get; set; }
        public string Posted { get; set; }
        public short? OffsetGroupNo { get; set; }
        public int? SubId { get; set; }
        public string AdjAccount { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
