using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaAccountingAdjDefaults
    {
        public string AccruedIncomes { get; set; }
        public string AccruedCharges { get; set; }
        public string DeferredCharges { get; set; }
        public string DeferredIncomes { get; set; }
        public int AccountingAdjDefaultsId { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
