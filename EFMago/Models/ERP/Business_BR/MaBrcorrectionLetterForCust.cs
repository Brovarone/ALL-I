using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaBrcorrectionLetterForCust
    {
        public int CorrectionLetterId { get; set; }
        public int? ProgressiveNumber { get; set; }
        public int? CorrectionLetterStatus { get; set; }
        public DateTime? CorrectionLetterDate { get; set; }
        public string CorrectionLetterText { get; set; }
        public string UseCondition { get; set; }
        public int? CrrefType { get; set; }
        public int? CrrefId { get; set; }
        public Guid? Tbguid { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
