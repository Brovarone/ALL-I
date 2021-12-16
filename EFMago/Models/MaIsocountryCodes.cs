using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaIsocountryCodes
    {
        public string IsocountryCode { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public string Currency { get; set; }
        public int? NumberFormat { get; set; }
        public int? DateFormat { get; set; }
        public int? TimeFormat { get; set; }
        public string SimplifiedIntrastat { get; set; }
        public string Eucountry { get; set; }
        public Guid? Tbguid { get; set; }
        public string CountryCode { get; set; }
        public string BlackList { get; set; }
        public string TelephonePrefix { get; set; }
        public string FiscalCode { get; set; }
        public string Disabled { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
