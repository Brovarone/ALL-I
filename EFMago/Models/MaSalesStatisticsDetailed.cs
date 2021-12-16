using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaSalesStatisticsDetailed
    {
        public string CustSupp { get; set; }
        public int CustSuppType { get; set; }
        public string CompanyName { get; set; }
        public string Account { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string IsocountryCode { get; set; }
        public string PriceList { get; set; }
        public string Disabled { get; set; }
        public string Payment { get; set; }
        public string ExternalCode { get; set; }
        public string Category { get; set; }
        public string Area { get; set; }
        public string Salesperson { get; set; }
        public double? TaxableAmount { get; set; }
        public double? GoodsAmount { get; set; }
        public double? ServiceAmounts { get; set; }
        public double? DiscountOnGoods { get; set; }
        public double? DiscountOnServices { get; set; }
        public double? FreeSamples { get; set; }
        public double? Discounts { get; set; }
        public double? Allowances { get; set; }
        public double? PackagingCharges { get; set; }
        public double? ShippingCharges { get; set; }
        public double? StampsCharges { get; set; }
        public double? CollectionCharges { get; set; }
        public double? AdditionalCharges { get; set; }
        public double? Contributions { get; set; }
        public int? DocumentType { get; set; }
        public string DocNo { get; set; }
        public DateTime? DocumentDate { get; set; }
        public DateTime? DepartureDate { get; set; }
        public string Currency { get; set; }
        public DateTime? FixingDate { get; set; }
        public string FixingIsManual { get; set; }
        public double? Fixing { get; set; }
        public string AreaManager { get; set; }
        public string AccTpl { get; set; }
        public string TaxJournal { get; set; }
        public string Issued { get; set; }
        public string PostedToAccounting { get; set; }
        public int SaleDocId { get; set; }
        public string InvRsn { get; set; }
        public string StubBook { get; set; }
        public string StoragePhase1 { get; set; }
        public string StoragePhase2 { get; set; }
        public string Job { get; set; }
        public string CostCenter { get; set; }
        public string DocumentPymt { get; set; }
        public string DocumentPriceList { get; set; }
        public string DocumentArea { get; set; }
        public string DocumentSalesperson { get; set; }
        public string ItemType { get; set; }
        public string CommodityCtg { get; set; }
        public string HomogeneousCtg { get; set; }
        public string CommissionCtg { get; set; }
        public string ProductCtg { get; set; }
        public int? LineType { get; set; }
        public string Description { get; set; }
        public string Item { get; set; }
        public string Department { get; set; }
        public double? LineTaxableAmount { get; set; }
        public string TaxCode { get; set; }
        public double? TotalAmount { get; set; }
        public string Offset { get; set; }
        public int? SaleType { get; set; }
        public string CombinedNomenclature { get; set; }
        public string Contribution { get; set; }
        public double? LineDiscountAmount { get; set; }
        public string LineJob { get; set; }
        public string LineCenterCost { get; set; }
    }
}
