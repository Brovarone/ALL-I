using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaCostAccEntries
    {
        public MaCostAccEntries()
        {
            MaCostAccEntriesDetail = new HashSet<MaCostAccEntriesDetail>();
        }

        public string Account { get; set; }
        public int? DebitCreditSign { get; set; }
        public int? CodeType { get; set; }
        public string RefNo { get; set; }
        public DateTime? PostingDate { get; set; }
        public DateTime? AccrualDate { get; set; }
        public DateTime? DocumentDate { get; set; }
        public string DocNo { get; set; }
        public string LogNo { get; set; }
        public string RefDocNo { get; set; }
        public double? TotalAmount { get; set; }
        public string Notes { get; set; }
        public int EntryId { get; set; }
        public int? JournalEntryId { get; set; }
        public int? InvEntryId { get; set; }
        public int? SaleDocId { get; set; }
        public string GenByDepreciation { get; set; }
        public int? PurchaseDocId { get; set; }
        public string Reversing { get; set; }
        public Guid? Tbguid { get; set; }
        public int? CustSuppType { get; set; }
        public string CustSupp { get; set; }
        public int? CrrefType { get; set; }
        public int? CrrefId { get; set; }
        public int? CrrefSubId { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ICollection<MaCostAccEntriesDetail> MaCostAccEntriesDetail { get; set; }
    }
}
