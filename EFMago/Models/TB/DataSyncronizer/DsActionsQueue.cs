using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class DsActionsQueue
    {
        public int LogId { get; set; }
        public string ProviderName { get; set; }
        public string ActionName { get; set; }
        public string SynchXmldata { get; set; }
        public int SynchStatus { get; set; }
        public int SynchDirection { get; set; }
        public string SynchFilters { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
