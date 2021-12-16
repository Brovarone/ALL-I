using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaPyblsRcvbls
    {
        public MaPyblsRcvbls()
        {
            ImPyblsRcvblsJobIncidence = new HashSet<ImPyblsRcvblsJobIncidence>();
            MaPyblsRcvblsDetails = new HashSet<MaPyblsRcvblsDetails>();
        }

        public int? CustSuppType { get; set; }
        public string CustSupp { get; set; }
        public string Payment { get; set; }
        public DateTime? InstallmStartDate { get; set; }
        public string Settled { get; set; }
        public string DocNo { get; set; }
        public DateTime? DocumentDate { get; set; }
        public string CreditNote { get; set; }
        public double? TotalAmount { get; set; }
        public double? TaxAmount { get; set; }
        public string Currency { get; set; }
        public string Salesperson { get; set; }
        public string SendDocumentsTo { get; set; }
        public int PymtSchedId { get; set; }
        public int? JournalEntryId { get; set; }
        public string LogNo { get; set; }
        public string Group1 { get; set; }
        public string Group2 { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public string Blocked { get; set; }
        public string Advance { get; set; }
        public Guid? Tbguid { get; set; }
        public string WithholdingTaxManagement { get; set; }
        public string AmountsWithWhtax { get; set; }
        public double? Whtaxable { get; set; }
        public double? WhtaxableCn { get; set; }
        public double? TotalAmountCn { get; set; }
        public string EsrreferenceNumber { get; set; }
        public string EsrcheckDigit { get; set; }
        public string Area { get; set; }
        public string ContractCode { get; set; }
        public string ProjectCode { get; set; }
        public int? CrrefType { get; set; }
        public int? CrrefId { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public string ImIncidenceIsManual { get; set; }

        public virtual ICollection<ImPyblsRcvblsJobIncidence> ImPyblsRcvblsJobIncidence { get; set; }
        public virtual ICollection<MaPyblsRcvblsDetails> MaPyblsRcvblsDetails { get; set; }
    }
}
