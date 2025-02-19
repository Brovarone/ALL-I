using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaOffsetsStoragesHead
    {
        public string Storage { get; set; }
        public string SaleOffset { get; set; }
        public string PurchaseOffset { get; set; }
        public string ConsumptionOffset { get; set; }
        public string CustomerAccountRoot { get; set; }
        public string PurchasesGoodsOffset { get; set; }
        public string ServicesPurchasesOffset { get; set; }
        public string SupplierAccountRoot { get; set; }
        public string SalesGoodsOffset { get; set; }
        public string ServicesSalesOffset { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
