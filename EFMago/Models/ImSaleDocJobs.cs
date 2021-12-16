using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImSaleDocJobs
    {
        public int SaleDocId { get; set; }
        public short Line { get; set; }
        public string Job { get; set; }
        public DateTime? JobDate { get; set; }
        public string Notes { get; set; }
        public double? JobTotalAmount { get; set; }
        public string Ofs { get; set; }
        public string TaxCode { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaSaleDoc SaleDoc { get; set; }
    }
}
