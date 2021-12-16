using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaUserDefaultPurchaseOrders
    {
        public string Branch { get; set; }
        public int WorkerId { get; set; }
        public string PurchaseOrderAccTpl { get; set; }
        public string BillofLadingPostingRsn { get; set; }
        public string EupurchaseOrderAccTpl { get; set; }
        public string SuspTaxPurchaseOrderAccTpl { get; set; }
        public string PurchaseOrderInvRsn { get; set; }
        public string ExtraEupurchaseOrderAccTpl { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
