using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImCheckGroupParameters
    {
        public string GroupCode { get; set; }
        public short Line { get; set; }
        public int? TypeLine { get; set; }
        public string ParameterCode { get; set; }
        public string Label { get; set; }
        public short? Row { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ImCheckGroups GroupCodeNavigation { get; set; }
    }
}
