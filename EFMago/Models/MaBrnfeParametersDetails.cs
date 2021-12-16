using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaBrnfeParametersDetails
    {
        public int BrnfeParameterId { get; set; }
        public int SubId { get; set; }
        public string NaturalPerson { get; set; }
        public string TaxIdNumber { get; set; }
        public string FiscalCode { get; set; }
        public string Name { get; set; }
        public string IsocountryCode { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
