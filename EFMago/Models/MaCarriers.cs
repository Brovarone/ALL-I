using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaCarriers
    {
        public string Carrier { get; set; }
        public string CompanyName { get; set; }
        public string TaxIdNumber { get; set; }
        public string FiscalCode { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public string Telex { get; set; }
        public string Fax { get; set; }
        public string IsocountryCode { get; set; }
        public string Currency { get; set; }
        public double? PackCharges { get; set; }
        public double? ShippingCharges { get; set; }
        public double? ChargesPercOnTotAmt { get; set; }
        public string InsuredGood { get; set; }
        public string Allowed { get; set; }
        public string Notes { get; set; }
        public string Disabled { get; set; }
        public Guid? Tbguid { get; set; }
        public string TaxOffice { get; set; }
        public string RoadHaulageContractorRegister { get; set; }
        public string TransportationForm { get; set; }
        public string Email { get; set; }
        public string CompanyRegistrNo { get; set; }
        public string Address2 { get; set; }
        public string StreetNo { get; set; }
        public string District { get; set; }
        public string FederalState { get; set; }
        public string FedStateReg { get; set; }
        public string NaturalPerson { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string TitleCode { get; set; }
        public string Eoricode { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
