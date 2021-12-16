using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaPyblsRcvblsParameters
    {
        public int PyblsRcvblsParametersId { get; set; }
        public string ConfirmPymtTerm { get; set; }
        public string NoBillsInClearing { get; set; }
        public string NoPymtOrdersInClearing { get; set; }
        public string TaxTransferInClearing { get; set; }
        public string CustomDescription1 { get; set; }
        public string CustomDescription2 { get; set; }
        public short? ReqForPymtMaxLevel { get; set; }
        public string ReqForPymtFile { get; set; }
        public string NoPaymentsToBlockedSupplier { get; set; }
        public string WtaxTransferInCollection { get; set; }
        public int? CustClearingPymtType { get; set; }
        public int? SuppClearingPymtType { get; set; }
        public string CustOverpymtEnabled { get; set; }
        public string SuppOverpymtEnabled { get; set; }
        public double? CustOverpymtAmount { get; set; }
        public double? SuppOverpymtAmount { get; set; }
        public string AdvancePaymentTerm { get; set; }
        public string NoSelBlockedInClearing { get; set; }
        public string NoSelLitigInClearing { get; set; }
        public string UnblockCustInClearing { get; set; }
        public string BillsAndPaymentsFolder { get; set; }
        public string BillsAndPaymentsExtension { get; set; }
        public string Calendar { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
