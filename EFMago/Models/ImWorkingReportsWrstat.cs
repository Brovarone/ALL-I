using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImWorkingReportsWrstat
    {
        public string WorkingReportNo { get; set; }
        public int? WorkingReportId { get; set; }
        public DateTime? WorkingReportDate { get; set; }
        public DateTime? PostingDate { get; set; }
        public string Customer { get; set; }
        public string Job { get; set; }
        public string StubBook { get; set; }
        public short Line { get; set; }
        public string Processing { get; set; }
        public string Description { get; set; }
        public int? Time { get; set; }
    }
}
