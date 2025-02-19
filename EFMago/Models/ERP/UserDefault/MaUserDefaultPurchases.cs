using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaUserDefaultPurchases
    {
        public string Branch { get; set; }
        public int WorkerId { get; set; }
        public string Storage { get; set; }
        public string InvoiceAccRsn { get; set; }
        public string CreditNoteAccRsn { get; set; }
        public string BillsOfLadingInvRsn { get; set; }
        public string BillOfLadingInvRsn { get; set; }
        public string InvoiceGoodReceiptInvRsn { get; set; }
        public string InspectionReceiptInvRsn { get; set; }
        public string ScrapInvRsn { get; set; }
        public string ReturnMaterialInvRsn { get; set; }
        public string ReturnedMaterialInvRsn { get; set; }
        public string InvoiceAccTpl { get; set; }
        public string EuinvoiceAccTpl { get; set; }
        public string SuspInvoiceAccTpl { get; set; }
        public string CreditNoteAccTpl { get; set; }
        public string EucreditNoteAccTpl { get; set; }
        public string SuspCreditNoteAccTpl { get; set; }
        public string StampsCharges { get; set; }
        public string StampsTaxAmount { get; set; }
        public string CollectionCharges { get; set; }
        public string CollectionTaxAmount { get; set; }
        public string PackagingCharges { get; set; }
        public string ShippingCharges { get; set; }
        public string AdditionalCharges { get; set; }
        public string ShippingTaxCode { get; set; }
        public string GoodCosts { get; set; }
        public string ServiceCosts { get; set; }
        public string AdditionalCosts { get; set; }
        public string FreeSamples { get; set; }
        public string Advance { get; set; }
        public string CorrectionInvoiceAccTpl { get; set; }
        public string InvoiceCorrectionRsn { get; set; }
        public string CreditNoteInvRsn { get; set; }
        public string CorrInvoiceAccRsn { get; set; }
        public string CorrEuinvoiceAccTpl { get; set; }
        public string CorrSuspInvoiceAccTpl { get; set; }
        public string PurchInvoiceForAdvanceAccTpl { get; set; }
        public string InvoiceForAdvanceAccount { get; set; }
        public string DebitNoteAccTpl { get; set; }
        public string DebitNoteEuaccTpl { get; set; }
        public string DebitNoteSuspAccTpl { get; set; }
        public string DebitNoteAccRsn { get; set; }
        public string DebitNoteInvRsn { get; set; }
        public string ProtocolAccTpl { get; set; }
        public string ProtocolCnaccTpl { get; set; }
        public string ProtocolDnaccTpl { get; set; }
        public string ProtocolAccRsn { get; set; }
        public string InspNotesConformingInvRsn { get; set; }
        public string InspNotesScrapInvRsn { get; set; }
        public string InspNotesRtsinvRsn { get; set; }
        public string InspectionManufInvRsn { get; set; }
        public string InvoiceValueInvRsn { get; set; }
        public string ExtraEuinvoiceAccTpl { get; set; }
        public string ExtraEucreditNoteAccTpl { get; set; }
        public string CorrExtraEuinvoiceAccTpl { get; set; }
        public string DebitNoteExtraEuaccTpl { get; set; }
        public string ReverseChargeAccTpl { get; set; }
        public string ReverseChargeCnaccTpl { get; set; }
        public string AdvanceAccRsn { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
