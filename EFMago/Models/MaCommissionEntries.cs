using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaCommissionEntries
    {
        public MaCommissionEntries()
        {
            MaCommissionEntriesDetail = new HashSet<MaCommissionEntriesDetail>();
        }

        public string DocNo { get; set; }
        public DateTime? DocumentDate { get; set; }
        public double? TotalAmount { get; set; }
        public string Customer { get; set; }
        public string Salesperson { get; set; }
        public string Area { get; set; }
        public string Notes { get; set; }
        public int? AccrualType { get; set; }
        public double? AccrualPercAtInvoiceDate { get; set; }
        public int EntryId { get; set; }
        public int? DocumentId { get; set; }
        public double? TaxableAmount { get; set; }
        public int? ParentEntryId { get; set; }
        public int? PymtSchedId { get; set; }
        public string Policy { get; set; }
        public Guid? Tbguid { get; set; }
        public int? CrrefType { get; set; }
        public int? CrrefId { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ICollection<MaCommissionEntriesDetail> MaCommissionEntriesDetail { get; set; }
    }
}
