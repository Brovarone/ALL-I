using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaTmpConsolidation
    {
        public int EntryId { get; set; }
        public short Line { get; set; }
        public int? SubId { get; set; }
        public int? ActionOnLifoFifo { get; set; }
        public int? LifoFifoLineSource { get; set; }
        public string AutomaticInvValueOnly { get; set; }
        public int? OriginalBoLid { get; set; }
        public int? ArchiveDocType { get; set; }
        public DateTime? PostingDate { get; set; }
        public string StoragePhase1 { get; set; }
        public string StoragePhase2 { get; set; }
        public string DocNo { get; set; }
        public string DocNoForProcedure { get; set; }
        public short? OrderForProcedure { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
