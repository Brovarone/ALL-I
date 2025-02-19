using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaLifofifoparameters
    {
        public int LifofifoparametersId { get; set; }
        public int? CheckForLoadsAvailaibility { get; set; }
        public string RestoreLoadsForRfcasPicking { get; set; }
        public string EnableBatchTracking { get; set; }
        public DateTime? ClosingDate { get; set; }
        public string AllowToModifyUnloadedLoads { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
