using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaWmtransferRequest
    {
        public int Trid { get; set; }
        public string Trnumber { get; set; }
        public int? DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public int? DocumentId { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? Trstatus { get; set; }
        public string Storage { get; set; }
        public string UoM { get; set; }
        public string Item { get; set; }
        public string Lot { get; set; }
        public short? Position { get; set; }
        public double? RequiredQty { get; set; }
        public DateTime? RequiredDate { get; set; }
        public double? ReleasedQty { get; set; }
        public double? PickedQty { get; set; }
        public double? DeliveredQty { get; set; }
        public double? ProcessedQty { get; set; }
        public double? ConfirmedToqty { get; set; }
        public int? Moid { get; set; }
        public string Notes { get; set; }
        public double? ReleasedQtyDiff { get; set; }
        public double? ProcessedQtyDiff { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
