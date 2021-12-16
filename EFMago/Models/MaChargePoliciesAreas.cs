using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaChargePoliciesAreas
    {
        public string Customer { get; set; }
        public string Area { get; set; }
        public double? Percentage { get; set; }
        public double? Value { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaChargePolicies CustomerNavigation { get; set; }
    }
}
