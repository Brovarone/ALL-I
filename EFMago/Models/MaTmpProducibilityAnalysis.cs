using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaTmpProducibilityAnalysis
    {
        public string UserName { get; set; }
        public string Computer { get; set; }
        public string Component { get; set; }
        public string Variant { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int Moid { get; set; }
        public short Line { get; set; }
        public string UoM { get; set; }
        public double? NeededQty { get; set; }
        public double? PickedQuantity { get; set; }
        public string PickingListNo { get; set; }
        public string Mono { get; set; }
        public string Storage { get; set; }
        public int? SpecificatorType { get; set; }
        public string Specificator { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
