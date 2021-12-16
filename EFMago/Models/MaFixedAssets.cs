using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaFixedAssets
    {
        public MaFixedAssets()
        {
            MaFixedAssetsBalance = new HashSet<MaFixedAssetsBalance>();
            MaFixedAssetsFinancial = new HashSet<MaFixedAssetsFinancial>();
            MaFixedAssetsFiscal = new HashSet<MaFixedAssetsFiscal>();
        }

        public int CodeType { get; set; }
        public string FixedAsset { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Class { get; set; }
        public string Location { get; set; }
        public string CostCenter { get; set; }
        public short? Qty { get; set; }
        public short? DepreciationStart { get; set; }
        public short? LastDepreciation { get; set; }
        public int? PurchaseType { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public short? PurchaseYear { get; set; }
        public double? PurchaseCost { get; set; }
        public DateTime? PurchaseDocDate { get; set; }
        public string PurchaseDocNo { get; set; }
        public string LogNo { get; set; }
        public string Supplier { get; set; }
        public int? DisposalType { get; set; }
        public DateTime? DisposalDate { get; set; }
        public double? DisposalAmount { get; set; }
        public DateTime? DisposalDocDate { get; set; }
        public string DisposalDocNo { get; set; }
        public string Customer { get; set; }
        public DateTime? InstallationDate { get; set; }
        public DateTime? InspectionDate { get; set; }
        public DateTime? PlacedInServiceDate { get; set; }
        public string IdNumber { get; set; }
        public string Notes { get; set; }
        public string Picture { get; set; }
        public string FiscalCustomized { get; set; }
        public double? FiscalPerc { get; set; }
        public string AcceleratedCustomized { get; set; }
        public double? AcceleratedPerc { get; set; }
        public short? LifePeriod { get; set; }
        public string AuthorizeInsufficient { get; set; }
        public double? BalancePerc { get; set; }
        public short? AuthorizationPeriod { get; set; }
        public double? AssignorContribution { get; set; }
        public string Job { get; set; }
        public string Disabled { get; set; }
        public string PartiallyDepreciable { get; set; }
        public double? PurchaseCostDocCurr { get; set; }
        public double? DisposalAmountDocCurr { get; set; }
        public double? AssignorContributionCurr { get; set; }
        public string NoChargesCalculation { get; set; }
        public string ProductLine { get; set; }
        public DateTime? DepreciationStartingDate { get; set; }
        public string BalanceCustomized { get; set; }
        public int? DepreciationMethod { get; set; }
        public DateTime? LastDepreciationDate { get; set; }
        public DateTime? LastBalDepreciationDate { get; set; }
        public Guid? Tbguid { get; set; }
        public int? ParentCodeType { get; set; }
        public string ParentFixedAsset { get; set; }
        public string ItemAdditionalCode { get; set; }
        public short? BalanceLifePeriod { get; set; }
        public int? BalanceDepreciationMethod { get; set; }
        public short? BalanceStep { get; set; }
        public string DeprTemplate { get; set; }
        public double? Activity { get; set; }
        public DateTime? BalMethodChangeDate { get; set; }
        public DateTime? BalLifePeriodChangeDate { get; set; }
        public DateTime? WriteOffDate { get; set; }
        public DateTime? BalWriteOffDate { get; set; }
        public string PartDeprByPerc { get; set; }
        public double? PartDeprLimit { get; set; }
        public double? PartDeprPerc { get; set; }
        public string PartDeprLimitCustom { get; set; }
        public string PartDeprPercCustom { get; set; }
        public string ApplyReduced { get; set; }
        public string Aligned { get; set; }
        public DateTime? AlignmentDate { get; set; }
        public string DeprByDate { get; set; }
        public DateTime? DepreciationEndingDate { get; set; }
        public string ExtraDed { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public string Acgcode { get; set; }

        public virtual ICollection<MaFixedAssetsBalance> MaFixedAssetsBalance { get; set; }
        public virtual ICollection<MaFixedAssetsFinancial> MaFixedAssetsFinancial { get; set; }
        public virtual ICollection<MaFixedAssetsFiscal> MaFixedAssetsFiscal { get; set; }
    }
}
