using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImCheckParameters
    {
        public ImCheckParameters()
        {
            ImCheckRuleParameter = new HashSet<ImCheckRuleParameter>();
        }

        public string Code { get; set; }
        public string Description { get; set; }
        public int? Type { get; set; }
        public string HotLink { get; set; }
        public string HotLinkParameters { get; set; }
        public short? EnumFamily { get; set; }
        public string LabelParam { get; set; }
        public string IsOwner { get; set; }
        public string Deleted { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ICollection<ImCheckRuleParameter> ImCheckRuleParameter { get; set; }
    }
}
