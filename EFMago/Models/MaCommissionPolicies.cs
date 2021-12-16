using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaCommissionPolicies
    {
        public MaCommissionPolicies()
        {
            MaCommissionPoliciesDetail = new HashSet<MaCommissionPoliciesDetail>();
        }

        public string Policy { get; set; }
        public string Description { get; set; }
        public string CommissionFormula { get; set; }
        public string CommissionOnLines { get; set; }
        public int? AccrualType { get; set; }
        public string FinalDiscountIncluded { get; set; }
        public int? CommissionType { get; set; }
        public double? AccrualPercAtInvoiceDate { get; set; }
        public string DiscountsDetail { get; set; }
        public Guid? Tbguid { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ICollection<MaCommissionPoliciesDetail> MaCommissionPoliciesDetail { get; set; }
    }
}
