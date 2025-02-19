using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaIntraArrivals1C
    {
        public int IntrastatId { get; set; }
        public short Line { get; set; }
        public int? CustSuppType { get; set; }
        public string CustSupp { get; set; }
        public DateTime? AccrualDate { get; set; }
        public int? ProgNo { get; set; }
        public double? TotalAmount { get; set; }
        public double? TotalAmountDocCurr { get; set; }
        public string DocNo { get; set; }
        public DateTime? DocumentDate { get; set; }
        public string Cpacode { get; set; }
        public int? IntrastatSupplyType { get; set; }
        public int? IntrastatCollectionType { get; set; }
        public string CountryOfPayment { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaIntra Intrastat { get; set; }
    }
}
