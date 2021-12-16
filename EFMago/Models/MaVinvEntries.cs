using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaVinvEntries
    {
        public string InvRsn { get; set; }
        public string StubBook { get; set; }
        public DateTime? PostingDate { get; set; }
        public int? CustSuppType { get; set; }
        public string CustSupp { get; set; }
        public string PreprintedDocNo { get; set; }
        public string DocNo { get; set; }
        public DateTime? DocumentDate { get; set; }
        public string Currency { get; set; }
        public DateTime? FixingDate { get; set; }
        public string FixingIsManual { get; set; }
        public double? Fixing { get; set; }
        public int EntryId { get; set; }
        public string StoragePhase1 { get; set; }
        public int? Specificator1Type { get; set; }
        public string SpecificatorPhase1 { get; set; }
        public string StoragePhase2 { get; set; }
        public int? Specificator2Type { get; set; }
        public string SpecificatorPhase2 { get; set; }
        public string Notes { get; set; }
        public string Description { get; set; }
        public int? LineCostOrigin { get; set; }
    }
}
