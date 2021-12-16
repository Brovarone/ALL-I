using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaVpaymentScheduleSplitTax
    {
        public string DocNo { get; set; }
        public short InstallmentNo { get; set; }
        public double? Amount { get; set; }
        public int? CustSuppType { get; set; }
        public string CustSupp { get; set; }
        public string Currency { get; set; }
        public int PymtSchedId { get; set; }
        public DateTime InstallmentDate { get; set; }
        public int? JournalEntryId { get; set; }
        public int? PaymentTerm { get; set; }
        public int? DebitCreditSign { get; set; }
        public string BillCode { get; set; }
        public string CompensationNo { get; set; }
        public DateTime? CollectionDate { get; set; }
        public DateTime? TransferDate { get; set; }
    }
}
