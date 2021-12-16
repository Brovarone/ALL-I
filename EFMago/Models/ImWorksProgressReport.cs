using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImWorksProgressReport
    {
        public ImWorksProgressReport()
        {
            ImWprdetails = new HashSet<ImWprdetails>();
            ImWprreferences = new HashSet<ImWprreferences>();
            ImWprwithholdingTax = new HashSet<ImWprwithholdingTax>();
        }

        public int Wprid { get; set; }
        public string Wprno { get; set; }
        public string Description { get; set; }
        public string Job { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Note { get; set; }
        public string Invoiced { get; set; }
        public int? GeneratedDocType { get; set; }
        public double? TotalAmount { get; set; }
        public double? CollectedTotalAmount { get; set; }
        public double? WithholdingTaxTotalAmount { get; set; }
        public double? CollectingTotalAmount { get; set; }
        public double? WithholdingTaxTaxableAmount { get; set; }
        public double? InvoicingTaxableAmount { get; set; }
        public double? TaxTotalAmount { get; set; }
        public double? InvoiceTotalAmount { get; set; }
        public int? InvoiceId { get; set; }
        public string TaxCode { get; set; }
        public string Offset { get; set; }
        public string TaxJournal { get; set; }
        public string AccTpl { get; set; }
        public string Payment { get; set; }
        public string InvoiceDescriptionLine1 { get; set; }
        public string InvoiceDescriptionLine2 { get; set; }
        public string InvoiceDescriptionLine3 { get; set; }
        public string Currency { get; set; }
        public DateTime? FixingDate { get; set; }
        public double? Fixing { get; set; }
        public string FixingIsManual { get; set; }
        public double? TaxableAmountDocCurr { get; set; }
        public double? TaxAmountDocCurr { get; set; }
        public double? InvoicedTotalAmountBaseCurr { get; set; }
        public double? CollectingTotalAmountBaseCurr { get; set; }
        public string DiscountFormula { get; set; }
        public double? Discount1 { get; set; }
        public double? Discount2 { get; set; }
        public double? DiscountedTotalAmount { get; set; }
        public double? ParentJobTotalAmount { get; set; }
        public double? VariantJobTotalAmount { get; set; }
        public double? OatambjobTotalAmount { get; set; }
        public string InvoiceWillNotFollow { get; set; }
        public string EnablesRowChange { get; set; }
        public DateTime? InvoicePreviewDate { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public Guid? Tbguid { get; set; }

        public virtual ICollection<ImWprdetails> ImWprdetails { get; set; }
        public virtual ICollection<ImWprreferences> ImWprreferences { get; set; }
        public virtual ICollection<ImWprwithholdingTax> ImWprwithholdingTax { get; set; }
    }
}
