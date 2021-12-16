using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaReceiptsBatchDetail
    {
        public int ReceiptBatchId { get; set; }
        public string IsFifo { get; set; }
        public short Line { get; set; }
        public string Storage { get; set; }
        public int? InvEntryId { get; set; }
        public int? InvEntrySubId { get; set; }
        public int? InvEntryType { get; set; }
        public double? Qty { get; set; }
        public double? LineCost { get; set; }
        public DateTime? PostingDate { get; set; }
        public string Temporary { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
