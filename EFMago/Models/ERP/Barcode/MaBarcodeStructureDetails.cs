using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaBarcodeStructureDetails
    {
        public string Code { get; set; }
        public int? Data { get; set; }
        public string InitialSeparator { get; set; }
        public string Prefix { get; set; }
        public string FinalSeparator { get; set; }
        public int? Length { get; set; }
        public short Position { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
