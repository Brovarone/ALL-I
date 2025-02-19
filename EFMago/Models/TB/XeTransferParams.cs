using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class XeTransferParams
    {
        public short IdParam { get; set; }
        public short? MaxDoc { get; set; }
        public short? MaxKbyte { get; set; }
        public string UseEnvClassExt { get; set; }
        public short? EnvPaddingNum { get; set; }
        public string UseAttribute { get; set; }
        public string UseEnumAsNum { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
