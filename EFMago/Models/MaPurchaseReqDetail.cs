using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaPurchaseReqDetail
    {
        public MaPurchaseReqDetail()
        {
            MaPurchaseReqRequirements = new HashSet<MaPurchaseReqRequirements>();
        }

        public int PurchaseReqId { get; set; }
        public short Line { get; set; }
        public short? Position { get; set; }
        public string PurchaseReqNo { get; set; }
        public string Item { get; set; }
        public string Variant { get; set; }
        public string ItemDescription { get; set; }
        public string UoM { get; set; }
        public double? Qty { get; set; }
        public string Job { get; set; }
        public string CostCenter { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string Supplier { get; set; }
        public int? PurchaseReqStatus { get; set; }
        public int? Feasibility { get; set; }
        public int? PurchaseOrdId { get; set; }
        public string PurchaseOrdNo { get; set; }
        public short? PurchaseOrdPos { get; set; }
        public string GoodsDelivery { get; set; }
        public int? ShipToCustSuppType { get; set; }
        public string ShipToCustSupp { get; set; }
        public double? Discount1 { get; set; }
        public double? Discount2 { get; set; }
        public string DiscountFormula { get; set; }
        public double? UnitValue { get; set; }
        public string ConfirmationLevel { get; set; }
        public string Storage { get; set; }
        public short? MrpconfirmationRank { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaPurchaseReq PurchaseReq { get; set; }
        public virtual ICollection<MaPurchaseReqRequirements> MaPurchaseReqRequirements { get; set; }
    }
}
