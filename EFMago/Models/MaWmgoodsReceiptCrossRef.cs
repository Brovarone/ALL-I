using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaWmgoodsReceiptCrossRef
    {
        public int GoodsReceiptId { get; set; }
        public int GoodsReceiptSubId { get; set; }
        public int? ItemStatus { get; set; }
        public string Item { get; set; }
        public string Lot { get; set; }
        public int CrrefType { get; set; }
        public int CrrefId { get; set; }
        public int CrrefSubId { get; set; }
        public double? ReceiptQty { get; set; }
        public string UnitOfMeasure { get; set; }
        public string InternalIdNo { get; set; }
        public string ExternalIdNo { get; set; }
        public short? GoodsReceiptLine { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
