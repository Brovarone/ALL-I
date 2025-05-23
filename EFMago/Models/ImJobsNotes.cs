﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImJobsNotes
    {
        public string Job { get; set; }
        public short Line { get; set; }
        public string Note { get; set; }
        public string Printing { get; set; }
        public string NoteType { get; set; }
        public string PrintInFrontPage { get; set; }
        public string PrintInEndingPage { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaJobs JobNavigation { get; set; }
    }
}
