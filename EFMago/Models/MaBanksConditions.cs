using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaBanksConditions
    {
        public string Bank { get; set; }
        public string IsAcompanyBank { get; set; }
        public string ConditionCode { get; set; }
        public string CompanyBankId { get; set; }
        public string Convenio { get; set; }
        public string Ca { get; set; }
        public string Carteira { get; set; }
        public string RegisteredCollection { get; set; }
        public string IssueSendByBank { get; set; }
        public int? MinRange { get; set; }
        public int? MaxRange { get; set; }
        public int? LastNumber { get; set; }
        public double? DiscountRate { get; set; }
        public double? InterestRate { get; set; }
        public double? PenalityRate { get; set; }
        public short? ProtestDays { get; set; }
        public string PaymentPlace { get; set; }
        public string Approved { get; set; }
        public int? FileLayout { get; set; }
        public int? LastFileId { get; set; }
        public string ReportNamespace { get; set; }
        public string CarteiraOnFile { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
