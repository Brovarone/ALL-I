using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaCommissionEntriesDetail
    {
        public int EntryId { get; set; }
        public short Line { get; set; }
        public string Salesperson { get; set; }
        public double? Base { get; set; }
        public double? Comm { get; set; }
        public DateTime? ExpectedAccrualDate { get; set; }
        public DateTime? ActualAccrualDate { get; set; }
        public string Suspended { get; set; }
        public string Authorized { get; set; }
        public string Invoiced { get; set; }
        public string Cancel { get; set; }
        public string Notes { get; set; }
        public short? InstallmentNo { get; set; }
        public int? DocumentId { get; set; }
        public string Outstanding { get; set; }
        public string GenByOutstanding { get; set; }
        public DateTime? OutstandingDate { get; set; }
        public DateTime? CreditNoteDate { get; set; }
        public DateTime? InstallmentDate { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaCommissionEntries Entry { get; set; }
    }
}
