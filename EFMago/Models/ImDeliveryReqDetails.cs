using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImDeliveryReqDetails
    {
        public int DeliveryRequestId { get; set; }
        public short Line { get; set; }
        public int? ApprovalStatus { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public string IsNew { get; set; }
        public string Job { get; set; }
        public string JobWorkingStep { get; set; }
        public int? ComponentType { get; set; }
        public string Component { get; set; }
        public string Description { get; set; }
        public string UoM { get; set; }
        public double? JobQtyRequest { get; set; }
        public double? CorrectedQtyRequest { get; set; }
        public double? JobOrderedQtyRequest { get; set; }
        public double? JobPickedQtyRequest { get; set; }
        public double? JobReturnedQtyRequest { get; set; }
        public double? ApprNoFulfilledQtyRequest { get; set; }
        public double? RequiredQty { get; set; }
        public double? JobQtyApprove { get; set; }
        public double? CorrectedQtyApprove { get; set; }
        public double? JobOrderedQtyApprove { get; set; }
        public double? JobPickedQtyApprove { get; set; }
        public double? JobReturnedQtyApprove { get; set; }
        public double? ApprNoFulfilledQtyApprove { get; set; }
        public double? ApprovedQty { get; set; }
        public string IsUrgent { get; set; }
        public double? OrderedQty { get; set; }
        public double? PickedQty { get; set; }
        public string Ordered { get; set; }
        public DateTime? RequiredDeliveryDate { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }
        public string IsAutomatic { get; set; }
        public int IdRow { get; set; }
        public int IdProw { get; set; }
        public string Note { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ImDeliveryRequest DeliveryRequest { get; set; }
    }
}
