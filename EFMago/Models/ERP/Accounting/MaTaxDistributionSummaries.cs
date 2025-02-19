using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaTaxDistributionSummaries
    {
        public string TaxJournal { get; set; }
        public string TaxCode { get; set; }
        public short BalanceYear { get; set; }
        public short Period { get; set; }
        public double? Perc { get; set; }
        public double? Purchases { get; set; }
        public double? Incidence { get; set; }
        public double? TaxableAmount { get; set; }
        public double? TaxAmount { get; set; }
        public double? TotalAmount { get; set; }
        public Guid? Tbguid { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
