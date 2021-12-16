using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaLots
    {
        public string Item { get; set; }
        public string Lot { get; set; }
        public string Description { get; set; }
        public string Storage { get; set; }
        public int? ReceiptInvTransId { get; set; }
        public string ReceiptDocNo { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public DateTime? OutOfStockDate { get; set; }
        public string TotallyConsumed { get; set; }
        public double? InitialBookInv { get; set; }
        public double? FinalBookInv { get; set; }
        public double? InitialOnHand { get; set; }
        public double? FinalOnHand { get; set; }
        public double? ReceivedQty { get; set; }
        public double? ReceivedValue { get; set; }
        public double? IssuedQty { get; set; }
        public double? IssuedValue { get; set; }
        public double? Cost { get; set; }
        public string Supplier { get; set; }
        public DateTime? LoadDate { get; set; }
        public string PurchaseOrdNo { get; set; }
        public string SupplierLotNo { get; set; }
        public string ParentLotNo { get; set; }
        public short? NoOfPacks { get; set; }
        public string Location { get; set; }
        public string AnalysisRefNo { get; set; }
        public DateTime? AnalysisDate { get; set; }
        public string AnalysisPerson { get; set; }
        public int? AnalysisStatus { get; set; }
        public string Notes { get; set; }
        public string InternallyProduced { get; set; }
        public string Disabled { get; set; }
        public double? BookedQty { get; set; }
        public string Mono { get; set; }
        public int? Moid { get; set; }
        public DateTime? ProductionDate { get; set; }
        public double? ReceiptLastCost { get; set; }
        public double? ReservedByMo { get; set; }
        public double? UsedByProduction { get; set; }
        public string DescriptionText { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public DateTime? LastMaintenance { get; set; }
        public DateTime? LastMaintenanceExtra { get; set; }
        public double? UsedQty { get; set; }
        public double? ThresholdQty { get; set; }
        public double? UsedQtyTot { get; set; }
        public double? ThresholdQtyTot { get; set; }
        public Guid? Tbguid { get; set; }
        public string BarcodeSegment { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
