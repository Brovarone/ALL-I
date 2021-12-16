using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaOwnedCompanies
    {
        public MaOwnedCompanies()
        {
            MaOwnedCompaniesBalances = new HashSet<MaOwnedCompaniesBalances>();
            MaOwnedCompaniesJe = new HashSet<MaOwnedCompaniesJe>();
            MaOwnedCompaniesSendings = new HashSet<MaOwnedCompaniesSendings>();
        }

        public string Company { get; set; }
        public string Notes { get; set; }
        public string ExpectedConsolidDayMonth { get; set; }
        public string CompanyName { get; set; }
        public string CompanyIdentifier { get; set; }
        public Guid? Tbguid { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ICollection<MaOwnedCompaniesBalances> MaOwnedCompaniesBalances { get; set; }
        public virtual ICollection<MaOwnedCompaniesJe> MaOwnedCompaniesJe { get; set; }
        public virtual ICollection<MaOwnedCompaniesSendings> MaOwnedCompaniesSendings { get; set; }
    }
}
