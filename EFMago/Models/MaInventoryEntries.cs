using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaInventoryEntries
    {
        public MaInventoryEntries()
        {
            MaInventoryEntriesDetail = new HashSet<MaInventoryEntriesDetail>();
        }

        public string InvRsn { get; set; }
        public string StubBook { get; set; }
        public DateTime? PostingDate { get; set; }
        public int? CustSuppType { get; set; }
        public string CustSupp { get; set; }
        public string PreprintedDocNo { get; set; }
        public string DocNo { get; set; }
        public DateTime? DocumentDate { get; set; }
        public string StoragePhase1 { get; set; }
        public int? Specificator1Type { get; set; }
        public string SpecificatorPhase1 { get; set; }
        public string StoragePhase2 { get; set; }
        public int? Specificator2Type { get; set; }
        public string SpecificatorPhase2 { get; set; }
        public string Currency { get; set; }
        public DateTime? FixingDate { get; set; }
        public string FixingIsManual { get; set; }
        public double? Fixing { get; set; }
        public string Notes { get; set; }
        public int EntryId { get; set; }
        public string Job { get; set; }
        public string PostedToCostAccounting { get; set; }
        public string CostCenter { get; set; }
        public string JobTicketNo { get; set; }
        public int? JobTicketId { get; set; }
        public string PickingListNo { get; set; }
        public string ReceiptPhase1 { get; set; }
        public string CancelPhase1 { get; set; }
        public string UsePhase2 { get; set; }
        public string ReceiptPhase2 { get; set; }
        public string CancelPhase2 { get; set; }
        public string ProductLine { get; set; }
        public int? LastSubId { get; set; }
        public Guid? Tbguid { get; set; }
        public DateTime? AccrualDate { get; set; }
        public string CorrectionEntry { get; set; }
        public string ClosingEntry { get; set; }
        public int? CigcorrEntryId { get; set; }
        public int? EntryIdloadVariation { get; set; }
        public string ManufacturingCostCorrection { get; set; }
        public string AutomaticInvValueOnly { get; set; }
        public string FromManufacturing { get; set; }
        public int? ManufacturingEntryType { get; set; }
        public string ManufacturingOutsrcRtgStep { get; set; }
        public int? CrrefType { get; set; }
        public int? CrrefId { get; set; }
        public string ManufacturingReversedEntry { get; set; }
        public int? ExtAccTransId { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ICollection<MaInventoryEntriesDetail> MaInventoryEntriesDetail { get; set; }
    }
}
