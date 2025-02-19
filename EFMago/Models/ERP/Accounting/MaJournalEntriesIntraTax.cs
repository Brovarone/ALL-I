using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaJournalEntriesIntraTax
    {
        public int JournalEntryId { get; set; }
        public string TaxJournal { get; set; }
        public int? TaxSign { get; set; }
        public DateTime? PostingDate { get; set; }
        public string DocNo { get; set; }
        public string Currency { get; set; }
        public double? TotalAmountDocCurr { get; set; }
        public double? Fixing { get; set; }
        public DateTime? TaxAccrualDate { get; set; }
        public int? Nature { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public int? Eistatus { get; set; }
        public string EidocId { get; set; }
        public string EiprogTransmission { get; set; }
        public int? EiintegrationType { get; set; }

        public virtual MaJournalEntriesTax JournalEntry { get; set; }
    }
}
