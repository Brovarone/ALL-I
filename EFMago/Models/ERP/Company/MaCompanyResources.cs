using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaCompanyResources
    {
        public MaCompanyResources()
        {
            MaCompanyResourcesBreakdown = new HashSet<MaCompanyResourcesBreakdown>();
            MaCompanyResourcesDetails = new HashSet<MaCompanyResourcesDetails>();
            MaCompanyResourcesFields = new HashSet<MaCompanyResourcesFields>();
        }

        public int ResourceType { get; set; }
        public string ResourceCode { get; set; }
        public string Description { get; set; }
        public int? Manager { get; set; }
        public string Notes { get; set; }
        public string ImagePath { get; set; }
        public string CostCenter { get; set; }
        public string Disabled { get; set; }
        public string HideOnLayout { get; set; }
        public string DomicilyAddress { get; set; }
        public string DomicilyCity { get; set; }
        public string DomicilyCounty { get; set; }
        public string DomicilyZip { get; set; }
        public string DomicilyCountry { get; set; }
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public string Telephone3 { get; set; }
        public string Telephone4 { get; set; }
        public string Email { get; set; }
        public string Url { get; set; }
        public string SkypeId { get; set; }
        public string Branch { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public Guid? Tbguid { get; set; }
        public string Address2 { get; set; }
        public string StreetNo { get; set; }
        public string District { get; set; }
        public string FederalState { get; set; }
        public string IsocountryCode { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ICollection<MaCompanyResourcesBreakdown> MaCompanyResourcesBreakdown { get; set; }
        public virtual ICollection<MaCompanyResourcesDetails> MaCompanyResourcesDetails { get; set; }
        public virtual ICollection<MaCompanyResourcesFields> MaCompanyResourcesFields { get; set; }
    }
}
