using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaMasterFor770Form
    {
        public string CompanyName { get; set; }
        public string CustSupp { get; set; }
        public int CustSuppType { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Address { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? Gender { get; set; }
        public string CityOfBirth { get; set; }
        public string CountyOfBirth { get; set; }
    }
}
