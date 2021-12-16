using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaJournalEntries
    {
        public string AccTpl { get; set; }
        public DateTime? PostingDate { get; set; }
        public string RefNo { get; set; }
        public DateTime? DocumentDate { get; set; }
        public string DocNo { get; set; }
        public double? TotalAmount { get; set; }
        public int JournalEntryId { get; set; }
        public DateTime? AccrualDate { get; set; }
        public int? CodeType { get; set; }
        public string Currency { get; set; }
        public double? TotalAmountDocCurr { get; set; }
        public DateTime? FixingDate { get; set; }
        public double? Fixing { get; set; }
        public string FixingIsManual { get; set; }
        public DateTime? ValueDate { get; set; }
        public int? TransactionType { get; set; }
        public int? Nature { get; set; }
        public string Eurotransfer { get; set; }
        public Guid? Tbguid { get; set; }
        public string GroupCode { get; set; }
        public string Posted { get; set; }
        public string Transfer { get; set; }
        public int? DelJournalEntryId { get; set; }
        public int? CrrefType { get; set; }
        public int? CrrefId { get; set; }
        public int? LastSubId { get; set; }
        public string DefReversal { get; set; }
        public string ForcedExigibility { get; set; }
        public string CurrencyReval { get; set; }
        public string IsAnAdjJe { get; set; }
        public int? AdjCustSuppType { get; set; }
        public string AdjCustSupp { get; set; }
        public string IsApayrollJe { get; set; }
        public string IsAcashJe { get; set; }
        public int? OperatorId { get; set; }
        public int? AuditorId { get; set; }
        public int? PosterId { get; set; }
        public DateTime? DateOfEnter { get; set; }
        public DateTime? DateOfAudit { get; set; }
        public DateTime? DateOfPost { get; set; }
        public int? DocumentStatus { get; set; }
        public string RejectReason { get; set; }
        public int? GljournalNo { get; set; }
        public short? NoOriginals { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
