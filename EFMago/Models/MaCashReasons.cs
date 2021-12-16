using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaCashReasons
    {
        public string Reason { get; set; }
        public string Description { get; set; }
        public int? OperationType { get; set; }
        public string AccTpl { get; set; }
        public string AccRsn { get; set; }
        public string Account { get; set; }
        public string CostCenter { get; set; }
        public string Job { get; set; }
        public int? DocNoIsMand { get; set; }
        public string AutoPrint { get; set; }
        public Guid? Tbguid { get; set; }
        public string AutoNumbering { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
