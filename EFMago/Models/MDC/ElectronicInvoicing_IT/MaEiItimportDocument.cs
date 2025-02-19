using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaEiItimportDocument
    {
        public int DocumentId { get; set; }
        public string DocumentXml { get; set; }
        public int? DocumentStatus { get; set; }
        public string SupplierCode { get; set; }
        public string Payment { get; set; }
        public string AccountingTemplate { get; set; }
        public DateTime? ReceiptDate { get; set; }
        public int? PostIn { get; set; }
        public int? Iddoc { get; set; }
        public string DocType { get; set; }
        public DateTime? DocDate { get; set; }
        public string DocNo { get; set; }
        public string DocCurr { get; set; }
        public double? TotalAmount { get; set; }
        public string TaxIdNumber { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string CityCounty { get; set; }
        public string DocIdDh { get; set; }
        public string TakenOver { get; set; }
        public string Idsdi { get; set; }
        public string HashSdi { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public DateTime? FirstDueDate { get; set; }
        public string FirstPaymentType { get; set; }
        public string PaymentTermInvoice { get; set; }
    }
}
