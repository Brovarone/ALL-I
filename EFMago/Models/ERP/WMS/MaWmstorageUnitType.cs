using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaWmstorageUnitType
    {
        public MaWmstorageUnitType()
        {
            MaWmbinTypeSut = new HashSet<MaWmbinTypeSut>();
            MaWmsutpackaging = new HashSet<MaWmsutpackaging>();
        }

        public string Sutcode { get; set; }
        public string Description { get; set; }
        public string MixedItems { get; set; }
        public string Category { get; set; }
        public string Disabled { get; set; }
        public double? MaximumWeight { get; set; }
        public double? MaximumVolume { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ICollection<MaWmbinTypeSut> MaWmbinTypeSut { get; set; }
        public virtual ICollection<MaWmsutpackaging> MaWmsutpackaging { get; set; }
    }
}
