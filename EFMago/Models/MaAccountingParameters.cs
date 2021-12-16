using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaAccountingParameters
    {
        public int AccountingParametersId { get; set; }
        public string AllowEditDefinitiveJe { get; set; }
        public string ManualClosing { get; set; }
        public short? ClosingMaxLines { get; set; }
        public string DetailedCustSuppClosing { get; set; }
        public string DetailedAccrualsDeferrals { get; set; }
        public string EuannOnSalesTaxJournal { get; set; }
        public string EufixingOnPostingDate { get; set; }
        public int? TotalDocCurrRounding { get; set; }
        public int? NetMassRounding { get; set; }
        public int? SupplementaryUnitRounding { get; set; }
        public string GljournalProgrNumber { get; set; }
        public string GljournalProgrAmount { get; set; }
        public string SortGljournalByNumber { get; set; }
        public string TaxJournalProgrNumber { get; set; }
        public string DailyRetailSales { get; set; }
        public string ContextualHeading { get; set; }
        public string TaxDebitCrediPrompt { get; set; }
        public double? MinTaxPayable { get; set; }
        public double? TaxAdvancePerc { get; set; }
        public double? TaxAdvance { get; set; }
        public double? TaxInterestPerc { get; set; }
        public string IssuedDocNoAutoNum { get; set; }
        public string PureRefNoAutoNum { get; set; }
        public string IssuedRefNoAutoNum { get; set; }
        public string ReceivedRefNoAutoNum { get; set; }
        public string ForecastPureRefNoAutoNum { get; set; }
        public string ForecastIssuedRefNoAutoNum { get; set; }
        public string ForecastReceivedRefNoAutoNum { get; set; }
        public string SimulationsAutoNum { get; set; }
        public short? TaxPymtDay { get; set; }
        public string TaxAccrualIssuedDocDate { get; set; }
        public string TaxAccrualReceivedDocDate { get; set; }
        public string AccrualPureDocDate { get; set; }
        public string CreatePymtInForecast { get; set; }
        public string PureDocNoAutoNum { get; set; }
        public string TaxSummaryNumbering { get; set; }
        public string TaxSummaryJournal { get; set; }
        public string PlafondByDocDate { get; set; }
        public string PlafondEmptyDate { get; set; }
        public string IntraProtocolFromAnnotation { get; set; }
        public double? LimitCompanyFirstYear { get; set; }
        public double? LimitCompany { get; set; }
        public double? LimitPrivatePerson { get; set; }
        public DateTime? LimitDatePrivatePerson { get; set; }
        public string GroupByCig { get; set; }
        public string GroupByCup { get; set; }
        public string GroupByJob { get; set; }
        public string GroupByTaxGroup { get; set; }
        public string GroupSettlementInvoices { get; set; }
        public string GroupCreditNote { get; set; }
        public string TaxGroupByCustSupp { get; set; }
        public string BlockEditDefinitiveDoc { get; set; }
        public int? LimitRowsForGrid { get; set; }
        public string GroupByCustSupp { get; set; }
        public int? IntraOperationDef { get; set; }
        public string EnableMonthlyDeferrals { get; set; }
        public int? MonthlyDeferralsNature { get; set; }
        public string FillTouristForm { get; set; }
        public string FilterByAccrualDate { get; set; }
        public double? LimitTouristForm { get; set; }
        public double? LimitBlackList { get; set; }
        public string GroupReversalInForecast { get; set; }
        public string ContextualHeadingAdditional { get; set; }
        public string TaxDbCrFromSummaries { get; set; }
        public string ViewUpdatedBalance { get; set; }
        public string DocToBeIssRecInAccrDate { get; set; }
        public DateTime? IntraServiceSimplifiedDate { get; set; }
        public double? KepyoLimit { get; set; }
        public string UseMinusOnCorrections { get; set; }
        public string PrintCompanyName { get; set; }
        public string PrintAccountCode { get; set; }
        public string PrintAllLevels { get; set; }
        public string PrintAccountRoot { get; set; }
        public string PrintLastLevel { get; set; }
        public int? CodeSeperator { get; set; }
        public int? DesSeperator { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public DateTime? IntraSimplified2018 { get; set; }
    }
}
