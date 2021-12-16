using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaVariants
    {
        public MaVariants()
        {
            MaVariantsComponents = new HashSet<MaVariantsComponents>();
            MaVariantsRouting = new HashSet<MaVariantsRouting>();
        }

        public string Item { get; set; }
        public string Variant { get; set; }
        public string Bom { get; set; }
        public string Notes { get; set; }
        public string FromConfigurator { get; set; }
        public Guid? Tbguid { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ICollection<MaVariantsComponents> MaVariantsComponents { get; set; }
        public virtual ICollection<MaVariantsRouting> MaVariantsRouting { get; set; }
    }
}
