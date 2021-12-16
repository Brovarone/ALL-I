using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaContactNotes
    {
        public string Contact { get; set; }
        public short Line { get; set; }
        public string Notes { get; set; }
        public string PrintCustQuota { get; set; }
        public string ShowCustQuota { get; set; }
        public string CopyCustQuota { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaContacts ContactNavigation { get; set; }
    }
}
