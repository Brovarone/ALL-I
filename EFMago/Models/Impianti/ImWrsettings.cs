using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImWrsettings
    {
        public short SettingId { get; set; }
        public string Wrreason { get; set; }
        public string AccTpl { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public string CustomH1label { get; set; }
        public string CustomH2label { get; set; }
        public string CustomH3label { get; set; }
        public string CustomH4label { get; set; }
        public string WrreasonEcoJob { get; set; }

        public virtual ImGeneralSettings Setting { get; set; }
    }
}
