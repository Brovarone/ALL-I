using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaOwnedCompaniesBalances
    {
        public string Company { get; set; }
        public short FiscalYear { get; set; }
        public DateTime? BalanceDate { get; set; }
        public string Notes { get; set; }
        public string Final { get; set; }
        public string Excluded { get; set; }
        public string ExclusionReason { get; set; }
        public int? JournalEntryId { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaOwnedCompanies CompanyNavigation { get; set; }
    }
}
