using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaBanks
    {
        public MaBanks()
        {
            MaBanksAccounts = new HashSet<MaBanksAccounts>();
            MaBanksFactoringCustomers = new HashSet<MaBanksFactoringCustomers>();
            MaBanksFactoringPymtTerms = new HashSet<MaBanksFactoringPymtTerms>();
            MaBanksPeople = new HashSet<MaBanksPeople>();
        }

        public string Abi { get; set; }
        public string Cab { get; set; }
        public string Bank { get; set; }
        public string IsAcompanyBank { get; set; }
        public string Description { get; set; }
        public string Account { get; set; }
        public string ChargesAccount { get; set; }
        public string Counter { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public string County { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public string Telex { get; set; }
        public string Fax { get; set; }
        public string Cabprefix { get; set; }
        public string Abiprefix { get; set; }
        public string Siacode { get; set; }
        public string Swift { get; set; }
        public short? BankDays { get; set; }
        public string Agency { get; set; }
        public string Branch { get; set; }
        public string ContactPerson { get; set; }
        public string SenderCode { get; set; }
        public string SenderReference { get; set; }
        public string Signature { get; set; }
        public string PreferredCa { get; set; }
        public string Notes { get; set; }
        public string Disabled { get; set; }
        public string Identifier { get; set; }
        public string CashOrderCbicode { get; set; }
        public Guid? Tbguid { get; set; }
        public string IsForeign { get; set; }
        public string CashOrderResultRequest { get; set; }
        public string FactoringCode { get; set; }
        public string FactoringCurrency { get; set; }
        public string UseValueDate { get; set; }
        public string BillsAndPaymentsFolder { get; set; }
        public string BillsAndPaymentsExtension { get; set; }
        public string Internet { get; set; }
        public string Email { get; set; }
        public string IsocountryCode { get; set; }
        public string DebitChargesSeparately { get; set; }
        public string Address2 { get; set; }
        public string StreetNo { get; set; }
        public string District { get; set; }
        public string FederalState { get; set; }
        public string Cbicode { get; set; }
        public string UseIso20022 { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ICollection<MaBanksAccounts> MaBanksAccounts { get; set; }
        public virtual ICollection<MaBanksFactoringCustomers> MaBanksFactoringCustomers { get; set; }
        public virtual ICollection<MaBanksFactoringPymtTerms> MaBanksFactoringPymtTerms { get; set; }
        public virtual ICollection<MaBanksPeople> MaBanksPeople { get; set; }
    }
}
