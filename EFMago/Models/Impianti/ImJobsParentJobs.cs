using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImJobsParentJobs
    {
        public string ParentJob { get; set; }
        public string Job { get; set; }
        public int? JobType { get; set; }
        public string GroupCode { get; set; }
        public string Customer { get; set; }
        public string Manager { get; set; }
    }
}
