using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImJobsWpr
    {
        public string Job { get; set; }
        public short Line { get; set; }
        public int? DocRefId { get; set; }
        public int? DocRefType { get; set; }
        public DateTime? DocRefDate { get; set; }
        public string DocRefNo { get; set; }
        public double? TaxableAmount { get; set; }
        public double? TaxAmount { get; set; }
        public double? Amount { get; set; }
        public double? CollectedTotAmount { get; set; }
        public double? TotAmountOnWpr { get; set; }
        public double? DiscountedTotAmountOnWpr { get; set; }
        public string Currency { get; set; }
        public DateTime? FixingDate { get; set; }
        public double? Fixing { get; set; }
        public string FixingIsManual { get; set; }
        public double? TaxableAmountInBaseCurr { get; set; }
        public double? AmountInBaseCurr { get; set; }
        public double? CollectedAmountInBaseCurr { get; set; }
        public double? TotAmountOnWprinBaseCurr { get; set; }
        public double? TaxAmountInBaseCurr { get; set; }
        public double? DiscountedTotAmountOnWprinBaseCurr { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaJobs JobNavigation { get; set; }
    }
}
