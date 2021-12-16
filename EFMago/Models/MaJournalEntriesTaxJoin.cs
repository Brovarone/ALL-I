using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaJournalEntriesTaxJoin
    {
        public string TaxJournal { get; set; }
        public string No { get; set; }
        public DateTime? PostingDate { get; set; }
        public DateTime? TaxAccrualDate { get; set; }
        public string DocNo { get; set; }
        public DateTime? DocumentDate { get; set; }
        public string CustSupp { get; set; }
        public int? CustSuppType { get; set; }
        public int JournalEntryId { get; set; }
        public int? TaxSign { get; set; }
        public string IntrastatOperation { get; set; }
        public string AccTpl { get; set; }
        public string NotExigible { get; set; }
        public string Currency { get; set; }
        public double? TotalAmountDocCurr { get; set; }
        public double? Fixing { get; set; }
    }
}
