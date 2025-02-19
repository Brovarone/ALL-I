using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImSubcontractOrd
    {
        public ImSubcontractOrd()
        {
            ImSubcontractOrdDetails = new HashSet<ImSubcontractOrdDetails>();
            ImSubcontractOrdNotes = new HashSet<ImSubcontractOrdNotes>();
            ImSubcontractOrdReferences = new HashSet<ImSubcontractOrdReferences>();
            ImSubcontractOrdTaxSummary = new HashSet<ImSubcontractOrdTaxSummary>();
            ImSubcontractOrdWithholdingTax = new HashSet<ImSubcontractOrdWithholdingTax>();
            ImSubcontractOrdWpr = new HashSet<ImSubcontractOrdWpr>();
        }

        public int SubcontractOrdId { get; set; }
        public string SubcontractOrdNo { get; set; }
        public string ExternalOrdNo { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ExpectedTestDate { get; set; }
        public DateTime? ExpectedEndingDate { get; set; }
        public string Supplier { get; set; }
        public string Job { get; set; }
        public int? SubcontractOrdStatus { get; set; }
        public string Currency { get; set; }
        public DateTime? FixingDate { get; set; }
        public string FixingIsManual { get; set; }
        public double? Fixing { get; set; }
        public string Payment { get; set; }
        public string Cancelled { get; set; }
        public string Delivered { get; set; }
        public string Paid { get; set; }
        public string AccTpl { get; set; }
        public string AccGroup { get; set; }
        public string CostCenter { get; set; }
        public string ContractCode { get; set; }
        public string ProjectCode { get; set; }
        public string SupplierBank { get; set; }
        public string CompanyBank { get; set; }
        public string SupplierCa { get; set; }
        public string CompanyCa { get; set; }
        public string Language { get; set; }
        public string PaymentAddress { get; set; }
        public string TaxJournal { get; set; }
        public string TaxCode { get; set; }
        public string Description { get; set; }
        public string OurReference { get; set; }
        public string YourReference { get; set; }
        public string Notes { get; set; }
        public string Printed { get; set; }
        public DateTime? WithholdingPaymentDate { get; set; }
        public int? OriginCostsSubcontract { get; set; }
        public string CodeService { get; set; }
        public string NetOfTax { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public Guid? Tbguid { get; set; }

        public virtual ImSubcontractOrdSummary ImSubcontractOrdSummary { get; set; }
        public virtual ICollection<ImSubcontractOrdDetails> ImSubcontractOrdDetails { get; set; }
        public virtual ICollection<ImSubcontractOrdNotes> ImSubcontractOrdNotes { get; set; }
        public virtual ICollection<ImSubcontractOrdReferences> ImSubcontractOrdReferences { get; set; }
        public virtual ICollection<ImSubcontractOrdTaxSummary> ImSubcontractOrdTaxSummary { get; set; }
        public virtual ICollection<ImSubcontractOrdWithholdingTax> ImSubcontractOrdWithholdingTax { get; set; }
        public virtual ICollection<ImSubcontractOrdWpr> ImSubcontractOrdWpr { get; set; }
    }
}
