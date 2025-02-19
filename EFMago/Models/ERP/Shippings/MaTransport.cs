using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaTransport
    {
        public MaTransport()
        {
            MaTransportLang = new HashSet<MaTransportLang>();
        }

        public string ModeOfTransport { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public int? CodeType { get; set; }
        public short? BrshippingMode { get; set; }
        public string ExcludeCharges { get; set; }
        public int? ShippingType { get; set; }
        public Guid? Tbguid { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ICollection<MaTransportLang> MaTransportLang { get; set; }
    }
}
