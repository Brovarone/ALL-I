using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaAdditionalCharges
    {
        public MaAdditionalCharges()
        {
            MaAdditionalChargesDetail = new HashSet<MaAdditionalChargesDetail>();
            MaAdditionalChargesRef = new HashSet<MaAdditionalChargesRef>();
        }

        public int AdditionalChargesId { get; set; }
        public string DocumentNumber { get; set; }
        public string DistributionTemplate { get; set; }
        public string Supplier { get; set; }
        public DateTime? DocumentDate { get; set; }
        public DateTime? OperationDate { get; set; }
        public DateTime? AccrualDate { get; set; }
        public string SupplierDocNo { get; set; }
        public string Currency { get; set; }
        public DateTime? FixingDate { get; set; }
        public double? Fixing { get; set; }
        public string FixingIsManual { get; set; }
        public double? TotalCharges { get; set; }
        public double? TotalDistributed { get; set; }
        public double? Delta { get; set; }
        public double? TotalPerc { get; set; }
        public Guid? Tbguid { get; set; }
        public string InvRsn { get; set; }
        public int? LastSubId { get; set; }
        public int? CrrefType { get; set; }
        public int? CrrefId { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ICollection<MaAdditionalChargesDetail> MaAdditionalChargesDetail { get; set; }
        public virtual ICollection<MaAdditionalChargesRef> MaAdditionalChargesRef { get; set; }
    }
}
