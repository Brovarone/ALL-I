using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaConaientries
    {
        public DateTime? EntryDate { get; set; }
        public int? DocumentId { get; set; }
        public string DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public short? DocumentLine { get; set; }
        public DateTime? DocumentDate { get; set; }
        public string Customer { get; set; }
        public double? ExemptionPerc { get; set; }
        public string Item { get; set; }
        public string Material { get; set; }
        public string PackageType { get; set; }
        public string PackageTypeDescription { get; set; }
        public string PrimaryPackage { get; set; }
        public double? Qty { get; set; }
        public double? ExemptQty { get; set; }
        public double? SubjectedQty { get; set; }
        public double? UnitContribution { get; set; }
        public double? TotalContributionAmount { get; set; }
        public double? PrimaryPackageQty { get; set; }
        public double? SecondaryTertiaryPackageQty { get; set; }
        public int EntryId { get; set; }
        public Guid? Tbguid { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
