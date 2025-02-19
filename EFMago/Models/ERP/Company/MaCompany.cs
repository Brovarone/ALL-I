using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaCompany
    {
        public MaCompany()
        {
            ImBudget = new HashSet<ImBudget>();
            MaCompanyBranches = new HashSet<MaCompanyBranches>();
            MaCompanyFiscalYears = new HashSet<MaCompanyFiscalYears>();
            MaCompanyFiscalYearsPeriod = new HashSet<MaCompanyFiscalYearsPeriod>();
            MaCompanyPeople = new HashSet<MaCompanyPeople>();
            MaCompanyYears = new HashSet<MaCompanyYears>();
        }

        public int CompanyId { get; set; }
        public string TitleCode { get; set; }
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
        public string Internet { get; set; }
        public string Email { get; set; }
        public string IsocountryCode { get; set; }
        public string Siacode { get; set; }
        public string CourtRegistrationId { get; set; }
        public string EnasarcoregistrationId { get; set; }
        public string Court { get; set; }
        public string TaxPayerCode { get; set; }
        public string TaxCano { get; set; }
        public string CollectorsOffice { get; set; }
        public string NaturalPerson { get; set; }
        public string BusinessCode { get; set; }
        public string BusinessKind { get; set; }
        public string TaxOffice { get; set; }
        public string LegalNature { get; set; }
        public string RevenueOfficeCounty { get; set; }
        public string LicenceNumber { get; set; }
        public DateTime? LicenceDate { get; set; }
        public int? TerritoryType { get; set; }
        public string BusinessInMoreLocations { get; set; }
        public string PartialBookKeeping { get; set; }
        public string SeasonalBusiness { get; set; }
        public string Artisan { get; set; }
        public string ChambOfCommRegistrNo { get; set; }
        public string ArtisanRegistrNo { get; set; }
        public string CommRegisetrRegistrNo { get; set; }
        public string AuthorizationCode { get; set; }
        public string SocialSecurityId { get; set; }
        public string SocialInsuranceId { get; set; }
        public string RegionCode { get; set; }
        public string SocialInsuranceBranch { get; set; }
        public string Inpdaienpalsentity { get; set; }
        public string Inpdaienpalsbranch { get; set; }
        public string SocialSecurityCode { get; set; }
        public string ChambOfCommArea { get; set; }
        public string ArtisanArea { get; set; }
        public string Inpdaienpalscode { get; set; }
        public short? SubscriberChargeCode { get; set; }
        public string SubscriberFiscalCode { get; set; }
        public string Nipeu { get; set; }
        public int? LastSubId { get; set; }
        public Guid? Tbguid { get; set; }
        public double? Capital { get; set; }
        public string FullyPaidUpCapital { get; set; }
        public string CompanyRegistrNo { get; set; }
        public string CooperativeRegistrNo { get; set; }
        public string ImportExportLicence { get; set; }
        public string BusinessCodeAteco { get; set; }
        public string LoadingPlace { get; set; }
        public int? LoaderType { get; set; }
        public string LoaderCode { get; set; }
        public string LoaderBranch { get; set; }
        public string IntrastatUserCode { get; set; }
        public string CustomsSectionCode { get; set; }
        public string CustomsTaxIdNumber { get; set; }
        public int? IntrastatProgNo { get; set; }
        public string IntrastatOutputPath { get; set; }
        public string Cbicode { get; set; }
        public string CertifiedEmail { get; set; }
        public string GenRegNo { get; set; }
        public string GenRegEntity { get; set; }
        public string FedStateReg { get; set; }
        public string MunicipalityReg { get; set; }
        public string Suframa { get; set; }
        public string Address2 { get; set; }
        public string StreetNo { get; set; }
        public string District { get; set; }
        public string FederalState { get; set; }
        public string GoodsActivity { get; set; }
        public string ServicesActivity { get; set; }
        public string FantasyName { get; set; }
        public string CreditorIdentifier { get; set; }
        public string ChambOfCommCounty { get; set; }
        public string Eoricode { get; set; }
        public string ProfessionalRegisterName { get; set; }
        public string ProfessionalRegisterCounty { get; set; }
        public string ProfessionalRegisterNo { get; set; }
        public DateTime? ProfessionalRegisterDate { get; set; }
        public string ProfessionalCashType { get; set; }
        public string SoleShareholder { get; set; }
        public string InLiquidation { get; set; }
        public string BelongToGroup { get; set; }
        public string GroupName { get; set; }
        public string GroupCountry { get; set; }
        public string SubmittedToCoordination { get; set; }
        public string CoordinatorName { get; set; }
        public string TsownerType { get; set; }
        public string FatherName { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaCompanyTaxDeclaration MaCompanyTaxDeclaration { get; set; }
        public virtual ICollection<ImBudget> ImBudget { get; set; }
        public virtual ICollection<MaCompanyBranches> MaCompanyBranches { get; set; }
        public virtual ICollection<MaCompanyFiscalYears> MaCompanyFiscalYears { get; set; }
        public virtual ICollection<MaCompanyFiscalYearsPeriod> MaCompanyFiscalYearsPeriod { get; set; }
        public virtual ICollection<MaCompanyPeople> MaCompanyPeople { get; set; }
        public virtual ICollection<MaCompanyYears> MaCompanyYears { get; set; }
    }
}
