using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImJobQuotasAddCharges
    {
        public int JobQuotationId { get; set; }
        public short Line { get; set; }
        public string AdditionalCharge { get; set; }
        public string Description { get; set; }
        public string BaseUoM { get; set; }
        public double? Quantity { get; set; }
        public double? UnitCost { get; set; }
        public double? MarkupPerc { get; set; }
        public double? TotalAmount { get; set; }
        public int? CompTypeDistributeOn { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ImJobQuotations JobQuotation { get; set; }
    }
}
