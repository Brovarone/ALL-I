using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImTmpJobQuotasTree
    {
        public string UserName { get; set; }
        public string ComputerName { get; set; }
        public string DocumentName { get; set; }
        public int JobQuotationId { get; set; }
        public short Section { get; set; }
        public short Line { get; set; }
        public short LineType { get; set; }
        public int ComponentType { get; set; }
        public string Component { get; set; }
        public string Description { get; set; }
        public int Position { get; set; }
        public string UoM { get; set; }
        public double? Quantity { get; set; }
        public double? Clquantity { get; set; }
        public int? TotalTime { get; set; }
        public double? BaseCost { get; set; }
        public double? FitValue { get; set; }
        public double? AccessoriesValue { get; set; }
        public double? DistributedChargesValue { get; set; }
        public double? TotalCost { get; set; }
        public double? MarkupValue { get; set; }
        public double? Amount { get; set; }
        public double? DiscountAmount { get; set; }
        public double? TaxableAmount { get; set; }
        public double? GoodsTotalAmount { get; set; }
        public double? ServicesTotalAmount { get; set; }
        public double? LabourTotalAmount { get; set; }
        public double? OtherTotalAmount { get; set; }
        public double? AddChargesTotalAmount { get; set; }
        public string Producer { get; set; }
        public string HomogeneousCtg { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
