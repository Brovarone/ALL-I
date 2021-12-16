using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImJobsSubStates
    {
        public string SubState { get; set; }
        public int JobState { get; set; }
        public int? SubStateOrder { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public string InJobStd { get; set; }
        public string InJobVar { get; set; }
        public string InJobEco { get; set; }
        public string DefJobStd { get; set; }
        public string DefJobVar { get; set; }
        public string DefJobEco { get; set; }
        public string IsDisable { get; set; }
        public int Idbmp { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ImJobsState JobStateNavigation { get; set; }
    }
}
