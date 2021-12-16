using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaDutyCodes
    {
        public int DutyType { get; set; }
        public string Reason { get; set; }
        public string Description { get; set; }
        public string Form770Letter { get; set; }
        public string NeedMonth { get; set; }
        public Guid? Tbguid { get; set; }
        public string WithholdingTaxDebitForDuty { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
