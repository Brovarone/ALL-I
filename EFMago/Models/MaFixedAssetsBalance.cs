using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaFixedAssetsBalance
    {
        public short FiscalYear { get; set; }
        public int CodeType { get; set; }
        public string FixedAsset { get; set; }
        public string Currency { get; set; }
        public double? Charges { get; set; }
        public double? Revaluation { get; set; }
        public double? AddDepreciation { get; set; }
        public double? InitialTotalDepreciable { get; set; }
        public double? TotalDepreciable { get; set; }
        public double? Depreciation { get; set; }
        public double? InitialAccumDepr { get; set; }
        public double? AccumDepr { get; set; }
        public string Category { get; set; }
        public double? Perc { get; set; }
        public double? Sales { get; set; }
        public double? Scraps { get; set; }
        public double? CapitalGain { get; set; }
        public double? CapitalLoss { get; set; }
        public double? WindfallLoss { get; set; }
        public DateTime? PurchaseDocDate { get; set; }
        public double? IncrementalCharges { get; set; }
        public short? PurchaseYear { get; set; }
        public short? TotPeriodsDepreciated { get; set; }
        public short? CurrPeriodsDepreciated { get; set; }
        public double? DepreciationPlan { get; set; }
        public string NewPeriod { get; set; }
        public double? Liquidation { get; set; }
        public double? InitialLiquidation { get; set; }
        public short? LifePeriod { get; set; }
        public int? DepreciationMethod { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaFixedAssets MaFixedAssets { get; set; }
    }
}
