using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaUserDefaultInventory
    {
        public string Branch { get; set; }
        public int WorkerId { get; set; }
        public string InventoryDecreaseAdjInvRsn { get; set; }
        public string InventoryIncreaseAdjInvRsn { get; set; }
        public string StockTransferInvRsn { get; set; }
        public string BusinessClosingInvRsn { get; set; }
        public string RevaluationFifoinvRsn { get; set; }
        public string RevaluationLifoinvRsn { get; set; }
        public string InventoryInitialInvRsn { get; set; }
        public string CigcorrInvReason { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
