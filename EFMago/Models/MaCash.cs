using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaCash
    {
        public string Cash { get; set; }
        public string Description { get; set; }
        public int? WorkerId { get; set; }
        public string PreferredCurrency { get; set; }
        public string AlternativeCurrency { get; set; }
        public Guid? Tbguid { get; set; }
        public string CashStubBook { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
