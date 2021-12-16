using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaCompanyGroupPeople
    {
        public string Company { get; set; }
        public short Line { get; set; }
        public string TitleCode { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Qualification { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? Gender { get; set; }
        public string CityOfBirth { get; set; }
        public string CountyOfBirth { get; set; }
        public string InternalPhone { get; set; }
        public string MobilePhone { get; set; }
        public string EmailAddress { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaCompanyGroups CompanyNavigation { get; set; }
    }
}
