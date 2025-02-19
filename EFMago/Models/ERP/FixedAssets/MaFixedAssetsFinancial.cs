using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaFixedAssetsFinancial
    {
        public short FiscalYear { get; set; }
        public int CodeType { get; set; }
        public string FixedAsset { get; set; }
        public string Currency { get; set; }
        public double? Charges { get; set; }
        public double? InitialTotalDepreciable { get; set; }
        public double? TotalDepreciable { get; set; }
        public double? InitialRenewalReserve { get; set; }
        public double? RenewalReserve { get; set; }
        public double? Depreciation { get; set; }
        public double? InitialAccumDepr { get; set; }
        public double? AccumDepr { get; set; }
        public double? RenewalDepr { get; set; }
        public double? InitialRenewalAccumDepr { get; set; }
        public double? RenewalAccumDepr { get; set; }
        public string Category { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaFixedAssets MaFixedAssets { get; set; }
    }
}
