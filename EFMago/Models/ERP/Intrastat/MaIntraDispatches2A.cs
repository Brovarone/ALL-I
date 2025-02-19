using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaIntraDispatches2A
    {
        public int IntrastatId { get; set; }
        public short Line { get; set; }
        public int? CustSuppType { get; set; }
        public string CustSupp { get; set; }
        public int? Operation { get; set; }
        public short? BalanceMonth { get; set; }
        public short? Quarter { get; set; }
        public short? BalanceYear { get; set; }
        public double? TotalAmount { get; set; }
        public int? NatureOfTransaction { get; set; }
        public string CombinedNomenclature { get; set; }
        public double? NetMass { get; set; }
        public double? SuppUnit { get; set; }
        public double? StatisticalValue { get; set; }
        public int? DeliveryTerms { get; set; }
        public int? ModeOfTransport { get; set; }
        public string CountryOfDestination { get; set; }
        public string CountyOfOrigin { get; set; }
        public string Notes { get; set; }
        public int? StatisticalPurpose { get; set; }
        public string CountryOfTransport { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaIntra Intrastat { get; set; }
    }
}
