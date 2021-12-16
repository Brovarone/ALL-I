using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaSaleParametersWithholdTax
    {
        public int SaleParametersId { get; set; }
        public string WithholdingTaxManagement { get; set; }
        public double? WithholdingTaxPerc { get; set; }
        public string WithholdingTaxOffset { get; set; }
        public string WholdingTaxAccRsn { get; set; }
        public string CashOffset { get; set; }
        public double? CashPerc { get; set; }
        public string CashTaxCode { get; set; }
        public double? WithholdingTaxBasePerc { get; set; }
        public string WholdingTaxOnCustomer { get; set; }
        public string WholdingTaxOnCollection { get; set; }
        public double? EnasarcosalesPerc { get; set; }
        public string EnasarcosalesOffset { get; set; }
        public string EnasarcosalesAccRsn { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
