using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaTaxCommCntoSplit
    {
        public int Jeid { get; set; }
        public int? CustSuppType { get; set; }
        public string DocNo { get; set; }
        public DateTime? PostDate { get; set; }
        public double? TotAssigned { get; set; }
        public double? TotTaxAssigned { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
