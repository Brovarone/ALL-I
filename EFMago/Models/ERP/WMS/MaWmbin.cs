using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaWmbin
    {
        public string Bin { get; set; }
        public string BinType { get; set; }
        public string Barcode { get; set; }
        public string Storage { get; set; }
        public string Section { get; set; }
        public string Zone { get; set; }
        public int? PathSequence { get; set; }
        public string Disabled { get; set; }
        public string ForPicking { get; set; }
        public string ForPutaway { get; set; }
        public string Blocked { get; set; }
        public string Suspect { get; set; }
        public DateTime? SuspectDate { get; set; }
        public double? MaxWeight { get; set; }
        public double? TotalCapacity { get; set; }
        public double? UsedWeight { get; set; }
        public double? UsedCapacity { get; set; }
        public double? ReservedWeight { get; set; }
        public double? ReservedCapacity { get; set; }
        public int? MaxStorageUnit { get; set; }
        public int? NumOfSu { get; set; }
        public int? ReservedNumOfSu { get; set; }
        public DateTime? LastEntry { get; set; }
        public DateTime? LastEmptying { get; set; }
        public DateTime? LastInventory { get; set; }
        public string IsFull { get; set; }
        public string IsEmpty { get; set; }
        public int? BlockWorker { get; set; }
        public DateTime? BlockDate { get; set; }
        public string BlockReason { get; set; }
        public int? BlockType { get; set; }
        public string BarcodeSegment { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
