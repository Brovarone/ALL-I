using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaDrawingsRevisions
    {
        public string Drawing { get; set; }
        public string Revision { get; set; }
        public string RevisionDescription { get; set; }
        public string ExecutionSignature { get; set; }
        public DateTime? ExecutionDate { get; set; }
        public string CheckSignature { get; set; }
        public DateTime? CheckDate { get; set; }
        public string ApprovalSignature { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public string RevisionDrawingPath { get; set; }
        public string BarCode { get; set; }
        public string Notes { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaDrawings DrawingNavigation { get; set; }
    }
}
