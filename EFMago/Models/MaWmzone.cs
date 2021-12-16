using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaWmzone
    {
        public string Zone { get; set; }
        public string Storage { get; set; }
        public string Description { get; set; }
        public string Blocked { get; set; }
        public string ForPicking { get; set; }
        public string ForPutaway { get; set; }
        public string StorageUnit { get; set; }
        public string CapacityCheck { get; set; }
        public string AllowNegativeStock { get; set; }
        public string UseSection { get; set; }
        public string UseBinStructure { get; set; }
        public string BinStructure { get; set; }
        public short? PathSequence { get; set; }
        public int? HazardousMaterial { get; set; }
        public string AddToStock { get; set; }
        public string MixedItem { get; set; }
        public string MixedLots { get; set; }
        public int? PutawayStrategy { get; set; }
        public int? PickingStrategy { get; set; }
        public int? PickingStrategyItemWithLot { get; set; }
        public string Disabled { get; set; }
        public string TotalRemoval { get; set; }
        public string Interim { get; set; }
        public string Grzone { get; set; }
        public string Gizone { get; set; }
        public string WeightCheck { get; set; }
        public string StorageUnitNumberCheck { get; set; }
        public string PutawayNearFixedBin { get; set; }
        public string Rtszone { get; set; }
        public string ScrapsZone { get; set; }
        public string QualityInspectionZone { get; set; }
        public DateTime? LastInventory { get; set; }
        public string PeriodicInventory { get; set; }
        public string ContinuousInventory { get; set; }
        public string InventoryBinAssignment { get; set; }
        public string ContInvOnPutaway { get; set; }
        public string ContInvOnZeroStock { get; set; }
        public string ContInvOnQtyStock { get; set; }
        public double? ContInvQuantity { get; set; }
        public int? LastSubId { get; set; }
        public int? BlockWorker { get; set; }
        public DateTime? BlockDate { get; set; }
        public string BlockReason { get; set; }
        public string ReplenishmentZone { get; set; }
        public string Mrzone { get; set; }
        public string Mizone { get; set; }
        public string Mipzone { get; set; }
        public string ZoneBarcodePrefix { get; set; }
        public string CrossDocking { get; set; }
        public string UniqueLot { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
