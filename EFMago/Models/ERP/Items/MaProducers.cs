using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaProducers
    {
        public MaProducers()
        {
            MaProducersCategories = new HashSet<MaProducersCategories>();
        }

        public string Producer { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public string Fax { get; set; }
        public string Internet { get; set; }
        public string Email { get; set; }
        public string ContactPerson { get; set; }
        public string WorkingTime { get; set; }
        public string Notes { get; set; }
        public string Disabled { get; set; }
        public Guid? Tbguid { get; set; }
        public string IsocountryCode { get; set; }
        public string Address2 { get; set; }
        public string StreetNo { get; set; }
        public string District { get; set; }
        public string FederalState { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ICollection<MaProducersCategories> MaProducersCategories { get; set; }
    }
}
