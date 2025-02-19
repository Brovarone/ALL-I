using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaWminventoryDetail
    {
        public int InventoryId { get; set; }
        public string Storage { get; set; }
        public string Zone { get; set; }
        public string Bin { get; set; }
        public string Item { get; set; }
        public string Lot { get; set; }
        public string UoM { get; set; }
        public int SpecialStock { get; set; }
        public string SpecialStockCode { get; set; }
        public string StorageUnit { get; set; }
        public string InternalIdNo { get; set; }
        public string ConsignmentPartner { get; set; }
        public string Selected { get; set; }
        public string InventoryNumber { get; set; }
        public DateTime? InventoryDate { get; set; }
        public double? ResultingQty { get; set; }
        public double? ResultingQtyOtherCount { get; set; }
        public double? ActualQty { get; set; }
        public double? FinalQty { get; set; }
        public double? Difference { get; set; }
        public string Togenerated { get; set; }
        public string InitialInventoryGenerated { get; set; }
        public string InterimDiffTogenerated { get; set; }
        public double? ProposedValue { get; set; }
        public string Team { get; set; }
        public int? Worker { get; set; }
        public string TeamOtherCount { get; set; }
        public int? WorkerOtherCount { get; set; }
        public int? HandheldStatus { get; set; }
        public int? HandheldStatusOtherCount { get; set; }
        public string InventoryToHandheld { get; set; }
        public string EmptyBin { get; set; }
        public string EmptyBinOtherCount { get; set; }
        public string FinalEmptyBin { get; set; }
        public string LineReadyToBeProcessed { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaWminventory Inventory { get; set; }
    }
}
