using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaTaxCommunicationGroup
    {
        public string TaxCommunicationGroup { get; set; }
        public string Description { get; set; }
        public string MultiYear { get; set; }
        public double? TaxableAmount { get; set; }
        public string Notes { get; set; }
        public int? CustSuppType { get; set; }
        public string CustSupp { get; set; }
        public Guid? Tbguid { get; set; }
        public string Summary { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
