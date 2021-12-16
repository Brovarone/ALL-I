using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaAdditionalChargesDetail
    {
        public int AdditionalChargesId { get; set; }
        public short Line { get; set; }
        public string Item { get; set; }
        public double? Qty { get; set; }
        public string BaseUoM { get; set; }
        public double? GrossWeight { get; set; }
        public double? NetWeight { get; set; }
        public double? GrossVolume { get; set; }
        public short? NoOfPacks { get; set; }
        public double? TaxableAmount { get; set; }
        public double? DistributionPerc { get; set; }
        public double? DistributedCharge { get; set; }
        public int? InvEntryId { get; set; }
        public int? InvEntrySubId { get; set; }
        public string InvEntryCurrency { get; set; }
        public DateTime? InvEntryFixingDate { get; set; }
        public double? InvEntryFixing { get; set; }
        public string InvEntryFixingIsManual { get; set; }
        public string Offset { get; set; }
        public int? CrrefType { get; set; }
        public int? CrrefId { get; set; }
        public int? CrrefSubId { get; set; }
        public int? SubId { get; set; }
        public string Lot { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaAdditionalCharges AdditionalCharges { get; set; }
    }
}
