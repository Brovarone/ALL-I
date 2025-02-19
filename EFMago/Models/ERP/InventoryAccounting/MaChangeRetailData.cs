using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaChangeRetailData
    {
        public MaChangeRetailData()
        {
            MaChangeRetailDataDetail = new HashSet<MaChangeRetailDataDetail>();
        }

        public int ChangeRetailDataId { get; set; }
        public string ChangeRetailDataNo { get; set; }
        public DateTime? ChangeRetailDataDate { get; set; }
        public DateTime? PostingDate { get; set; }
        public string AccTemplate { get; set; }
        public string AccReason { get; set; }
        public string Storage { get; set; }
        public string ForValue { get; set; }
        public string ForTaxChange { get; set; }
        public double? TotNetPriceDiff { get; set; }
        public double? TotVatdiff { get; set; }
        public double? GrandTotDiff { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ICollection<MaChangeRetailDataDetail> MaChangeRetailDataDetail { get; set; }
    }
}
