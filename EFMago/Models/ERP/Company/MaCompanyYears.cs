using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaCompanyYears
    {
        public int CompanyId { get; set; }
        public short BalanceYear { get; set; }
        public string UseTaxDistribution { get; set; }
        public string QuarterlyTaxSettlement { get; set; }
        public int? IntrastatSales { get; set; }
        public int? IntrastatPurchases { get; set; }
        public string SalesStatisticalValue { get; set; }
        public string PurchasesStatisticalValue { get; set; }
        public string FarmerTax { get; set; }
        public double? Plafond { get; set; }
        public double? PreviousYearTurnover { get; set; }
        public double? PreviousYearExport { get; set; }
        public double? TemporaryProRataPerc { get; set; }
        public double? FinalProRataPercc { get; set; }
        public int? TaxRegulations { get; set; }
        public double? SalesTaxPerc { get; set; }
        public double? SalesTaxPerc2 { get; set; }
        public string MixedRegime { get; set; }
        public double? Factor { get; set; }
        public string TaxexigibilityOnCollection { get; set; }
        public DateTime? IntrastatSalesChangeDate { get; set; }
        public DateTime? IntrastatPurchasesChangeDate { get; set; }
        public string QuarterlyBlackList { get; set; }
        public string TaxexigibilityCashRegime { get; set; }
        public short? TaxexigibilityCashRegimeFrom { get; set; }
        public short? TaxexigibilityCashRegimeTo { get; set; }
        public double? FinalProRataDiff { get; set; }
        public double? TaxAdvance { get; set; }
        public string TaxAdvanceDescri { get; set; }
        public string YearDeclPresented { get; set; }
        public string PlafondExport { get; set; }
        public string PlafondIntraSales { get; set; }
        public string PlafondSanMarinoSales { get; set; }
        public string PlafondAssOp { get; set; }
        public string PlafondExtraOp { get; set; }
        public string MonthlyPlafond { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public string QuarterlyTaxOption { get; set; }
        public string SplitTax { get; set; }
        public int? TaxAdvanceMethod { get; set; }

        public virtual MaCompany Company { get; set; }
    }
}
