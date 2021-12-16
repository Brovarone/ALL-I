using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaItemSuppliers
    {
        public MaItemSuppliers()
        {
            MaItemSuppliersOperations = new HashSet<MaItemSuppliersOperations>();
            MaItemSuppliersPriceLists = new HashSet<MaItemSuppliersPriceLists>();
        }

        public string Item { get; set; }
        public string Supplier { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierDescription { get; set; }
        public string Currency { get; set; }
        public double? StandardPrice { get; set; }
        public double? Discount1 { get; set; }
        public double? Discount2 { get; set; }
        public string DiscountFormula { get; set; }
        public double? LastDiscount1 { get; set; }
        public double? LastDiscount2 { get; set; }
        public string LastDiscountFormula { get; set; }
        public string LastPaymentTerm { get; set; }
        public double? LastPrice { get; set; }
        public string LastPriceCurrency { get; set; }
        public string LastPriceUoM { get; set; }
        public double? MinOrderQty { get; set; }
        public double? ShippingCost { get; set; }
        public double? AdditionalCharges { get; set; }
        public short? DaysForDelivery { get; set; }
        public string LastPurchaseDocNo { get; set; }
        public DateTime? LastPurchaseDocDate { get; set; }
        public double? LastPurchaseQty { get; set; }
        public double? LastPurchaseValue { get; set; }
        public string LastRmadocNo { get; set; }
        public DateTime? LastRmadocDate { get; set; }
        public double? LastRmaqty { get; set; }
        public double? LastRmavalue { get; set; }
        public string Notes { get; set; }
        public string Disabled { get; set; }
        public string PurchaseOffset { get; set; }
        public int? PostToInspection { get; set; }
        public string LastPurchaseDocType { get; set; }
        public string OutsrcPriceListUoM { get; set; }
        public Guid? Tbguid { get; set; }
        public string StandardPriceWithTax { get; set; }
        public string LastPriceWithTax { get; set; }
        public string UoMstandardPrice { get; set; }
        public string SpecificationsForSupplier { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ICollection<MaItemSuppliersOperations> MaItemSuppliersOperations { get; set; }
        public virtual ICollection<MaItemSuppliersPriceLists> MaItemSuppliersPriceLists { get; set; }
    }
}
