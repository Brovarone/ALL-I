using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaConfigurations
    {
        public MaConfigurations()
        {
            MaConfigurationsQnA = new HashSet<MaConfigurationsQnA>();
        }

        public string Item { get; set; }
        public string Configuration { get; set; }
        public string Customer { get; set; }
        public string Notes { get; set; }
        public double? Price { get; set; }
        public Guid? Tbguid { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ICollection<MaConfigurationsQnA> MaConfigurationsQnA { get; set; }
    }
}
