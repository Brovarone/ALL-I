using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaCircularLetterTemplates
    {
        public string Template { get; set; }
        public string Description { get; set; }
        public string Disabled { get; set; }
        public string FileNamespace { get; set; }
        public string PrintAuthSect { get; set; }
        public int? PldeliveryType { get; set; }
        public int? PlprintType { get; set; }
        public Guid? Tbguid { get; set; }
        public string ReportNamespace { get; set; }
        public string Subject { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
