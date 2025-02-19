using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaCommissionPoliciesDetail
    {
        public string Disabled { get; set; }
        public string Policy { get; set; }
        public short Line { get; set; }
        public string AllCodes { get; set; }
        public int? PolicyCommType { get; set; }
        public int? CrossingCodeType { get; set; }
        public string CrossingCode { get; set; }
        public int? CrossingCodeType2 { get; set; }
        public string CrossingCode2 { get; set; }
        public double? CrossingValue { get; set; }
        public double? SalespersonCommPerc { get; set; }
        public double? AreaManagerCommPerc { get; set; }
        public string FinalDiscountIncluded { get; set; }
        public int? CommissionType { get; set; }
        public DateTime? StartingFrom { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaCommissionPolicies PolicyNavigation { get; set; }
    }
}
