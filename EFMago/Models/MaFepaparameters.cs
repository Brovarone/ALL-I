using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaFepaparameters
    {
        public int ParameterId { get; set; }
        public string ServerName { get; set; }
        public string Dbname { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string CompanyCode { get; set; }
        public int? DocStatusCheckError { get; set; }
        public string UseInternalTranscoding { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public string ProcessCodeB2b { get; set; }
    }
}
