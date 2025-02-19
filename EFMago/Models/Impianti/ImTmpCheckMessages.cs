using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImTmpCheckMessages
    {
        public string ComputerName { get; set; }
        public string UserName { get; set; }
        public string GroupCode { get; set; }
        public string RuleCode { get; set; }
        public short Line { get; set; }
        public string RefKeyValue { get; set; }
        public string RefDisplayValue { get; set; }
        public string RefDocument { get; set; }
        public string ShortMessage { get; set; }
        public string FullMessage { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
