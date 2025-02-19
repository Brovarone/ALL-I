using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaBrnotaFiscalForCustShipping
    {
        public int SaleDocId { get; set; }
        public int? PickUpPointType { get; set; }
        public string PickUpPointCode { get; set; }
        public string PickUpPointBranch { get; set; }
        public int? DeliveryToType { get; set; }
        public string DeliveryToCode { get; set; }
        public string DeliveryToBranch { get; set; }
        public string ShippingFederalState { get; set; }
        public string ShippingPlace { get; set; }
        public string SpecificShippingPlace { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
