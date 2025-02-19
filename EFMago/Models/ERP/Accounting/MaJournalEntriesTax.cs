using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaJournalEntriesTax
    {
        public MaJournalEntriesTax()
        {
            MaJournalEntriesTaxDetail = new HashSet<MaJournalEntriesTaxDetail>();
        }

        public string AccTpl { get; set; }
        public DateTime? PostingDate { get; set; }
        public DateTime? DocumentDate { get; set; }
        public string DocNo { get; set; }
        public string LogNo { get; set; }
        public string RefNo { get; set; }
        public int? CustSuppType { get; set; }
        public string CustSupp { get; set; }
        public string TaxJournal { get; set; }
        public double? TaxableAmount { get; set; }
        public double? TaxAmount { get; set; }
        public double? UndeductibleAmount { get; set; }
        public string Eoydeductible { get; set; }
        public string IntrastatOperation { get; set; }
        public DateTime? TaxAccrualDate { get; set; }
        public int? TaxSign { get; set; }
        public int JournalEntryId { get; set; }
        public string NotExigible { get; set; }
        public DateTime? ExigibilityDate { get; set; }
        public int? TransactionType { get; set; }
        public int? Nature { get; set; }
        public Guid? Tbguid { get; set; }
        public int? CollectionJournalEntryId { get; set; }
        public string GroupCode { get; set; }
        public string CreditNotePreviousPeriod { get; set; }
        public DateTime? PlafondAccrualDate { get; set; }
        public string BlackListCustSupp { get; set; }
        public DateTime? DepartureDate { get; set; }
        public int? TaxCommunicationOperation { get; set; }
        public string TaxCommunicationGroup { get; set; }
        public string Notes { get; set; }
        public int? OperatorId { get; set; }
        public int? AuditorId { get; set; }
        public int? PosterId { get; set; }
        public DateTime? DateOfEnter { get; set; }
        public DateTime? DateOfAudit { get; set; }
        public DateTime? DateOfPost { get; set; }
        public int? DocumentStatus { get; set; }
        public string RejectReason { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public string HashSdi { get; set; }
        public string Idsdi { get; set; }

        public virtual MaJournalEntriesIntraTax MaJournalEntriesIntraTax { get; set; }
        public virtual ICollection<MaJournalEntriesTaxDetail> MaJournalEntriesTaxDetail { get; set; }
    }
}
