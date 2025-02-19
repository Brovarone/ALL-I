using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaDrawings
    {
        public MaDrawings()
        {
            MaDrawingsDescription = new HashSet<MaDrawingsDescription>();
            MaDrawingsRevisions = new HashSet<MaDrawingsRevisions>();
        }

        public string Drawing { get; set; }
        public string Description { get; set; }
        public string Revision { get; set; }
        public string DerivedFrom { get; set; }
        public string Notes { get; set; }
        public string BarCode { get; set; }
        public DateTime? DateOfSignature { get; set; }
        public string ApprovalSignature { get; set; }
        public string FilePath { get; set; }
        public string Item { get; set; }
        public Guid? Tbguid { get; set; }
        public string PreferredDrawing { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ICollection<MaDrawingsDescription> MaDrawingsDescription { get; set; }
        public virtual ICollection<MaDrawingsRevisions> MaDrawingsRevisions { get; set; }
    }
}
