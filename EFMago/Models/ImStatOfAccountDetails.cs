using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImStatOfAccountDetails
    {
        public int StatOfAccountId { get; set; }
        public short Line { get; set; }
        public int? ComponentType { get; set; }
        public string Component { get; set; }
        public string Description { get; set; }
        public double? Quantity { get; set; }
        public string UoM { get; set; }
        public int? InvoicingTime { get; set; }
        public double? Value { get; set; }
        public double? MarkupUnitValue { get; set; }
        public double? MarkupPerc { get; set; }
        public double? MarkupAmount { get; set; }
        public double? Discount1 { get; set; }
        public double? Discount2 { get; set; }
        public string DiscountFormula { get; set; }
        public double? DiscountAmount { get; set; }
        public double? LineAmount { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Job { get; set; }
        public int? TypeHourly { get; set; }
        public double? Cost { get; set; }
        public double? LineCost { get; set; }
        public int? CostificationType { get; set; }
        public int? EvaluationType { get; set; }
        public string NoPrint { get; set; }
        public string NoToInvoice { get; set; }
        public string Note { get; set; }
        public int? DocId { get; set; }
        public int? DocType { get; set; }
        public string Internalnote { get; set; }
        public int? CrrefType { get; set; }
        public int? CrrefId { get; set; }
        public short? CrrefLine { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ImStatOfAccount StatOfAccount { get; set; }
    }
}
