using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaReceiptsBatch
    {
        public int ReceiptBatchId { get; set; }
        public string IsFifo { get; set; }
        public string Storage { get; set; }
        public DateTime? LoadDate { get; set; }
        public string Item { get; set; }
        public double? Qty { get; set; }
        public int? EntryId { get; set; }
        public int? SubId { get; set; }
        public DateTime? TotallyConsumedDate { get; set; }
        public Guid? Tbguid { get; set; }
        public string Temporary { get; set; }
        public string ClosedByInvClosing { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
