using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaInvAccDefaults
    {
        public MaInvAccDefaults()
        {
            MaInvAccDefaultsDetail = new HashSet<MaInvAccDefaultsDetail>();
        }

        public int InvAccDefaultsId { get; set; }
        public string ItemPurchacesOffset { get; set; }
        public string ItemSalesOffset { get; set; }
        public string ItemConsumptionOffset { get; set; }
        public string CustomerAccountRoot { get; set; }
        public string PurchasesGoodsOffset { get; set; }
        public string ServicesPurchasesOffset { get; set; }
        public string SupplierAccountRoot { get; set; }
        public string SalesGoodsOffset { get; set; }
        public string ServicesSalesOffset { get; set; }
        public string RetailPriceChangeAccTpl { get; set; }
        public string RetailPriceChangeAccRsn { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ICollection<MaInvAccDefaultsDetail> MaInvAccDefaultsDetail { get; set; }
    }
}
