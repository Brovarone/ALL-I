using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaTaxDefaults
    {
        public string Purchases { get; set; }
        public string Sales { get; set; }
        public string RetailSales { get; set; }
        public string RetailSalesToBeDistributed { get; set; }
        public string SuspendedSales { get; set; }
        public string SuspendedPurchases { get; set; }
        public string TaxToPayOrReceive { get; set; }
        public string FreeSamples { get; set; }
        public int TaxDefaultsId { get; set; }
        public string Rounding { get; set; }
        public string RoundingAccRsn { get; set; }
        public string TaxToReceive { get; set; }
        public string SalesSplitPayment { get; set; }
        public double? PaymentLimit { get; set; }
        public double? BalanceLimit { get; set; }
        public string CashAccountFrom { get; set; }
        public string CashAccountTo { get; set; }
        public string SalesJournalCode { get; set; }
        public string SalesGoodsJournalCode { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public string ExigiblePurchases { get; set; }
        public string ExigibleSales { get; set; }
    }
}
