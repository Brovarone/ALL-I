using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaSubcontratorAnalysis
    {
        public int Moid { get; set; }
        public string Mono { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Wc { get; set; }
        public string Bom { get; set; }
        public string UoM { get; set; }
        public double? ProductionQty { get; set; }
        public double? ProducedQty { get; set; }
        public string Storage { get; set; }
        public string Supplier { get; set; }
        public double? ProcessingQuantity { get; set; }
        public string Component { get; set; }
        public double? NeededQty { get; set; }
        public string Operation { get; set; }
        public short RtgStep { get; set; }
        public string Outsourced { get; set; }
        public short? DnrtgStep { get; set; }
        public short AltRtgStep { get; set; }
        public string Alternate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string InternalOrdNo { get; set; }
        public string Customer { get; set; }
        public string Job { get; set; }
    }
}
