using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaProductionPlans
    {
        public MaProductionPlans()
        {
            MaProductionPlansDetail = new HashSet<MaProductionPlansDetail>();
            MaProductionPlansReferences = new HashSet<MaProductionPlansReferences>();
        }

        public int ProductionPlanId { get; set; }
        public string ProductionPlanNo { get; set; }
        public string Description { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? LastModificationDate { get; set; }
        public DateTime? ProductionRunDate { get; set; }
        public DateTime? ProductionConfirmDate { get; set; }
        public string Notes { get; set; }
        public string SemifinishedNetting { get; set; }
        public string Closed { get; set; }
        public string GeneratedForMrp { get; set; }
        public string GenerateForShortage { get; set; }
        public Guid? Tbguid { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ICollection<MaProductionPlansDetail> MaProductionPlansDetail { get; set; }
        public virtual ICollection<MaProductionPlansReferences> MaProductionPlansReferences { get; set; }
    }
}
