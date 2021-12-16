using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaCompanyPeople
    {
        public int CompanyId { get; set; }
        public int Person { get; set; }
        public string TitleCode { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? Gender { get; set; }
        public string CityOfBirth { get; set; }
        public string CountyOfBirth { get; set; }
        public string DomicileCity { get; set; }
        public string DomicileCounty { get; set; }
        public string DomicileAddress { get; set; }
        public string DomicileZip { get; set; }
        public string DomicileFc { get; set; }
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaCompany Company { get; set; }
    }
}
