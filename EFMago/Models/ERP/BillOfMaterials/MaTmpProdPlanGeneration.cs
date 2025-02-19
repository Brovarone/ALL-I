using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaTmpProdPlanGeneration
    {
        public string Item { get; set; }
        public string Variant { get; set; }
        public string Description { get; set; }
        public string BaseUoM { get; set; }
        public string UoM { get; set; }
        public string SaleOrdUoM { get; set; }
        public double? OnHand { get; set; }
        public double? Reserved { get; set; }
        public double? InProduction { get; set; }
        public double? Production { get; set; }
        public double? SaleOrdQty { get; set; }
        public double? MinimumStock { get; set; }
        public int? SaleOrdId { get; set; }
        public string ReferenceDocNo { get; set; }
        public DateTime? RefDocDate { get; set; }
        public short Position { get; set; }
        public string NoProduction { get; set; }
        public string Job { get; set; }
        public string CostCenter { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }
        public string ShortageAvoided { get; set; }
        public string Drawing { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
