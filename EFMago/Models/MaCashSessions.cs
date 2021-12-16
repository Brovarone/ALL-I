using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaCashSessions
    {
        public MaCashSessions()
        {
            MaCashSessionsEntries = new HashSet<MaCashSessionsEntries>();
        }

        public int SessionId { get; set; }
        public string SessionNo { get; set; }
        public string Cash { get; set; }
        public DateTime? OpeningDate { get; set; }
        public DateTime? ClosingDate { get; set; }
        public string Posted { get; set; }
        public Guid? Tbguid { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ICollection<MaCashSessionsEntries> MaCashSessionsEntries { get; set; }
    }
}
