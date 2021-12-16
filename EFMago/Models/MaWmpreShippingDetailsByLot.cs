using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaWmpreShippingDetailsByLot
    {
        public int PreShippingId { get; set; }
        public string Lot { get; set; }
        public string InternalIdNo { get; set; }
        public int PreShippingSubId { get; set; }
        public string UnitOfMeasure { get; set; }
        public double? LotQty { get; set; }
        public double? LotQtyConsumed { get; set; }
        public double? LotQtyPacked { get; set; }
        public string Consumed { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
