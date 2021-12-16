using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaWmbinType
    {
        public MaWmbinType()
        {
            MaWmbinTypeSut = new HashSet<MaWmbinTypeSut>();
        }

        public string Code { get; set; }
        public string Description { get; set; }
        public string LooseStock { get; set; }
        public string Disabled { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ICollection<MaWmbinTypeSut> MaWmbinTypeSut { get; set; }
    }
}
