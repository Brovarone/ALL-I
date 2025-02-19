using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaWmgoodsReceiptDetail
    {
        public int GoodsReceiptId { get; set; }
        public int? GoodsReceiptSubId { get; set; }
        public short GoodsReceiptLine { get; set; }
        public int? ItemStatus { get; set; }
        public string StorageUnit { get; set; }
        public string Item { get; set; }
        public string Lot { get; set; }
        public string UnitOfMeasure { get; set; }
        public double? Qty { get; set; }
        public string Togenerated { get; set; }
        public double? Toqty { get; set; }
        public string Printed { get; set; }
        public string Cancelled { get; set; }
        public int? OriginDocType { get; set; }
        public int? OriginDocId { get; set; }
        public int? OriginSubId { get; set; }
        public string OriginDocNumber { get; set; }
        public int? GoodsReceiptType { get; set; }
        public string IsManual { get; set; }
        public string ForcedZone { get; set; }
        public string ForcedBin { get; set; }
        public string NotTransactable { get; set; }
        public string InternalIdNo { get; set; }
        public string ExternalIdNo { get; set; }
        public string ConsignmentPartner { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
