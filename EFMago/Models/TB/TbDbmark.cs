using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class TbDbmark
    {
        public string Application { get; set; }
        public string AddOnModule { get; set; }
        public short Dbrelease { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Status { get; set; }
        public string ExecLevel3 { get; set; }
        public short UpgradeLevel { get; set; }
        public short Step { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
