using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaCustList
    {
        public string Customer { get; set; }
        public short BalanceYear { get; set; }
        public string IsManual { get; set; }
        public short IssuingYear { get; set; }
        public double? TaxableAmount { get; set; }
        public double? TaxAmount { get; set; }
        public double? ExemptNoTaxable { get; set; }
        public Guid? Tbguid { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
