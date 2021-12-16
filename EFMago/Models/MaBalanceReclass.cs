using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaBalanceReclass
    {
        public MaBalanceReclass()
        {
            MaBalanceReclassDetail = new HashSet<MaBalanceReclassDetail>();
        }

        public string SchemaCode { get; set; }
        public string Description { get; set; }
        public string Predefined { get; set; }
        public string Currency { get; set; }
        public Guid? Tbguid { get; set; }
        public string IsBalance { get; set; }
        public string PositiveRoundingCode { get; set; }
        public string NegativeRoundingCode { get; set; }
        public string IsXbrl { get; set; }
        public string XbrlMap { get; set; }
        public int? XbrlBalanceType { get; set; }
        public string XbrlRoundingFinStat { get; set; }
        public string XbrlRoundingProfit { get; set; }
        public string XbrlRoundingLoss { get; set; }
        public string Disabled { get; set; }
        public string IsBeO { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ICollection<MaBalanceReclassDetail> MaBalanceReclassDetail { get; set; }
    }
}
