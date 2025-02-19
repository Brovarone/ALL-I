using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaWorkCenters
    {
        public MaWorkCenters()
        {
            MaWcfamiliesDetails = new HashSet<MaWcfamiliesDetails>();
            MaWorkCentersBreakdown = new HashSet<MaWorkCentersBreakdown>();
        }

        public string Wc { get; set; }
        public string Description { get; set; }
        public string Supplier { get; set; }
        public int? ManagerId { get; set; }
        public string Outsourced { get; set; }
        public string Template { get; set; }
        public string Make { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public DateTime? PlacedInServiceDate { get; set; }
        public int? AverageCapacity { get; set; }
        public short? ResourceNo { get; set; }
        public string Notes { get; set; }
        public int? WorkType { get; set; }
        public double? HourlyCost { get; set; }
        public double? UnitCost { get; set; }
        public double? AdditionalCost { get; set; }
        public string Calendar { get; set; }
        public Guid? Tbguid { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ICollection<MaWcfamiliesDetails> MaWcfamiliesDetails { get; set; }
        public virtual ICollection<MaWorkCentersBreakdown> MaWorkCentersBreakdown { get; set; }
    }
}
