using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaOwnedCompaniesSendings
    {
        public string Company { get; set; }
        public short Line { get; set; }
        public DateTime? BalanceDate { get; set; }
        public DateTime? SendingDate { get; set; }
        public string Notes { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaOwnedCompanies CompanyNavigation { get; set; }
    }
}
