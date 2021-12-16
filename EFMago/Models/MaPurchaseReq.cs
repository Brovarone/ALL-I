using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaPurchaseReq
    {
        public MaPurchaseReq()
        {
            MaPurchaseReqDetail = new HashSet<MaPurchaseReqDetail>();
        }

        public int PurchaseReqId { get; set; }
        public string Simulation { get; set; }
        public string PurchaseReqNo { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Fulfilled { get; set; }
        public string Notes { get; set; }
        public int? CodeType { get; set; }
        public int? LastSubId { get; set; }
        public Guid? Tbguid { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ICollection<MaPurchaseReqDetail> MaPurchaseReqDetail { get; set; }
    }
}
