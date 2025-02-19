using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaWorkersFields
    {
        public int WorkerId { get; set; }
        public short Line { get; set; }
        public string FieldName { get; set; }
        public string FieldValue { get; set; }
        public string Notes { get; set; }
        public string HideOnLayout { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaWorkers Worker { get; set; }
    }
}
