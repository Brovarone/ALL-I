using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaCustQuotasDetail
    {
        public short Line { get; set; }
        public int? LineType { get; set; }
        public string Description { get; set; }
        public string NoPrint { get; set; }
        public string NoCopyOnOrder { get; set; }
        public string Item { get; set; }
        public string Variant { get; set; }
        public string Drawing { get; set; }
        public string Department { get; set; }
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
        public int? SaleType { get; set; }
        public short? NoOfPacks { get; set; }
        public string PacksUoM { get; set; }
        public double? GrossWeight { get; set; }
        public double? NetWeight { get; set; }
        public double? GrossVolume { get; set; }
        public DateTime? QuotationDate { get; set; }
        public string Customer { get; set; }
        public string Contact { get; set; }
        public int CustQuotaId { get; set; }
        public short? KitNo { get; set; }
        public double? KitQty { get; set; }
        public short? DaysForDelivery { get; set; }
        public double? BookedQty { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }
        public short? Position { get; set; }
        public int? SubId { get; set; }
        public short? ExternalLineReference { get; set; }
        public string Job { get; set; }
        public string CostCenter { get; set; }
        public string ProductLine { get; set; }
        public int? ReferenceDocId { get; set; }
        public string ReferenceDocNo { get; set; }
        public string Notes { get; set; }
        public string PriceList { get; set; }
        public int? CrrefType { get; set; }
        public int? CrrefId { get; set; }
        public int? CrrefSubId { get; set; }
        public double? NetPrice { get; set; }
        public string NetPriceIsAuto { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public string InEi { get; set; }

        public virtual MaCustQuotas CustQuota { get; set; }
    }
}
