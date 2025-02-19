using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaTaxExigibility
    {
        public DateTime? ExigibilityDate { get; set; }
        public string Exigible { get; set; }
        public DateTime? DocumentDate { get; set; }
        public DateTime? PostingDate { get; set; }
        public string TaxJournal { get; set; }
        public string DocNo { get; set; }
        public string LogNo { get; set; }
        public double? TotalAmount { get; set; }
        public double? TaxableAmount { get; set; }
        public double? TaxAmount { get; set; }
        public double? UndeductibleAmount { get; set; }
        public string IsManual { get; set; }
        public int? DocumentId { get; set; }
        public int? ClosingId { get; set; }
        public int TaxExigibilityId { get; set; }
        public string Currency { get; set; }
        public short? Line { get; set; }
        public string TaxCode { get; set; }
        public Guid? Tbguid { get; set; }
        public string ForcedExigibility { get; set; }
        public string SplitPayment { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
