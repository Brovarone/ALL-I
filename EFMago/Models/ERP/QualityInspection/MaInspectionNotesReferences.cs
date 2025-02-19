using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaInspectionNotesReferences
    {
        public short Line { get; set; }
        public int? DocumentId { get; set; }
        public int? DocumentType { get; set; }
        public DateTime? DocumentDate { get; set; }
        public string DocumentNumber { get; set; }
        public int InspectionNotesId { get; set; }
        public string Notes { get; set; }
        public string ReferenceIsAuto { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaInspectionNotes InspectionNotes { get; set; }
    }
}
