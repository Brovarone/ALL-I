using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class DsProviders
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Disabled { get; set; }
        public string ProviderUrl { get; set; }
        public string ProviderUser { get; set; }
        public string ProviderPassword { get; set; }
        public string ProviderParameters { get; set; }
        public string IsEaprovider { get; set; }
        public Guid? Tbguid { get; set; }
        public string SkipCrtValidation { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
