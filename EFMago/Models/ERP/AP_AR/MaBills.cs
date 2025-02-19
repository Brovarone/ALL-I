using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaBills
    {
        public string BillCode { get; set; }
        public string FiscalNo { get; set; }
        public int? BillType { get; set; }
        public string Description { get; set; }
        public string IssuerName { get; set; }
        public string IssuerBank { get; set; }
        public string IssuePlace { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? DueDate { get; set; }
        public double? Amount { get; set; }
        public string Customer { get; set; }
        public string Supplier { get; set; }
        public string PresentationBank { get; set; }
        public string PresentationCa { get; set; }
        public int? BillStatus { get; set; }
        public DateTime? ReceiptDate { get; set; }
        public DateTime? PresentationDate { get; set; }
        public DateTime? CollectionDate { get; set; }
        public DateTime? OutstandingDate { get; set; }
        public DateTime? TransferDate { get; set; }
        public int? ReceiptJeid { get; set; }
        public int? CollectionJeid { get; set; }
        public int? OutstandingJeid { get; set; }
        public int? TransferJeid { get; set; }
        public string IsAnIssuedBill { get; set; }
        public string IssuerBankCa { get; set; }
        public string IssuerTaxIdNumber { get; set; }
        public string IssuerFiscalCode { get; set; }
        public string Return1Reason { get; set; }
        public DateTime? Return1Date { get; set; }
        public DateTime? RePresentationDate { get; set; }
        public string Return2Reason { get; set; }
        public DateTime? Return2Date { get; set; }
        public int? PresentationJeid { get; set; }
        public int? Return1Jeid { get; set; }
        public int? Return2Jeid { get; set; }
        public int? RePresentationJeid { get; set; }
        public string IsAblankCheck { get; set; }
        public string Disabled { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
