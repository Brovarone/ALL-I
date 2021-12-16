using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaCollectionParameters
    {
        public string SubjectToCollection { get; set; }
        public string CashOrderUponCollection { get; set; }
        public string AfterCollection { get; set; }
        public string BillOfExchUponCollection { get; set; }
        public string DduponCollection { get; set; }
        public string PanuponCollection { get; set; }
        public string CashOrderToBePresented { get; set; }
        public string BillOfExchToBePresented { get; set; }
        public string DdtoBePresented { get; set; }
        public string PantoBePresented { get; set; }
        public string CustClosingInPresentation { get; set; }
        public string UseApproval { get; set; }
        public string CustClosingOnBankAccount { get; set; }
        public string CustClosingInCollection { get; set; }
        public string TransferInPresentation { get; set; }
        public string CustClosingInInvoicing { get; set; }
        public string OutstandingAccount { get; set; }
        public string ChargesAccount { get; set; }
        public string OutstandingReopening { get; set; }
        public string BlockOutstandingCustomers { get; set; }
        public string OpenedAdmCasesManagement { get; set; }
        public string UsePymtScheduleBank { get; set; }
        public string ClosedInstallmentPresentable { get; set; }
        public string OneGllineForEachCustomer { get; set; }
        public string DebitBankForOutstanding { get; set; }
        public string OneGllineForEachBill { get; set; }
        public string ReopenTransferOnBillAccount { get; set; }
        public string VouchersManagement { get; set; }
        public string SlipWithDifferentPymtTerm { get; set; }
        public string UseBank { get; set; }
        public string Bank { get; set; }
        public string Ca { get; set; }
        public int? Presentation { get; set; }
        public string UseVouchersBank { get; set; }
        public string VouchersBank { get; set; }
        public string VouchersCa { get; set; }
        public int? VouchersPresentation { get; set; }
        public string BillsAreVouchers { get; set; }
        public int? Glnotes { get; set; }
        public string NotClosedInExposure { get; set; }
        public int CollectionParametersId { get; set; }
        public string TransInPresDebitBank { get; set; }
        public string PancustClosingInCollection { get; set; }
        public string ReopenAtDueDate { get; set; }
        public string UseFactoringBank { get; set; }
        public string FactoringBank { get; set; }
        public string FactoringCa { get; set; }
        public string FactoringToBePresented { get; set; }
        public string FactoringPresAccTpl { get; set; }
        public string FactoringPresAccRsn { get; set; }
        public string FactoringAdvAccTpl { get; set; }
        public string FactoringAdvAccRsn { get; set; }
        public string FactoringCollAccTpl { get; set; }
        public string FactoringCollAccRsn { get; set; }
        public string ReopeningAccTpl { get; set; }
        public string ReopeningAccRsn { get; set; }
        public string TaxExigibilityOnAdvance { get; set; }
        public int? ReopPymtTerm { get; set; }
        public string IssuedChecks { get; set; }
        public string AlignRcvblInstDateToBoleto { get; set; }
        public string DefaultBoletoBankCode { get; set; }
        public string DefaultBoletoBankCondition { get; set; }
        public int? SddmandateType { get; set; }
        public string ExcludeWithHoldingTax { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
