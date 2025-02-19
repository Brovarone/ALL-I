using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaWttransferOrder
    {
        public int Id { get; set; }
        public int ChildNumber { get; set; }
        public int AutoId { get; set; }
        public string Tonumber { get; set; }
        public DateTime? ConfirmationDate { get; set; }
        public string Storage { get; set; }
        public string SourceZone { get; set; }
        public string SourceBin { get; set; }
        public string DestZone { get; set; }
        public string DestBin { get; set; }
        public string SourceStorageUnit { get; set; }
        public string DestStorageUnit { get; set; }
        public string Item { get; set; }
        public string Lot { get; set; }
        public string IsManualLot { get; set; }
        public double? QtyToMove { get; set; }
        public double? QtyMoved { get; set; }
        public double? QtyMissing { get; set; }
        public double? QtyBroken { get; set; }
        public string UoM { get; set; }
        public string PickFromPackUoM { get; set; }
        public int? ToResource { get; set; }
        public string Team { get; set; }
        public int? SourceSpecialStock { get; set; }
        public string SourceSpecialStockCode { get; set; }
        public int? DestSpecialStock { get; set; }
        public string DestSpecialStockCode { get; set; }
        public int? MovementType { get; set; }
        public string Notes { get; set; }
        public string Transferred { get; set; }
        public string Updated { get; set; }
        public string Closed { get; set; }
        public string StorageUnitType { get; set; }
        public int? ZonePathSequence { get; set; }
        public int? BinPathSequence { get; set; }
        public double? GrossWeight { get; set; }
        public string ErrorMsg { get; set; }
        public int? SyncStatus { get; set; }
        public int? OperationType { get; set; }
        public string MacAddress { get; set; }
        public string PackingUnit { get; set; }
        public string AllowPacking { get; set; }
        public string DocumentNo { get; set; }
        public int? CustSuppType { get; set; }
        public string CustSupp { get; set; }
        public string BillOfLadingNumber { get; set; }
        public DateTime? BillOfLadingDate { get; set; }
        public string SupplierLotNo { get; set; }
        public DateTime? SupplierLotExpiryDate { get; set; }
        public string ReferenceDocNo { get; set; }
        public int? ItemStatus { get; set; }
        public string Loading { get; set; }
        public string Job { get; set; }
        public string InternalIdNo { get; set; }
        public string ManualInternalIdNo { get; set; }
        public string PreShippingNo { get; set; }
        public string LockedByManufacturing { get; set; }
        public int? ReferenceDocType { get; set; }
        public string ConsignmentPartner { get; set; }
        public string OriginalItem { get; set; }
        public int? RetryForError { get; set; }
        public string InProcess { get; set; }
        public DateTime? InProcessFrom { get; set; }
        public int? InventoryId { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
