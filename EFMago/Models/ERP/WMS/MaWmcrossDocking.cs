using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaWmcrossDocking
    {
        public string Storage { get; set; }
        public string Zone { get; set; }
        public int CrossDockingNumber { get; set; }
        public string Item { get; set; }
        public string Lot { get; set; }
        public int? SpecialStock { get; set; }
        public string SpecialStockCode { get; set; }
        public double? QtyBaseUoM { get; set; }
        public string InternalIdNo { get; set; }
        public string ConsignmentPartner { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
