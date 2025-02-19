using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImPurchaseRequest
    {
        public ImPurchaseRequest()
        {
            ImPurchReqDetails = new HashSet<ImPurchReqDetails>();
            ImPurchReqGenDocRef = new HashSet<ImPurchReqGenDocRef>();
            ImPurchReqOriginDocRef = new HashSet<ImPurchReqOriginDocRef>();
            ImPurchReqSuppSummary = new HashSet<ImPurchReqSuppSummary>();
        }

        public int PurchaseRequestId { get; set; }
        public string PurchaseRequestNo { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? OriginDocType { get; set; }
        public string Final { get; set; }
        public string Simulation { get; set; }
        public int? OriginalPurchReqId { get; set; }
        public double? TaxableAmount { get; set; }
        public double? TaxAmount { get; set; }
        public double? Amount { get; set; }
        public double? DiscountTotalAmount { get; set; }
        public double? GoodsTotalAmount { get; set; }
        public double? ServicesTotalAmount { get; set; }
        public int? SimulatedValueType { get; set; }
        public string ManageQuotasDiscount { get; set; }
        public string ManageQuotasAllowances { get; set; }
        public string NettingStorage { get; set; }
        public int? NettingSpecificatorType { get; set; }
        public string NettingSpecificator { get; set; }
        public string Applier { get; set; }
        public string Notes { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public Guid? Tbguid { get; set; }

        public virtual ICollection<ImPurchReqDetails> ImPurchReqDetails { get; set; }
        public virtual ICollection<ImPurchReqGenDocRef> ImPurchReqGenDocRef { get; set; }
        public virtual ICollection<ImPurchReqOriginDocRef> ImPurchReqOriginDocRef { get; set; }
        public virtual ICollection<ImPurchReqSuppSummary> ImPurchReqSuppSummary { get; set; }
    }
}
