using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ChimiOrdinatoConsegnato
    {
        public short? Position { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? MaPurchaseOrdDetailsLineType { get; set; }
        public string MaPurchaseOrdDetailsItem { get; set; }
        public double? MaPurchaseOrdDetailsQty { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }
        public int? ExpectedDeliveryYear { get; set; }
        public int? ExpectedDeliveryMonth { get; set; }
        public double? DeliveredQty { get; set; }
        public string Delivered { get; set; }
        public string Cancelled { get; set; }
        public string MaPurchaseOrdDetailsSupplier { get; set; }
        public double? MaPurchaseOrdDetailsTaxableAmount { get; set; }
        public int? DocumentType { get; set; }
        public string MaPurchaseDocSupplier { get; set; }
        public DateTime? SupplierDocDate { get; set; }
        public int? PurchaseOrdId { get; set; }
        public string PurchaseOrdNo { get; set; }
        public int? AnnoEffettivaConsegna { get; set; }
        public int? MeseEffettivaConsegna { get; set; }
        public short? PurchaseOrdPos { get; set; }
        public int? MaPurchaseDocDetailLineType { get; set; }
        public string MaPurchaseDocDetailItem { get; set; }
        public double? MaPurchaseDocDetailQty { get; set; }
        public double? MaPurchaseDocDetailTaxableAmount { get; set; }
    }
}
