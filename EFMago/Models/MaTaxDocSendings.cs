using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaTaxDocSendings
    {
        public MaTaxDocSendings()
        {
            MaTaxDocSendingsDetails = new HashSet<MaTaxDocSendingsDetails>();
        }

        public int TaxDocSendingId { get; set; }
        public string TaxDocSendingNo { get; set; }
        public int? SendingStatus { get; set; }
        public DateTime? SetupDate { get; set; }
        public DateTime? SendingDate { get; set; }
        public string Idfile { get; set; }
        public int? SendingType { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? CrrefType { get; set; }
        public int? CrrefId { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public string ManuallyUpdate { get; set; }
        public string Retails { get; set; }

        public virtual ICollection<MaTaxDocSendingsDetails> MaTaxDocSendingsDetails { get; set; }
    }
}
