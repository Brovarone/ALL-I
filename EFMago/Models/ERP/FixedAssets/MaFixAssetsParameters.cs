using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaFixAssetsParameters
    {
        public int FixAssetsParametersId { get; set; }
        public double? MinimumPerc { get; set; }
        public double? FirstFiscalYearPerc { get; set; }
        public double? AcceleratedPerc { get; set; }
        public short? AcceleratedNoOfYears { get; set; }
        public double? ChargesPerc { get; set; }
        public short? ChargesNoOfyears { get; set; }
        public string FiscalDeprFarsn { get; set; }
        public string AcceleratedDeprFarsn { get; set; }
        public string LostDeprFarsn { get; set; }
        public string BalanceDeprFarsn { get; set; }
        public string FinancialDeprFarsn { get; set; }
        public string RenewalDeprFarsn { get; set; }
        public string SaleFarsn { get; set; }
        public string PartialSaleFarsn { get; set; }
        public string ScrapFarsn { get; set; }
        public string PartialScrapFarsn { get; set; }
        public string AccumDeprReversalFarsn { get; set; }
        public string AccAccumDeprReversalFarsn { get; set; }
        public string LostAccumDeprReversalFarsn { get; set; }
        public string CapitalGainFarsn { get; set; }
        public string CapitalLossFarsn { get; set; }
        public string WindfallLossFarsn { get; set; }
        public string BalanceSaleFarsn { get; set; }
        public string BalancePartialSaleFarsn { get; set; }
        public string BalanceScrapFarsn { get; set; }
        public string BalancePartialScrapFarsn { get; set; }
        public string BalAccumDeprReversalFarsn { get; set; }
        public string BalanceCapitalGainFarsn { get; set; }
        public string BalanceCapitalLossFarsn { get; set; }
        public string BalanceWindfallLossFarsn { get; set; }
        public string JournalEntryFiscalValue { get; set; }
        public string DisposalDepr { get; set; }
        public string DepreciationAccTpl { get; set; }
        public string SaleAccTpl { get; set; }
        public string ScrapAccTpl { get; set; }
        public string DepreciationAccRsn { get; set; }
        public string AcceleratedDeprAccRsn { get; set; }
        public string AccumDeprReversalAccRsn { get; set; }
        public string CapitalLossAccRsn { get; set; }
        public string CapitalGainAccRsn { get; set; }
        public string WindfallLossAccRsn { get; set; }
        public string CapitalLoss { get; set; }
        public string CapitalGain { get; set; }
        public string WindfallLoss { get; set; }
        public string PurchaseFarsn { get; set; }
        public string CoAaccount1 { get; set; }
        public string CoAaccount2 { get; set; }
        public string CoAaccount3 { get; set; }
        public string CoAaccount4 { get; set; }
        public string CoAaccount5 { get; set; }
        public string CostAccFiscalValue { get; set; }
        public string FixedAssetsAutoNum { get; set; }
        public int? LastFixedAsset { get; set; }
        public short? LastFixedAssetMaxChar { get; set; }
        public short? MaxLines { get; set; }
        public string PostOneJeperCategory { get; set; }
        public string PostOneJeperFixedAsset { get; set; }
        public string RecalculateInital { get; set; }
        public string ReducedBalanceDepr { get; set; }
        public string PurchaseFiscalYear { get; set; }
        public int? FirstFiscalYearReduction { get; set; }
        public int? PeriodPosting { get; set; }
        public string BalanceDeprInDays { get; set; }
        public string BalanceDeprInMonths { get; set; }
        public string DisposalPostJe { get; set; }
        public string EntryAutonumbering { get; set; }
        public int? FirstBalanceYearReduction { get; set; }
        public string FiscalCalendarYear { get; set; }
        public string BalanceCalendarYear { get; set; }
        public string DisableAccelerated { get; set; }
        public string DisableReduced { get; set; }
        public string NoFiscalOverBalance { get; set; }
        public string AlignAccAccumDeprFarsn { get; set; }
        public string AlignAccumDeprFarsn { get; set; }
        public string NoFiscalOverBalance2008 { get; set; }
        public string BalanceDeprUsage100 { get; set; }
        public string CoAaccount6 { get; set; }
        public string CoAaccount7 { get; set; }
        public string CoAaccount8 { get; set; }
        public string CoAaccount9 { get; set; }
        public string CoAaccount10 { get; set; }
        public string PrintExtraDed { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
