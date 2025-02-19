using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImInvEntryJobs
    {
        public string Storage { get; set; }
        public short? Line { get; set; }
        public string Item { get; set; }
        public int EntryId { get; set; }
        public DateTime? PostingDate { get; set; }
        public string InvRsn { get; set; }
        public double? Qty { get; set; }
        public string Receipted { get; set; }
        public int? CustSuppType { get; set; }
        public string Cancel { get; set; }
        public double? UnitValue { get; set; }
        public string DiscountFormula { get; set; }
        public double? DiscountAmount { get; set; }
        public double? LineAmount { get; set; }
        public string Job { get; set; }
        public string CliFor { get; set; }
        public int? SpecificatorType { get; set; }
        public string Specificator { get; set; }
        public int Phase { get; set; }
        public string UoM { get; set; }
    }
}
