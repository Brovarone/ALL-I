using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImDeliveryRequest
    {
        public ImDeliveryRequest()
        {
            ImDeliveryReqDetails = new HashSet<ImDeliveryReqDetails>();
            ImDeliveryReqReferences = new HashSet<ImDeliveryReqReferences>();
        }

        public int DeliveryRequestId { get; set; }
        public string DeliveryRequestNo { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Applier { get; set; }
        public string Description { get; set; }
        public string Job { get; set; }
        public string StoragePo { get; set; }
        public string StoragePl { get; set; }
        public int? EvaluationStatus { get; set; }
        public DateTime? EvaluationDate { get; set; }
        public int? ApprovalStatus { get; set; }
        public string Note { get; set; }
        public string Ordered { get; set; }
        public DateTime? RequiredDeliveryDate { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public Guid? Tbguid { get; set; }

        public virtual ICollection<ImDeliveryReqDetails> ImDeliveryReqDetails { get; set; }
        public virtual ICollection<ImDeliveryReqReferences> ImDeliveryReqReferences { get; set; }
    }
}
