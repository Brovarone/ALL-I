using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaCompanyFiscalYears
    {
        public MaCompanyFiscalYears()
        {
            ImBudget = new HashSet<ImBudget>();
            MaCompanyFiscalYearsPeriod = new HashSet<MaCompanyFiscalYearsPeriod>();
        }

        public int CompanyId { get; set; }
        public short FiscalYear { get; set; }
        public DateTime? OpeningDate { get; set; }
        public DateTime? ClosingDate { get; set; }
        public DateTime? TemporaryClosingDate { get; set; }
        public DateTime? TemporaryClosingCustSupp { get; set; }
        public DateTime? ProfitLossClosingDate { get; set; }
        public DateTime? FinalClosingDate { get; set; }
        public DateTime? FinalOpeningDate { get; set; }
        public DateTime? InventoryClosingDate { get; set; }
        public string ExceptionalEvents { get; set; }
        public string CalculateInventoryValue { get; set; }
        public int? InventoryValueCriteria { get; set; }
        public DateTime? DepreciationDate { get; set; }
        public string Notes { get; set; }
        public string BlockAccountingPosting { get; set; }
        public string BlockInventoryPosting { get; set; }
        public string UseItemDefaultValuation { get; set; }
        public int? FiscalPeriodType { get; set; }
        public int? SubId { get; set; }
        public DateTime? BlockInventoryPostingDate { get; set; }
        public string BlockFixedAssetsPosting { get; set; }
        public string InitialInventoryBalances { get; set; }
        public string BlockCostAccPosting { get; set; }
        public string DoAudit { get; set; }
        public string CombinAuditPost { get; set; }
        public string CanDeletePostedTrans { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaCompany Company { get; set; }
        public virtual ICollection<ImBudget> ImBudget { get; set; }
        public virtual ICollection<MaCompanyFiscalYearsPeriod> MaCompanyFiscalYearsPeriod { get; set; }
    }
}
