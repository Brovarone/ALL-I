using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaTmpSaleOrdFulfilment
    {
        public int SaleOrdId { get; set; }
        public short Line { get; set; }
        public int? LineType { get; set; }
        public short? Position { get; set; }
        public string Description { get; set; }
        public string Item { get; set; }
        public string UoM { get; set; }
        public double? Qty { get; set; }
        public double? UnitValue { get; set; }
        public double? TaxableAmount { get; set; }
        public string TaxCode { get; set; }
        public double? TotalAmount { get; set; }
        public double? Discount1 { get; set; }
        public double? Discount2 { get; set; }
        public string DiscountFormula { get; set; }
        public double? DiscountAmount { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }
        public string CloseSaleOrdPos { get; set; }
        public short? Priority { get; set; }
        public string Customer { get; set; }
        public string SaleOrdNo { get; set; }
        public int? SubId { get; set; }
        public string UserName { get; set; }
        public string Computer { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
