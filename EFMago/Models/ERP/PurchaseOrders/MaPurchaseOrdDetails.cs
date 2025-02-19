using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaPurchaseOrdDetails
    {
        public int PurchaseOrdId { get; set; }
        public short Line { get; set; }
        public short? Position { get; set; }
        public int? LineType { get; set; }
        public string Description { get; set; }
        public string NoPrint { get; set; }
        public string Item { get; set; }
        public string Drawing { get; set; }
        public string Supplier { get; set; }
        public DateTime? OrderDate { get; set; }
        public string UoM { get; set; }
        public double? Qty { get; set; }
        public double? AdditionalQty1 { get; set; }
        public double? AdditionalQty2 { get; set; }
        public double? AdditionalQty3 { get; set; }
        public double? AdditionalQty { get; set; }
        public double? UnitValue { get; set; }
        public double? TaxableAmount { get; set; }
        public string TaxCode { get; set; }
        public double? TotalAmount { get; set; }
        public double? Discount1 { get; set; }
        public double? Discount2 { get; set; }
        public string DiscountFormula { get; set; }
        public double? DiscountAmount { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }
        public DateTime? ConfirmedDeliveryDate { get; set; }
        public double? DeliveredQty { get; set; }
        public double? PaidQty { get; set; }
        public int? SaleType { get; set; }
        public string Paid { get; set; }
        public string Delivered { get; set; }
        public string Cancelled { get; set; }
        public string Lot { get; set; }
        public string SaleOrdNo { get; set; }
        public short? SaleOrdPos { get; set; }
        public string Job { get; set; }
        public string CostCenter { get; set; }
        public string Offset { get; set; }
        public int? PurchaseReqId { get; set; }
        public short? PurchaseReqPos { get; set; }
        public string PurchaseReqNo { get; set; }
        public string NoDn { get; set; }
        public string NoInvoice { get; set; }
        public int? SuppQuotaId { get; set; }
        public short? SuppQuotaLine { get; set; }
        public int? Moid { get; set; }
        public short? RtgStep { get; set; }
        public string Alternate { get; set; }
        public short? AltRtgStep { get; set; }
        public short? KitNo { get; set; }
        public double? KitQty { get; set; }
        public int? SubId { get; set; }
        public string StoragePhase1 { get; set; }
        public string StoragePhase2 { get; set; }
        public string SpecificatorPhase1 { get; set; }
        public string SpecificatorPhase2 { get; set; }
        public short? ExternalLineReference { get; set; }
        public int? ReferenceDocId { get; set; }
        public string ReferenceDocNo { get; set; }
        public short? NoOfPacks { get; set; }
        public string PacksUoM { get; set; }
        public double? GrossWeight { get; set; }
        public double? NetWeight { get; set; }
        public double? GrossVolume { get; set; }
        public int? SaleOrdId { get; set; }
        public int? DefaultValueType { get; set; }
        public int? DiscountDefaultType { get; set; }
        public string Notes { get; set; }
        public string FixedCost { get; set; }
        public string ProductLine { get; set; }
        public string SupplierCode { get; set; }
        public string Department { get; set; }
        public string ConfirmationNum { get; set; }
        public DateTime? PreviousConfirmedDeliveryDate { get; set; }
        public string ExtendedNotes { get; set; }
        public string Receipt { get; set; }
        public double? ReceiptQty { get; set; }
        public double? ReceiptAndDeliveredQty { get; set; }
        public int? CrrefType { get; set; }
        public int? CrrefId { get; set; }
        public int? CrrefSubId { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public string ImJobWorkingStep { get; set; }
        public int? ImDeliveryRequestId { get; set; }
        public short? ImDelReqLine { get; set; }

        public virtual MaPurchaseOrd PurchaseOrd { get; set; }
    }
}
