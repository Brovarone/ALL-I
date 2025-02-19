using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImComplianceDeclaration
    {
        public ImComplianceDeclaration()
        {
            ImComplianceDeclEncloseMat = new HashSet<ImComplianceDeclEncloseMat>();
        }

        public int ComplianceDeclarationId { get; set; }
        public string ComplianceDeclarationNo { get; set; }
        public string Job { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string Sector { get; set; }
        public string Address { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string TelephoneNumber { get; set; }
        public string TaxIdNumber { get; set; }
        public string IsChambOfCommRegistr { get; set; }
        public string ChambOfCommRegistrNo { get; set; }
        public string ChambOfCommArea { get; set; }
        public string IsArtisanRegist { get; set; }
        public string ArtisanRegistNo { get; set; }
        public string ArtisanArea { get; set; }
        public string SystemBriefDescription { get; set; }
        public string IsAnewSystem { get; set; }
        public string IsAchange { get; set; }
        public string IsAnEnlargment { get; set; }
        public string AreExtraordinaryRepairs { get; set; }
        public string IsOther { get; set; }
        public string DescriptionOther { get; set; }
        public string SystemCustomer { get; set; }
        public string SystemTown { get; set; }
        public string SystemCounty { get; set; }
        public string SystemAddress { get; set; }
        public string SystemAddressNo { get; set; }
        public string SystemStairs { get; set; }
        public string SystemFloor { get; set; }
        public string SystemApartmentNo { get; set; }
        public string OwnerData { get; set; }
        public string IsForIndustrialUsage { get; set; }
        public string IsForCivilUsage { get; set; }
        public string IsForCommercialUsage { get; set; }
        public string IsForOtherUsage { get; set; }
        public string ProjectFollowed { get; set; }
        public string Manager { get; set; }
        public string TechnicalRuleFollowed { get; set; }
        public string TechnicalRuleDescription { get; set; }
        public string InstallationAccordingToRules { get; set; }
        public string ControlledSystem { get; set; }
        public string EcloseProject { get; set; }
        public string EncloseUsedMaterialReport { get; set; }
        public string EncloseSystemDesign { get; set; }
        public string EnclosePreviousEnclosuresRef { get; set; }
        public string EncloseCertificatesCopy { get; set; }
        public string EncloseComplianceSystemNonStandard { get; set; }
        public string EncloseOtherPapers { get; set; }
        public DateTime? PostingDate { get; set; }
        public string Note { get; set; }
        public string Referements { get; set; }
        public string Customer { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public Guid? Tbguid { get; set; }

        public virtual ICollection<ImComplianceDeclEncloseMat> ImComplianceDeclEncloseMat { get; set; }
    }
}
