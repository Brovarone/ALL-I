using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaVinvEntriesDetail
    {
        public string InvRsn { get; set; }
        public string StubBook { get; set; }
        public DateTime? PostingDate { get; set; }
        public int? CustSuppType { get; set; }
        public string CustSupp { get; set; }
        public string PreprintedDocNo { get; set; }
        public string DocNo { get; set; }
        public DateTime? DocumentDate { get; set; }
        public string Currency { get; set; }
        public DateTime? FixingDate { get; set; }
        public string FixingIsManual { get; set; }
        public double? Fixing { get; set; }
        public int EntryId { get; set; }
        public string StoragePhase1 { get; set; }
        public string StoragePhase2 { get; set; }
        public string AutomaticInvValueOnly { get; set; }
        public string Description { get; set; }
        public int? LineCostOrigin { get; set; }
        public short Line { get; set; }
        public string Item { get; set; }
        public string Lot { get; set; }
        public string UoM { get; set; }
        public double? Qty { get; set; }
        public double? BaseUomQty { get; set; }
        public double? UnitValue { get; set; }
        public double? LineAmount { get; set; }
        public string DiscountFormula { get; set; }
        public int? VariationInvEntryId { get; set; }
        public int? VariationInvEntrySubId { get; set; }
        public double? LineCost { get; set; }
        public int? SubId { get; set; }
        public int? EntryTypeForLfbatchEval { get; set; }
        public int? BoLid { get; set; }
        public int? BoLsubId { get; set; }
        public int? DocumentType { get; set; }
        public int? ActionOnLifoFifo { get; set; }
        public int? LifoFifoLineSource { get; set; }
        public short? OrderForProcedure { get; set; }
    }
}
