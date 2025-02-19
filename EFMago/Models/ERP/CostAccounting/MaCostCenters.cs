using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaCostCenters
    {
        public MaCostCenters()
        {
            MaCostCentersBalances = new HashSet<MaCostCentersBalances>();
        }

        public string CostCenter { get; set; }
        public string Description { get; set; }
        public string GroupCode { get; set; }
        public int? CodeType { get; set; }
        public int? Nature { get; set; }
        public double? SqMtSurfaceArea { get; set; }
        public string CostCenterManager { get; set; }
        public double? DirectEmployeesNo { get; set; }
        public double? IndirectEmployeesNo { get; set; }
        public double? DepreciationPerc { get; set; }
        public string DummyCostCenter { get; set; }
        public string Disabled { get; set; }
        public string Notes { get; set; }
        public string Account { get; set; }
        public Guid? Tbguid { get; set; }
        public string BarcodeSegment { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ICollection<MaCostCentersBalances> MaCostCentersBalances { get; set; }
    }
}
