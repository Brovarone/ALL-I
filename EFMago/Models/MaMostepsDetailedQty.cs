using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaMostepsDetailedQty
    {
        public int Moid { get; set; }
        public short RtgStep { get; set; }
        public string Alternate { get; set; }
        public short AltRtgStep { get; set; }
        public short Line { get; set; }
        public DateTime? PostingDate { get; set; }
        public int? ItemType { get; set; }
        public string Item { get; set; }
        public string Variant { get; set; }
        public string UoM { get; set; }
        public int? ProcessingType { get; set; }
        public double? ProducedQty { get; set; }
        public double? IssuedQuantity { get; set; }
        public string PostedToInventory { get; set; }
        public string Storage { get; set; }
        public string AutomaticallyConfirmation { get; set; }
        public string PreprintedDocNo { get; set; }
        public int? BoLid { get; set; }
        public short? BoLline { get; set; }
        public string BoL { get; set; }
        public int? PurchaseOrdId { get; set; }
        public short? Position { get; set; }
        public string CostCenter { get; set; }
        public int? ActualProcessingTime { get; set; }
        public int? ActualSetupTime { get; set; }
        public string ToBeCosted { get; set; }
        public int? SpecificatorType { get; set; }
        public string Specificator { get; set; }
        public short? ShiftNumber { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaMosteps MaMosteps { get; set; }
    }
}
