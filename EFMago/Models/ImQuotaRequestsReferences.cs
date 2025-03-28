﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImQuotaRequestsReferences
    {
        public int QuotationRequestId { get; set; }
        public short Line { get; set; }
        public int? DocRefId { get; set; }
        public int? DocRefType { get; set; }
        public DateTime? DocRefDate { get; set; }
        public string DocRefNo { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ImQuotationRequests QuotationRequest { get; set; }
    }
}
