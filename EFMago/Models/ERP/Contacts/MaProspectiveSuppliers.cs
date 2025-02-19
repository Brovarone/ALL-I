using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaProspectiveSuppliers
    {
        public MaProspectiveSuppliers()
        {
            MaProspectiveSuppBranches = new HashSet<MaProspectiveSuppBranches>();
            MaProspectiveSuppNotes = new HashSet<MaProspectiveSuppNotes>();
            MaProspectiveSuppPeople = new HashSet<MaProspectiveSuppPeople>();
        }

        public string ProspectiveSupplier { get; set; }
        public DateTime? FromDate { get; set; }
        public string Language { get; set; }
        public string TitleCode { get; set; }
        public string CustSuppBank { get; set; }
        public string Payment { get; set; }
        public string Currency { get; set; }
        public string Port { get; set; }
        public string SuspendedTax { get; set; }
        public string ExemptFromTax { get; set; }
        public string IsAnEucustSupp { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public string IsocountryCode { get; set; }
        public string TaxIdNumber { get; set; }
        public string FiscalCode { get; set; }
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public string Telex { get; set; }
        public string Fax { get; set; }
        public string ContactPerson { get; set; }
        public string Internet { get; set; }
        public string Email { get; set; }
        public string IsAcustSupp { get; set; }
        public string CustSupp { get; set; }
        public DateTime? ConversionDate { get; set; }
        public string Notes { get; set; }
        public string Category { get; set; }
        public double? Discount1 { get; set; }
        public double? Discount2 { get; set; }
        public string DiscountFormula { get; set; }
        public string TaxCode { get; set; }
        public string Account { get; set; }
        public int? ProspSuppKind { get; set; }
        public Guid? Tbguid { get; set; }
        public string TaxOffice { get; set; }
        public string Disabled { get; set; }
        public string Region { get; set; }
        public int? MailSendingType { get; set; }
        public int? DocumentSendingType { get; set; }
        public string ContactOrigin { get; set; }
        public string ContactSpecification { get; set; }
        public string GoodsOffset { get; set; }
        public string ServicesOffset { get; set; }
        public string WorkingTime { get; set; }
        public string CompanyRegistrNo { get; set; }
        public string PaymentAddress { get; set; }
        public string SkypeId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string NoSendPostaLite { get; set; }
        public string GenRegNo { get; set; }
        public string GenRegEntity { get; set; }
        public string FedStateReg { get; set; }
        public string MunicipalityReg { get; set; }
        public string Suframa { get; set; }
        public string Address2 { get; set; }
        public string StreetNo { get; set; }
        public string District { get; set; }
        public string FederalState { get; set; }
        public string NaturalPerson { get; set; }
        public int? TaxpayerType { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ICollection<MaProspectiveSuppBranches> MaProspectiveSuppBranches { get; set; }
        public virtual ICollection<MaProspectiveSuppNotes> MaProspectiveSuppNotes { get; set; }
        public virtual ICollection<MaProspectiveSuppPeople> MaProspectiveSuppPeople { get; set; }
    }
}
