using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaBoletos
    {
        public string BoletoNo { get; set; }
        public string IssuerBank { get; set; }
        public string ConditionCode { get; set; }
        public string Customer { get; set; }
        public double? Amount { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? IssuingDate { get; set; }
        public double? DiscountRate { get; set; }
        public double? InterestRate { get; set; }
        public double? PenalityRate { get; set; }
        public short? ProtestDays { get; set; }
        public string OurNumber { get; set; }
        public string PrintedOurNumber { get; set; }
        public string BarCode { get; set; }
        public string Instruction { get; set; }
        public string PrintedOnPaper { get; set; }
        public string PrintedOnFile { get; set; }
        public string Cancelled { get; set; }
        public string Collected { get; set; }
        public DateTime? CollectionDate { get; set; }
        public double? CollectedAmount { get; set; }
        public double? InterestPenality { get; set; }
        public int? CollectionJeid { get; set; }
        public double? OriginalAmount { get; set; }
        public short? UpdateNo { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
