using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaPorts
    {
        public MaPorts()
        {
            MaPortsLang = new HashSet<MaPortsLang>();
        }

        public string Port { get; set; }
        public string Description { get; set; }
        public string Disabled { get; set; }
        public int? IntraArrivalsDeliveryTerm { get; set; }
        public int? IntraDispatchesDeliveryTerm { get; set; }
        public Guid? Tbguid { get; set; }
        public string Incoterm { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ICollection<MaPortsLang> MaPortsLang { get; set; }
    }
}
