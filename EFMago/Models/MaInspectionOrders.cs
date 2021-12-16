using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaInspectionOrders
    {
        public MaInspectionOrders()
        {
            MaInspectionOrderReferences = new HashSet<MaInspectionOrderReferences>();
            MaInspectionOrdersDetail = new HashSet<MaInspectionOrdersDetail>();
        }

        public int InspectionOrderId { get; set; }
        public string InspectionOrderNo { get; set; }
        public DateTime? InspectionOrderDate { get; set; }
        public string Supplier { get; set; }
        public string Reference { get; set; }
        public string Notes { get; set; }
        public string PostedToInventory { get; set; }
        public int? InventoryEntryId { get; set; }
        public string Printed { get; set; }
        public string IsCancelled { get; set; }
        public DateTime? ExpectedInspectionDate { get; set; }
        public DateTime? InspectionDate { get; set; }
        public string InspectionClosed { get; set; }
        public string InvRsn { get; set; }
        public string StoragePhase1 { get; set; }
        public string SpecificatorPhase1 { get; set; }
        public string StoragePhase2 { get; set; }
        public string SpecificatorPhase2 { get; set; }
        public int? SpecificatorTypePhase1 { get; set; }
        public int? SpecificatorTypePhase2 { get; set; }
        public int? BoLid { get; set; }
        public int? LastSubId { get; set; }
        public Guid? Tbguid { get; set; }
        public int? Moid { get; set; }
        public string InternalOrder { get; set; }
        public int? CrrefType { get; set; }
        public int? CrrefId { get; set; }
        public string Archived { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ICollection<MaInspectionOrderReferences> MaInspectionOrderReferences { get; set; }
        public virtual ICollection<MaInspectionOrdersDetail> MaInspectionOrdersDetail { get; set; }
    }
}
