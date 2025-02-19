using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaItemsWms
    {
        public string Item { get; set; }
        public string SutpreShipping { get; set; }
        public string SutpreShippingUoM { get; set; }
        public double? SutpreShippingQty { get; set; }
        public string Category { get; set; }
        public string CategoryForPutaway { get; set; }
        public string HazardousMaterial { get; set; }
        public string PrintBarcodeInGr { get; set; }
        public string ScanItemInPicking { get; set; }
        public string CrossDocking { get; set; }
        public string ConsignmentPartner { get; set; }
        public string UsedInWmsmobile { get; set; }
        public string ScanItemInPutaway { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
