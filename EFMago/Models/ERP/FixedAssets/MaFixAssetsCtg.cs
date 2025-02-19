using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaFixAssetsCtg
    {
        public int CodeType { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public double? OfficialPerc { get; set; }
        public double? MinimumPerc { get; set; }
        public string DepreciateByLifePeriod { get; set; }
        public short? LifePeriod { get; set; }
        public double? FirstFiscalYearPerc { get; set; }
        public double? AcceleratedPerc { get; set; }
        public short? AcceleratedNoOfYears { get; set; }
        public string AcceleratedDisabled { get; set; }
        public double? ChargesPerc { get; set; }
        public short? ChargesNoOfyears { get; set; }
        public string CategoryAccount { get; set; }
        public string DeprAccount { get; set; }
        public string AcceleratedDeprAccount { get; set; }
        public string AccumDeprAccount { get; set; }
        public string AcceleratedAccumDeprAccount { get; set; }
        public string PartiallyDepreciable { get; set; }
        public double? BalancePerc { get; set; }
        public int? DepreciationMethod { get; set; }
        public Guid? Tbguid { get; set; }
        public short? MinLifePeriod { get; set; }
        public short? MaxLifePeriod { get; set; }
        public string PartDeprByPerc { get; set; }
        public double? PartDeprLimit { get; set; }
        public double? PartDeprPerc { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
