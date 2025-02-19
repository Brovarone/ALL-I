using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaAdditionalChargesParams
    {
        public int AdditionalChargesParamsId { get; set; }
        public string ManageLoadOffsetOnAddChRow { get; set; }
        public string StartInBackgroundMode { get; set; }
        public string DefaultSpreadingTemplate { get; set; }
        public Guid? Tbguid { get; set; }
        public int? ActionModifyInvEntry { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
