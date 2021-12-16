using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaConsBalSheetParameters
    {
        public MaConsBalSheetParameters()
        {
            MaConsBalSheetParametersAcc = new HashSet<MaConsBalSheetParametersAcc>();
        }

        public int ConsBalSheetParametersId { get; set; }
        public string ConsolidationAccTpl { get; set; }
        public string ConsolidationAccRsn { get; set; }
        public string ConsolidationAccount { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ICollection<MaConsBalSheetParametersAcc> MaConsBalSheetParametersAcc { get; set; }
    }
}
