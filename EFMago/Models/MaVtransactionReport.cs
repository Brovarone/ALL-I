using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaVtransactionReport
    {
        public int DocumentType { get; set; }
        public int DocumentSubType { get; set; }
        public DateTime? DocumentDate { get; set; }
        public string ExternalNumber { get; set; }
        public string InternalNumber { get; set; }
        public int? CustSuppType { get; set; }
        public string CustomerSupplier { get; set; }
        public string Currency { get; set; }
        public DateTime? FixingDate { get; set; }
        public string FixingIsManual { get; set; }
        public double? Fixing { get; set; }
        public int DocId { get; set; }
        public int? InvEntryId { get; set; }
        public string Storage { get; set; }
        public int Phase { get; set; }
    }
}
