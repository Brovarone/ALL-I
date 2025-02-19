using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImTmpJobQuotasDetails
    {
        public string UserName { get; set; }
        public string ComputerName { get; set; }
        public int JobQuotationId { get; set; }
        public short ReportPosition { get; set; }
        public short? Section { get; set; }
        public short? Line { get; set; }
        public int? ComponentType { get; set; }
        public string Component { get; set; }
        public string BaseUoM { get; set; }
        public double? Quantity { get; set; }
        public double? Price { get; set; }
        public double? QuotedTotalAmount { get; set; }
        public string Specification { get; set; }
        public string SpecificationItem { get; set; }
        public short? Position { get; set; }
        public string FromJobQuotation { get; set; }
        public string Printing { get; set; }
        public int? UnitTime { get; set; }
        public int? TotalTime { get; set; }
        public short? Level { get; set; }
        public double? UnitValue { get; set; }
        public string DiscountFormula { get; set; }
        public string TaxCode { get; set; }
        public int? LineType { get; set; }
        public string Description { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
