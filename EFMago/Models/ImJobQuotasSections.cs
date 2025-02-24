﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImJobQuotasSections
    {
        public int JobQuotationId { get; set; }
        public short Section { get; set; }
        public string Description { get; set; }
        public int? TotalTime { get; set; }
        public double? PriceTotalAmount { get; set; }
        public double? GoodsCostTotalAmount { get; set; }
        public double? MarkupTotalAmount { get; set; }
        public double? LabourCostTotalAmount { get; set; }
        public double? DistribExpensesTotalAmount { get; set; }
        public double? SpecificationTotalAmount { get; set; }
        public double? QuotedTotalAmount { get; set; }
        public double? CostSubtotalAmount { get; set; }
        public double? FitCostSubtotalAmount { get; set; }
        public double? PricesSubtotalAmount { get; set; }
        public double? ValueSubtotalAmount { get; set; }
        public double? PerformanceSubtotalAmount { get; set; }
        public double? AccessoriesSubtotalAmount { get; set; }
        public double? FitValueSubtotalAmount { get; set; }
        public double? MarkupSubtotalAmount { get; set; }
        public double? DiscountSubtotalAmount { get; set; }
        public string UnitValueIsCalculated { get; set; }
        public string TaxCode { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ImJobQuotations JobQuotation { get; set; }
    }
}
