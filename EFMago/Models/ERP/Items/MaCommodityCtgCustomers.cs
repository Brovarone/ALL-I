using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaCommodityCtgCustomers
    {
        public MaCommodityCtgCustomers()
        {
            MaCommodityCtgCustomersBudget = new HashSet<MaCommodityCtgCustomersBudget>();
        }

        public string Category { get; set; }
        public string Customer { get; set; }
        public double? Discount1 { get; set; }
        public double? Discount2 { get; set; }
        public string DiscountFormula { get; set; }
        public double? LastDiscount1 { get; set; }
        public double? LastDiscount2 { get; set; }
        public string LastDiscountFormula { get; set; }
        public string LastPaymentTerm { get; set; }
        public double? MinOrderQty { get; set; }
        public double? ShippingCost { get; set; }
        public double? AdditionalCharges { get; set; }
        public short? DaysForDelivery { get; set; }
        public string LastSaleDocNo { get; set; }
        public DateTime? LastSaleDocDate { get; set; }
        public double? LastSaleQty { get; set; }
        public double? LastSaleValue { get; set; }
        public string LastRmadocNo { get; set; }
        public DateTime? LastRmadocDate { get; set; }
        public double? LastRmaqty { get; set; }
        public double? LastRmavalue { get; set; }
        public string Notes { get; set; }
        public string Disabled { get; set; }
        public string LastSaleDocType { get; set; }
        public string SaleOffset { get; set; }
        public Guid? Tbguid { get; set; }
        public string PriceList { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ICollection<MaCommodityCtgCustomersBudget> MaCommodityCtgCustomersBudget { get; set; }
    }
}
