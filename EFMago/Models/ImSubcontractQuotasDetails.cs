﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImSubcontractQuotasDetails
    {
        public int SubcontractQuotationId { get; set; }
        public short Line { get; set; }
        public int? ComponentType { get; set; }
        public string Component { get; set; }
        public string Description { get; set; }
        public string Specification { get; set; }
        public string SpecificationItem { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public string UoM { get; set; }
        public double? Qty { get; set; }
        public double? OrderedQty { get; set; }
        public string Ordered { get; set; }
        public double? UnitCost { get; set; }
        public string DiscountFormula { get; set; }
        public double? Discount1 { get; set; }
        public double? Discount2 { get; set; }
        public double? DiscountAmount { get; set; }
        public double? TaxableAmount { get; set; }
        public string TaxCode { get; set; }
        public double? TotalAmount { get; set; }
        public string CostCenter { get; set; }
        public string Notes { get; set; }
        public string Job { get; set; }
        public short JobSection { get; set; }
        public int JobLineId { get; set; }
        public string JobWorkingStep { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ImSubcontractQuotations SubcontractQuotation { get; set; }
    }
}
