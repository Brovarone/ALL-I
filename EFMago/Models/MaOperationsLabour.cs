using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaOperationsLabour
    {
        public string Operation { get; set; }
        public int Line { get; set; }
        public int? ResourceType { get; set; }
        public string ResourceCode { get; set; }
        public int? WorkerId { get; set; }
        public int? LabourType { get; set; }
        public double? AttendancePerc { get; set; }
        public int? WorkingTime { get; set; }
        public DateTime? LabourDate { get; set; }
        public short? NoOfResources { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaOperations OperationNavigation { get; set; }
    }
}
