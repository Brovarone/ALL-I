using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class XeSiteParams
    {
        public short IdParam { get; set; }
        public string DomainName { get; set; }
        public string SiteName { get; set; }
        public string SiteCode { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public string RepositoryUrl { get; set; }
        public short? TryNumber { get; set; }
        public short? TimeOut { get; set; }
        public short? CompressSize { get; set; }
        public string EncodingType { get; set; }
        public string ImportPath { get; set; }
        public string ExportPath { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
