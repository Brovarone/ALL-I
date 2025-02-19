using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaPaymentParameters
    {
        public string Charges { get; set; }
        public string OneGllineForEachInstallment { get; set; }
        public string PaymentInIssue { get; set; }
        public string AllPymtTerms { get; set; }
        public string SlipWithDifferentPymtTerm { get; set; }
        public string UseBank { get; set; }
        public string Bank { get; set; }
        public string Ca { get; set; }
        public int? Glnotes { get; set; }
        public string UseProcessingDate { get; set; }
        public int PaymentParametersId { get; set; }
        public double? StatisticAmount { get; set; }
        public string StatisticReason { get; set; }
        public string StatisticType { get; set; }
        public string StatisticReasonOver { get; set; }
        public string StatisticTypeOver { get; set; }
        public string UsePymtScheduleBank { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
