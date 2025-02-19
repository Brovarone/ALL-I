using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaPurchasesParameters
    {
        public int PurchasesParametersId { get; set; }
        public string NoLoadsFromBlockedSupplier { get; set; }
        public string NoPaymentsToBlockedSupplier { get; set; }
        public string CloseOrdOnlyForConforming { get; set; }
        public string ZeroAmountInvoice { get; set; }
        public string WarnNoPrintedLine { get; set; }
        public string BalanceTaxSummaryBaseCurr { get; set; }
        public string BalanceEutaxSummaryDocCurr { get; set; }
        public string GeneratePymtSchedInBaseCurr { get; set; }
        public string ServicesOnBillOfLading { get; set; }
        public string ShowSf { get; set; }
        public string ConsistencyCheckIsAuto { get; set; }
        public string DescriptiveLinesAreDelivered { get; set; }
        public string UseAdditionalSupplierCharges { get; set; }
        public string InvoiceNoUpdateLastData { get; set; }
        public int? CombNomenclatureCheckType { get; set; }
        public string WarningMaximumStock { get; set; }
        public string ReceiptBl { get; set; }
        public string RecepitBoth { get; set; }
        public string ReceiptInv { get; set; }
        public string DiffNothing { get; set; }
        public string DiffBlinv { get; set; }
        public string DiffCorrBl { get; set; }
        public int? ReturnToSupplierQtyCheck { get; set; }
        public int? InvoiceQtyCheck { get; set; }
        public int? ClearingBoLcheck { get; set; }
        public string PureJecollectionPaymentMng { get; set; }
        public string NegativeValueInLedgerCard { get; set; }
        public string LoadInvEntryNetOfDiscount { get; set; }
        public int? FreeBorderDefault { get; set; }
        public string InvEntryOnlyValueInNdC { get; set; }
        public int? InvEntryOnlyValueInNdCprop { get; set; }
        public string InsAnalPar { get; set; }
        public string AllowOnlyItemOfKindPurchase { get; set; }
        public string PurchaseOrderRowFulfillment { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
