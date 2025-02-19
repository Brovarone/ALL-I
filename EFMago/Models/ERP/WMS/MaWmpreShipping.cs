using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaWmpreShipping
    {
        public MaWmpreShipping()
        {
            MaWmpreShippingComponents = new HashSet<MaWmpreShippingComponents>();
        }

        public int PreShippingId { get; set; }
        public int? PreShippingType { get; set; }
        public string PreShippingNo { get; set; }
        public DateTime? PreShippingDate { get; set; }
        public string Storage { get; set; }
        public string DestinationStorage { get; set; }
        public string Togenerated { get; set; }
        public string Toconfirmed { get; set; }
        public string DeliveryDocumentGenerated { get; set; }
        public string Printed { get; set; }
        public string Packed { get; set; }
        public string Cancelled { get; set; }
        public int? LastSubId { get; set; }
        public string Zone { get; set; }
        public string ReturnZone { get; set; }
        public string Notes { get; set; }
        public string ReturnPickingNormal { get; set; }
        public string ReturnPickingReturn { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ICollection<MaWmpreShippingComponents> MaWmpreShippingComponents { get; set; }
    }
}
