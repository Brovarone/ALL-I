using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaInventoryEntriesDetail
    {
        public DateTime? PostingDate { get; set; }
        public string Item { get; set; }
        public string InternalIdNo { get; set; }
        public string ExternalIdNo { get; set; }
        public string Variant { get; set; }
        public string Description { get; set; }
        public string Department { get; set; }
        public string UoM { get; set; }
        public double? Qty { get; set; }
        public double? AdditionalQty1 { get; set; }
        public double? AdditionalQty2 { get; set; }
        public double? AdditionalQty3 { get; set; }
        public double? UnitValue { get; set; }
        public double? Discount1 { get; set; }
        public double? Discount2 { get; set; }
        public string DiscountFormula { get; set; }
        public double? DiscountAmount { get; set; }
        public double? LineAmount { get; set; }
        public int? OrderId { get; set; }
        public short? OrderLine { get; set; }
        public int? BoLid { get; set; }
        public short? BoLline { get; set; }
        public double? AdditionalQty4 { get; set; }
        public string Lot { get; set; }
        public string Job { get; set; }
        public string CostCenter { get; set; }
        public string CostAccAccount { get; set; }
        public int? Moid { get; set; }
        public string Mono { get; set; }
        public short? RtgStep { get; set; }
        public string Alternate { get; set; }
        public short? AltRtgStep { get; set; }
        public short? MocompLine { get; set; }
        public int? DocumentType { get; set; }
        public int? OrderType { get; set; }
        public int EntryId { get; set; }
        public short Line { get; set; }
        public short? ExternalLineReference { get; set; }
        public string Temporary { get; set; }
        public string Location { get; set; }
        public string Drawing { get; set; }
        public string ProductLine { get; set; }
        public int? ProdJobId { get; set; }
        public string ProdJobNo { get; set; }
        public int? SubId { get; set; }
        public DateTime? AccrualDate { get; set; }
        public int? VariationInvEntryId { get; set; }
        public int? VariationInvEntrySubId { get; set; }
        public double? LineCost { get; set; }
        public string ManufacturingCorrection { get; set; }
        public int? VariationExternalId { get; set; }
        public int? EntryTypeForLfbatchEval { get; set; }
        public double? ManufacturingProcCost { get; set; }
        public int? BoLsubId { get; set; }
        public double? BaseUoMqty { get; set; }
        public string NonConformityReason { get; set; }
        public double? ActualRetailPrice { get; set; }
        public string ActualRetailPriceWithTax { get; set; }
        public double? BkinitialCost { get; set; }
        public double? Bkqty { get; set; }
        public double? BklineCost { get; set; }
        public double? BklineAmount { get; set; }
        public double? BkunitValue { get; set; }
        public string InvRsn { get; set; }
        public int? ActionOnLifoFifo { get; set; }
        public int? LifoFifoLineSource { get; set; }
        public string ManufacturingDeletion { get; set; }
        public short? OrderForProcedure { get; set; }
        public int? CrrefType { get; set; }
        public int? CrrefId { get; set; }
        public int? CrrefSubId { get; set; }
        public short? CrrefLine { get; set; }
        public double? ActualRetailPricePhase2 { get; set; }
        public int? ReceiptBatchId { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public string ImJobWorkingStep { get; set; }

        public virtual MaInventoryEntries Entry { get; set; }
    }
}
