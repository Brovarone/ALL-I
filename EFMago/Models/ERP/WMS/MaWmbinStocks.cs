using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaWmbinStocks
    {
        public string Bin { get; set; }
        public string Storage { get; set; }
        public string Zone { get; set; }
        public int StockNumber { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Item { get; set; }
        public string Lot { get; set; }
        public int? SpecialStock { get; set; }
        public string SpecialStockCode { get; set; }
        public string StorageUnit { get; set; }
        public string StorageUnitType { get; set; }
        public string IsMultilevelStorageUnit { get; set; }
        public double? QtyBaseUoM { get; set; }
        public double? Qty { get; set; }
        public string UnitOfMeasure { get; set; }
        public double? QtyReserved { get; set; }
        public double? QtyIncoming { get; set; }
        public DateTime? LotValidTo { get; set; }
        public string Snapshot { get; set; }
        public string SnapshotCert { get; set; }
        public int? SnapshotWorker { get; set; }
        public DateTime? SnapshotDate { get; set; }
        public double? Weight { get; set; }
        public double? Capacity { get; set; }
        public int? SnapshotToid { get; set; }
        public string InternalIdNo { get; set; }
        public string ConsignmentPartner { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
