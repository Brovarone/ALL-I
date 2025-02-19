using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaWmpreShippingDetails
    {
        public int PreShippingId { get; set; }
        public short PreShippingLine { get; set; }
        public int? PreShippingSubId { get; set; }
        public int? PreShippingParentSubId { get; set; }
        public int? SaleDocId { get; set; }
        public int? SaleDocSubId { get; set; }
        public int? CustSuppType { get; set; }
        public string CustSupp { get; set; }
        public string Storage { get; set; }
        public string Zone { get; set; }
        public string ReturnZone { get; set; }
        public string Item { get; set; }
        public string Description { get; set; }
        public string Lot { get; set; }
        public string UnitOfMeasure { get; set; }
        public double? Qty { get; set; }
        public double? PickingRequestQty { get; set; }
        public double? PickedQty { get; set; }
        public double? QtyToDeliver { get; set; }
        public double? QtyDelivered { get; set; }
        public double? QtyPacked { get; set; }
        public string Togenerated { get; set; }
        public string Toconfirmed { get; set; }
        public string DeliveryDocumentGenerated { get; set; }
        public string Packed { get; set; }
        public string Cancelled { get; set; }
        public DateTime? PreShippingDate { get; set; }
        public int? PreShippingType { get; set; }
        public string NotTransactable { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }
        public DateTime? ConfirmedDeliveryDate { get; set; }
        public string Carrier { get; set; }
        public string ShipToAddress { get; set; }
        public string Transport { get; set; }
        public string Port { get; set; }
        public string Package { get; set; }
        public string IsAbom { get; set; }
        public string CrossDocking { get; set; }
        public string Notes { get; set; }
        public string InternalIdNo { get; set; }
        public string NoPrint { get; set; }
        public string NoInvoice { get; set; }
        public string ConsignmentPartner { get; set; }
        public int? CrrefType { get; set; }
        public int? CrrefId { get; set; }
        public int? CrrefSubId { get; set; }
        public string CloseSaleOrd { get; set; }
        public string InvoiceTypes { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
