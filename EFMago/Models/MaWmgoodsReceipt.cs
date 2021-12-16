using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaWmgoodsReceipt
    {
        public int GoodsReceiptId { get; set; }
        public string GoodsReceiptNumber { get; set; }
        public DateTime? GoodsReceiptDate { get; set; }
        public string BillOfLadingNumber { get; set; }
        public DateTime? BillOfLadingDate { get; set; }
        public string Supplier { get; set; }
        public string ConfInvReason { get; set; }
        public string SourceStorage { get; set; }
        public string ConfStorage { get; set; }
        public int? ConfSpecificatorType { get; set; }
        public string ConfSpecificator { get; set; }
        public string ConfZone { get; set; }
        public int? ConfSpecialStock { get; set; }
        public string ConfSpecialStockCode { get; set; }
        public string ScrapInvReason { get; set; }
        public string ScrapStorage { get; set; }
        public int? ScrapSpecificatorType { get; set; }
        public string ScrapSpecificator { get; set; }
        public string ScrapZone { get; set; }
        public int? ScrapSpecialStock { get; set; }
        public string ScrapSpecialStockCode { get; set; }
        public string ReturnInvReason { get; set; }
        public string ReturnStorage { get; set; }
        public int? ReturnSpecificatorType { get; set; }
        public string ReturnSpecificator { get; set; }
        public string ReturnZone { get; set; }
        public int? ReturnSpecialStock { get; set; }
        public string ReturnSpecialStockCode { get; set; }
        public string InspectInvReason { get; set; }
        public string InspectStorage { get; set; }
        public int? InspectSpecificatorType { get; set; }
        public string InspectSpecificator { get; set; }
        public string InspectZone { get; set; }
        public int? InspectSpecialStock { get; set; }
        public string InspectSpecialStockCode { get; set; }
        public string BillOfLadingGenerated { get; set; }
        public int? BillOfLadingId { get; set; }
        public int? LastSubId { get; set; }
        public string ConfInvEntryGenerated { get; set; }
        public int? ConfInvEntryId { get; set; }
        public string ScrapInvEntryGenerated { get; set; }
        public int? ScrapInvEntryId { get; set; }
        public string ReturnInvEntryGenerated { get; set; }
        public int? ReturnInvEntryId { get; set; }
        public string InspectInvEntryGenerated { get; set; }
        public int? InspectInvEntryId { get; set; }
        public string TwoStepsPutaway { get; set; }
        public string Printed { get; set; }
        public string Cancelled { get; set; }
        public int? GoodsReceiptType { get; set; }
        public string Togenerated { get; set; }
        public int? InspectionOrderId { get; set; }
        public string InspOrderGenerated { get; set; }
        public string InspNoteGenerated { get; set; }
        public int? NoOfSu { get; set; }
        public double? TotalGrossVolume { get; set; }
        public double? TotalGrossWeight { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
