using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaCashSessionsEntriesDetails
    {
        public int SessionId { get; set; }
        public short Line { get; set; }
        public short SubLine { get; set; }
        public string IsAcashIn { get; set; }
        public string Reason { get; set; }
        public double? Amount { get; set; }
        public string Notes { get; set; }
        public string CostCenter { get; set; }
        public string Job { get; set; }
        public int? DocumentType { get; set; }
        public string DocNo { get; set; }
        public DateTime? DocumentDate { get; set; }
        public int? CustSuppType { get; set; }
        public string CustSupp { get; set; }
        public int? JournalEntryId { get; set; }
        public string Posted { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaCashSessionsEntries MaCashSessionsEntries { get; set; }
    }
}
