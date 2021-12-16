using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaCostAccEntriesDetail
    {
        public int EntryId { get; set; }
        public short Line { get; set; }
        public string Account { get; set; }
        public DateTime? PostingDate { get; set; }
        public DateTime? AccrualDate { get; set; }
        public int? CodeType { get; set; }
        public string CostCenter { get; set; }
        public string Job { get; set; }
        public double? Perc { get; set; }
        public int? DebitCreditSign { get; set; }
        public double? Qty { get; set; }
        public double? Amount { get; set; }
        public string Item { get; set; }
        public string Notes { get; set; }
        public string HasCostCenter { get; set; }
        public string HasJob { get; set; }
        public string ProductLine { get; set; }
        public string HasProductLine { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaCostAccEntries Entry { get; set; }
    }
}
