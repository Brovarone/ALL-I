using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaCompanyFiscalYearsPeriod
    {
        public int CompanyId { get; set; }
        public int SubId { get; set; }
        public short FiscalYear { get; set; }
        public short FiscalPeriod { get; set; }
        public DateTime? OpeningDate { get; set; }
        public DateTime? ClosingDate { get; set; }
        public DateTime? InventoryClosingDate { get; set; }
        public string BlockInventoryPosting { get; set; }
        public string BlockDocumentsPosting { get; set; }
        public DateTime? DepreciationDate { get; set; }
        public DateTime? ProfitLossClosingDate { get; set; }
        public DateTime? FinalClosingDate { get; set; }
        public string BlockAccountingPosting { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaCompany Company { get; set; }
        public virtual MaCompanyFiscalYears MaCompanyFiscalYears { get; set; }
    }
}
