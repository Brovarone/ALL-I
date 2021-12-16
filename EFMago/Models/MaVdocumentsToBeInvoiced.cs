using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaVdocumentsToBeInvoiced
    {
        public int SaleDocId { get; set; }
        public string CustSupp { get; set; }
        public string InvoicingCustomer { get; set; }
        public string Job { get; set; }
        public string ContractCode { get; set; }
        public string ProjectCode { get; set; }
        public string TaxCommunicationGroup { get; set; }
        public string ShippingReason { get; set; }
        public int? ProFormaInvoiceId { get; set; }
        public string SendDocumentsTo { get; set; }
        public string Currency { get; set; }
        public string InvoicingTaxJournal { get; set; }
        public string InvoicingAccTpl { get; set; }
        public string InvoicingAccGroup { get; set; }
        public string NoChangeExigibility { get; set; }
        public string Salesperson { get; set; }
        public string AreaManager { get; set; }
        public string SalespersonPolicy { get; set; }
        public string AreaManagerPolicy { get; set; }
        public string SalespersonCommAuto { get; set; }
        public string AreaManagerCommAuto { get; set; }
        public string Area { get; set; }
        public string SalespersonCommPercAuto { get; set; }
        public string AreaManagerCommPercAuto { get; set; }
        public string DiscountFormula { get; set; }
        public DateTime? DepartureDate { get; set; }
        public string InvRsn { get; set; }
        public string ShipToAddress { get; set; }
        public int? CustSuppType { get; set; }
        public string StubBook { get; set; }
        public DateTime? DocumentDate { get; set; }
        public string DocNo { get; set; }
        public int? DocumentType { get; set; }
        public string Issued { get; set; }
        public string InvoiceFollows { get; set; }
        public string Summarized { get; set; }
        public string CorrectionDocument { get; set; }
        public string InvoiceTypes { get; set; }
        public int SaleDocIdDetail { get; set; }
        public int? SubId { get; set; }
        public short Line { get; set; }
        public int? LineType { get; set; }
        public int? PerishablesType { get; set; }
        public double? DistributedDiscount { get; set; }
        public double? DistributedShipCharges { get; set; }
        public double? DistributedAdvanceAmount { get; set; }
        public double? DistributedAdvanceAmount2 { get; set; }
        public double? DistributedAdvanceAmount3 { get; set; }
        public double? DistributedAllowances { get; set; }
        public string Payment { get; set; }
        public string PaymentForBreak { get; set; }
    }
}
