using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaWeeeentries
    {
        public DateTime? EntryDate { get; set; }
        public string Customer { get; set; }
        public double? Qty { get; set; }
        public double? TotalContributionAmount { get; set; }
        public string Item { get; set; }
        public string Category { get; set; }
        public int? DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime? DocumentDate { get; set; }
        public short? DocumentLine { get; set; }
        public int? DocumentId { get; set; }
        public int EntryId { get; set; }
        public Guid? Tbguid { get; set; }
        public string Prodcom { get; set; }
        public string CombinedNomenclature { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
