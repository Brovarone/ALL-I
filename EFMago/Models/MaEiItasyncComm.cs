using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaEiItasyncComm
    {
        public int OperationId { get; set; }
        public short? OperationStatus { get; set; }
        public string InElaboration { get; set; }
        public short? NumOfRetry { get; set; }
        public DateTime? NextOpDate { get; set; }
        public int? DocId { get; set; }
        public string FileName { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public int? DocumentType { get; set; }
    }
}
