using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class DsTranscoding
    {
        public string ProviderName { get; set; }
        public string ErptableName { get; set; }
        public string Erpkey { get; set; }
        public Guid? DocTbguid { get; set; }
        public string EntityName { get; set; }
        public string EntityId { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
