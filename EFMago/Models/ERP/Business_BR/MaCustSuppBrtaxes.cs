using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaCustSuppBrtaxes
    {
        public int CustSuppType { get; set; }
        public string CustSupp { get; set; }
        public string IsstaxRateCode { get; set; }
        public string IsswithHoldingTax { get; set; }
        public string IrwithHoldingTax { get; set; }
        public string CswithHoldingTax { get; set; }
        public string PiswithHoldingTax { get; set; }
        public string CofinswithHoldingTax { get; set; }
        public string InsswithHoldingTax { get; set; }
        public Guid? Tbguid { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
