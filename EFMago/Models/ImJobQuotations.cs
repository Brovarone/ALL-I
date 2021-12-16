using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImJobQuotations
    {
        public ImJobQuotations()
        {
            ImJobQuotasAddCharges = new HashSet<ImJobQuotasAddCharges>();
            ImJobQuotasDetails = new HashSet<ImJobQuotasDetails>();
            ImJobQuotasDetailsVcl = new HashSet<ImJobQuotasDetailsVcl>();
            ImJobQuotasDocuments = new HashSet<ImJobQuotasDocuments>();
            ImJobQuotasNotes = new HashSet<ImJobQuotasNotes>();
            ImJobQuotasSections = new HashSet<ImJobQuotasSections>();
            ImJobQuotasSummByCompType = new HashSet<ImJobQuotasSummByCompType>();
            ImJobQuotasSummByCompTypeByWorkingStep = new HashSet<ImJobQuotasSummByCompTypeByWorkingStep>();
            ImJobQuotasTaxSummary = new HashSet<ImJobQuotasTaxSummary>();
            ImJobQuotasWorkingStep = new HashSet<ImJobQuotasWorkingStep>();
        }

        public int JobQuotationId { get; set; }
        public string Customer { get; set; }
        public string JobQuotationNo { get; set; }
        public string QuotationReference { get; set; }
        public DateTime? CreationDate { get; set; }
        public double? HourlyRate { get; set; }
        public double? MarkupPerc { get; set; }
        public string Specification { get; set; }
        public DateTime? ValidityEndingDate { get; set; }
        public string Contact { get; set; }
        public string UseContact { get; set; }
        public double? LabourMarkup { get; set; }
        public string UseSpecificationPrice { get; set; }
        public string Description { get; set; }
        public string Storage { get; set; }
        public DateTime? ExpectedStartingDate { get; set; }
        public DateTime? ExpectedEndingDate { get; set; }
        public DateTime? WorksEndingDate { get; set; }
        public string Simulation { get; set; }
        public DateTime? SimDate { get; set; }
        public string SimPurchaseRequestNo { get; set; }
        public int? SimPurchaseRequestId { get; set; }
        public int? OriginalJobQuotationId { get; set; }
        public string TaxCode { get; set; }
        public string Payment { get; set; }
        public string CustomerBank { get; set; }
        public string CompanyBank { get; set; }
        public string CompanyCurrentAccount { get; set; }
        public int? Presentation { get; set; }
        public string Language { get; set; }
        public string PriceList { get; set; }
        public string SendDocumentsTo { get; set; }
        public string SendPaymentsTo { get; set; }
        public string NetOfTax { get; set; }
        public string SalesPerson { get; set; }
        public string Currency { get; set; }
        public DateTime? FixingDate { get; set; }
        public double? Fixing { get; set; }
        public string FixingIsManual { get; set; }
        public string UnitValueIsCalculated { get; set; }
        public int? QuotationRequestId { get; set; }
        public string UseSpecificationQty { get; set; }
        public short JobQuotaRevNo { get; set; }
        public string JobQuotaFinal { get; set; }
        public int JobQuotaParentId { get; set; }
        public string EmployeeReference { get; set; }
        public string JobReference { get; set; }
        public string JobQuotaPreferentialRev { get; set; }
        public int? JobQuotaStatus { get; set; }
        public DateTime? AcceptanceDate { get; set; }
        public DateTime? AcquireProbabilityDate { get; set; }
        public double? AcquireProbabilityPerc { get; set; }
        public int? CrrefType { get; set; }
        public int? CrrefId { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public Guid? Tbguid { get; set; }
        public string JobQuotationGroup { get; set; }
        public string JobGroup { get; set; }

        public virtual ImJobQuotasSummary ImJobQuotasSummary { get; set; }
        public virtual ICollection<ImJobQuotasAddCharges> ImJobQuotasAddCharges { get; set; }
        public virtual ICollection<ImJobQuotasDetails> ImJobQuotasDetails { get; set; }
        public virtual ICollection<ImJobQuotasDetailsVcl> ImJobQuotasDetailsVcl { get; set; }
        public virtual ICollection<ImJobQuotasDocuments> ImJobQuotasDocuments { get; set; }
        public virtual ICollection<ImJobQuotasNotes> ImJobQuotasNotes { get; set; }
        public virtual ICollection<ImJobQuotasSections> ImJobQuotasSections { get; set; }
        public virtual ICollection<ImJobQuotasSummByCompType> ImJobQuotasSummByCompType { get; set; }
        public virtual ICollection<ImJobQuotasSummByCompTypeByWorkingStep> ImJobQuotasSummByCompTypeByWorkingStep { get; set; }
        public virtual ICollection<ImJobQuotasTaxSummary> ImJobQuotasTaxSummary { get; set; }
        public virtual ICollection<ImJobQuotasWorkingStep> ImJobQuotasWorkingStep { get; set; }
    }
}
