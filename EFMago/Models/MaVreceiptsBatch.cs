using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaVreceiptsBatch
    {
        public int ReceiptBatchId { get; set; }
        public string IsFifo { get; set; }
        public string Storage { get; set; }
        public string Item { get; set; }
        public DateTime? TotallyConsumedDate { get; set; }
        public DateTime? LoadDate { get; set; }
        public int? InvEntryId { get; set; }
        public int? InvEntrySubId { get; set; }
        public int? InvEntryType { get; set; }
        public DateTime? PostingDate { get; set; }
        public string Reason { get; set; }
        public double? UnitLineCost { get; set; }
        public double? LineCost { get; set; }
        public double? Qty { get; set; }
    }
}
