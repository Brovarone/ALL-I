using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImBudget
    {
        public string Code { get; set; }
        public int CompanyId { get; set; }
        public short FiscalYear { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? CreationDate { get; set; }
        public double? FixedCostsAmount { get; set; }
        public string FixedCostsIndexCode { get; set; }
        public string FixedCostsNotes { get; set; }
        public double? FinancChargesAmount { get; set; }
        public string FinancChargesIndexCode { get; set; }
        public string FinancChargesNotes { get; set; }
        public string DisplayInControlManag { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaCompany Company { get; set; }
        public virtual MaCompanyFiscalYears MaCompanyFiscalYears { get; set; }
    }
}
