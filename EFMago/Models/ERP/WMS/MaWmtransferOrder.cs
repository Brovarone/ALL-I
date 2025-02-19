using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaWmtransferOrder
    {
        public int Id { get; set; }
        public string Tonumber { get; set; }
        public string CreatedFromInventory { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ConfirmationDate { get; set; }
        public string Reason { get; set; }
        public int? Idparent { get; set; }
        public int? Tostatus { get; set; }
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
        public double? QtyNeeded { get; set; }
        public double? QtyToMove { get; set; }
        public double? QtyMoved { get; set; }
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
        public string PackingUnit { get; set; }
        public string InternalIdNo { get; set; }
        public string IsManualInternalIdNo { get; set; }
        public string AutoConfirmed { get; set; }
        public string ConsignmentPartner { get; set; }
        public string OriginalItem { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
