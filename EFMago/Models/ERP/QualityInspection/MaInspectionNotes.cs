using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaInspectionNotes
    {
        public MaInspectionNotes()
        {
            MaInspectionNotesDetail = new HashSet<MaInspectionNotesDetail>();
            MaInspectionNotesReferences = new HashSet<MaInspectionNotesReferences>();
        }

        public int InspectionNotesId { get; set; }
        public string InspectionNotesNo { get; set; }
        public DateTime? InspectionNotesDate { get; set; }
        public string Supplier { get; set; }
        public string Reference { get; set; }
        public string Notes { get; set; }
        public string PostedToInventory { get; set; }
        public int? InventoryEntryId { get; set; }
        public string Rtsgenerated { get; set; }
        public int? Rtsid { get; set; }
        public string ScrapGenerated { get; set; }
        public int? ScrapInvEntryId { get; set; }
        public string Printed { get; set; }
        public string IsCancelled { get; set; }
        public string InvRsn { get; set; }
        public string ConformingStorage1 { get; set; }
        public string ConformingSpecificator1 { get; set; }
        public string ConformingStorage2 { get; set; }
        public string ConformingSpecificator2 { get; set; }
        public int? ConformingSpecificator1Type { get; set; }
        public int? ConformingSpecificator2Type { get; set; }
        public string NotConformingInvRsn { get; set; }
        public string NotConformingStorage1 { get; set; }
        public string NotConformingSpecificator1 { get; set; }
        public string NotConformingStorage2 { get; set; }
        public string NotConformingSpecificator2 { get; set; }
        public int? NotConfSpecificator1Type { get; set; }
        public int? NotConfSpecificator2Type { get; set; }
        public string ScrapInvRsn { get; set; }
        public string ScrapStorage1 { get; set; }
        public string ScrapSpecificator1 { get; set; }
        public string ScrapStorage2 { get; set; }
        public string ScrapSpecificator2 { get; set; }
        public int? ScrapSpecificator1Type { get; set; }
        public int? ScrapSpecificator2Type { get; set; }
        public int? LastSubId { get; set; }
        public int? BoLid { get; set; }
        public Guid? Tbguid { get; set; }
        public string InternalOrder { get; set; }
        public int? CrrefType { get; set; }
        public string Archived { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ICollection<MaInspectionNotesDetail> MaInspectionNotesDetail { get; set; }
        public virtual ICollection<MaInspectionNotesReferences> MaInspectionNotesReferences { get; set; }
    }
}
