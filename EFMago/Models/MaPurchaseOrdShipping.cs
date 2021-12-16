﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaPurchaseOrdShipping
    {
        public int PurchaseOrdId { get; set; }
        public string Port { get; set; }
        public string Shipping { get; set; }
        public string Package { get; set; }
        public string Carrier1 { get; set; }
        public string Carrier2 { get; set; }
        public string Carrier3 { get; set; }
        public int? ShipToCustSuppType { get; set; }
        public string ShipToCustSupp { get; set; }
        public string ShipToAddress { get; set; }
        public string Transport { get; set; }
        public string NoOfPacksIsAuto { get; set; }
        public string NetWeightIsAuto { get; set; }
        public string GrossWeightIsAuto { get; set; }
        public string GrossVolumeIsAuto { get; set; }
        public short? NoOfPacks { get; set; }
        public double? NetWeight { get; set; }
        public double? GrossWeight { get; set; }
        public double? GrossVolume { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaPurchaseOrd PurchaseOrd { get; set; }
    }
}
