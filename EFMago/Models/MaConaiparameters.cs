using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaConaiparameters
    {
        public string ItemDescription { get; set; }
        public string GroupMaterials { get; set; }
        public string ShowConfirmDialog { get; set; }
        public string NoContributionOnDocument { get; set; }
        public string GroupTaxCodeMaterial { get; set; }
        public int ConaiParametersId { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public string ContributionAcquittedNoteFe { get; set; }
    }
}
