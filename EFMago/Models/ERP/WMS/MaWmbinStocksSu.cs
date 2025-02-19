using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaWmbinStocksSu
    {
        public int StockNumber { get; set; }
        public int Lev { get; set; }
        public string Sunumber { get; set; }
        public string Snapshot { get; set; }
        public string SnapshotCert { get; set; }
        public int? SnapshotWorker { get; set; }
        public DateTime? SnapshotDate { get; set; }
        public int? SnapshotToid { get; set; }
        public string Storage { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
