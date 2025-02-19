using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImSubcontractQuotations
    {
        public ImSubcontractQuotations()
        {
            ImSubcontractQuotasDetails = new HashSet<ImSubcontractQuotasDetails>();
            ImSubcontractQuotasNotes = new HashSet<ImSubcontractQuotasNotes>();
            ImSubcontractQuotasReferences = new HashSet<ImSubcontractQuotasReferences>();
            ImSubcontractQuotasTaxSummary = new HashSet<ImSubcontractQuotasTaxSummary>();
        }

        public int SubcontractQuotationId { get; set; }
        public string SubcontractQuotationNo { get; set; }
        public DateTime? SubcontractQuotaDate { get; set; }
        public string Supplier { get; set; }
        public string UseProspSupp { get; set; }
        public string ProspectiveSupplier { get; set; }
        public string SupplierDocNo { get; set; }
        public int? OriginDocType { get; set; }
        public string OriginDocNo { get; set; }
        public int? OriginDocId { get; set; }
        public int? SubcontractQuotaStatus { get; set; }
        public DateTime? ValidityEndingDate { get; set; }
        public string Currency { get; set; }
        public DateTime? FixingDate { get; set; }
        public string FixingIsManual { get; set; }
        public double? Fixing { get; set; }
        public string Payment { get; set; }
        public string SupplierBank { get; set; }
        public string CompanyBank { get; set; }
        public string SupplierCa { get; set; }
        public string CompanyCa { get; set; }
        public string CostCenter { get; set; }
        public string Language { get; set; }
        public string PaymentAddress { get; set; }
        public string ContractCode { get; set; }
        public string ProjectCode { get; set; }
        public string TaxCode { get; set; }
        public string Description { get; set; }
        public string OurReference { get; set; }
        public string YourReference { get; set; }
        public string Notes { get; set; }
        public string Printed { get; set; }
        public string NetOfTax { get; set; }
        public int? CrrefType { get; set; }
        public int? CrrefId { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public Guid? Tbguid { get; set; }

        public virtual ImSubcontractQuotasSummary ImSubcontractQuotasSummary { get; set; }
        public virtual ICollection<ImSubcontractQuotasDetails> ImSubcontractQuotasDetails { get; set; }
        public virtual ICollection<ImSubcontractQuotasNotes> ImSubcontractQuotasNotes { get; set; }
        public virtual ICollection<ImSubcontractQuotasReferences> ImSubcontractQuotasReferences { get; set; }
        public virtual ICollection<ImSubcontractQuotasTaxSummary> ImSubcontractQuotasTaxSummary { get; set; }
    }
}
