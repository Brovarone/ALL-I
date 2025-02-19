using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImInvRsnPolicies
    {
        public string InvRsn { get; set; }
        public int? ActionOnSoa { get; set; }
        public int? QtyActionOnEconomicAnalysis { get; set; }
        public int? CostActionOnEconomicAnalysis { get; set; }
        public int? UseImpiantiSchedule { get; set; }
        public string OnlyStandardVariantJob { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaInventoryReasons InvRsnNavigation { get; set; }
    }
}
