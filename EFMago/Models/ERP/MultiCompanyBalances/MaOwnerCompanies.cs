using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaOwnerCompanies
    {
        public MaOwnerCompanies()
        {
            MaOwnerCompaniesBalances = new HashSet<MaOwnerCompaniesBalances>();
            MaOwnerCompaniesSendings = new HashSet<MaOwnerCompaniesSendings>();
        }

        public string Company { get; set; }
        public string Notes { get; set; }
        public string Currency { get; set; }
        public string Language { get; set; }
        public string ExpectedConsolidDayMonth { get; set; }
        public string DefaultTemplate { get; set; }
        public string CompanyName { get; set; }
        public Guid? Tbguid { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ICollection<MaOwnerCompaniesBalances> MaOwnerCompaniesBalances { get; set; }
        public virtual ICollection<MaOwnerCompaniesSendings> MaOwnerCompaniesSendings { get; set; }
    }
}
