using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaBrseriesUnusedNumbersDetail
    {
        public string Series { get; set; }
        public string Model { get; set; }
        public string FromNumber { get; set; }
        public string ToNumber { get; set; }
        public DateTime OperationDate { get; set; }
        public DateTime? ElabDate { get; set; }
        public string InutReason { get; set; }
        public string AuthProtocol { get; set; }
        public string AnswerStatus { get; set; }
        public string AnswerStatusDescri { get; set; }
        public string MagoUserId { get; set; }
        public int? EasyAttachId { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
