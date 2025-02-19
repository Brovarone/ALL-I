using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImMeasuresBooks
    {
        public ImMeasuresBooks()
        {
            ImMeasuresBooksDetails = new HashSet<ImMeasuresBooksDetails>();
            ImMeasuresBooksNotes = new HashSet<ImMeasuresBooksNotes>();
        }

        public int MeasuresBookId { get; set; }
        public string MeasuresBookNo { get; set; }
        public string Description { get; set; }
        public string AlreadyInWpr { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Job { get; set; }
        public string ParentJob { get; set; }
        public string Note { get; set; }
        public int? Approval { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public string ApprovalBy { get; set; }
        public string Currency { get; set; }
        public DateTime? FixingDate { get; set; }
        public double? Fixing { get; set; }
        public string FixingIsManual { get; set; }
        public int? MeasuresBookType { get; set; }
        public DateTime? AccrualDate { get; set; }
        public string Disabled { get; set; }
        public string EnablesRowChange { get; set; }
        public int? CrrefType { get; set; }
        public int? CrrefId { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public Guid? Tbguid { get; set; }

        public virtual ICollection<ImMeasuresBooksDetails> ImMeasuresBooksDetails { get; set; }
        public virtual ICollection<ImMeasuresBooksNotes> ImMeasuresBooksNotes { get; set; }
    }
}
