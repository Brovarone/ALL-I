using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaTaxAccountsDefaults
    {
        public int TaxAccountType { get; set; }
        public string TaxCode { get; set; }
        public string TaxAccount { get; set; }
        public string TaxSuspendedAccount { get; set; }
        public int TaxDefaultsId { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
