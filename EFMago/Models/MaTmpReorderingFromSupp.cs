using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaTmpReorderingFromSupp
    {
        public string Supplier { get; set; }
        public string Item { get; set; }
        public string ReferenceDocNo { get; set; }
        public short Position { get; set; }
        public string Storage { get; set; }
        public int SpecificatorType { get; set; }
        public string Specificator { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Description { get; set; }
        public string BaseUoM { get; set; }
        public string UoM { get; set; }
        public double? OnHand { get; set; }
        public double? Reserved { get; set; }
        public double? Ordered { get; set; }
        public double? ReorderingLotSize { get; set; }
        public double? ToOrder { get; set; }
        public double? MinOrderQty { get; set; }
        public double? MinimumStock { get; set; }
        public double? Price { get; set; }
        public double? Discount1 { get; set; }
        public double? Discount2 { get; set; }
        public string DiscountFormula { get; set; }
        public double? TotalAmount { get; set; }
        public DateTime? CustDeliveryDate { get; set; }
        public DateTime? SuppDeliveryDate { get; set; }
        public int? SaleOrdId { get; set; }
        public string NotOrder { get; set; }
        public string Currency { get; set; }
        public double? PurchaseFixing { get; set; }
        public double? DiscountAmount { get; set; }
        public double? SupplierOrdered { get; set; }
        public string ReservationType { get; set; }
        public string Deselected { get; set; }
        public string Drawing { get; set; }
        public double? TotalAmountInBaseCurr { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
