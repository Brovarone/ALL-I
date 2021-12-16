using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImStatOfAccountReferences
    {
        public int StatOfAccountId { get; set; }
        public int DocType { get; set; }
        public int DocId { get; set; }
        public string Job { get; set; }
        public string DocNo { get; set; }
        public DateTime? DocDate { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ImStatOfAccount StatOfAccount { get; set; }
    }
}
