using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaEiselectedAttachment
    {
        public int ErpDocumentId { get; set; }
        public string DocNamespace { get; set; }
        public int PrimaryKeyValue { get; set; }
        public string DescriptionValue { get; set; }
        public string IsSetByDefault { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public string IsFileToAttach { get; set; }
        public string NameValue { get; set; }
    }
}
