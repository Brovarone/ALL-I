using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaCustSuppTaxCommunication
    {
        public int CustSuppType { get; set; }
        public string CustSupp { get; set; }
        public short BalanceYear { get; set; }
        public string IsManual { get; set; }
        public DateTime OperationDate { get; set; }
        public string DocumentNumber { get; set; }
        public int? Jeid { get; set; }
        public string IsCreditNote { get; set; }
        public double? TotalAmount { get; set; }
        public double? TotalTaxAmount { get; set; }
        public int? GroupPaymentType { get; set; }
        public DateTime? CreditNoteOriginalDate { get; set; }
        public string CreditNoteOriginalNumber { get; set; }
        public double? CreditNoteOriginalAmount { get; set; }
        public double? CreditNoteOriginalTax { get; set; }
        public string DocumentNotes { get; set; }
        public Guid? Tbguid { get; set; }
        public string TaxCommunicationGroup { get; set; }
        public string CommunicationForm { get; set; }
        public DateTime? DocumentDate { get; set; }
        public string ReverseCharge { get; set; }
        public string SelfInvoice { get; set; }
        public string TaxNotShown { get; set; }
        public string Grouping { get; set; }
        public string SummaryDocuments { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
