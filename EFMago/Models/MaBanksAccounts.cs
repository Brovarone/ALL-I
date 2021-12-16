using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaBanksAccounts
    {
        public string Bank { get; set; }
        public string IsAcompanyBank { get; set; }
        public string Ca { get; set; }
        public int Presentation { get; set; }
        public string Cacheck { get; set; }
        public string Iban { get; set; }
        public string IbanisManual { get; set; }
        public string Currency { get; set; }
        public string Cin { get; set; }
        public string Notes { get; set; }
        public string Disabled { get; set; }
        public string Account { get; set; }
        public double? MaxCreditLimit { get; set; }
        public double? Presented { get; set; }
        public double? BorrowingRate { get; set; }
        public string Blocked { get; set; }
        public string PostalNumber { get; set; }
        public string InternalNumber { get; set; }
        public int? FactoringType { get; set; }
        public string FactoringAdvance { get; set; }
        public string PymtCash { get; set; }
        public string DebitCollCharges { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaBanks MaBanks { get; set; }
    }
}
