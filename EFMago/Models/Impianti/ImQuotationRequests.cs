using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImQuotationRequests
    {
        public ImQuotationRequests()
        {
            ImQuotaRequestsDocuments = new HashSet<ImQuotaRequestsDocuments>();
            ImQuotaRequestsNotes = new HashSet<ImQuotaRequestsNotes>();
            ImQuotaRequestsReferences = new HashSet<ImQuotaRequestsReferences>();
        }

        public int QuotationRequestId { get; set; }
        public string QuotationRequestNo { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Customer { get; set; }
        public string Contact { get; set; }
        public string UseContact { get; set; }
        public DateTime? ValidityEndingDate { get; set; }
        public string RequestReference { get; set; }
        public string Description { get; set; }
        public string DetailedDescription { get; set; }
        public string Specification { get; set; }
        public string QuotationIsIssued { get; set; }
        public DateTime? FeasibilityDate { get; set; }
        public string FeasibilityManager { get; set; }
        public string Feasible { get; set; }
        public string Note { get; set; }
        public string QuotationManager { get; set; }
        public string CustomerBank { get; set; }
        public string CompanyBank { get; set; }
        public string CompanyCurrentAccount { get; set; }
        public string SendDocumentsTo { get; set; }
        public string SendPaymentsTo { get; set; }
        public string Language { get; set; }
        public string PriceList { get; set; }
        public string TaxCode { get; set; }
        public string NetOfTax { get; set; }
        public string Closed { get; set; }
        public string CustomerReference { get; set; }
        public string CustomerRefPerson { get; set; }
        public string Printed { get; set; }
        public string CustomerEngineer { get; set; }
        public int? QuotationRequestStatus { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public Guid? Tbguid { get; set; }

        public virtual ICollection<ImQuotaRequestsDocuments> ImQuotaRequestsDocuments { get; set; }
        public virtual ICollection<ImQuotaRequestsNotes> ImQuotaRequestsNotes { get; set; }
        public virtual ICollection<ImQuotaRequestsReferences> ImQuotaRequestsReferences { get; set; }
    }
}
