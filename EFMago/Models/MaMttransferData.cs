using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaMttransferData
    {
        public int AutoId { get; set; }
        public string Guid { get; set; }
        public int? RecordType { get; set; }
        public string Team { get; set; }
        public int? Mbresource { get; set; }
        public int? ItemType { get; set; }
        public string Item { get; set; }
        public string Variant { get; set; }
        public string Lot { get; set; }
        public string Job { get; set; }
        public string CostCenter { get; set; }
        public string Wc { get; set; }
        public string Operation { get; set; }
        public double? LeadTime { get; set; }
        public string UoM { get; set; }
        public double? ProductionQty { get; set; }
        public double? StillToProduceQty { get; set; }
        public double? Qty { get; set; }
        public string DocumentNo { get; set; }
        public int? DocumentId { get; set; }
        public string BarcodeSegment { get; set; }
        public short? RtgStep { get; set; }
        public string Alternate { get; set; }
        public short? AltRtgStep { get; set; }
        public int? Line { get; set; }
        public int? Mostatus { get; set; }
        public string CloseMo { get; set; }
        public string Storage { get; set; }
        public DateTime? DueDate { get; set; }
        public int? SyncStatus { get; set; }
        public string Closed { get; set; }
        public string Transferred { get; set; }
        public string ErrorMsg { get; set; }
        public string MacAddress { get; set; }
        public string Notes { get; set; }
        public string InProcess { get; set; }
        public DateTime? InProcessFrom { get; set; }
        public int? RetryForError { get; set; }
        public double? ProcessingQty { get; set; }
        public string SecondRate { get; set; }
        public string SecondRateVariant { get; set; }
        public double? SecondRateQuantity { get; set; }
        public string Scrap { get; set; }
        public string ScrapVariant { get; set; }
        public double? ScrapQuantity { get; set; }
        public int? ProcessingTime { get; set; }
        public int? SetupTime { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
