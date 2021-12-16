using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImPyblsRcvblsJobIncidenceDocs
    {
        public int? InstallmentYear { get; set; }
        public int? InstallmentMonth { get; set; }
        public string DocNo { get; set; }
        public int? DocumentType { get; set; }
        public int PymtSchedId { get; set; }
        public short InstallmentNo { get; set; }
        public int? DocumentId { get; set; }
        public DateTime InstallmentDate { get; set; }
        public string Job { get; set; }
        public int InstallmentType { get; set; }
        public double? JobIncidence { get; set; }
        public int? CustSuppType { get; set; }
        public string CustSupp { get; set; }
        public double? PayableAmountInBaseCurr { get; set; }
        public int? DebitCreditSign { get; set; }
        public string Disabled { get; set; }
    }
}
