using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaFixAssetEntries
    {
        public MaFixAssetEntries()
        {
            MaFixAssetEntriesDetail = new HashSet<MaFixAssetEntriesDetail>();
        }

        public string Farsn { get; set; }
        public DateTime? PostingDate { get; set; }
        public DateTime? DocumentDate { get; set; }
        public string DocNo { get; set; }
        public string LogNo { get; set; }
        public int? CustSuppType { get; set; }
        public string CustSupp { get; set; }
        public string DepreciationEntry { get; set; }
        public string DisposalEntry { get; set; }
        public string Simulated { get; set; }
        public int EntryId { get; set; }
        public int? JournalEntryId { get; set; }
        public string Currency { get; set; }
        public Guid? Tbguid { get; set; }
        public string RefNo { get; set; }
        public string Alignment { get; set; }
        public int? CrrefType { get; set; }
        public int? CrrefId { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ICollection<MaFixAssetEntriesDetail> MaFixAssetEntriesDetail { get; set; }
    }
}
