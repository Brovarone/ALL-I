using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaCompanyGroups
    {
        public MaCompanyGroups()
        {
            MaCompanyGroupNotes = new HashSet<MaCompanyGroupNotes>();
            MaCompanyGroupPeople = new HashSet<MaCompanyGroupPeople>();
        }

        public string Company { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public string Telex { get; set; }
        public string Fax { get; set; }
        public string InternetAddress { get; set; }
        public string EmailAddress { get; set; }
        public string Currency { get; set; }
        public string Language { get; set; }
        public string BusinessKind { get; set; }
        public double? StatedCapital { get; set; }
        public string TaxIdNumber { get; set; }
        public string IsocountryCode { get; set; }
        public Guid? Tbguid { get; set; }
        public string TaxOffice { get; set; }
        public string Address2 { get; set; }
        public string StreetNo { get; set; }
        public string District { get; set; }
        public string FederalState { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ICollection<MaCompanyGroupNotes> MaCompanyGroupNotes { get; set; }
        public virtual ICollection<MaCompanyGroupPeople> MaCompanyGroupPeople { get; set; }
    }
}
