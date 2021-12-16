using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaFixAssetEntriesDetail
    {
        public int EntryId { get; set; }
        public short Line { get; set; }
        public int? CodeType { get; set; }
        public string FixedAsset { get; set; }
        public DateTime? PostingDate { get; set; }
        public short? Qty { get; set; }
        public double? Perc { get; set; }
        public double? Amount { get; set; }
        public string Notes { get; set; }
        public string Currency { get; set; }
        public double? AmountDocCurr { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaFixAssetEntries Entry { get; set; }
    }
}
