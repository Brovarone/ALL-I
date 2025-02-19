using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaChargePolicies
    {
        public MaChargePolicies()
        {
            MaChargePoliciesAreas = new HashSet<MaChargePoliciesAreas>();
            MaChargePoliciesPackages = new HashSet<MaChargePoliciesPackages>();
            MaChargePoliciesShippings = new HashSet<MaChargePoliciesShippings>();
        }

        public string Customer { get; set; }
        public string ShippingFormula { get; set; }
        public string PackageFormula { get; set; }
        public double? ShippingRounding { get; set; }
        public int? ShippingRoundingType { get; set; }
        public double? PackageRounding { get; set; }
        public int? PackageRoundingType { get; set; }
        public Guid? Tbguid { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ICollection<MaChargePoliciesAreas> MaChargePoliciesAreas { get; set; }
        public virtual ICollection<MaChargePoliciesPackages> MaChargePoliciesPackages { get; set; }
        public virtual ICollection<MaChargePoliciesShippings> MaChargePoliciesShippings { get; set; }
    }
}
