using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaPricePolicies
    {
        public int PricePoliciesId { get; set; }
        public string WarnOnZeroValues { get; set; }
        public string NotSaveZeroValues { get; set; }
        public string WarnOnBelowCost { get; set; }
        public string WarnOnBelowStandardCost { get; set; }
        public string BelowCostMarginCheck { get; set; }
        public string BelowStandardCostMarginCheck { get; set; }
        public string UpdateDiscount { get; set; }
        public Guid? Tbguid { get; set; }
        public string WarnOnBelowWavgCost { get; set; }
        public string BelowWavgCostMarginCheck { get; set; }
        public string ManageDocumentRowPriceList { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
