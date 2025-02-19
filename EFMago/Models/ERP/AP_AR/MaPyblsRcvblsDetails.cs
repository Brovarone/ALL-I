using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaPyblsRcvblsDetails
    {
        public int PymtSchedId { get; set; }
        public short InstallmentNo { get; set; }
        public int InstallmentType { get; set; }
        public int ClosingType { get; set; }
        public DateTime InstallmentDate { get; set; }
        public DateTime? OpeningDate { get; set; }
        public int? CustSuppType { get; set; }
        public string CustSupp { get; set; }
        public string Salesperson { get; set; }
        public int? PaymentTerm { get; set; }
        public int? DebitCreditSign { get; set; }
        public double? Amount { get; set; }
        public string Currency { get; set; }
        public DateTime? FixingDate { get; set; }
        public string FixingIsManual { get; set; }
        public double? Fixing { get; set; }
        public double? PayableAmountInBaseCurr { get; set; }
        public string OpenedAdmCases { get; set; }
        public string Closed { get; set; }
        public string Notes { get; set; }
        public string BillNo { get; set; }
        public DateTime? PresentationDate { get; set; }
        public string CustSuppBank { get; set; }
        public string PresentationBank { get; set; }
        public string Ca { get; set; }
        public string Cin { get; set; }
        public int? Presentation { get; set; }
        public string AtSight { get; set; }
        public string Outstanding { get; set; }
        public DateTime? ValueDate { get; set; }
        public int? PresentationJeid { get; set; }
        public int? JournalEntryId { get; set; }
        public string DebitCa { get; set; }
        public string Printed { get; set; }
        public string Presented { get; set; }
        public string NotPresentable { get; set; }
        public double? PresentationAmount { get; set; }
        public double? PresentationAmountBaseCurr { get; set; }
        public double? OutstandingAmount { get; set; }
        public double? OutstandingAmountBaseCurr { get; set; }
        public string Approved { get; set; }
        public string Collected { get; set; }
        public string Blocked { get; set; }
        public string Slip { get; set; }
        public int? DocumentId { get; set; }
        public int? DocumentType { get; set; }
        public string Advance { get; set; }
        public string PresentationNotes { get; set; }
        public DateTime? OutstandingDate { get; set; }
        public short? ReopeningInstallmentNo { get; set; }
        public string StatisticReason { get; set; }
        public string StatisticType { get; set; }
        public string CustomTariff { get; set; }
        public int? ChargesType { get; set; }
        public string BillCode { get; set; }
        public DateTime? CollectionDate { get; set; }
        public double? PresAmountWithWhtax { get; set; }
        public int? CollectionJeid { get; set; }
        public string Area { get; set; }
        public double? ApprovedAmount { get; set; }
        public double? ApprovedAmountBaseCurr { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public int? ApprovalJeid { get; set; }
        public DateTime? OpeningDateBeforePres { get; set; }
        public string PymtCash { get; set; }
        public string PymtAccount { get; set; }
        public string CostCenter { get; set; }
        public string SepacategoryPurpose { get; set; }
        public string MandateCode { get; set; }
        public int? MandateSequenceType { get; set; }
        public string ToBeCompensated { get; set; }
        public string CompensationNo { get; set; }
        public double? CompensationAmount { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public int? AmountType { get; set; }

        public virtual MaPyblsRcvbls PymtSched { get; set; }
    }
}
