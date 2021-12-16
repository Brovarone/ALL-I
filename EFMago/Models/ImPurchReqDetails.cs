using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImPurchReqDetails
    {
        public int PurchaseRequestId { get; set; }
        public short Line { get; set; }
        public short? Position { get; set; }
        public int? OriginDocType { get; set; }
        public string OriginDocNo { get; set; }
        public int? OriginDocId { get; set; }
        public int? ComponentType { get; set; }
        public string Item { get; set; }
        public string Description { get; set; }
        public string UoM { get; set; }
        public double? Quantity { get; set; }
        public int? ValueType { get; set; }
        public int? SuppQuotaId { get; set; }
        public string SuppQuotaNo { get; set; }
        public double? DiscountValueOnQuota { get; set; }
        public double? AllowancesAmountOnQuota { get; set; }
        public double? UnitValue { get; set; }
        public double? TotalValue { get; set; }
        public int? DiscountType { get; set; }
        public double? Discount1 { get; set; }
        public double? Discount2 { get; set; }
        public string DiscountFormula { get; set; }
        public double? DiscountAmount { get; set; }
        public double? TaxableAmount { get; set; }
        public string TaxCode { get; set; }
        public double? TaxAmount { get; set; }
        public double? Amount { get; set; }
        public string Simulation { get; set; }
        public string PurchaseRequestNo { get; set; }
        public string Producer { get; set; }
        public string ProductCtg { get; set; }
        public string ProductSubCtg { get; set; }
        public string Supplier { get; set; }
        public string Ordering { get; set; }
        public string Ordered { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }
        public double? ExpectedCost { get; set; }
        public string SimulationWillNotFollow { get; set; }
        public string PurchReqWillNotFollow { get; set; }
        public double? JobQty { get; set; }
        public double? PickedQty { get; set; }
        public string JobWorkingStep { get; set; }
        public string Notes { get; set; }
        public int? CrrefType { get; set; }
        public int? CrrefId { get; set; }
        public short? CrrefLine { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ImPurchaseRequest PurchaseRequest { get; set; }
    }
}
